using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AngularJSTest.Models
{
    public class Authentication
    {
        public static string GenerateJWTToken(string Username, List<string> roles, string base64Key)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub , Username),
                 new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, Username)
            };

            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Convert.ToString(base64Key)));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(Convert.ToString(ConfigurationManager.AppSettings["config.JwtExpireDays"])));


            var token = new JwtSecurityToken(
                Convert.ToString(ConfigurationManager.AppSettings["config.JwtIssuer"]),
                Convert.ToString(ConfigurationManager.AppSettings["config.JwtAudience"]),
                claims,
                expires: expires,
                signingCredentials: creds

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string ValidateToken(string token , string base64Key1)
        {
            if (token == null)
            {
                return null;
            }

            string base64Key = base64Key1; // Replace with your actual secret key
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(base64Key);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validateToken);

                var jwtToken = (JwtSecurityToken)validateToken;
                var jti = jwtToken.Claims.First(claim => claim.Type == "jti").Value;
                var userName = jwtToken.Claims.First(sub => sub.Type == "sub").Value;

                return userName;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                return null;
            }
        }

    }
}