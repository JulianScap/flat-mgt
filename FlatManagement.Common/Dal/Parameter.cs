using System.Diagnostics;
using FlatManagement.Common.Dto;

namespace FlatManagement.Common.Dal
{
	[DebuggerDisplay("{Name}:{Value}:{Type}")]
	public class Parameter
	{
		public Parameter(string fieldName, TypeEnum type, object value = null)
		{
			this.Name = fieldName;
			this.Value = value;
			this.Type = type;
		}

		public string Name { get; set; }
		public object Value { get; set; }
		public TypeEnum Type { get; set; }
	}
}
