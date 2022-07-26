using IAExternalDb.Context;
using IAExternalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAExternalDb.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }
        /* [HttpGet]
         public int Like(int indexofimage)
         {
             User user = db.UserTable.ToList().SingleOrDefault(x => x.user_id == Int32.Parse(Session["CurrentUser"].ToString()));
             Like newLike = new Like()
             {
                 Post_ID = user.PostsList.ToList()[indexofimage].id,
                 like_owner_id = user.user_id
             };
             db.LikeTable.Add(newLike);
             db.SaveChanges();
             return user.PostsList.ToList()[indexofimage].LikesList.Count;
         }*/
        [HttpGet]
        public int Like (int postID)
        {
            Like newLike = new Like()
            {
                Post_ID = postID,
                like_owner_id = Int32.Parse(Session["CurrentUser"].ToString())
            };
            db.LikeTable.Add(newLike);
            db.SaveChanges();
            return db.PostTable.ToList().SingleOrDefault(x => x.id == postID).LikesList.Count;
        }

        public ActionResult showPost(int id)
        {
            return View(db.PostTable.SingleOrDefault(item => item.id == id));
        }

    }
}