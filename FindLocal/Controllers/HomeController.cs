using FindLocal.Models;
using FindLocal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindLocal.Controllers
{
    public class HomeController : Controller
    {
        CommentService cs = new CommentService();
        BusinessService bs = new BusinessService();
        MediaService ms = new MediaService();

        public ActionResult Index()
        {
            //List<Comment> c = cs.getCommentsByBusinessId(1);
            Business bus = bs.getRandomNBusinesses(1).SingleOrDefault();
            bus.media = ms.getMediaByBusinessId((int) bus.id).FirstOrDefault();
            return View(bus);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult _Comments() {
            var list = cs.getLatestNComments(3);            
            return PartialView(list);
        }

        public PartialViewResult _FeaturedBusinesses() {
            var list = bs.getRandomNBusinesses(2);
            MediaService ms = new MediaService();
            foreach (var business in list) {
                business.media = ms.getMediaByBusinessId((int)business.id).FirstOrDefault();
            }
            return PartialView(list);
        }
    }
}