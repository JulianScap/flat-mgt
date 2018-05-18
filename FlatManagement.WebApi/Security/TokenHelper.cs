using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FlatManagement.Common.Extensions;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FlatManagement.WebApi.Security
{
	public class TokenHelper
	{
		private static byte[] symmetricSecurityKey;
		private static string audience;
		private static string issuer;

		public static void Configure(IConfiguration configuration)
		{
			string symmetricSecurityKeyAsString = configuration["Security:Jwt:SymmetricSecurityKey"];
			symmetricSecurityKey = Convert.FromBase64String(symmetricSecurityKeyAsString);
			audience = configuration["Security:Jwt:Audience"];
			issuer = configuration["Security:Jwt:Issuer"];
		}

		internal static bool CheckToken(string token)
		{
			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(symmetricSecurityKey);
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			TokenValidationParameters parameters = new TokenValidationParameters()
			{
				IssuerSigningKey = securityKey,
				RequireSignedTokens = true,
				ValidateLifetime = true,
				ValidateAudience = true,
				ValidateIssuer = true,
				ValidIssuer = issuer,
				ValidAudience = audience
			};

			try
			{
				ClaimsPrincipal claims = tokenHandler.ValidateToken(token, parameters, out SecurityToken validatedToken);
			}
			catch
			{
				return false;
			}
			return true;
		}

		internal static string GetNewToken(Account account, string profile = "default")
		{
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(symmetricSecurityKey);
			DateTime utcNow = DateTime.UtcNow;
			DateTime expires = utcNow.AddMinutes(60);
			SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
						new Claim(ClaimTypes.Name, account.Login),
						new Claim(ClaimTypes.Sid, account.AccountId.ToInvariantString()),
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
