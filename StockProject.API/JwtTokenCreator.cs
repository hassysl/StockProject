﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockProject.API
{
    public class JwtTokenCreator
    {
        public string GenerateToken()
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("halilhalilhalil1.")); //simetrik encryptionda şifrelenecek olan dataya ve şifrelenmiş haline aynı key ile giriş yapılır.

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //imzamızı oluşturduk

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", claims: claims, audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddDays(10), signingCredentials: credentials );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();



            return handler.WriteToken(token);
        }
    }
}
