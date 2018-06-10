namespace FlatManagement.Common.Security
{
	public interface ICryptoHelper
	{
		string Hash(string toHash);
		string Encrypt(string clearTextValue);
		string Decrypt(string encryptedBase64);
	}
}