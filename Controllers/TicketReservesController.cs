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
    public class TicketReservesController : Controller
    {
        private ContextCS db = new ContextCS();
        public ActionResult Index()
        {
           
            if (User.Identity.IsAuthenticated == true)
            {
                var tblTicketReserves = db.tblTicketReserves.Include(t => t.TrainInfo);
                return View(tblTicketReserves.ToList());
            }
            else
            {
                return RedirectToAction("AccLogin", "Account");
            }

        }

      
        public ActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                 if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TblTicketReserve tblTicketReserve = db.tblTicketReserves.Find(id);
                if (tblTicketReserve == null)
                {
                    return HttpNotFound();
                }
                return View(tblTicketReserve);
            }
            else
            {
                return RedirectToAction("AccLogin", "Account");
            }
            
        }

        public ActionResult Create()
        {
           
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.TrainId = new SelectList(db.TrainInfos, "TrainId", "TrainName");
                return View();
            }
            else
            {
                return RedirectToAction("AdmninLogin", "Admin");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResId,ResFrom,ResTo,ResDate,DepTime,TrainId,TrainSeat,ResTicketPrice,ResPlaneType")] TblTicketReserve tblTicketReserve)
        {
            if (ModelState.IsValid)
            {
                db.tblTicketReserves.Add(tblTicketReserve);
                db.SaveChanges();

                ViewBag.m = "Record saved";
   
                return RedirectToAction("Index");
            }

            ViewBag.TrainId = new SelectList(db.TrainInfos, "TrainId", "TrainName", tblTicketReserve.TrainId);
            return View(tblTicketReserve);
        }

  
        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TblTicketReserve tblTicketReserve = db.tblTicketReserves.Find(id);
                if (tblTicketReserve == null)
                {
                    return HttpNotFound();
                }
                ViewBag.TrainId = new SelectList(db.TrainInfos, "TrainId", "TrainName", tblTicketReserve.TrainId);
                return View(tblTicketReserve);
            }
            else
            {
                return RedirectToAction("AccLogin", "Account");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResId,ResFrom,ResTo,ResDate,DepTime,TrainId,TrainSeat,ResTicketPrice,ResPlaneType")] TblTicketReserve tblTicketReserve)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tblTicketReserve).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.TrainId = new SelectList(db.TrainInfos, "TrainId", "TrainName", tblTicketReserve.TrainId);
                return View(tblTicketReserve);
            }
            else
            {
                return RedirectToAction("AccLogin", "Account");
            }
            
        }

        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TblTicketReserve tblTicketReserve = db.tblTicketReserves.Find(id);
                if (tblTicketReserve == null)
                {
                    return HttpNotFound();
                }
                return View(tblTicketReserve);
            }
            else
            {
                return RedirectToAction("AccLogin", "Account");
            } 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblTicketReserve tblTicketReserve = db.tblTicketReserves.Find(id);
            db.tblTicketReserves.Remove(tblTicketReserve);
            db.SaveChanges();
            return RedirectToAction("Index");
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
