using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Entityframework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{    
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager (ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<Customer> CustomerInfo()
        {
           return _customerDal.GetCustomerInfo();
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }
       
        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
        }
        public void insert(Customer t)
        {
           _customerDal.insert(t);
        }
        public void Remove(Customer t)
        {
            _customerDal.delete(t);
        }
        public void Update(Customer t)
        {
            _customerDal.Update(t);
        }
    }
}
