using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReservationProjectMvc.Models;

namespace ReservationProjectMvc.Controllers
{
    public class BookingInfoesController : Controller
    {
        private ContextCS db = new ContextCS();
        public ActionResult Index()
        {
            ViewBag.dcity = db.tblTicketReserves.Select(l => l.ResFrom).Distinct().ToList();
            ViewBag.acity = db.tblTicketReserves.Select(l => l.ResTo).Distinct().ToList();
            return View();  
        }
        [HttpPost]
        public ActionResult Search(string cityfrom ,string cityto, string date1)
        {
            var c = db.tblTicketReserves.Where(l => l.ResFrom == cityfrom && l.ResTo == cityto && l.ResDate == date1);
            ViewBag.ss = c;
            return View();
        }

        public ActionResult Booking()
        {
            ViewBag.ResId = new SelectList(db.tblTicketReserves, "ResId", "ResFrom");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking([Bind(Include = "BId,bPassName,bPassAddress,bPassEmail,bPassSeats,bPassPhone,bPassNid,ResId")] BookingInfo bookingInfo)
        {
            if (ModelState.IsValid)
            {
                db.BookingInfos.Add(bookingInfo);
                db.SaveChanges();
                return RedirectToAction("Index", "BookingInfoes");
            }

            ViewBag.ResId = new SelectList(db.tblTicketReserves, "ResId", "ResFrom", bookingInfo.ResId);
            return View(bookingInfo);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
