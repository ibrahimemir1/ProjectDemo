using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Process
    {
        [Key]
        public int Process_Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        // Müşteri ile ilişki
        public int Customer_Id { get; set; }
        public Customer Customer { get; set; }

        // Çalışan ile ilişki
        public int Employee_Id { get; set; }
        public Employee Employee { get; set; }
    }
}  