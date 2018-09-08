﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senparc.CO2NET.Cache;
using Senparc.CO2NET.Extensions;
using Senparc.CO2NET.HttpUtility;
using Senparc.Weixin.MP.Sample.CommonService.TemplateMessage.WxOpen;
using Senparc.Weixin.MP.Sample.CommonService.Utilities;
using Senparc.Weixin.MP.Sample.CommonService.WxOpenMessageHandler;
using Senparc.Weixin.WxOpen.AdvancedAPIs.Sns;
using Senparc.Weixin.WxOpen.Containers;
using Senparc.Weixin.WxOpen.Entities;
using Senparc.Weixin.WxOpen.Entities.Request;
using Senparc.Weixin.WxOpen.Helpers;
using System;
using System.IO;
using Senparc.Weixin.TenPay.V3;
using Senparc.Weixin.Entities;
using Microsoft.Extensions.Options;
using WeWaiter.DataBase;
using System.Collections.Generic;
using WeWaiter.Utils;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Senparc.Weixin.MP.CoreSample.Controllers.WxOpen
{
    [Route("api/[controller]")]
    [ApiController]
   
    public   class WeAppController : Controller
    {
        private readonly WeWaiterContext _context;
        SenparcWeixinSetting _senparcWeixinSetting;

        public string Token { get; }
        public string EncodingAESKey { get; }
        public string WxOpenAppId { get; }
        public string WxOpenAppSecret { get; }

        public WeAppController(IOptions<SenparcWeixinSetting> senparcWeixinSetting, WeWaiterContext context)
        {
            _senparcWeixinSetting = senparcWeixinSetting.Value;
            Token = _senparcWeixinSetting.WxOpenToken;//与微信小程序后台的Token设置保持一致，区分大小写。
            EncodingAESKey = _senparcWeixinSetting.WxOpenEncodingAESKey;//与微信小程序后台的EncodingAESKey设置保持一致，区分大小写。
            WxOpenAppId = _senparcWeixinSetting.WxOpenAppId;//与微信小程序后台的AppId设置保持一致，区分大小写。
            WxOpenAppSecret = _senparcWeixinSetting.WxOpenAppSecret;//与微信小程序账号后台的AppId设置保持一致，区分大小写。
            _context = context;
        }
    
        readonly Func<string> _getRandomFileName = () => DateTime.Now.ToString("yyyyMMdd-HHmmss") + Guid.NewGuid().ToString("n").Substring(0, 6);


        /// <summary>
        /// GET请求用于处理微信小程序后台的URL验证
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery]PostModel postModel, [FromQuery]string echostr)
        {
            if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, _senparcWeixinSetting.WxOpenToken))
            {
                return Ok(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return BadRequest("failed:" + postModel.Signature + "," + MP.CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, Token) + "。" +
                    "如果你在浏览器中看到这句话，说明此地址可以被作为微信小程序后台的Url，请注意保持Token一致。"+ Token);
            }
        }

       

        [HttpPost("RequestData")]
        [Authorize]
        public ActionResult RequestData([FromBody]string nickName)
        {
            var data = new
            {
                msg = string.Format("服务器时间：{0}，昵称：{1}", DateTime.Now, nickName)
            };
            return Json(data);
        }

        /// <summary>
        /// wx.login登陆成功之后发送的请求
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost("OnLogin")]
        [AllowAnonymous]
        public ActionResult OnLogin([FromBody]string code)
        {
            var jsonResult = SnsApi.JsCode2Json(WxOpenAppId, WxOpenAppSecret, code);
            if (jsonResult.errcode == ReturnCode.请求成功)
            {
                //Session["WxOpenUser"] = jsonResult;//使用Session保存登陆信息（不推荐）
                //使用SessionContainer管理登录信息（推荐）
                var unionId = "";
                if (!_context.User.Any(u=>u.OpenID==jsonResult.openid))
                {
                  var adduser=  _context.User.Add(new WeWaiter.DataBase.User()
                    {
                        UserID = Guid.NewGuid().ToString().Replace("-", ""),
                        JoinIn = DateTime.Now,
                        LastActive = DateTime.Now,
                        OpenID = jsonResult.openid,
                    });
                    _context.SaveChanges();
                }
                var usr = _context.User.FirstOrDefault(u => u.OpenID == jsonResult.openid);

                //https://github.com/aspnet/Home/issues/2193
                var token = TokenBuilder.CreateJsonWebToken(usr.UserID, new List<string>() { "WeApp" }, "https://bonafortune.com", "https://bonafortune.com", Guid.NewGuid(), DateTime.UtcNow.AddMinutes(20));
                var sessionBag = SessionContainer.UpdateSession(usr.UserID, jsonResult.openid, jsonResult.session_key, unionId);
                //注意：生产环境下SessionKey属于敏感信息，不能进行传输！
                return Json(new { success = true, msg = "OK", token = token });
            }
            else
            {
                return Json(new { success = false, msg = jsonResult.errmsg });
            }
        }

        [HttpPost("CheckWxOpenSignature")]
        public ActionResult CheckWxOpenSignature(string sessionId, string rawData, string signature)
        {
            try
            {
                var checkSuccess = Senparc.Weixin.WxOpen.Helpers.EncryptHelper.CheckSignature(sessionId, rawData, signature);
                return Json(new { success = checkSuccess, msg = checkSuccess ? "签名校验成功" : "签名校验失败" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost("DecodeEncryptedData")]
        public ActionResult DecodeEncryptedData(string type, string sessionId, string encryptedData, string iv)
        {
            DecodeEntityBase decodedEntity = null;
            switch (type.ToUpper())
            {
                case "USERINFO"://wx.getUserInfo()
                    decodedEntity = Senparc.Weixin.WxOpen.Helpers.EncryptHelper.DecodeUserInfoBySessionId(
                        sessionId,
                        encryptedData, iv);
                    break;
                default:
                    break;
            }

            //检验水印
            var checkWartmark = false;
            if (decodedEntity != null)
            {
                checkWartmark = decodedEntity.CheckWatermark(WxOpenAppId);
            }

            //注意：此处仅为演示，敏感信息请勿传递到客户端！
            return Json(new
            {
                success = checkWartmark,
                //decodedEntity = decodedEntity,
                msg = string.Format("水印验证：{0}",
                        checkWartmark ? "通过" : "不通过")
            });
        }

        [HttpPost("TemplateTest")]
        public ActionResult TemplateTest(string sessionId, string formId)
        {
            var sessionBag = SessionContainer.GetSession(sessionId);
            var openId = sessionBag != null ? sessionBag.OpenId : "用户未正确登陆";

            string title = null;
            decimal price = 100;
            string productName = null;
            string orderNumber = null;

            if (formId.StartsWith("prepay_id="))
            {
                formId = formId.Replace("prepay_id=", "");
                title = "这是来自小程序支付的模板消息";

                var cacheStrategy = CacheStrategyFactory.GetObjectCacheStrategyInstance();
                var unifiedorderRequestData = cacheStrategy.Get<TenPayV3UnifiedorderRequestData>($"WxOpenUnifiedorderRequestData-{openId}");//获取订单请求信息缓存
                var unifedorderResult = cacheStrategy.Get<UnifiedorderResult>($"WxOpenUnifiedorderResultData-{openId}");//获取订单信息缓存

                if (unifedorderResult != null && formId == unifedorderResult.prepay_id)
                {
                    price = unifiedorderRequestData.TotalFee;
                    productName = unifiedorderRequestData.Body + "/缓存获取 prepay_id 成功";
                    orderNumber = unifiedorderRequestData.OutTradeNo;
                }
                else
                {
                    productName = "缓存获取 prepay_id 失败";
                    orderNumber = "1234567890";
                }
            }
            else
            {
                title = "在线购买（小程序Demo测试）";
                productName = "商品名称-模板消息测试";
                orderNumber = "9876543210";
            }

            var data = new WxOpenTemplateMessage_PaySuccessNotice(title, DateTime.Now, productName, orderNumber, price,
                            "400-031-8816", "https://sdk.senparc.weixin.com");

            try
            {
                Senparc.Weixin.WxOpen.AdvancedAPIs
                    .Template.TemplateApi
                    .SendTemplateMessage(
                        WxOpenAppId, openId, data.TemplateId, data, formId, "pages/index/index", "图书", "#fff00");

                return Json(new { success = true, msg = "发送成功，请返回消息列表中的【服务通知】查看模板消息。\r\n点击模板消息还可重新回到小程序内。" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, openId = openId, formId = formId, msg = ex.Message });
            }
        }
        [HttpPost("DecryptPhoneNumber")]
        public ActionResult DecryptPhoneNumber(string sessionId, string encryptedData, string iv)
        {
            var sessionBag = SessionContainer.GetSession(sessionId);
            try
            {
                var phoneNumber = Senparc.Weixin.WxOpen.Helpers.EncryptHelper.DecryptPhoneNumber(sessionId, encryptedData,
               iv);

                //throw new WeixinException("解密PhoneNumber异常测试");//启用这一句，查看客户端返回的异常信息

                return Json(new { success = true, phoneNumber = phoneNumber });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });

            }
        }
        [HttpPost("GetPrepayid")]
        public ActionResult GetPrepayid(string sessionId)
        {
            try
            {
                var sessionBag = SessionContainer.GetSession(sessionId);
                var openId = sessionBag.OpenId;


                //生成订单10位序列号，此处用时间和随机数生成，商户根据自己调整，保证唯一
                var sp_billno = string.Format("{0}{1}{2}", Config.SenparcWeixinSetting.TenPayV3_MchId /*10位*/, DateTime.Now.ToString("yyyyMMddHHmmss"),
                        TenPayV3Util.BuildRandomStr(6));

                var timeStamp = TenPayV3Util.GetTimestamp();
                var nonceStr = TenPayV3Util.GetNoncestr();

                var body = "小程序微信支付Demo";
                var price = 1;//单位：分
                var xmlDataInfo = new TenPayV3UnifiedorderRequestData(WxOpenAppId, Config.SenparcWeixinSetting.TenPayV3_MchId, body, sp_billno,
                    price, HttpContext.UserHostAddress().ToString(), Config.SenparcWeixinSetting.TenPayV3_WxOpenTenpayNotify, TenPay.TenPayV3Type.JSAPI, openId, Config.SenparcWeixinSetting.TenPayV3_Key, nonceStr);

                var result = TenPayV3.Unifiedorder(xmlDataInfo);//调用统一订单接口

                WeixinTrace.SendCustomLog("统一订单接口调用结束", "请求：" + xmlDataInfo.ToJson() + "\r\n\r\n返回结果：" + result.ToJson());

                var packageStr = "prepay_id=" + result.prepay_id;

                //记录到缓存

                var cacheStrategy = CacheStrategyFactory.GetObjectCacheStrategyInstance();
                cacheStrategy.Set($"WxOpenUnifiedorderRequestData-{openId}", xmlDataInfo, TimeSpan.FromDays(4));//3天内可以发送模板消息
                cacheStrategy.Set($"WxOpenUnifiedorderResultData-{openId}", result, TimeSpan.FromDays(4));//3天内可以发送模板消息

                return Json(new
                {
                    success = true,
                    prepay_id = result.prepay_id,
                    appId = Config.SenparcWeixinSetting.WxOpenAppId,
                    timeStamp,
                    nonceStr,
                    package = packageStr,
                    //signType = "MD5",
                    paySign = TenPayV3.GetJsPaySign(WxOpenAppId, timeStamp, nonceStr, packageStr, Config.SenparcWeixinSetting.TenPayV3_Key)
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    msg = ex.Message
                });
            }

        }
    }
}