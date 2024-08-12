using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entityframework
{
    public class EfEmployeeRepository : GenericRepository<Employee>, IEmployeeDal
    {
        public List<Employee> GetEmployeeCountWithBranch(int id)
        {
            using (var c = new Context())
            {
                return c.Employees.Include(x => x.Branch).Where(x => x.Branch_Id == id).ToList();
            }
        }

        public List<Employee> GetEmployeeInfo()
        {
            using (var c = new Context())
            {
                return c.Employees.Include(x => x.Branch).ToList();
            }
        }
    }
}
