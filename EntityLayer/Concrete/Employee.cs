using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Employee_mail { get; set; }
        public string Employee_password { get; set; }

        // Şube ile ilişki
        public int Branch_Id { get; set; }
        public Branch Branch { get; set; }

        // İşlemler ile ilişki
        public List<Process> Processes { get; set; }

        // Randevular ile ilişki
        public List<Appointment> Appointments { get; set; }
    }
}
