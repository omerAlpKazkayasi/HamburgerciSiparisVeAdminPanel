using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.Users
{
	public class UserRegisterProfile : Profile
	{
		public UserRegisterProfile()
		{
			CreateMap<UserRegisterDTO, User>().ReverseMap();
		}
	}

}