using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservationSystem.Areas.Customer.Models
{
    public class UserLogOn
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
    }
}