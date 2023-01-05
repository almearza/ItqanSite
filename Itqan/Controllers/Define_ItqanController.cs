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

    public class Define_ItqanController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Define_Itqan
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            var define_Itqan = db.Define_Itqan.Include(d => d.Lang1);
            return View(define_Itqan.ToList());
        }

        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            var define_Itqan = db.Define_Itqan.Include(d => d.Lang1).Where(a => a.Lang == Lang);
            return View(define_Itqan.ToList());
        }


        // GET: Define_Itqan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Define_Itqan define_Itqan = db.Define_Itqan.Find(id);
            if (define_Itqan == null)
            {
                return HttpNotFound();
            }
            return View(define_Itqan);
        }

        // GET: Define_Itqan/Create
        public ActionResult Create()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Define_Itqan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name_Itqan,Vision,Message,Breife,Lang")] Define_Itqan define_Itqan)
        {
            if (ModelState.IsValid)
            {
                db.Define_Itqan.Add(define_Itqan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", define_Itqan.Lang);
            return View(define_Itqan);
        }

        // GET: Define_Itqan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Define_Itqan define_Itqan = db.Define_Itqan.Find(id);
            if (define_Itqan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", define_Itqan.Lang);
            return View(define_Itqan);
        }

        // POST: Define_Itqan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name_Itqan,Vision,Message,Breife,Lang")] Define_Itqan define_Itqan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(define_Itqan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", define_Itqan.Lang);
            return View(define_Itqan);
        }

        // GET: Define_Itqan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Define_Itqan define_Itqan = db.Define_Itqan.Find(id);
            if (define_Itqan == null)
            {
                return HttpNotFound();
            }
            return View(define_Itqan);
        }

        // POST: Define_Itqan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Define_Itqan define_Itqan = db.Define_Itqan.Find(id);
            db.Define_Itqan.Remove(define_Itqan);
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
