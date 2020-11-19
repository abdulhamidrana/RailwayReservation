using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservationProjectMvc.Models;

namespace ReservationProjectMvc.Controllers
{
    public class AdminController : Controller
    {
        ContextCS c = new ContextCS();
        
        public ActionResult LoginTemplate()
        {
            ViewBag.msg = "";
            return View();
        }        

        public ActionResult Dashboard()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("AccLogin", "Account");
            }
        }
    }
}