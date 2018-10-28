using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Senparc.Weixin.BrowserUtility;
using Senparc.Weixin.Helpers;
using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.TenPay.V3;
using ZXing;
using ZXing.Common;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP.Sample.CommonService.TemplateMessage;
using Microsoft.AspNetCore.Http;
using Senparc.CO2NET.Extensions;
using Senparc.CO2NET.Helpers;
using Senparc.Weixin;
using WeWaiter.Utils;
using WeWaiter.DataBase;
using Senparc.Weixin.TenPay;
using Senparc.Weixin.MP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Senparc.Weixin.Entities;
using Microsoft.Extensions.Logging;
using Senparc.Weixin.WxOpen.Containers;
using Senparc.Weixin.MP.Sample.CommonService.TemplateMessage.WxOpen;
using Senparc.CO2NET.Cache;
using Swashbuckle.AspNetCore.Swagger;
namespace WeWaiter.Controllers
{



    /* 
     * 友情提示：微信支付正式上线之前，请进行沙箱测试！ 
     * 单元测试见：Senparc.Weixin.MP.Test.TenPayV3/TenPayV3Test.cs/GetSignKeyTest()
     */
    [Route("api/[controller]")]
    [ApiController]
    public class TenPayV3Controller : ControllerBase
    {
        private static TenPayV3Info _tenPayV3Info;
        private readonly WeWaiterContext _context;
        private readonly SenparcWeixinSetting _senparcWeixinSetting;
        private readonly ILogger _logger;
        public TenPayV3Controller(IOptions<SenparcWeixinSetting> senparcWeixinSetting, WeWaiterContext context, ILogger<TenPayV3Controller> logger)
        {
            _context = context;
            _senparcWeixinSetting = senparcWeixinSetting.Value;
            _logger = logger;
        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors == SslPolicyErrors.None)
                return true;
            return false;
        }

        public static TenPayV3Info TenPayV3Info
        {
            get
            {
                if (_tenPayV3Info == null)
                {
                    _tenPayV3Info =
                        TenPayV3InfoCollection.Data[Config.SenparcWeixinSetting.TenPayV3_MchId];
                }
                return _tenPayV3Info;
            }
        }

     

       
        #region JsApi支付

        //需要OAuth登录
        [Authorize]
        [HttpGet("JsApi/{orderid}")]
        public IActionResult JsApi([FromRoute]string orderid)
        {
            IActionResult actionResult = NoContent();
            try
            {
          
                var product = _context.Order.FirstOrDefault(z => z.OrderID == orderid);
         
                if (product == null || product.OrderStatus!=0)
                {
                    _logger.LogInformation($"订单不存在{orderid}");
                    actionResult = Ok(new { code = 1010, msg =$"商品信息不存在，或已支付{product.OrderStatus}" });
                }
                else
                {
                    var items = from bi in _context.BuyItem where bi.OrderID == orderid select bi;
                    var body = string.Join('_' ,( from bi in items select bi.GoodsName).Take(3).ToArray());
                    var sessionBag = SessionContainer.GetSession(Request.GetJwtSecurityToken()?.GetUserId());
                    var openId = sessionBag.OpenId;
                    string sp_billno = orderid;
                    var timeStamp = TenPayV3Util.GetTimestamp();
                    var nonceStr = TenPayV3Util.GetNoncestr();
                    var price = product == null ? 100 : (int)(product.TotalPrice * 100);//单位：分
                    _logger.LogInformation($"body:{body},openId={openId},orderid={orderid},timeStamp={timeStamp},nonceStr={nonceStr},price={price}");
                    var xmlDataInfo = new TenPayV3UnifiedorderRequestData(TenPayV3Info.AppId, TenPayV3Info.MchId, body, sp_billno, price, HttpContext.UserHostAddress()?.ToString(), TenPayV3Info.TenPayV3Notify,  Senparc.Weixin.TenPay.TenPayV3Type.JSAPI, openId, TenPayV3Info.Key, nonceStr);
                    var result = TenPayV3.Unifiedorder(xmlDataInfo);
                    if (result.return_code == "SUCCESS")
                    {
                        _logger.LogInformation($"= {result.prepay_id}  ");
                        var package = string.Format("prepay_id={0}", result.prepay_id);
                        var data = new
                        {
                            out_trade_no= orderid,
                            TenPayV3Info.AppId,
                            timeStamp,
                            nonceStr,
                            package,
                            signType="MD5",
                            paySign = TenPayV3.GetJsPaySign(TenPayV3Info.AppId, timeStamp, nonceStr, package, TenPayV3Info.Key)
                        };
                        actionResult = Ok(new { code = 0, msg = "OK", data });
                    }
                    else
                    {
                        actionResult = Ok(new { code = 1013, msg = result.return_msg,result.result_code ,result.err_code,result.err_code_des  });
                        _logger.LogInformation($"msg ={ result.return_msg},result_code= {result.result_code} ,err_code={result.err_code},err_code_des={result.err_code_des}");
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                msg += $"\r\n{ex.StackTrace}\r\n==Source==\r\n{ex.Source}";
                if (ex.InnerException != null)
                {
                    msg += $"\r\n ===InnerException===\r\n{ex.InnerException.Message}";
                }
                actionResult= Ok( new { code=1012,msg=msg });
            }
            return actionResult;
        }



        /// <summary>
        /// JS-SDK支付回调地址（在统一下单接口中设置notify_url）
        /// </summary>
        /// <returns></returns>
        [HttpGet("PayNotifyUrl")]
        public IActionResult PayNotifyUrl()//注意：统一下单接口中不能带参数！
        {
            return PayNotifyUrl_Ex(false);
        }
   
        IActionResult PayNotifyUrl_Ex(bool isWxOpenPay)//注意：统一下单接口中不能带参数！
        {
            WeixinTrace.SendCustomLog("微信支付回调", "来源：" + (isWxOpenPay ? "微信支付" : "小程序支付"));

            try
            {
                ResponseHandler resHandler = new ResponseHandler(null);

                string return_code = resHandler.GetParameter("return_code");
                string return_msg = resHandler.GetParameter("return_msg");

                bool paySuccess = false;

                resHandler.SetKey(TenPayV3Info.Key);
                //验证请求是否从微信发过来（安全）
                if (resHandler.IsTenpaySign() && return_code.ToUpper() == "SUCCESS")
                {
                    string out_trade_no = resHandler.GetParameter("out_trade_no");
                    string openid = resHandler.GetParameter("openid");
                    string total_fee = resHandler.GetParameter("total_fee");
                    string transaction_id = resHandler.GetParameter("transaction_id");

                    try
                    {
                        var order = _context.Order.FirstOrDefault(od => od.OrderID == out_trade_no);
                        if (order != null)
                        {
                            order.TransactionId = transaction_id;
                            order.ActPay = decimal.Parse(total_fee);
                            order.OrderStatus = 1;
                            order.PayType = "WeiXin";
                            order.OpenID = openid;
                            _context.Order.Update(order);
                            _context.SaveChanges();
                        }
                        paySuccess = true;//正确的订单处理
                    }
                    catch (Exception ex)
                    {
                        return_code = "FAIL";
                        return_msg = "无法购买商品";
                        paySuccess = false;
                        _logger.LogError(ex, "数据无法保存");
                    }
                }
                else
                {
                    paySuccess = false;//错误的订单处理
                }
                if (paySuccess)
                {
                    /* 这里可以进行订单处理的逻辑 */

                    //发送支付成功的模板消息
                    try
                    {
                        string appId = Config.SenparcWeixinSetting.WeixinAppId;//与微信公众账号后台的AppId设置保持一致，区分大小写。
                        string openId = resHandler.GetParameter("openid");

                        if (isWxOpenPay)
                        {
                            var cacheStrategy = CacheStrategyFactory.GetObjectCacheStrategyInstance();
                            var unifiedorderRequestData = cacheStrategy.Get<TenPayV3UnifiedorderRequestData>($"WxOpenUnifiedorderRequestData-{openId}");//获取订单请求信息缓存
                            var unifedorderResult = cacheStrategy.Get<UnifiedorderResult>($"WxOpenUnifiedorderResultData-{openId}");//获取订单信息缓存

                            if (unifedorderResult != null || !string.IsNullOrEmpty(unifedorderResult.prepay_id))
                            {
                                Senparc.Weixin.WeixinTrace.SendCustomLog("支付成功模板消息参数（小程序）", appId + " , " + openId);

                                //小程序支付，发送小程序模板消息
                                var templateData = new WxOpenTemplateMessage_PaySuccessNotice(
                                                    "在线购买（小程序支付）测试", DateTime.Now, "小程序支付 | 注意：这条消息来自微信服务器异步回调，官方证明支付成功！ | prepay_id：" + unifedorderResult.prepay_id,
                                                   unifiedorderRequestData.OutTradeNo, unifiedorderRequestData.TotalFee, "400-031-8816", "https://weixin.senparc.com");

                                Senparc.Weixin.WxOpen.AdvancedAPIs
                                    .Template.TemplateApi
                                    .SendTemplateMessage(
                                        Config.SenparcWeixinSetting.WxOpenAppId, openId, templateData.TemplateId, templateData, unifedorderResult.prepay_id, "pages/index/index", "图书", "#fff00");
                            }
                            else
                            {
                                Senparc.Weixin.WeixinTrace.SendCustomLog("支付成功模板消息参数（小程序）", "prepayId未记录：" + appId + " , " + openId);
                            }

                        }
                        else
                        {
                            //微信公众号支付
                            var templateData = new WeixinTemplate_PaySuccess("https://weixin.senparc.com", "购买商品", "状态：" + return_code);
                            Senparc.Weixin.WeixinTrace.SendCustomLog("支付成功模板消息参数（公众号）", appId + " , " + openId);
                            var result = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(appId, openId, templateData);
                        }

                    }
                    catch (Exception ex)
                    {
                        WeixinTrace.WeixinExceptionLog(new WeixinException("支付成功模板消息异常", ex));
                        //WeixinTrace.SendCustomLog("支付成功模板消息", ex.ToString());
                    }

                    WeixinTrace.SendCustomLog("PayNotifyUrl回调", "支付成功");

                }
                else
                {
                    Senparc.Weixin.WeixinTrace.SendCustomLog("PayNotifyUrl回调", "支付失败");
                }
                string xml = string.Format(@"<xml>
<return_code><![CDATA[{0}]]></return_code>
<return_msg><![CDATA[{1}]]></return_msg>
</xml>", return_code, return_msg);

                return Content(xml, "text/xml");
            }
            catch (Exception ex)
            {
                WeixinTrace.WeixinExceptionLog(new WeixinException(ex.Message, ex));
                throw;
            }
        }
        /// <summary>
        /// 小程序微信支付回调
        /// </summary>
        /// <returns></returns>
        [HttpGet("PayNotifyUrlWxOpen")]
        public IActionResult PayNotifyUrlWxOpen()
        {
            WeixinTrace.SendCustomLog("小程序微信支付回调", "TenPayV3Controller.PayNotifyUrlWxOpen()");
            return PayNotifyUrl_Ex(true);//调用正常的流程

        }


        #endregion





    }
}

