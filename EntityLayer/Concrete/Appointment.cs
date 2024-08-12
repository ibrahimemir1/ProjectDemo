using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Appointment
    {
        [Key]
        public int Appointment_Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        // Müşteri ile ilişki
        public int Customer_Id { get; set; }
        public Customer Customer { get; set; }

        // Çalışan ile ilişki
        public int Employee_Id { get; set; }
        public Employee Employee { get; set; }


        // branch ilişkilendirmesini yap
    }
}
