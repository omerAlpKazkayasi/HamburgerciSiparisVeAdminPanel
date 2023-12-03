using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace BusinessLayer.AutoMapper.Users
{
	public class UserUpdateProfile : Profile
	{
		public UserUpdateProfile()
		{
			CreateMap<UserUpdateDTO, User>().ReverseMap();
		}
	}

}