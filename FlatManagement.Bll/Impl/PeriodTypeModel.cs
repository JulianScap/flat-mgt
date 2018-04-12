using FlatManagement.Bll.Interface;
using FlatManagement.Dal;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;

namespace FlatManagement.Bll.Impl
{
	internal class PeriodTypeModel : AbstractModel<PeriodType>, IPeriodTypeModel
	{
		protected override IDataAccess<PeriodType> GetDal(params object[] args)
		{
			return DalFactory.Instance.Get<IPeriodTypeDataAccess>();
		}
	}
}
