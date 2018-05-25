using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;

namespace FlatManagement.Test.Tools
{
	public interface IFakeDto : IDto
	{

	}

	public class FakeDto : AbstractDto, IFakeDto
	{
		public override string[] IdFieldNames { get; }
		public override string[] DataFieldNames { get; }
		public override string[] AllFieldNames { get; }
		public override TypeEnum[] IdFieldTypes { get; }
		public override bool IsPersisted { get; }
		public override TypeEnum[] DataFieldTypes { get; }
		public override TypeEnum[] AllFieldTypes { get; }

		public override void Validate()
		{
			ValidationResult = new ValidationResult();
		}
	}
}
