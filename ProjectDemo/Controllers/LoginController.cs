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
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }



        //[HttpPost]
        //public  async Task<IActionResult> Index(Employee p)
        //{
        //    Context c = new Context();
        //    var datavalue = c.Employees.FirstOrDefault(x => p.Employee_mail == p.Employee_mail &&
        //    x.Employee_password == p.Employee_password);
        //    if (datavalue != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, p.Employee_mail)
        //        };
        //        var useridentity = new ClaimsIdentity(claims,"a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index","Dashboard");

        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    } 
}

