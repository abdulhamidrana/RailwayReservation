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
    public class TrainController : Controller
    {
        private ContextCS db = new ContextCS();


        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated == true)
            {
                return View(db.TrainInfos.ToList());
            }
            else
            {
                return RedirectToAction("AccLogin", "Account");
            }
            
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TrainInfo trainInfo = db.TrainInfos.Find(id);
                if (trainInfo == null)
                {
                    return HttpNotFound();
                }
                return View(trainInfo);
            }
            else
            {
                return RedirectToAction("AccLogin", "Account");
            }
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AccLogin", "Account");
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainId,TrainName,SeatingCapacity,Price")] TrainInfo trainInfo)
        {
            if (ModelState.IsValid)
            {
                db.TrainInfos.Add(trainInfo);
                db.SaveChanges();

                ViewBag.m = "Record Saved";
                return View();
            }

            return View(trainInfo);
        }


        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TrainInfo trainInfo = db.TrainInfos.Find(id);
                if (trainInfo == null)
                {
                    return HttpNotFound();
                }
                return View(trainInfo);
            }
            else
            {
                return RedirectToAction("AccLogin", "Account");
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainId,TrainName,SeatingCapacity,Price")] TrainInfo trainInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainInfo);
        }


        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TrainInfo trainInfo = db.TrainInfos.Find(id);
                if (trainInfo == null)
                {
                    return HttpNotFound();
                }
                return View(trainInfo);
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
            TrainInfo trainInfo = db.TrainInfos.Find(id);
            db.TrainInfos.Remove(trainInfo);
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
