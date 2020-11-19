using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReservationProjectMvc.Models
{
    public class TrainInfo
    {
        [Key]
        public int TrainId { get; set; }


        [Required(ErrorMessage = "Train Name Required")]
        [Display(Name = "Train Name")]
        [MinLength(3, ErrorMessage = "Minimum 3 Characters Required"), MaxLength(30, ErrorMessage = "Maximum 30 Characters are Allowed")]
        public string TrainName { get; set; }


        [Required(ErrorMessage = "Capacity Required")]
        [Display(Name = "Seating Capacity")]
        public int SeatingCapacity { get; set; }


        [Required(ErrorMessage = "Price Required")]
        public float Price { get; set; }

        public virtual ICollection<TblTicketReserve> TblTicketReserves { get; set; }


    }
}