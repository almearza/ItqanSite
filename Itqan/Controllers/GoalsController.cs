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
    public class GoalsController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Goals
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");


            var goals = db.Goals.Include(g => g.Define_Itqan).Include(g => g.Lang11);
            return View(goals.ToList());
        }

        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            var goals = db.Goals.Include(g => g.Lang11).Where(a => a.Lang == Lang);
            return View(goals.ToList());
        }

        public ActionResult blank()
        {
            return View();
        }
        public ActionResult blank3()
        {
            return View();
        }
        // GET: Goals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goals goals = db.Goals.Find(id);
            if (goals == null)
            {
                return HttpNotFound();
            }
            return View(goals);
        }

        // GET: Goals/Create
        public ActionResult Create()
        {
            ViewBag.ID_Define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Goals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Goals,Gaol,ID_Define,Lang")] Goals goals)
        {
            if (ModelState.IsValid)
            {
                //goals.ID_Define = 3;
                db.Goals.Add(goals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", goals.ID_Define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", goals.Lang);
            return View(goals);
        }

        // GET: Goals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goals goals = db.Goals.Find(id);
            if (goals == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", goals.ID_Define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", goals.Lang);
            return View(goals);
        }

        // POST: Goals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Goals,Gaol,ID_Define,Lang")] Goals goals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", goals.ID_Define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", goals.Lang);
            return View(goals);
        }

        // GET: Goals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goals goals = db.Goals.Find(id);
            if (goals == null)
            {
                return HttpNotFound();
            }
            return View(goals);
        }

        // POST: Goals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Goals goals = db.Goals.Find(id);
            db.Goals.Remove(goals);
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
