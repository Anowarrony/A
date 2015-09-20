using System;
using System.Linq;
using System.Web.Mvc;
using HotelReservationSystem.Models;



namespace HotelReservationSystem.Areas.Admin.Controllers
{
    public class ReservationDeatilsController : Controller
    {
        readonly HotelDbContext _db = new HotelDbContext();
      
        public ActionResult ReservationInfoList(int? page)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            if (!Request.IsAuthenticated)
                return View(_db.Reservations.OrderBy(name => name.Fullname).ToList());
            var findAuthUserFromAdminTable = _db.Admins.SingleOrDefault(m => m.Email.Equals(User.Identity.Name));
            if (findAuthUserFromAdminTable == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View(_db.Reservations.OrderBy(name => name.Fullname).ToList());

        }

       

        [HttpPost]
        public ActionResult ReservationInfoList(int? page, string searchName)
        {
            if (searchName.Length >= 2)
            {

                TempData["Searchname"] = "for Name" + " => " + searchName;
                return PartialView("_SearchCustomers", _db.Reservations.Where(x => x.Fullname.StartsWith(searchName) || searchName == null).OrderBy(name => name.Fullname).ToList());

            }

            if (searchName.Length < 2)
            {
                TempData["Searchname"] = "Please Enter minimum 2 Characters to make a Successful Search";
            }

            return PartialView("_SearchCustomers", _db.Reservations.Where(x => x.Fullname.StartsWith(searchName) || searchName == null).OrderBy(name => name.Fullname).ToList());


        }

        public ActionResult EditList(int id = 0)
        {
            Reservation singleListInfo = _db.Reservations.Find(id);
            if (singleListInfo == null)
            {
                return HttpNotFound();
            }
            return PartialView("_EditList", singleListInfo);


        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditList(int id, String cmd)
        {
            var reserinfo = new Reservation();
            reserinfo = _db.Reservations.Single(x => x.Id.Equals(id));
            UpdateModel(reserinfo, new string[] { "Standard", "Suit", "Deluxi", "Delux" });
            if (ModelState.IsValid)
            {

                if (cmd == "Save")
                {

                    try
                    {

                        _db.Reservations.Add(reserinfo);

                        _db.SaveChanges();

                        return RedirectToAction("ReservationInfoList");

                    }

                    catch { }

                }

                else
                {

                    try
                    {

                        var singleInfo = _db.Reservations.Where(m => m.Id == reserinfo.Id).FirstOrDefault();

                        if (singleInfo != null)
                        {
                            singleInfo.Standard = reserinfo.Standard;
                            singleInfo.Suit = reserinfo.Suit;
                            singleInfo.Deluxi = reserinfo.Deluxi;
                            singleInfo.Delux = reserinfo.Delux;
                            _db.SaveChanges();

                        }

                        return RedirectToAction("ReservationInfoList");

                    }

                    catch { }

                }

            }



            if (Request.IsAjaxRequest())
            {

                return PartialView("_EditList", reserinfo);

            }

            else
            {

                return View("EditList", reserinfo);

            }
        }


        public ActionResult Details(int id)
        {

            Reservation singledetails = _db.Reservations.Where(m => m.Id == id).FirstOrDefault();

            if (singledetails != null)
            {

                if (Request.IsAjaxRequest())
                {

                    return PartialView("_Details", singledetails);

                }

                else
                {

                    return View("Details", singledetails);

                }

            }

            return View("ReservationInfoList");

        }

        //public JsonResult GetCustomers(string term)
        //{
           


        //    return Json(customers, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Delete(int id)
        {

            Reservation customerId = _db.Reservations.Where(m => m.Id == id).FirstOrDefault();

            if (customerId != null)
            {

                try
                {

                    _db.Reservations.Remove(customerId);

                    _db.SaveChanges();

                }

                catch { }

            }

            return RedirectToAction("ReservationInfoList");

        }

        public ActionResult V()
        {
            return View();
        }

    }
}
