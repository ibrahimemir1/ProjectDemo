using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectDemo.Models;
using System.Security.Claims;

namespace ProjectDemo.Controllers
{
	[AllowAnonymous]
	public class AdminLoginController : Controller
	{
		
		private readonly SignInManager<AppUser> _signInManager;

		public AdminLoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Index(UserSignInViewModel p)
		{

			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Widget", new { area = "Admin" });
				}
				else
				{
					return RedirectToAction("Index", "Login");
				}
			}
			return View();
		
		}
	}
}
