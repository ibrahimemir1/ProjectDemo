using BusinessLayer.Concrete;
using DataAccessLayer.Entityframework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BranchController : Controller
    {
        BranchManager bm = new BranchManager(new EfBranchRepository());
        public IActionResult Index()
        {

            return View();

        }
        public IActionResult BranchList()
        {
            var values = bm.GetAll();

            return View(values);

        }
       
        [HttpPost]
        public IActionResult DeleteBranch(int id)
        {
            
            var values = bm.GetById(id);
            bm.Remove(values);
            return RedirectToAction("BranchList", "Branch", new { area = "Admin" });

        }
        [HttpGet]
        public IActionResult AddBranch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBranch(Branch p)
        {
            bm.insert(p);
            var url = Url.Action("BranchList", "Branch", new { area = "Admin" });
            return Redirect(url);
        }
    }
}
