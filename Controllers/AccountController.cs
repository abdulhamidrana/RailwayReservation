using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ReservationProjectMvc.Identity;
using ReservationProjectMvc.ViewModels;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ReservationProjectMvc.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModels rvm)
        {
            if (ModelState.IsValid)
            {
                //register
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new ApplicationUser() { UserName = rvm.UserName, PasswordHash = passwordHash, Email = rvm.Email, PhoneNumber = rvm.Mobile, Birthday = rvm.DateOfBirth, Address = rvm.Address, City = rvm.City, Country = rvm.Country };

                IdentityResult result = userManager.Create(user);

                if (result.Succeeded)
                {
                    //role
                    userManager.AddToRole(user.Id, "Passenger");

                    //login
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "BookingInfoes");
            }
            else
            {
                ModelState.AddModelError("MyError", "Invalid Data");
                return View();
            }
            
        }
        public ActionResult AccLogin()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AccLogin(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                //login 
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var user = userManager.Find(lvm.UserName, lvm.Password);

                if (user != null)
                {
                    //login
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

                    if (userManager.IsInRole(user.Id, "Admin"))
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "BookingInfoes");
                    }

                }
                else
                {
                    ModelState.AddModelError("myErr", "Invalid username or password");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("myErr", "Invalid username or password");
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("AccLogin", "Account");
            }
            return RedirectToAction("Index", "BookingInfoes");
        }
    }
}