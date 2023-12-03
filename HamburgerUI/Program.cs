using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer.AutoMapper.Users;
using BusinessLayer.DependencyResolvers.Autofac;
using BusinessLayer.Extensions;
using BusinessLayer.Validation;
using Entities.Concrete;
using Entitiess.Concrete.DBcontext;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(options =>
{
	options.RegisterModule(new AutofacBusiness());
});


//Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(
	option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConnString")));

builder.Services.AddIdentity<User, AppRole>(
	option =>
	{
		option.Password.RequiredLength = 3;
		option.Password.RequireUppercase = false;
		option.Password.RequireLowercase = false;
		option.Password.RequireNonAlphanumeric = false;
	}
	).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
options =>
{
   options.LoginPath = "/Account/Login";
   options.LogoutPath = "/Account/Logout";
   options.AccessDeniedPath = "/Account/AccessDenied";
   options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
});



builder.Services.LoadBusinessLayerExtensions();
builder.Services.AddControllersWithViews()
 .AddFluentValidation(options =>
 {
     options.RegisterValidatorsFromAssemblyContaining<AdditionalAddValidator>();
     options.RegisterValidatorsFromAssemblyContaining<ProductUpdateValidator>();
     options.RegisterValidatorsFromAssemblyContaining<BeverageAddValidator>();
     options.RegisterValidatorsFromAssemblyContaining<HamburgerAddValidator>();
     options.RegisterValidatorsFromAssemblyContaining<MenuValidator>();
     options.RegisterValidatorsFromAssemblyContaining<ProductDetailsValidator>();


     options.ConfigureClientsideValidation(configuration =>
     {

     });
 });

var app = builder.Build();


app.UseStatusCodePagesWithReExecute("/Account/NotFound", "?code={0}");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
           name: "Admin",
           pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
         );


app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();