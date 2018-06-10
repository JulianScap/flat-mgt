using System.Reflection;
using FlatManagement.Common.Validation;
using Newtonsoft.Json;

namespace FlatManagement.Common.Dto
{
	public abstract class AbstractDto : IDto
	{
		[JsonIgnore]
		public abstract string[] IdFieldNames { get; }
		[JsonIgnore]
		public abstract string[] DataFieldNames { get; }
		[JsonIgnore]
		public abstract string[] AllFieldNames { get; }
		[JsonIgnore]
		public abstract TypeEnum[] IdFieldTypes { get; }
		[JsonIgnore]
		public abstract TypeEnum[] DataFieldTypes { get; }
		[JsonIgnore]
		public abstract TypeEnum[] AllFieldTypes { get; }
		[JsonIgnore]
		public abstract bool IsPersisted { get; }

		public ValidationResult ValidationResult { get; protected set; }

		public AbstractDto()
		{
			ValidationResult = new ValidationResult();
		}


		public virtual object GetFieldValue(string fieldName)
		{
			PropertyInfo pi = GetProperty(fieldName);
			return pi.GetValue(this);
		}

		public virtual void SetFieldValue(string fieldName, object value)
		{
			PropertyInfo pi = GetProperty(fieldName);
			pi.SetValue(this, value);
		}

		public abstract ValidationResult Validate();

		private PropertyInfo GetProperty(string name)
		{
			return GetType().GetProperty(name);
		}
	}
}
