using System;

using System.Linq;

using System.Web.Mvc;
using HotelReservationSystem.Models;
using OnlineHotelReservationSystem.Areas.Admin.Models;


namespace HotelReservationSystem.Areas.Admin.Controllers
{
    public class UploadImageController : Controller
    {
        readonly HotelDbContext _db = new HotelDbContext();

        public ActionResult Upload(int? page)
        {
     
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            if (Request.IsAuthenticated)
            {
                var findAuthUserFromAdminTable = _db.Admins.SingleOrDefault(m => m.Email.Equals(User.Identity.Name));
                if (findAuthUserFromAdminTable == null)
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            ViewData["users"] = _db.ImagGallaries.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Upload(ImageMetaData imageMetaData)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var imageGallary = new ImagGallary();
                    var data = new byte[imageMetaData.File.ContentLength];
                    imageMetaData.File.InputStream.Read(data, 0, imageMetaData.File.ContentLength);
                    imageGallary.Image = data;
                    imageGallary.Description = imageMetaData.Description;
                    _db.ImagGallaries.Add(imageGallary);
                    _db.SaveChanges();


                    ViewData["users"] = _db.ImagGallaries.ToList();


                    return View();

                }
                catch (Exception)
                {
                    Response.Write("<div id='uploadImageError'>");
                    Response.Write("* Sorry,You are allowed to Upload only JPG type Picture .If Your picture is jpg typed then make sure that it is less than 2MB in size");
                    Response.Write("</div>");
                }

            }



            ViewData["users"] = _db.ImagGallaries.ToList();
            return View();
        }

        public ActionResult Delete(int id)
        {

            ImagGallary imagId = _db.ImagGallaries.Where(m => m.ID == id).FirstOrDefault();

            if (imagId != null)
            {

                try
                {

                    _db.ImagGallaries.Remove(imagId);

                    _db.SaveChanges();

                }

                catch
                {
                }

            }

            return RedirectToAction("Upload", "UploadImage");
        }


    }
}
