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
    public class AlnoorsController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Alnoors
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var alnoor = db.Alnoor.Include(a => a.Define_Itqan).Include(a => a.Lang1);
            return View(alnoor.ToList());
        }

        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            var alnoor = db.Alnoor.Include(a => a.Lang1).Where(e => e.Lang == Lang);
            return View(alnoor.ToList());
        }


        // GET: Alnoors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alnoor alnoor = db.Alnoor.Find(id);
            if (alnoor == null)
            {
                return HttpNotFound();
            }
            return View(alnoor);
        }

        // GET: Alnoors/Create
        public ActionResult Create()
        {
            ViewBag.ID_Itqan = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Alnoors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Alnoor,Lang,AdvantageAlnoor,ID_Itqan")] Alnoor alnoor)
        {
            if (ModelState.IsValid)
            {
                db.Alnoor.Add(alnoor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Itqan = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", alnoor.ID_Itqan);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", alnoor.Lang);
            return View(alnoor);
        }

        // GET: Alnoors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alnoor alnoor = db.Alnoor.Find(id);
            if (alnoor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Itqan = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", alnoor.ID_Itqan);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", alnoor.Lang);
            return View(alnoor);
        }

        // POST: Alnoors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Alnoor,Lang,AdvantageAlnoor,ID_Itqan")] Alnoor alnoor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alnoor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Itqan = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", alnoor.ID_Itqan);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", alnoor.Lang);
            return View(alnoor);
        }

        // GET: Alnoors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alnoor alnoor = db.Alnoor.Find(id);
            if (alnoor == null)
            {
                return HttpNotFound();
            }
            return View(alnoor);
        }

        // POST: Alnoors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alnoor alnoor = db.Alnoor.Find(id);
            db.Alnoor.Remove(alnoor);
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
