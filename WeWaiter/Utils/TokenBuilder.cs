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

namespace WeWaiter.Utils
{
    public static class TokenBuilder
    {
        private const string keyString = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed";
        public static readonly byte[] symmetricKeyBytes = Encoding.ASCII.GetBytes(keyString);
        public static readonly SymmetricSecurityKey symmetricKey = new SymmetricSecurityKey(symmetricKeyBytes);
        public static readonly SigningCredentials signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
        internal static TokenValidationParameters tokenValidationParams;
        //Construct our JWT authentication paramaters then inject the parameters into the current TokenBuilder instance
        // If injecting an RSA key for signing use this method
        // Be weary of common jwt trips: https://trustfoundry.net/jwt-hacking-101/ and https://www.sjoerdlangkemper.nl/2016/09/28/attacking-jwt-authentication/
        //public static void ConfigureJwtAuthentication(this IServiceCollection services, RSAParameters rsaParams)
        public static void ConfigureJwtAuthentication(this IServiceCollection services)
        {
            tokenValidationParams = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://bonafortune.com",
                ValidateLifetime = true,
                ValidAudience = "https://bonafortune.com",
                ValidateAudience = true,
                RequireSignedTokens = true,
                // Use our signing credentials key here
                // optionally we can inject an RSA key as
                //IssuerSigningKey = new RsaSecurityKey(rsaParams),
                IssuerSigningKey = signingCredentials.Key,
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
        public static string CreateJsonWebToken(
               string userid,
               IEnumerable<string> roles,
               string audienceUri,
               string issuerUri,
               Guid applicationId,
               DateTime expires,
               string deviceId = null,
               bool isReAuthToken = false)
        {
            var claims = new List<Claim>();
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }
            var head = new JwtHeader();
            var jwt = new JwtSecurityToken(issuerUri, audienceUri, claims, DateTime.UtcNow, expires, signingCredentials);
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
                try
                {
                    principal = jwtSecurityTokenHandler.ValidateToken(jwToken, TokenBuilder.tokenValidationParams, out securityToken);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
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
