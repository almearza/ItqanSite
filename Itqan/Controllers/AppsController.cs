using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Itqan.Models;

namespace Itqan.Controllers
{
    [Authorize]

    public class AppsController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Apps
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var app = db.App.Include(a => a.Define_Itqan).Include(a => a.Lang1);
            return View(app.ToList());
        }
        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var app = db.App.Include(a => a.Lang1).Where(b => b.Lang == Lang);
            return View(app.ToList());


        }
        // GET: Apps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            App app = db.App.Find(id);
            if (app == null)
            {
                return HttpNotFound();
            }
            return View(app);
        }

        // GET: Apps/Create
        public ActionResult Create()
        {
            ViewBag.ID_Itqan = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Apps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_App,Name_App,Desc_App,ID_Itqan,Lang")] App app)
        {
            if (ModelState.IsValid)
            {
                db.App.Add(app);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Itqan = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", app.ID_Itqan);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", app.Lang);
            return View(app);
        }

        // GET: Apps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            App app = db.App.Find(id);
            if (app == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Itqan = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", app.ID_Itqan);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", app.Lang);
            return View(app);
        }

        // POST: Apps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_App,Name_App,Desc_App,ID_Itqan,Lang")] App app)
        {
            if (ModelState.IsValid)
            {
                db.Entry(app).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Itqan = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", app.ID_Itqan);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", app.Lang);
            return View(app);
        }

        // GET: Apps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            App app = db.App.Find(id);
            if (app == null)
            {
                return HttpNotFound();
            }
            return View(app);
        }

        // POST: Apps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            App app = db.App.Find(id);
            db.App.Remove(app);
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
