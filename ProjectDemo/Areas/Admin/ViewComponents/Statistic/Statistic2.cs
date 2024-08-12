using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entityframework;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        AdminManager adm = new AdminManager(new EfAdminRepository());   
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var adminID = c.Admins.Where(x => x.Admin_mail == usermail).Select(y => y.Admin_Id).FirstOrDefault();
            if (adminID != null)
            {
                var values = adm.GetById(adminID);
                

            }
            ViewBag.adminname = c.Admins.Where(x => x.Admin_Id == adminID).Select(y => y.Name).FirstOrDefault();
            ViewBag.adminsurname = c.Admins.Where(x => x.Admin_Id == adminID).Select(y => y.Surname).FirstOrDefault();
            ViewBag.admindesc = c.Admins.Where(x => x.Admin_Id == adminID).Select(y => y.Description).FirstOrDefault();
            ViewBag.adminmail = c.Admins.Where(x => x.Admin_Id == adminID).Select(y => y.Admin_mail).FirstOrDefault();
            ViewBag.adminNO = c.Admins.Where(x => x.Admin_Id == adminID).Select(y => y.Admin_Id).FirstOrDefault();

            return View();
        }
    }
}
