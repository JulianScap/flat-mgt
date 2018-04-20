using System;
using FlatManagement.Common.Dto;

namespace FlatManagement.Test.Tools
{
	public interface IFakeDto : IDto
	{

	}

	public class FakeDto : AbstractDto<int>, IFakeDto
	{
		public override string[] IdFieldNames { get; }
		public override string[] DataFieldNames { get; }
		public override string[] AllFieldNames { get; }
		public override TypeEnum[] IdFieldTypes { get; }

		public override int GetId()
		{
			throw new NotImplementedException();
		}
	}
}
