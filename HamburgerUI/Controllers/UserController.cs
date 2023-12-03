using AutoMapper;
using BusinessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using HamburgerUI.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace HamburgerUI.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public UserController(UserManager<User> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> UserUpdate()
		{
			//UserUpdateVM dto= new UserUpdateVM();
			//User user = await _userManager.FindByNameAsync(User.Identity.Name);

			//dto.Name = user.Name;
			//dto.Surname=user.Surname;


			User user = await _userManager.FindByNameAsync(User.Identity.Name);
			UserUpdateDTO dto = _mapper.Map<UserUpdateDTO>(user);

			return View(dto);


		}
		[HttpPost]
		public async Task<IActionResult> UserUpdate(UserUpdateDTO useru)
		{
			User user = await _userManager.FindByNameAsync(User.Identity.Name);
			user.Name = useru.Name;
			user.Surname = useru.Surname;
			//user.PasswordHash = _passwordHasher.HashPassword(null, useru.Password);
			await _userManager.UpdateAsync(user);

			//User user = await _userManager.FindByNameAsync(User.Identity.Name);
			//user = _mapper.Map<User>(useru);

			//await _userManager.UpdateAsync(user);

			return View();
		}
	}
}
