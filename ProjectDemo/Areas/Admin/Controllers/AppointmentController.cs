using BusinessLayer.Concrete;
using DataAccessLayer.Entityframework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        AppointmentManager apm = new AppointmentManager(new EfAppointmentRepository());
        EmployeeManager em = new EmployeeManager(new EfEmployeeRepository());


        public IActionResult AppointmentList()
        {
            var values = apm.AppointmentListDashboard();
            return View(values);
        }
        public IActionResult AppointmentDelete(int id)
        {
            var values = apm.GetById(id);
            apm.Remove(values);
            return RedirectToAction("AppointmentList", "Appointment", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult AppointmentUpdate(int id)
        {
            List<SelectListItem> appvalues = (from x in apm.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Description,
                                                       Value = x.Appointment_Id.ToString()
                                                   }).ToList();
            ViewBag.ev = appvalues;
            var appointment = apm.GetById(id);
            return View(appointment);
        }
        [HttpPost]
        public IActionResult AppointmentUpdate(Appointment appointment)

        {
            apm.Update(appointment);
            return RedirectToAction("AppointmentList", "Appointment", new { area = "Admin" });
        }



    }
}
