using Microsoft.AspNet.Identity.EntityFramework;
using ReservationProjectMvc.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReservationProjectMvc.Models
{
    public class ContextCS:IdentityDbContext<ApplicationUser>
    {
        public ContextCS():base("name=cs")
        {

        }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<TrainInfo> TrainInfos { get; set; }        
        public DbSet<BookingInfo> BookingInfos { get; set; }
        //public DbSet<TblTicketReserve> tblTicketReserves { get; set; }
        public System.Data.Entity.DbSet<ReservationProjectMvc.Models.TblTicketReserve> tblTicketReserves { get; set; }
    }
}