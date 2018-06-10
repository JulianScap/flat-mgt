using System;
using System.Security.Cryptography;
using System.Text;
using FlatManagement.Common.Exceptions;
using FlatManagement.Common.Extensions;
using FlatManagement.Common.Logging;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Security
{
	public class CryptoHelper : ICryptoHelper
	{
		private readonly IConfiguration configuration;

		public CryptoHelper(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public string Hash(string toHash)
		{
			if (toHash == null)
			{
				return null;
			}

			byte[] bytesToHash = Encoding.UTF8.GetBytes(toHash);
			using (SHA256 sha = SHA256.Create())
			{
				byte[] hashed = sha.ComputeHash(bytesToHash);
				return Convert.ToBase64String(hashed);
			}
		}

		public string Encrypt(string clearTextValue)
		{
			if (clearTextValue == null)
			{
				return null;
			}
			try
			{
				byte[] toEncrypt = Encoding.UTF8.GetBytes(clearTextValue);

				using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
				{
					provider.FromXmlStringOverride(configuration["Security:Password:Xml:PublicKey"]);
					byte[] encrypted = provider.Encrypt(toEncrypt, false);
					return Convert.ToBase64String(encrypted);
				}
			}
			catch (Exception ex)
			{
				LogStuff.Log(ex);
				throw new SecurityException();
			}
		}

		public string Decrypt(string encryptedBase64)
		{
			if (encryptedBase64 == null)
			{
				return null;
			}
			try
			{
				byte[] toDecrypt = Convert.FromBase64String(encryptedBase64);

				using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
				{
					provider.FromXmlStringOverride(configuration["Security:Password:Xml:PrivateKey"]);
					byte[] decrypted = provider.Decrypt(toDecrypt, false);
					return Encoding.UTF8.GetString(decrypted);
				}
			}
			catch (Exception ex)
			{
				LogStuff.Log(ex);
				throw new SecurityException();
			}
		}
	}
}
