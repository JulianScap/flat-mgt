using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace FlatManagement.WebApi.Security
{
	public class TokenHelper
	{
		private const string key = "mLBMceMJwD7uzHKXzk2vA5qmqlx9ms2sTjsuSr6tGCXvefjoZlh0dmKPkCj7U0lXU8sMA23yC7iAJxki0DB0Xk+1lrt5v3+zLZGeY3ZYu7bZ2HWsEBX/SOBAPZGpWwHeGe4MFsdk5tUo2B+0v2cAHbgM/7s0Jw0K9s4iGo1201U=";

		public static string GetNewToken(string login, string profile)
		{
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Convert.FromBase64String(key));
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
				Audience = "http://fm.web.local:4200/",
				IssuedAt = utcNow,
				NotBefore = utcNow,
				Issuer = "http://fm.api.local/",
				SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature),
			};

			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
			string tokenAsString = tokenHandler.WriteToken(token);
			return tokenAsString;
		}
	}
}
