namespace FlatManagement.Common.Validation
{
	public class Message
	{

		public Message(string text, bool isError)
		{
			this.IsError = isError;
			this.Text = text;
		}

		public bool IsError { get; set; }
		public string Text { get; set; }
	}
}
