using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Entityframework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        CustomerManager cm = new CustomerManager(new EfCustomerRepository());
        [HttpGet]  //     sayfa yüklenince çalışır
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost] //    sayfa da buton tetiklenince çalışır
        public IActionResult Index(Customer p)
        {
            CustomerValidator cv = new CustomerValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {

                p.Appointment_Date = DateTime.Now;
                p.Branch_Id = 2; // bu düzeltilecek
                cm.insert(p);
                return RedirectToAction("Index","Customer"); // kayıt ola bastığında customera çekiyor
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}

