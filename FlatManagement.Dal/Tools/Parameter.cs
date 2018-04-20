using System.Diagnostics;

namespace FlatManagement.Dal.Tools
{
	[DebuggerDisplay("{FieldName}: {Value}")]
	public class Parameter
	{
		public Parameter(string fieldName, object value)
		{
			this.FieldName = fieldName;
			this.Value = value;
		}

		public string FieldName { get; private set; }
		public object Value { get; private set; }
	}
}
