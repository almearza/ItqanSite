using Itqan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading;
using System.Globalization;

namespace Itqan.Controllers
{
    public class HomeController : MyController
    {
        private ItqanEntities db = new ItqanEntities();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult blank()
        {
            return View();
        }



        public ActionResult Quran()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }


        

        public ActionResult _Qurain()
        {

            return View();
        }

        public ActionResult _course()
        {
            return View();
        }

        

        public ActionResult _Links()
        {
            return View(db.Links.ToList());

        }
      
        
    }
}