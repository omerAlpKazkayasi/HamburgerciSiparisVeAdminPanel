

using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using HamburgerUI.Models.VMs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                //Random random = new Random();
                //int code;
                //code = random.Next(100000, 1000000);


                //User appUser = new User()
                //{
                //    Cart = new Cart(),

                //    UserName = appUserRegisterDto.Username,

                //    Email = appUserRegisterDto.Email,

                //    PasswordHash = _passwordHasher.HashPassword(null, appUserRegisterDto.Password),

                //};

                User user = _mapper.Map<User>(userRegisterDto);
                var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
                user.Cart = new Cart();
                await _userManager.AddToRoleAsync(user, "User");


                //eklenecek

                //if (result.Succeeded)
                //{
                //    MimeMessage mimeMessage = new MimeMessage();
                //    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "projekursapi@gmail.com");
                //    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                //    mimeMessage.From.Add(mailboxAddressFrom);
                //    mimeMessage.To.Add(mailboxAddressTo);

                //    var bodyBuilder = new BodyBuilder();
                //    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz:" + code;
                //    mimeMessage.Body = bodyBuilder.ToMessageBody();

                //    mimeMessage.Subject = "Easy Cash Onay Kodu";

                //    SmtpClient client = new SmtpClient();
                //    client.Connect("smtp.gmail.com", 587, false);
                //    client.Authenticate("projekursapi@gmail.com", "btfcoirevejxphfr");
                //    client.Send(mimeMessage);
                //    client.Disconnect(true);

                //    TempData["Mail"] = appUserRegisterDto.Email;

                //    return RedirectToAction("Index", "ConfirmMail");
                //}
                //else
                //{
                //    foreach (var item in result.Errors)
                //    {
                //        ModelState.AddModelError("", item.Description);
                //    }
                //}
            }
            return RedirectToAction("Index","Home");
        }

        public IActionResult Login(string returnUrl)
        {
            returnUrl = returnUrl is null ? "~/Home/Index" : returnUrl;
            return View(new LoginVM() { ReturnUrl = returnUrl });
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (ModelState.IsValid)
            {
                User appUser = await _userManager.FindByNameAsync(vm.Username);

                if (appUser != null)
                {
                    var d = await _userManager.GetRolesAsync(appUser);

                    await _signInManager.SignOutAsync();

                    if (d.Contains("Admin"))
                    {
                        Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, vm.Password, false, false);
                        if (signInResult.Succeeded)
                        {

                            return RedirectToAction("MenuListele", "Menu", new { area = "Admin" });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Kullanıcı adı veya parola yanlış");
                        }
                    }
                    else
                    {
                        Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, vm.Password, false, false);
                        if (signInResult.Succeeded)
                        {
                            return Redirect(vm.ReturnUrl ?? "/");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Kullanıcı adı veya parola yanlış");
                        }
                    }
                }

            }
            return View(vm);
        }

    
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        public IActionResult Liste()
        {
            return View(_userManager.Users);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult NotFound()
        {
            return View();
        }
    }
}