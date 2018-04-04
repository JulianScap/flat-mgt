using FlatManagement.Common.Dto;
using FlatManagement.Dto.Entities;
using FlatManagement.Dto.Interface;

namespace FlatManagement.Dto.List
{
	public class PeriodType : AbstractDtoList<SinglePeriodType>, IPeriodType
	{
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
	}
}
