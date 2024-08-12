using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Branch
    {
        [Key]
        public int Branch_Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        // Çalışanlar ile ilişki
        public List<Employee> Employees { get; set; }

        // Müşteriler ile ilişki
        public List<Customer> Customers { get; set; }
    }
}

  
