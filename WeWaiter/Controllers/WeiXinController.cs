using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Senparc.CO2NET.HttpUtility;
using Senparc.Weixin;
using Senparc.Weixin.Entities;
using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.Sample.CommonService.CustomMessageHandler;

namespace WeWaiter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeiXinController : ControllerBase
    {

     
        SenparcWeixinSetting _senparcWeixinSetting;

        public WeiXinController(IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            _senparcWeixinSetting = senparcWeixinSetting.Value;
        }

        /// <summary>
        /// 微信后台验证地址（使用Get），微信后台的“接口配置信息”的Url填写如：http://sdk.weixin.senparc.com/weixin
        /// </summary>
        [HttpGet]
        public IActionResult Get([FromQuery]PostModel postModel, [FromQuery] string echostr)
        {
            try
            {
                if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, _senparcWeixinSetting.Token))
                {
                    return Ok(echostr); //返回随机字符串则表示验证通过
                }
                else
                {
                    return Ok($"failed:{postModel.Signature},{Senparc.Weixin.MP.CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, _senparcWeixinSetting.Token)}。如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。_senparcWeixinSetting.Token:{_senparcWeixinSetting.Token},WeixinAppId:{_senparcWeixinSetting.WeixinAppId},echostr={echostr}");
                }
            }
            catch (Exception ex)
            {

                return Ok(ex.ToString());
            }
        }
         
    }
}

   

       

 