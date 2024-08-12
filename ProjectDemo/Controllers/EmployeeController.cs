using BusinessLayer.Concrete;
using DataAccessLayer.Entityframework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDemo.Controllers
{
	
    public class EmployeeController : Controller
	{
		EmployeeManager em = new EmployeeManager(new EfEmployeeRepository());
		CustomerManager cm = new CustomerManager(new EfCustomerRepository());
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}	
		public IActionResult Test()
		{
			return View();
		}
		public PartialViewResult EmployeeNavbarPartial()
		{ 
			return PartialView();
		
		}
		public PartialViewResult EmployeeFooterPartial()
		{
			return PartialView();
		}
		
	}
}
