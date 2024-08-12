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
    public class BranchManager : IBranchService
    {
        IBranchDal _branchDal;
        public BranchManager(IBranchDal branchDal)
        {
                _branchDal = branchDal;
        }

        //public List<Branch> EmployeeListWithBranch()
        //{
        //    return _branchDal.GetEmployeeListWithBranch();
        //}

        public List<Branch> GetAll()
        {
            return _branchDal.GetAll();
        }

        public Branch GetById(int id)
        {
            return _branchDal.GetById(id);
        }

        //public List<Branch> GetEmployeeCountWithBranch(int id)
        //{
        //    return _branchDal.GetEmployeeCountWithBranch(id);
        //}

        public void insert(Branch t)
        {
           _branchDal.insert(t);
        }

        public void Remove(Branch t)
        {
            _branchDal.delete(t);

        }

        public void Update(Branch t)
        {
            _branchDal.Update(t);
        }
    }
}
