using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        IAppointmentDal _appointmentDal;
        public AppointmentManager(IAppointmentDal appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }

        public List<Appointment> AppointmentListByEmployee(int id) // randevu listesi çalışan ıdsine göre (employeedashboard)                                                                 //
        {
          return _appointmentDal.GetAppointmentListByEmployee(id);
        }

		public List<Appointment> DayAppointmentListByEmployee(int id) // günlük randevu listesi çalışan ıdsine göre
		{
			return _appointmentDal.GetDayAppointmentListByEmployee(id);
		}
        public List<Appointment> AppointmentListDashboard()
        {
            return _appointmentDal.GetAppointmentListWithAdminDashboard();
        }
        public List<Appointment> AppointmentListByCustomer(int id)
        {
            return _appointmentDal.GetAppointmentListByCustomer(id);

        }
        public List<Appointment> AppointmentListCustomerDashboard()
        {
            return _appointmentDal.GetAppointmentListWithCustomerDashboard();
        }

        public List<Appointment> GetAll()
        {
          return _appointmentDal.GetAll();
        }

        public Appointment GetById(int id)
        {
           return _appointmentDal.GetById(id);
        }



        public void insert(Appointment t)
        {
            _appointmentDal.insert(t);
        }

        public void Remove(Appointment t)
        {
            _appointmentDal.delete(t);
        }

        public void Update(Appointment t)
        {
            _appointmentDal.Update(t);
        }

        
    }
}
