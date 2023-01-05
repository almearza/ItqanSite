using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Itqan.Models;

namespace Itqan.Controllers
{
    [Authorize]
    public class Lang1Controller : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        [HttpPost]
        [AllowAnonymous]
      public ActionResult convertLang(string newLangId)
        {
            //Check  cookie

            var userLang =Request.Cookies["userLang"];
            if (userLang !=null)
            {
                if(userLang["lang"] != newLangId)
                {
                    userLang.Expires = DateTime.Now.AddDays(-2);
                    createCookie(newLangId);
                }
            }
            else
            {
                createCookie(newLangId);
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(newLangId);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(newLangId);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(newLangId);

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
        private void createCookie(string newLangId)
        {
            HttpCookie newUserCookie = new HttpCookie("userLang");
            newUserCookie["lang"] = newLangId;
            newUserCookie["langId"] =db.Lang1.FirstOrDefault(a=>a.Code== newLangId).ID_lang.ToString();
            Response.Cookies.Add(newUserCookie);
            Response.Cookies.Add(new HttpCookie("culture",newLangId));
        }
        
        // GET: Lang1
        public ActionResult Index()
        {
            return View(db.Lang1.ToList());
        }

        // GET: Lang1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lang1 lang1 = db.Lang1.Find(id);
            if (lang1 == null)
            {
                return HttpNotFound();
            }
            return View(lang1);
        }

        // GET: Lang1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lang1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_lang,Name_lang,Code")] Lang1 lang1)
        {
            if (ModelState.IsValid)
            {

                db.Lang1.Add(lang1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lang1);
        }

        // GET: Lang1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lang1 lang1 = db.Lang1.Find(id);
            if (lang1 == null)
            {
                return HttpNotFound();
            }
            return View(lang1);
        }

        // POST: Lang1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_lang,Name_lang,Code")] Lang1 lang1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lang1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lang1);
        }

        // GET: Lang1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lang1 lang1 = db.Lang1.Find(id);
            if (lang1 == null)
            {
                return HttpNotFound();
            }
            return View(lang1);
        }

        // POST: Lang1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lang1 lang1 = db.Lang1.Find(id);
            db.Lang1.Remove(lang1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
