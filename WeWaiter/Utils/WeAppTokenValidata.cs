using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Senparc.Weixin.WxOpen.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WeWaiter.Utils
{
    public class WeAppTokenValidata : ISecurityTokenValidator
    {
        //判断当前token是否有值
        public bool CanValidateToken => true;

        public int MaximumTokenSizeInBytes { get; set; }//顾名思义是验证token的最大bytes

        public bool CanReadToken(string securityToken)
        {
            return SessionContainer.CheckRegistered(securityToken);
        }
        ///验证securityToken
        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            validatedToken = null;
            if (!SessionContainer.CheckRegistered(securityToken))
            {
                return null;
            }
            else
            {
                var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                return principal;
            }
        }
    }
}
