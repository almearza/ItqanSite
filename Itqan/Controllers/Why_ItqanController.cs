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

    public class Why_ItqanController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Why_Itqan
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var why_Itqan = db.Why_Itqan.Include(w => w.Define_Itqan).Include(w => w.Lang1);
            return View(why_Itqan.ToList());
        }

        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            var why_Itqan = db.Why_Itqan.Include(w => w.Lang1).Where(a => a.Lang == Lang);
            return View(why_Itqan.ToList());
        }


        // GET: Why_Itqan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Why_Itqan why_Itqan = db.Why_Itqan.Find(id);
            if (why_Itqan == null)
            {
                return HttpNotFound();
            }
            return View(why_Itqan);
        }

        // GET: Why_Itqan/Create
        public ActionResult Create()
        {
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Why_Itqan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_WhyItqan,Why_1,ID_define,Lang")] Why_Itqan why_Itqan)
        {
            if (ModelState.IsValid)
            {
                db.Why_Itqan.Add(why_Itqan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", why_Itqan.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", why_Itqan.Lang);
            return View(why_Itqan);
        }

        // GET: Why_Itqan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Why_Itqan why_Itqan = db.Why_Itqan.Find(id);
            if (why_Itqan == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", why_Itqan.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", why_Itqan.Lang);
            return View(why_Itqan);
        }

        // POST: Why_Itqan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_WhyItqan,Why_1,ID_define,Lang")] Why_Itqan why_Itqan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(why_Itqan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", why_Itqan.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", why_Itqan.Lang);
            return View(why_Itqan);
        }

        // GET: Why_Itqan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Why_Itqan why_Itqan = db.Why_Itqan.Find(id);
            if (why_Itqan == null)
            {
                return HttpNotFound();
            }
            return View(why_Itqan);
        }

        // POST: Why_Itqan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Why_Itqan why_Itqan = db.Why_Itqan.Find(id);
            db.Why_Itqan.Remove(why_Itqan);
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
