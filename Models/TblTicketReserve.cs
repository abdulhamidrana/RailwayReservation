using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReservationProjectMvc.Models
{
    public class TblTicketReserve
    {
        [Key]
        public int ResId { get; set; }


        [Required(ErrorMessage = "From City Required")]
        [Display(Name = "From City : ")]
        public string ResFrom { get; set; }


        [Required(ErrorMessage = "To City Required")]
        [Display(Name = "To City : ")]
        public string ResTo { get; set; }


        [Display(Name = "Departure Date : ")]
        //[DataType(DataType.Date)]
        public string ResDate { get; set; }


        [Display(Name = "Departure Time")]
        [StringLength(15)]
        public string DepTime { get; set; }

        //foreign key
        [Required, Display(Name = "Train No : ")]
        public int TrainId { get; set; }
        public virtual TrainInfo TrainInfo { get; set; }


        [Required, Display(Name = "Seats Available : ")]
        public int TrainSeat { get; set; }

        [Required, Display(Name = "Price : ")]
        public float ResTicketPrice { get; set; }


        [Required, Display(Name = "Train Type : ")]
        public string ResPlaneType { get; set; }

        public virtual ICollection<BookingInfo> BookingInfos { get; set; }
    }
}