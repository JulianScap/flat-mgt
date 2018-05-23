using System;
using System.Security.Cryptography;
using System.Text;
using FlatManagement.Common.Exceptions;
using FlatManagement.Common.Extensions;
using FlatManagement.Common.Logging;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Security
{
	public class CryptoTool
	{
		#region Hash
		public static string Hash(string toHash)
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
		#endregion

		#region Encrypt
		public static string Encrypt(string clearTextValue, IConfiguration configuration)
		{
			return Encrypt(clearTextValue, configuration["Security:Password:Xml:PublicKey"]);
		}

		private static string Encrypt(string clearTextValue, string publicKey)
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
					provider.FromXmlStringOverride(publicKey);
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
		#endregion

		#region Decrypt
		public static string Decrypt(string encryptedBase64, IConfiguration configuration)
		{
			return Decrypt(encryptedBase64, configuration["Security:Password:Xml:PrivateKey"]);
		}

		private static string Decrypt(string encryptedBase64, string privateKey)
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
					provider.FromXmlStringOverride(privateKey);
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
		#endregion
	}
}
