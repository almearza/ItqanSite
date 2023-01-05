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

    public class Categore_PeopleController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Categore_People
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            var categore_People = db.Categore_People.Include(c => c.Define_Itqan).Include(c => c.Lang1);
            return View(categore_People.ToList());
        }
        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            var categore_People = db.Categore_People.Include(c => c.Lang1).Where(a => a.Lang == Lang);
            return View(categore_People.ToList());
        }


        // GET: Categore_People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categore_People categore_People = db.Categore_People.Find(id);
            if (categore_People == null)
            {
                return HttpNotFound();
            }
            return View(categore_People);
        }

        // GET: Categore_People/Create
        public ActionResult Create()
        {
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Categore_People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_categore,Categore_Age,Descreption_Categore,ID_define,Lang")] Categore_People categore_People)
        {
            if (ModelState.IsValid)
            {
                db.Categore_People.Add(categore_People);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", categore_People.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", categore_People.Lang);
            return View(categore_People);
        }

        // GET: Categore_People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categore_People categore_People = db.Categore_People.Find(id);
            if (categore_People == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", categore_People.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", categore_People.Lang);
            return View(categore_People);
        }

        // POST: Categore_People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_categore,Categore_Age,Descreption_Categore,ID_define,Lang")] Categore_People categore_People)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categore_People).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", categore_People.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", categore_People.Lang);
            return View(categore_People);
        }

        // GET: Categore_People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categore_People categore_People = db.Categore_People.Find(id);
            if (categore_People == null)
            {
                return HttpNotFound();
            }
            return View(categore_People);
        }

        // POST: Categore_People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categore_People categore_People = db.Categore_People.Find(id);
            db.Categore_People.Remove(categore_People);
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
