//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using HotelReservationSystem.Areas.Admin.Models;


//namespace HotelReservationSystem.Areas.Admin.Controllers
//{
//    public class ImageUploadController : Controller
//    {

//        ImageGalleryDbContext db=new ImageGalleryDbContext();

//        public ActionResult Upload(int? page)
//        {
//            ViewData["users"] = db.ImagGallaries.ToList().ToPagedList(page ?? 1, 3);
//            return View(db.ImagGallaries.ToList().ToPagedList(page ?? 1, 3));
//        }
//        [HttpPost]
//        public ActionResult Upload(ImagGallary imageGallary, int? page)
//        {
//            if (imageGallary.file == null)
//            {
//                Response.Write("<div id='uploadImageError'>");
//                Response.Write("You have to select a photo of type jpg");
//                Response.Write("</div>");
//            }
//            if (imageGallary.Description == null)
//            {
//                Response.Write("<div id='uploadImageErro'>");
//                Response.Write("You must provide a very short description about the Image");
//                Response.Write("</div>");
//            }
//            if (imageGallary.file != null && imageGallary.Description != null)
//            {
//                try
//                {
//                        byte[] data = new byte[imageGallary.file.ContentLength];
//                        imageGallary.file.InputStream.Read(data, 0, imageGallary.file.ContentLength);
//                        imageGallary.Image = data;

//                        db.ImagGallaries.Add(imageGallary);
//                        db.SaveChanges();
//                        imageGallary.file = null;

//                        ViewData["users"] = db.ImagGallaries.ToList().ToPagedList(page ?? 1, 5);


//                        return View(db.ImagGallaries.ToList().ToPagedList(page ?? 1, 3));
                    
//                }
//                catch (Exception)
//                {
//                    Response.Write("<div id='uploadImageError'>");
//                    Response.Write("Sorry,You are allowed to Upload only JPG type Picture .If Your picture is jpg typed then make sure that it is less than 2MB in size");
//                    Response.Write("</div>");
//                }
//            }


//            ViewData["users"] = db.ImagGallaries.ToList().ToPagedList(page ?? 1, 3);
//            return View(db.ImagGallaries.ToList().ToPagedList(page ?? 1, 3));
//        }

//        public ActionResult Delete(int id)
//        {

//            ImagGallary imagId = db.ImagGallaries.Where(m => m.ID == id).FirstOrDefault();

//            if (imagId != null)
//            {

//                try
//                {

//                    db.ImagGallaries.Remove(imagId);

//                    db.SaveChanges();

//                }

//                catch
//                {
//                }

//            }

//            return RedirectToAction("Upload", "ImageUpload");
//        }


//    }
//}
