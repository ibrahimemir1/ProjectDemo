using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Customer_mail { get; set; }
        public string Customer_password { get; set; }
        public DateTime Appointment_Date { get; set; }


        // Şube ile ilişki
        public int Branch_Id { get; set; }
        public Branch Branch { get; set; }

        // İşlemler ile ilişki
        public List<Process> Processes { get; set; }

        // Randevular ile ilişki
        public List<Appointment> Appointments { get; set; }
    }

}