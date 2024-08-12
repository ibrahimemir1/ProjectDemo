using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAppointmentService :IGenericService<Appointment>
    {
        List<Appointment> AppointmentListByEmployee(int id);
        List<Appointment> AppointmentListByCustomer(int id);
		List<Appointment> DayAppointmentListByEmployee(int id);
        List<Appointment> AppointmentListDashboard();
        List<Appointment> AppointmentListCustomerDashboard();

    }
}
