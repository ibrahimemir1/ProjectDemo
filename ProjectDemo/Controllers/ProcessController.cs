using BusinessLayer.Concrete;
using DataAccessLayer.Entityframework;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDemo.Controllers
{
    public class ProcessController : Controller
    {
        ProcessManager pm = new ProcessManager(new EfProcessRepository());
        public IActionResult Index()
        {
            var values = pm.GetAll();
            return View(values);
        }
    }
}
