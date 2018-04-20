using System.Diagnostics;
using FlatManagement.Common.Dto;

namespace FlatManagement.Dal.Tools
{
	[DebuggerDisplay("{Name}: {Value}")]
	public class Parameter
	{
		public Parameter()
		{
			this.Type = TypeEnum.Int32;
		}

		public Parameter(string fieldName, object value) : this()
		{
			this.Name = fieldName;
			this.Value = value;
		}

		public string Name { get; set; }
		public object Value { get; set; }
		public TypeEnum Type { get; set; }
	}
}
