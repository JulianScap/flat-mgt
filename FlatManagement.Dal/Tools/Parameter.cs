using System.Diagnostics;

namespace FlatManagement.Dal.Tools
{
	[DebuggerDisplay("{FieldName}: {Value}")]
	public class Parameter
	{
		public Parameter()
		{

		}

		public Parameter(string fieldName, object value)
		{
			this.Name = fieldName;
			this.Value = value;
		}

		public string Name { get; set; }
		public object Value { get; set; }
	}
}
