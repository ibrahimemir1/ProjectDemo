using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entityframework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDemo.Models;

namespace ProjectDemo.Controllers
{
    [AllowAnonymous]
    public class CustomerController : Controller
    {
        CustomerManager cm = new CustomerManager(new EfCustomerRepository());
        public IActionResult Index(UserSignInViewModel p)
        {
			Context c = new Context();
			
			var username = User.Identity.Name;
			ViewBag.veri = username;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var employeeID = c.Customers.Where(x => x.Customer_mail == usermail).Select(y => y.Customer_Id).FirstOrDefault();
			if (employeeID != null)
			{
				var values = cm.GetById(employeeID);
				ViewBag.name = values.Name;
				ViewBag.surname = values.Surname;

			}
			return View();
			//Context c = new Context();

			//var usermail = User.Identity.Name;
			//var employeeID = c.Customers.Where(x => x.Customer_mail == usermail).Select(y => y.Customer_Id).FirstOrDefault();
			//var values = cm.GetById(employeeID);

			//ViewBag.name = values.Name;
			//ViewBag.surname = values.Surname;
			//return View();
		}
		public PartialViewResult CustomerNavbar()
		{
			return PartialView();

		}
		



	}
}