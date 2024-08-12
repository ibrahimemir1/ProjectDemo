using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entityframework
{
    public class EfAppointmentRepository : GenericRepository<Appointment> , IAppointmentDal
    {
        public List<Appointment> GetAppointmentListByEmployee(int id)
        {
            using (var c = new Context())
            {
                return c.Appointments.Include(x => x.Customer).Where(x => x.Employee_Id == id).ToList();
            }
        }
		public List<Appointment> GetDayAppointmentListByEmployee(int id)
		{
			using (var c = new Context())
			{
				return c.Appointments.Include(x => x.Customer).Where(x => x.Employee_Id == id &&
				x.Date.Day == DateTime.Now.Day &&
			    x.Date.Month == DateTime.Now.Month &&
			    x.Date.Year == DateTime.Now.Year).ToList();
			}
		}

        public List<Appointment> GetAppointmentListByCustomer(int id)
        {
            using (var c = new Context())
            {
                return c.Appointments.Include(x => x.Employee).Where(x => x.Customer_Id == id).ToList();
            }
        }

        public List<Appointment> GetAppointmentListWithAdminDashboard()
        {
            using (var c = new Context())
            {
                return c.Appointments.Include(x => x.Customer).ToList();
            }
        }
        
        public List<Appointment> GetAppointmentListWithCustomerDashboard()
        {
            using (var c = new Context())
            {
                return c.Appointments.Include(x => x.Employee).ToList();
            }
        }

    }
} 
