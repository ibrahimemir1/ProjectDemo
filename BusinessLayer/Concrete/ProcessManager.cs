using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Entityframework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
     public class ProcessManager : IProcessService

    {
        IProcessDal _processDal;

        public ProcessManager(IProcessDal processDal)
        {
            _processDal = processDal;
        }
       public List<Process> GetAll()
       {
          return _processDal.GetAll();
        }

       public Process GetById(int id)
       {
         return _processDal.GetById(id);
        }

        public void insert(Process t)
        {
            _processDal.insert(t);
        }

        public void Remove(Process t)
        {
            _processDal.delete(t);
        }

        public void Update(Process t)
        {
            _processDal.Update(t);
        }
    }
}
