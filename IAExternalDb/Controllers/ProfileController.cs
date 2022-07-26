using IAExternalDb.Context;
using IAExternalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAExternalDb.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserProfile(int id)
        {
            User user = db.UserTable.ToList().SingleOrDefault(x => x.user_id == id);
            return View(user);
        }
        [HttpGet]
        public ActionResult myProfile()
        {
            User CurrentLoggedin = Session["CurrentUser"] as IAExternalDb.Models.User;
            User user = db.UserTable.ToList().SingleOrDefault(x => x.user_id == CurrentLoggedin.user_id);
            return View(user);
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            User CurrentLoggedin = Session["CurrentUser"] as IAExternalDb.Models.User;
            User user = db.UserTable.ToList().SingleOrDefault(x => x.user_id == CurrentLoggedin.user_id);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditProfile(User user, HttpPostedFileBase file)
        {
            User CurrentLoggedin = Session["CurrentUser"] as IAExternalDb.Models.User;
            var St = db.UserTable.SingleOrDefault(x => x.user_id == CurrentLoggedin.user_id);
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Images/ProfilePictures/"), pic);

                file.SaveAs(path);

                St.ProfilePicture = pic;
            }
            St.Fname = user.Fname;
            St.Lname = user.Lname;
            St.Telephone = user.Telephone;
            St.Password = user.Password;

            db.Entry(St).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("myProfile");
        }
        [HttpGet]
        public ActionResult ShowFollowers(int id)
        {
            return View(db.UserTable.ToList().SingleOrDefault(x => x.user_id == id).FollowersList.ToList());
        }
        [HttpGet]
        public ActionResult ShowFollowing(int id)
        {
            return View(db.UserTable.ToList().SingleOrDefault(x => x.user_id == id).FollowingList.ToList());
        }
    }
}