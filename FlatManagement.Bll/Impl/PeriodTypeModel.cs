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

		#region IPeriodType members
		public int PeriodTypeId
		{
			get { return Current.PeriodTypeId; }
			set { Current.PeriodTypeId = value; }
		}

		public string Name
		{
			get { return Current.Name; }
			set { Current.Name = value; }
		}
		#endregion
	}
}
