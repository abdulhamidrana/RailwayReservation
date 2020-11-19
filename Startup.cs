using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ReservationProjectMvc.Identity;

[assembly: OwinStartup(typeof(ReservationProjectMvc.Startup))]

namespace ReservationProjectMvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login") });
            this.CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var appDbContext = new ApplicationDbContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appUserStore);

            //create Admin role
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            //create Admin user
            if (userManager.FindByName("admin") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "amdin@gmail.com";
                string userPassword = "admin123";

                var chkUser = userManager.Create(user, userPassword);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            //create manager role
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            //create Manager user
            if (userManager.FindByName("manager") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "manager";
                user.Email = "manager@gmail.com";
                var userPaasword = "manager123";

                var chkUser = userManager.Create(user, userPaasword);

                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }

            //crerte Passenger Role
            if (!roleManager.RoleExists("Passenger"))
            {
                var role = new IdentityRole();
                role.Name = "Passenger";
                roleManager.Create(role);
            }
        }


    }
}
