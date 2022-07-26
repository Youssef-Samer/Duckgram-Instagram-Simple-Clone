using IAExternalDb.Context;
using IAExternalDb.Models;
using IAExternalDb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAExternalDb.Controllers
{
    public class myHomeController : Controller
    {
        DataContext db = new DataContext();
        [HttpGet]
        public ActionResult timeLine()
        {
            User Current = Session["CurrentUser"] as User;
            Current = db.UserTable.SingleOrDefault(x => x.user_id == Current.user_id);
            Session["CurrentUser"] = Current;
            ViewBag.CurrentUserID = Current.user_id;
            List<User> following = Current.FollowingList.ToList();
            List<Post> toShow = new List<Post>();
            foreach(var followed in following)
            {
                foreach(var post in followed.PostsList)
                {
                    toShow.Add(post);
                }
            }

            ReqPost reqpost = new ReqPost()
            {
                PostsList = toShow,
                user = Current
            };
            return View(reqpost);
        }

        [HttpPost]
        public ActionResult timeLine(ReqPost req)
        {
            return RedirectToAction("mrProfile", "Profile");
        }
    }
}