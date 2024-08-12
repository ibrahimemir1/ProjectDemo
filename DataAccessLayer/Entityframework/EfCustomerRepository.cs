using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entityframework
{
    public class EfCustomerRepository : GenericRepository<Customer>, ICustomerDal
    {
        public List<Customer> GetCustomerInfo()
        {
            using (var c = new Context())
            {
                return c.Customers.Include(x => x.Branch).ToList();
            }
        }
    }


}
