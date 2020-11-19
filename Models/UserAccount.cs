using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReservationProjectMvc.Models
{
    [Table("TblUserAccount")]
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }


        [Required(ErrorMessage = "First Name Required")]
        [Display(Name = "First Name")]
        [MinLength(5, ErrorMessage = "Minimum 5 Characters Required"), MaxLength(40, ErrorMessage = "Maximum 40 Characters are Allowed")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name Required")]
        [Display(Name = "Last Name")]
        [MinLength(5, ErrorMessage = "Minimum 5 Characters Required"), MaxLength(40, ErrorMessage = "Maximum 40 Characters are Allowed")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email Address Required")]
        [Display(Name = "Email ID")]
        [MinLength(5, ErrorMessage = "Minimum 5 Characters Required"), MaxLength(30, ErrorMessage = "Maximum 30 Characters are Allowed")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "User Name Required")]
        [Display(Name = "User Name")]
        [MinLength(3), StringLength(20), RegularExpression(@"^([a-zA-Z0-9 \.\&\'\-]+)$", ErrorMessage = "Must be alpha numeric")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Minimum 4 Characters Required"), MaxLength(20, ErrorMessage = "Maximum 20 Characters are Allowed")]
        public string Password { get; set; }

        //[Display(Name ="Confirm Password")]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage ="Password not matched!")]
        //[MinLength(5, ErrorMessage = "Minimum 5 Characters Required"), MaxLength(20, ErrorMessage = "Maximum 20 Characters are Allowed")]
        //public string CPassword { get; set; }


        [Required(ErrorMessage = "Age Required")]
        [Range(18, 120, ErrorMessage = "Min 18 Years Aged Person are Allowed for Reservation")]
        public int Age { get; set; }


        [Display(Name = "Phone No")]
        [Required(ErrorMessage = "Phone Number Required"), RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Phone no is Not Valid")]
        [StringLength(11)]
        public string Phoneno { get; set; }


        [Display(Name = "NID No")]
        [Required(ErrorMessage = "NID Number Required"), RegularExpression(@"^([0-9]{13})$", ErrorMessage = "Invalid NID")]
        [StringLength(13)]
        public string NID { get; set; }
    }
}