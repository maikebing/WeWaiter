using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WeWaiter.Data;
using WeWaiter.Models;

namespace WeWaiter.Utils
{
    public static class TokenExtension
    {
        internal static TokenValidationParameters tokenValidationParams;

        public static SigningCredentials SigningCredentials = null;

        //Construct our JWT authentication paramaters then inject the parameters into the current TokenBuilder instance
        // If injecting an RSA key for signing use this method
        // Be weary of common jwt trips: https://trustfoundry.net/jwt-hacking-101/ and https://www.sjoerdlangkemper.nl/2016/09/28/attacking-jwt-authentication/
        //public static void ConfigureJwtAuthentication(this IServiceCollection services, RSAParameters rsaParams)
        public static void ConfigureJwtAuthentication(this IServiceCollection services,  AppSettings appSettings)
        {
            SigningCredentials=   new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.JwtKey)), SecurityAlgorithms.HmacSha256);
            tokenValidationParams = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = appSettings.JwtIssuer,
                ValidateLifetime = true,
                ValidAudience =appSettings.JwtAudience,
                ValidateAudience = true,
                RequireSignedTokens = true,
                // Use our signing credentials key here
                // optionally we can inject an RSA key as
                //IssuerSigningKey = new RsaSecurityKey(rsaParams),
                IssuerSigningKey = SigningCredentials.Key,
                ClockSkew = TimeSpan.FromMinutes(0)
            };
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParams;
#if PROD || UAT
                options.IncludeErrorDetails = false;
#elif DEBUG
                options.RequireHttpsMetadata = false;
#endif
            });
        }
        public static string CreateJsonWebToken(this User user, AppSettings appSettings)
        {
            IEnumerable<string> roles = new List<string>() { "WeApp" };
            string userid = user.UserID;
            var claims = new List<Claim>();
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }
            var jwt = new JwtSecurityToken(appSettings.JwtIssuer, appSettings.JwtAudience, claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(appSettings.JwtExpireMinutes), SigningCredentials);
            jwt.Payload.AddClaims(claims.ToArray());
            jwt.Payload.Add("userid", userid);
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        public static JwtSecurityToken GetJwtSecurityToken(this HttpRequest httpRequest)
        {
            JwtSecurityToken result = null;
            var authenticationHeaders = httpRequest.Headers["Authorization"].ToArray();
            if ((authenticationHeaders == null) || (authenticationHeaders.Length != 1))
            {
                result =  null;
            }
            else
            {
                var jwToken = authenticationHeaders[0].Split(' ')[1];
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                ClaimsPrincipal principal = null;
                SecurityToken securityToken = null;
                principal = jwtSecurityTokenHandler.ValidateToken(jwToken, tokenValidationParams, out securityToken);

                if ((principal != null) && (principal.Claims != null))
                {
                    result = securityToken as JwtSecurityToken;
                    Trace.WriteLine(result.Audiences.First());
                    Trace.WriteLine(result.Issuer);
                }
            }
            return result;
        }
        public static string GetUserId(this JwtSecurityToken jwtSecurityToken)
        {
            return jwtSecurityToken.Payload["userid"] as string;
        }
        public static string GetPayloadValue(this JwtSecurityToken jwtSecurityToken,string Key)
        {
            return jwtSecurityToken.Payload[Key] as  string;
        }
    }
}
