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

    public class PoliceController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Police
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var police = db.Police.Include(p => p.Define_Itqan).Include(p => p.Lang1);
            return View(police.ToList());
        }

        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var police = db.Police.Include(p => p.Lang1).Where(a => a.Lang == Lang);
            return View(police.ToList());
        }


        // GET: Police/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Police police = db.Police.Find(id);
            if (police == null)
            {
                return HttpNotFound();
            }
            return View(police);
        }

        // GET: Police/Create
        public ActionResult Create()
        {
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Police/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Ploce,Police1,id_define,Lang")] Police police)
        {
            if (ModelState.IsValid)
            {
                db.Police.Add(police);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", police.id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", police.Lang);
            return View(police);
        }

        // GET: Police/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Police police = db.Police.Find(id);
            if (police == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", police.id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", police.Lang);
            return View(police);
        }

        // POST: Police/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Ploce,Police1,id_define,Lang")] Police police)
        {
            if (ModelState.IsValid)
            {
                db.Entry(police).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", police.id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", police.Lang);
            return View(police);
        }

        // GET: Police/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Police police = db.Police.Find(id);
            if (police == null)
            {
                return HttpNotFound();
            }
            return View(police);
        }

        // POST: Police/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Police police = db.Police.Find(id);
            db.Police.Remove(police);
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
