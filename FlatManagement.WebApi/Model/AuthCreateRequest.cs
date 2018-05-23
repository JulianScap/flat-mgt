using FlatManagement.Dto.Entities;

namespace FlatManagement.WebApi.Model
{
	public class AuthCreateRequest
    {
		public Flat Flat { get; set; }
		public Flatmate Flatmate { get; set; }
	}
}
