using BusinessLayer.Concrete;
using DataAccessLayer.Entityframework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.NetworkInformation;
using X.PagedList.Extensions;

namespace ProjectDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {

        EmployeeManager em = new EmployeeManager(new EfEmployeeRepository());
        BranchManager bm = new BranchManager(new EfBranchRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EmployeeInfo()
        {
            var values = em.EmployeeInfo();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {

            List<SelectListItem> branchvalues = (from x in bm.GetAll()           //Hangi banka şubesine çalışan EKLİYORUZ ? 
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Branch_Id.ToString()
                                                 }).ToList();

            ViewBag.branch = branchvalues;

            return View();

        }
        [HttpPost]
        public IActionResult AddEmployee(Employee p)
        {

            em.insert(p);
            var url = Url.Action("EmployeeInfo", "Employee", new {area="Admin"});
            return Redirect(url);
        }

        public IActionResult EmployeeDelete(int id)
        {
            var value = em.GetById(id);
            em.Remove(value);
            return RedirectToAction("EmployeeInfo", "Employee", new { area = "Admin" });
        }

    }
}