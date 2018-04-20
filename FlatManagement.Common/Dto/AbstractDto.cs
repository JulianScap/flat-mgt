using System.Collections.Generic;
using System.Reflection;

namespace FlatManagement.Common.Dto
{
	public abstract class AbstractDto : IDto
	{
		public abstract string[] IdFieldNames { get; }
		public abstract string[] DataFieldNames { get; }
		public abstract string[] AllFieldNames { get; }
		public abstract TypeEnum[] IdFieldTypes { get; }
		public abstract bool IsPersisted { get; }

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

		private PropertyInfo GetProperty(string name)
		{
			return GetType().GetProperty(name);
		}
	}

	public abstract class AbstractDto<TId> : AbstractDto, IDto<TId>
	{
		public AbstractDto() { }

		public abstract TId GetId();

		public override bool IsPersisted {
			get
			{
				return !EqualityComparer<TId>.Default.Equals(GetId(), default(TId));
			}
		}
	}
}
