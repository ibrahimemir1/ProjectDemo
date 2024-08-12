using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entityframework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectDemo.ViewComponents.Appointment
{
    public class AppointmentListDashboard : ViewComponent
    {
        //CustomerManager apm = new CustomerManager(new EfCustomerRepository());
        AppointmentManager apm = new AppointmentManager(new EfAppointmentRepository());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var employeeID = c.Employees.Where(x=>x.Name==usermail).Select(y=>y.Employee_Id).FirstOrDefault();
            var values = apm.DayAppointmentListByEmployee(employeeID);
            return View(values);
        }


    }
}
