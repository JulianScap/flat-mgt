using System.Collections.Generic;
using System.Linq;
using FlatManagement.Common.Extensions;

namespace FlatManagement.Common.Validation
{
	public class ValidationResult
	{
		public ValidationResult(params string[] messages)
		{
			Messages = new List<Message>();
			foreach (string message in messages)
			{
				Messages.Add(new Message(message, isError: true));
			}
		}

		/// <summary>
		/// The error messages.
		/// </summary>
		public List<Message> Messages { get; private set; }

		/// <summary>
		/// Returns true if the Messages collection is empty.
		/// </summary>
		public bool IsValid { get => Messages.IsEmpty(); }

		/// <summary>
		/// Concatenates two Validation result messages
		/// </summary>
		/// <param name="validationResult"></param>
		public void Add(ValidationResult validationResult)
		{
			if (validationResult != null)
			{
				this.Messages.AddRange(validationResult.Messages);
			}
		}

		/// <summary>
		/// Adds the message to the existing ones
		/// </summary>
		/// <param name="validationResult"></param>
		public void Add(string message, bool isError)
		{
			this.Messages.Add(new Message(message, isError));
		}

		/// <summary>
		/// Adds the messages to the existing ones
		/// </summary>
		/// <param name="validationResult"></param>
		public void AddError(params string[] messages)
		{
			if (messages != null && messages.Length != 0)
			{
				this.Messages.AddRange(messages.Select(x => new Message(x, true)));
			}
		}

		/// <summary>
		/// Adds the messages to the existing ones
		/// </summary>
		/// <param name="validationResult"></param>
		public void AddSuccess(params string[] messages)
		{
			if (messages != null && messages.Length != 0)
			{
				this.Messages.AddRange(messages.Select(x => new Message(x, false)));
			}
		}
	}
}
