using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FlatManagement.Common.Extensions;
using FlatManagement.Common.Logging;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Model;
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

		internal static bool CheckToken(string token, out UserInfo userInfo)
		{
			userInfo = null;
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
				userInfo = GetUserInfo(claims.Claims);
			}
			catch (Exception ex)
			{
				LogStuff.Log(ex);

				return false;
			}
			return true;
		}

		private static UserInfo GetUserInfo(IEnumerable<Claim> claims)
		{
			UserInfo result = new UserInfo();

			foreach (Claim claim in claims)
			{
				if (claim.Type == ClaimTypes.Name)
				{
					result.Login = claim.Value;
				}
				else if (claim.Type == ClaimTypes.Sid)
				{
					result.AccountId = Convert.ToInt32(claim.Value);
				}
				else if (claim.Type == ClaimTypes.Role)
				{
					result.Role = claim.Value;
				}
			}

			return result;
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
