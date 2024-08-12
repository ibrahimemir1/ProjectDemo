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
    public class AdminManager : IAdminService
    {
        IAdminDal _admindal;
        public AdminManager(IAdminDal admindal)
        {
            _admindal = admindal;
        }
         public List<Admin> GetAll()
         {
               return _admindal.GetAll();
         }
        public Admin GetById(int id)
        {
           return _admindal.GetById(id);
        }

        public void insert(Admin t)
        {
            _admindal.insert(t);

        }

        public void Remove(Admin t)
        {
            _admindal.delete(t);
        }

        public void Update(Admin t)
        {
            _admindal.Update(t);
        }
    }
}
