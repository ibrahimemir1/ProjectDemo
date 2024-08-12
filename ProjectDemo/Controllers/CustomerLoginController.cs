using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entityframework;
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
	public class CustomerLoginController : Controller
	{

		private readonly SignInManager<AppUser> _signInManager;
		CustomerManager cm = new CustomerManager(new EfCustomerRepository());
		public CustomerLoginController(SignInManager<AppUser> signInManager)
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
					return RedirectToAction("Index", "Customer");
				}
				else
				{
					return RedirectToAction("Index", "CustomerLogin");
				}
			}
			return View();
		}
	}
}
