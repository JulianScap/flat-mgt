using FlatManagement.Common.Dto;
using FlatManagement.Common.Exceptions;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Tools
{
	public abstract class ReadOnlyAbstractDataAccess<TDto> : AbstractDataAccess<TDto>, IDataAccess<TDto>
		where TDto : IDto, new()
	{
		protected ReadOnlyAbstractDataAccess(IConfiguration configuration) : base(configuration)
		{
		}

		public sealed override void Delete(IDto item)
		{
			throw new DisabledOperationException("This data access is read only");
		}

		public sealed override void Insert(TDto item)
		{
			throw new DisabledOperationException("This data access is read only");
		}

		public sealed override void Update(TDto item)
		{
			throw new DisabledOperationException("This data access is read only");
		}
	}
}
