using Challenge.Commons.Const;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace Challenge.Commons.Helper
{
    public static class JwtHelper
    {
        private static JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
        private static string JwtKey = ConfigurationManager.AppSettings["jwt.key"];

        public static string CreateToken(string username, string userId)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim("username", username));
            claimsIdentity.AddClaim(new Claim("user_id", userId));

            JwtSecurityToken jwtSecurityToken = TokenHandler.CreateJwtSecurityToken(null, null, claimsIdentity, null, DateTime.Now.AddDays(1), DateTime.Now, credentials);

            return TokenHandler.WriteToken(jwtSecurityToken);
        }

        public static JwtSecurityToken ReadToken(string token)
        {
            return TokenHandler.ReadJwtToken(token);
        }

        public static bool ValidateToken(string token)
        {
            try
            {
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey));
                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = securityKey,
                    RequireExpirationTime = true,
                    ValidateAudience = false
                };

                TokenHandler.ValidateToken(token, validationParameters, out var securityToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}