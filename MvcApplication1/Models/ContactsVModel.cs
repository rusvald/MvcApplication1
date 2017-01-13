using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ContactsVModel
    {
        [Display(Name="Enter Your name:")]
        public string Name { get; set; }
        [Display(Name = "Enter Your E-mail:")]
        public string Email { get; set; }
        [Display(Name = "Enter message subject:")]
        public string Subject { get; set; }
        [Display(Name = "Enter message:")]
        public string Message { get; set; }
        public bool ErrorMsg { get; set; }
        public string ErrorText { get; set; }
    }
}