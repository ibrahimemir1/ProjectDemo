using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int Admin_Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Admin_mail { get; set; }
        public string Admin_password { get; set; }


    }
}
