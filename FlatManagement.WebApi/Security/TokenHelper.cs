using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FlatManagement.WebApi.Security
{
	public class TokenHelper
	{
		private static string symmetricSecurityKey;
		private static string audience;
		private static string issuer;

		public static void Configure(IConfiguration configuration)
		{
			symmetricSecurityKey = configuration["Security:Jwt:SymmetricSecurityKey"];
			audience = configuration["Security:Jwt:Audience"];
			issuer = configuration["Security:Jwt:Issuer"];
		}

		public static string GetNewToken(string login, string profile)
		{
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Convert.FromBase64String(symmetricSecurityKey));
			DateTime utcNow = DateTime.UtcNow;
			DateTime expires = utcNow.AddMinutes(60);
			SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
						new Claim(ClaimTypes.Name, login),
						new Claim(ClaimTypes.Role, profile)
				}),
				Expires = expires,
				Audience = audience,
				IssuedAt = utcNow,
				NotBefore = utcNow,
				Issuer = issuer,
				SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature),
			};

			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
			string tokenAsString = tokenHandler.WriteToken(token);
			return tokenAsString;
		}
	}
}
