using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReservationProjectMvc.Models
{
    [Table("TblAdminLogic")]
    public class AdminLogin
    {
        [Key]
        public int AdminId { get; set; }


        [Required(ErrorMessage = "User Name Required")]
        [Display(Name = "User Name")]
        [MinLength(3, ErrorMessage = "Minimum 3 Characters Required"), MaxLength(10, ErrorMessage = "Maximum 10 Characters are Allowed")]
        public string AdminName { get; set; }


        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Minimum 3 Characters Required"), MaxLength(10, ErrorMessage = "Maximum 10 Characters are Allowed")]
        public string Password { get; set; }
    }
}