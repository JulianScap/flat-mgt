using FlatManagement.Bll.Interface;
using FlatManagement.Dto.List;

namespace FlatManagement.Bll.Impl
{
	class PeriodTypeModel : AbstractModel<PeriodType>, IPeriodTypeModel
	{
		public PeriodTypeModel()
		{
			Items = new PeriodType();
		}
	}
}
