using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReservationProjectMvc.Models
{
    [Table("TblBookInfo")]
    public class BookingInfo
    {
        [Key]
        public int BId { get; set; }

        [Required, Display(Name = "Passenger Name : ")]
        public string bPassName { get; set; }

        [Required, Display(Name = "Passenger's Address : ")]
        public string bPassAddress { get; set; }

        [Required, Display(Name = "Passenger's Email : ")]
        public string bPassEmail { get; set; }


        [Required, Display(Name = "No Of Seats : ")]
        public int bPassSeats { get; set; }

        [Required, Display(Name = "Phone No : ")]
        public string bPassPhone { get; set; }

        [Required, Display(Name = "NID : ")]
        public string bPassNid { get; set; }


        public int ResId { get; set; }
        public virtual TblTicketReserve TblTicketReserve { get; set; }
    }
}