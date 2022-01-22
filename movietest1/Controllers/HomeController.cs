using movietest1.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace movietest1.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext db = new MovieContext();
        public ActionResult Index()
        {
            var posts = db.Movies.OrderByDescending(a => a.PostedOn);
            return View(posts.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //public ActionResult Products()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
        //public ActionResult Account()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
        //public ActionResult Single()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
       

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}