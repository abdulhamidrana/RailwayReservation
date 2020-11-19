using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationProjectMvc.ViewModels
{
    public class RegisterViewModels
    {
        [Required(ErrorMessage ="Username can't be blank"), Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password can't be blank")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password can't be blank"), Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage ="Password and confirm password can't match")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage ="Email can't be blank"), Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }


        public string Mobile { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}