using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entityframework;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ProjectDemo.Controllers
{
    public class AppointmentController : Controller
    {
		AppointmentManager apm = new AppointmentManager(new EfAppointmentRepository());
		CustomerManager cm = new CustomerManager(new EfCustomerRepository());
        EmployeeManager em = new EmployeeManager(new EfEmployeeRepository());
		BranchManager bm = new BranchManager(new EfBranchRepository());
		private readonly UserManager<AppUser> _customermanager;
		public AppointmentController(UserManager<AppUser> customermanager)
		{
			_customermanager = customermanager;
		}
		public IActionResult Index()
        {
            var appointments = apm.AppointmentListCustomerDashboard(); // 
            return View(appointments);
        }

        [HttpGet]
        public IActionResult CreateAppointment()
        {
            List<SelectListItem> branchvalues = (from x in bm.GetAll()             // Hangi banka şubesi ile randevu ?
												  select new SelectListItem
												  {
													  Text = x.Name,
													  Value = x.Branch_Id.ToString()
												  }).ToList();

			ViewBag.bv = branchvalues;

            List<SelectListItem> employeevalues = (from x in em.GetAll()          // Hangi Çalışan ile randevu ? 
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Employee_Id.ToString()
                                                   }).ToList();
            ViewBag.ev = employeevalues;
            
            return View();

		}
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(Appointment appointment)
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var customerID = c.Customers.Where(x => x.Name == usermail).Select(y => y.Customer_Id).FirstOrDefault(); // dynamic olarak sisteme otantike
																													 // olan kişinin ıdsini alıyoruz.
																													
            var values = apm.GetById(customerID); 
            appointment.Customer_Id = customerID;
			appointment.IsActive = true;
            apm.insert(appointment); 
            return RedirectToAction("AppointmentListByCustomer","Appointment");
        }
		[HttpGet]
		public IActionResult UpdateAppointment(int id)
		{
            List<SelectListItem> employeevalues = (from x in em.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Employee_Id.ToString()
                                                   }).ToList();
            ViewBag.ev = employeevalues;
            var appointment = apm.GetById(id);
			return View(appointment);
		}
		[HttpPost]
		public IActionResult UpdateAppointment(Appointment appointment)

        { 
			apm.Update(appointment);
			return RedirectToAction("AppointmentListByEmployee","Appointment");
		}

		[HttpGet]
		public IActionResult DeleteAppointmentWithCust(int id)
		{
			var values = apm.GetById(id);
			apm.Remove(values);
			return RedirectToAction("Index","Appointment");

		}
		public IActionResult DeleteAppointment(int id)
		{
			var appointment = apm.GetById(id); //
			if (appointment == null)
			{
				return NotFound();
			}
			return View(appointment);
		}

		[HttpPost]

		[ActionName("DeleteAppointment")]
		public IActionResult DeleteConfirmed(Appointment appointment)
		{

			if (appointment == null)
			{
				return NotFound();
			}
			apm.Remove(appointment); // 
			return RedirectToAction("AppointmentListByEmployee", "Appointment");
		}

		public IActionResult AppointmentListByEmployee()
		{
            Context c = new Context();
            var usermail = User.Identity.Name;
            var employeeID = c.Employees.Where(x => x.Name == usermail).Select(y => y.Employee_Id).FirstOrDefault();
            var values = apm.AppointmentListByEmployee(employeeID);
			return View(values);                          
		}
        public IActionResult AppointmentListByCustomer()
        {
            Context c = new Context();
			var usermail = User.Identity.Name;
			var customerID = c.Customers.Where(x => x.Name == usermail).Select(y => y.Customer_Id).FirstOrDefault();
			var values = apm.AppointmentListByCustomer(customerID);
			return View(values);
        }



    }
}

