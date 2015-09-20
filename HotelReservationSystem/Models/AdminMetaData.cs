using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservationSystem.Models
{
    public class AdminMetaData
    {
        [Required(ErrorMessage = "Email is Required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required!")]
        public string Password { get; set; }
    }
    [MetadataType(typeof(AdminMetaData))]
    public partial class Admin
    {

    }
}