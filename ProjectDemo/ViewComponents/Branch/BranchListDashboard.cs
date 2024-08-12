using BusinessLayer.Concrete;
using DataAccessLayer.Entityframework;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDemo.ViewComponents.Branch
{
    public class BranchListDashboard : ViewComponent
    {
        BranchManager bm = new BranchManager(new EfBranchRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetAll();
            return View(values);
        }
    }
}
