using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using HotelReservationSystem.Models;


namespace HotelReservationSystem.Areas.Customer.Controllers
{
    public class CustomerReservationController : Controller
    {
        readonly HotelDbContext _db = new HotelDbContext();

   

        public ActionResult Reserve()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("LogOn", "LoginSignUp", new {area = "Customer"});
            }

            return View();
        }

       

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Reserve(Reservation reservation)
        {
            ViewBag.postMethodId = 1;
            var regForPhone = new Regex(@"[01]\d{9}");
            if (ModelState.IsValid)
            {
                try
                {
                    var checkIsReservationAlreadyExist = _db.Reservations.Any(c => c.Email.Equals(reservation.Email));
                    if (!checkIsReservationAlreadyExist)
                    {
                        var findCustomerRegistrationEmail =

                    _db.Customers.Single(m => m.Username.Equals(User.Identity.Name)).Email;

                        if (findCustomerRegistrationEmail == reservation.Email)
                        {


                            if (reservation.Country == "Bangladesh")
                            {
                                int banPhoneNum = Convert.ToInt32(reservation.Phonenumber);
                                if (regForPhone.IsMatch(banPhoneNum.ToString()))
                                {
                                    if (reservation.Standard != null || reservation.Suit != null || reservation.Deluxi != null ||
                                        reservation.Delux != null)
                                    {

                                        _db.Reservations.Add(reservation);
                                        _db.SaveChanges();
                                        return RedirectToAction("SuccessfulMessage", "CustomerReservation",
                                            new { area = "Customer" });
                                    }
                                    if (reservation.Standard == null || reservation.Suit == null || reservation.Deluxi == null ||
                                        reservation.Delux == null)
                                    {

                                        ViewBag.RoomReqMessId = 1;

                                    }
                                }
                                else
                                {
                                    ViewBag.MobNoInvalidId = 1;
                                }
                            }

                            else
                            {
                                if (reservation.Standard != null || reservation.Suit != null || reservation.Deluxi != null ||
                                    reservation.Delux != null)
                                {

                                    _db.Reservations.Add(reservation);
                                    _db.SaveChanges();
                                    return RedirectToAction("SuccessfulMessage", "CustomerReservation", new { area = "Customer" });
                                }
                                if (reservation.Standard == null || reservation.Suit == null || reservation.Deluxi == null ||
                                    reservation.Delux == null)
                                {
                                    ViewBag.RoomReqMessId = 1;

                                }
                            }

                        }
                        else
                        {
                            ModelState.AddModelError("", "Please enter the Email which you used at the time of Registration.");
                        
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "A record already exist for Email ID => "+reservation.Email);
                        
                    }


                


            }

                catch (Exception msg)
                {


                    Response.Write("<div id='resRoomReq'>");

                    Response.Write(msg.Message);
                    Response.Write("</div>");

                }
                ViewBag.notificationHideId = 1;
            }

            return View(reservation);
        }

        public ActionResult SuccessfulMessage()
        {
            return View();
        }
        public ActionResult RoomDeatils()
        {
            return View();
        }


        public JsonResult CheckIsEmailExist(string email)
        {

            return Json(!_db.Reservations.Any(x => x.Email.Equals(email)), JsonRequestBehavior.AllowGet);
        }
    }
}
