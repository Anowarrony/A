using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservationSystem.Models
{
    public class UserMetaData
    {
        [Remote("CheckIsUserExist", "LoginSignUp", ErrorMessage = "Username Already Exist")]
        [Required(ErrorMessage = "Username is Required!")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Length must be between 4 and 10")]
        [DisplayName("Username ")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        public string Username { get; set; }

        [Remote("CheckIsEmailExist", "LoginSignUp", ErrorMessage = "Email Already Exist")]
        [Required(ErrorMessage = "Email is Required!")]
        [DisplayName("Email ")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter a valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required!")]
        [DisplayName("Password ")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 20")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }

    [MetadataType(typeof(UserMetaData))]
    public partial class Customer
    {
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password don't match")]
        public string ConfirmPassword { get; set; }

    }
}