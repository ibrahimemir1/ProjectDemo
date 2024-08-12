using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
     public  interface IAppointmentDal : IGenericDal<Appointment>
    {
        List<Appointment> GetAppointmentListByEmployee(int id);
        List<Appointment> GetAppointmentListByCustomer(int id);
        List<Appointment> GetDayAppointmentListByEmployee(int id);
        List<Appointment> GetAppointmentListWithAdminDashboard();
        List<Appointment> GetAppointmentListWithCustomerDashboard();




    }
}
