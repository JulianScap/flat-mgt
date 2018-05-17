using FlatManagement.Common.Security;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Common
{
	public class CryptoToolShould : TestBase
	{
		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("short")]
		public void DecryptAndEncryptSuccessfully(string text)
		{
			string encrypted = CryptoTool.Encrypt(text, GetConfiguration());
			string decrypted = CryptoTool.Decrypt(encrypted, GetConfiguration());
			Assert.Equal(text, decrypted);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("short")]
		[InlineData("longlonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglonglong")]
		public void HashValuesSuccessfully(string text)
		{
			string hashed1 = CryptoTool.Hash(text);
			string hashed2 = CryptoTool.Hash(text);
			Assert.Equal(hashed1, hashed2);
		}

		[Theory]
		[InlineData("8451ba8a14d79753d34cb33b51ba46b4b025eb81|2018-05-16T02:14:57.667Z", "IeqWliZZeqRDB+uKb21xnHd2Gvcy0+WqIPsFBCsZEBJWIl0VV4Zp8Pv4uo/arsBje21lOE5ezn2F+JHzT9xT2WfbqW1W59kiwD9OmMukQ8zPnD8cdOlGdUVSKCfaii9xVzVDyfYRRiuNoPO8slt9UGUcBGF8wr/pJ2osnbxqWnY=")]
		[InlineData("5804ab1727f55e0b6d7130e3339d2c1cf0b92aed|2018-05-16T02:15:40.095Z", "KizOg9fmOYlX75ta4wOnDpiKI5m6HpoNFK5SYD85SIv4AV0hUzqDjRhJylmubzvzbc6aZpMgTBwH34WOuJkXJXmgT+hEVosZt/WOcNH4Bm6C9XrApdFaWeE0GKzNA6avgA9kLn6xEyblv5sqVwRH9kXjIvhhUe/1h5HlJuHNRSU=")]
		[InlineData("14b0b1825fc47fdd59e1a0b90ef0f8def2383dbf|2018-05-16T02:15:55.442Z", "nLO6Hhhq3789WlRdbidUiT3WqgUqhBFeIQMWwg2DAW6V+MyrPnkCxGvla8X9Y9ee5cNOLHScb7bNLwbc7+KWaSL8KgTh7vG0WMUZg5MDU3kVhqdBr7cK5I3wY69I9wnyWgQ/fqIUynSS/pvLnV/rFQ9wuZjsiChCEB5qqRQTXxc=")]
		[InlineData("14b0b1825fc47fdd59e1a0b90ef0f8def2383dbf|2018-05-16T02:15:56.151Z", "UuprR9OgDLVq6Y/HxdxlssosIieiPw+p1WaynlhFImtsMt4Ns20uic4y1wOiBj7qmRF0YkwhrhSgv3wzxyfanPUJlU0KOXJZX0rTtPWlu5F7SuaHkqniPSHOGZCT1bn3WMIpEVWfTXHqtCfVSqRZPCFPx2SgrVNkSaf12S9suso=")]
		[InlineData("9231acbc581b3b0003e4915100c0dcc1d8827633|2018-05-16T02:16:01.614Z", "ZaENv5tvHi5I+sMt0dE4jwD0/l1zvKOSwiFyLr99sw7zq96KHG2OOrmJXC6Oe3igh/wSvdzit5mIwNszl79Ce4rHZUlQFD/rljpiBtLHlKtNwjx7OmAFK2QqD3/nsuGAZeymKOKlPFuTBZY+hl+Gpk43qZ28iGp0hHWEBbi4mm4=")]
		[InlineData("6101c2d56a4970fce9fa60f0748032b93d6401eb|2018-05-16T02:16:37.839Z", "I29xANnF9Chy8rkddipSs2LmXncOFgRRJpSUvVtlEtbn87+xYmfStyzBanioPkj4Pvoad3bQwemuVuieO/1CX9ieANXrpt0yjiJ4bsVBFLERfZ5LeTrIjTorb1GIsPyLrLL248oW3rO2hFCJvbFaQg+9CzDz1RNTj+FiRN+r6mM=")]
		public void CryptoToolShouldDecryptJavascriptGeneratedPasswords(string clearText, string encrypted)
		{
			string decrypted = CryptoTool.Decrypt(encrypted, GetConfiguration());
			Assert.Equal(clearText, decrypted);
		}
	}
}
