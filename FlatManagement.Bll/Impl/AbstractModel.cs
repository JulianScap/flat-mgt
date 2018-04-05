using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dto;

namespace FlatManagement.Bll.Impl
{
	internal class AbstractModel : IModel
	{

	}


	internal class AbstractModel<TList> : AbstractModel, IModel<TList>
		where TList : IDtoList, new()
	{
		protected TList Items { get; set; }
	}
}
