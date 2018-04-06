using FlatManagement.Bll.Interface;
using FlatManagement.Dal;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.Dto.List;

namespace FlatManagement.Bll.Impl
{
	class PeriodTypeModel : AbstractModel<PeriodType, PeriodTypeDto>, IPeriodTypeModel
	{
		public PeriodTypeModel()
		{
			Items = new PeriodType();
		}

		protected override IDataAccess<PeriodType> GetDal(params object[] args)
		{
			return DalFactory.Instance.Get<IPeriodTypeDataAccess>();
		}
	}
}
