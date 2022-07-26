using IAExternalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IAExternalDb.Context;
using System.Web.Security;
using System.Diagnostics;

namespace IAExternalDb.Controllers
{
    public class UserController : Controller
    {
        DataContext db = new DataContext();
        // GET: User
        public ActionResult Index()
        {
            List<User> Users = db.UserTable.ToList();
            return View(Users);
        }

        [HttpGet]
        public ActionResult signUp()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult signup(User user)
        {
            if(ModelState.IsValid)
            {
                db.UserTable.Add(user);
                db.SaveChanges();
                return RedirectToAction("UserProfile", "Profile",new { id=user.user_id});
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(User user)
        {
            User CheckResult = CheckUser(user);
            if (CheckResult != null) // success
            {
                Session["CurrentUser"] = CheckResult;
                return RedirectToAction("myProfile", "Profile");
            }
            else
            {
                TempData["ResultMessage"] = "Error in Email or password";
                return RedirectToAction("login");
            }
        }

        public ActionResult Test()
        {
            return View(db.UserTable.ToList()[0].FollowersList);
        }

        public ActionResult Test2()
        {
            return View();
        }

        public User CheckUser(User user)
        {
            foreach(var entry in db.UserTable.ToList())
            {
                if (entry.Email == user.Email)
                {
                    if (entry.Password == user.Password)
                    {
                        return entry;
                    }
                }
            }
            return null;
        }
    }
}