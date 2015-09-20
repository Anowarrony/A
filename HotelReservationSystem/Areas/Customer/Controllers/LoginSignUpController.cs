using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HotelReservationSystem.Areas.Customer.Models;
using HotelReservationSystem.Models;


namespace HotelReservationSystem.Areas.Customer.Controllers
{
    public class LoginSignUpController : Controller
    {
        readonly HotelDbContext _db = new HotelDbContext();

        public ActionResult LogOn()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(UserLogOn user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new HotelDbContext())
                    {
                        var v =
                            db.Customers.FirstOrDefault(
                                userCheck =>
                                    userCheck.Username.Equals(user.Username) && userCheck.Password.Equals(user.Password));
                        if (v != null)
                        {
                            FormsAuthentication.SetAuthCookie(user.Username, false);


                            return RedirectToAction("Reserve", "CustomerReservation", new { area = "Customer" });
                        }
                        else
                        {
                            Response.Write("<div id='logmess'>");

                            Response.Write("Sorry,Invalid Username and Password Combination!!.Your Username or Password or Both incorrect.If you have no account Signup first");

                            Response.Write("</div>");
                        }

                    }
                }
                catch (Exception exmException)
                {

                    Response.Write("<div id='logmess'>");

                    Response.Write(exmException.Message);

                    Response.Write("</div>");
                }
            }

            return View();
        }




        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult SignUp()
        {
            if (Request.IsAjaxRequest())
            {
                return View("_SignUp");
            }

            else
            {

                return View("SignUp");
            }

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SignUp(HotelReservationSystem.Models.Customer customer, string pass)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var v = _db.Customers.FirstOrDefault(username => username.Username == customer.Username);

                    var u = _db.Customers.FirstOrDefault(userEmail => userEmail.Email == customer.Email);

                    if (v != null)
                    {
                        ModelState.AddModelError("", "UserName Already Exist");
                    }
                    if (u != null)
                    {
                        ModelState.AddModelError("", "EmailId Already Exist");

                    }
                    if (u == null && v == null)
                    {
                       
                        _db.Customers.Add(customer);
                        _db.SaveChanges();

                        return RedirectToAction("LogOn", "LoginSignUp", new { area = "Customer" });

                    }






                }
                catch (Exception)
                {

                    throw new Exception();
                }
            }
            return View();

        }
        [HttpPost]
        public ActionResult CancelSignUp()
        {
            return RedirectToAction("LogOn", "LoginSignUp");
        }

        public JsonResult CheckIsEmailExist(string email)
        {

            return Json(!_db.Customers.Any(x => x.Email.Equals(email)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckIsUserExist(string username)
        {

            return Json(!_db.Customers.Any(x => x.Username.Equals(username)), JsonRequestBehavior.AllowGet);
        }
    }
}
