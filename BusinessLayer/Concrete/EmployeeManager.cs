using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public List<Employee> EmployeeInfo()
        {
          return _employeeDal.GetEmployeeInfo();
        }

        public List<Employee> GetAll()
        {
          return _employeeDal.GetAll();
        }

        public Employee GetById(int id)
        {
            return _employeeDal.GetById(id);
        }

        

        public void insert(Employee t)
        {
            _employeeDal.insert(t);
        }

        public void Remove(Employee t)
        {
            _employeeDal.delete(t);
        }

        public void Update(Employee t)
        {
            _employeeDal.Update(t);
        }
    }
}
