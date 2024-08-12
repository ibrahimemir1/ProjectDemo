using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entityframework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ProjectDemo.Controllers
{
    public class DashboardController : Controller
    {

        EmployeeManager em = new EmployeeManager(new EfEmployeeRepository());
        public IActionResult Index(int id)
        {
            Context c = new Context(); 
            var a = DateTime.Now.ToShortDateString();
            ViewBag.TotalCustomer = c.Appointments.Where(x => x.Date.Day == DateTime.Now.Day &&
            x.Date.Month == DateTime.Now.Month &&
            x.Date.Year == DateTime.Now.Year).Count().ToString();

            ViewBag.ActiveCustomer = c.Appointments.Where(x => x.Date.Day == DateTime.Now.Day &&
            x.Date.Month == DateTime.Now.Month &&
            x.Date.Year == DateTime.Now.Year && 
            x.Date.Hour >= DateTime.Now.Hour).Count().ToString();

            ViewBag.NoActiveCustomer = c.Appointments.Where(x => x.Date.Day == DateTime.Now.Day &&
            x.Date.Month == DateTime.Now.Month &&
            x.Date.Year == DateTime.Now.Year &&
            x.Date.Hour < DateTime.Now.Hour).Count().ToString();
            //ViewBag.TotalEmployee = c.Employees.Where(x=> x.Branch_Id == 1  ).Count().ToString();

            var username = User.Identity.Name;
            ViewBag.veri = username;
            var usermail = c.Users.Where(x=> x.UserName == username).Select(y=> y.Email).FirstOrDefault();
            var employeeID = c.Employees.Where(x => x.Employee_mail == usermail).Select(y => y.Employee_Id).FirstOrDefault();
            if (employeeID != null)
            {
                var values = em.GetById(employeeID);
                ViewBag.name = values.Name;
                ViewBag.surname = values.Surname;

            }
            string api = "0bf5875c2602824bc1a7ed81b7d4d959";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&xln=tr&units=metric&appid=" + api;
            if (connection != null)
            {
                XDocument document = XDocument.Load(connection);
                ViewBag.havadurumu = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            }
            return View();

        }
    }
}
