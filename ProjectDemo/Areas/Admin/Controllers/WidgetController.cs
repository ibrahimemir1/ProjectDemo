using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entityframework;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

namespace ProjectDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WidgetController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminRepository());
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
