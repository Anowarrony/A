using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelReservationSystem.Models;
using OnlineHotelReservationSystem.Areas.Admin.Models;

namespace HotelReservationSystem.Controllers
{
    public class ImageGalleryController : Controller
    {
        readonly HotelDbContext _db = new HotelDbContext();
        public ActionResult Gallery()
        {
          
            return View( _db.ImagGallaries.ToList());
        }

    }
}
