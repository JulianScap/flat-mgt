using System;
using FlatManagement.Common.Dto;

namespace FlatManagement.Test.Tools
{
	public interface IFakeDto : IDto
	{

	}

	public class FakeDto : AbstractDto<int>, IFakeDto
	{
		public override int GetId()
		{
			throw new NotImplementedException();
		}
	}
}
