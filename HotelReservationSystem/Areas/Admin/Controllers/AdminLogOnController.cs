
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using HotelReservationSystem.Models;
using OnlineHotelReservationSystem.Areas.Admin.Models;

namespace HotelReservationSystem.Areas.Admin.Controllers
{
    public class AdminLogOnController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogOn(Models.Admin admin)
        {
            if (ModelState.IsValid)
            {
                using (var db = new HotelDbContext())
                {
                    var u =
                        db.Admins.FirstOrDefault(
                            adminCheck => adminCheck.Email == admin.Email && adminCheck.Password == admin.Password);

                    if (u != null)
                    {
                        FormsAuthentication.SetAuthCookie(admin.Email, false);
                        return RedirectToAction("ReservationInfoList", "ReservationDeatils", new { area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Email and Password Combination!!");
                    }
                }
            }

            return View();
        }

        public ActionResult LogOff()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
