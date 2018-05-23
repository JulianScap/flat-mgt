using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;

namespace FlatManagement.Common.Bll
{
	public interface IModel : IReadOnlyModel, IValidable
	{
		void DeleteAll();
		ValidationResult PersistAll();
	}

	public interface IModel<TDto> : IReadOnlyModel<TDto>, IModel
		where TDto : IDto, new()
	{
	}
}
