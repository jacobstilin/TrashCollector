using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trash.Models;

namespace Trash.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: User
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;
                
                ViewBag.displayMenu = "No";


                if (isEmployeeUser())
                {

                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }

            return View();
        }

        public bool isEmployeeUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Employee")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


    }
}