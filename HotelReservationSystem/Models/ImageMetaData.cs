using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservationSystem.Models
{
    public class ImageMetaData
    {

        [Required(ErrorMessage = "* Required!")]
        public string Description { get; set; }
        [ValidateFile]
        public HttpPostedFileBase File { get; set; }
    }


    public partial class ImagGallary
    {


    }
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int maxContentLength = 1024 * 1024 * 3; //3 MB
            string[] allowedFileExtensions = new string[] { ".jpg" };

            var file = value as HttpPostedFileBase;

            if (file == null)
            {
                ErrorMessage = "Please upload a Photo of type: " + string.Join(", ", allowedFileExtensions);

                return false;
            }

            if (!allowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", allowedFileExtensions);

                return false;
            }

            if (file.ContentLength > maxContentLength)
            {
                ErrorMessage = "Your Photo is too large, maximum allowed size is : " + (maxContentLength / 1024).ToString() + "MB";
                return false;
            }


            return true;
        }

    }
}