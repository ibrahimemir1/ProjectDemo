using BusinessLayer.Concrete;
using DataAccessLayer.Entityframework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ProjectDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BranchManager bm = new BranchManager(new EfBranchRepository());
        AppointmentManager apm = new AppointmentManager(new EfAppointmentRepository());
        CustomerManager cm = new CustomerManager(new EfCustomerRepository());
        EmployeeManager em = new EmployeeManager(new EfEmployeeRepository());        
            
        public IViewComponentResult Invoke() 
        {
            ViewBag.v1= bm.GetAll().Count();
            ViewBag.v2= apm.GetAll().Count();
            ViewBag.v3= em.GetAll().Count();
            string api = "0bf5875c2602824bc1a7ed81b7d4d959";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&xln=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.havadurumu = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
