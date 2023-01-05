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

    public class Feture_ItqanController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Feture_Itqan
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            var feture_Itqan = db.Feture_Itqan.Include(f => f.Define_Itqan).Include(f => f.Lang1);
            return View(feture_Itqan.ToList());
        }

        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var feture_Itqan = db.Feture_Itqan.Include(f => f.Lang1).Where(re => re.Lang==Lang);
            return View(feture_Itqan.ToList());
        }


        // GET: Feture_Itqan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feture_Itqan feture_Itqan = db.Feture_Itqan.Find(id);
            if (feture_Itqan == null)
            {
                return HttpNotFound();
            }
            return View(feture_Itqan);
        }

        // GET: Feture_Itqan/Create
        public ActionResult Create()
        {
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Feture_Itqan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Feutre,Descreption_Feture,id_define,Lang")] Feture_Itqan feture_Itqan)
        {
            if (ModelState.IsValid)
            {
                db.Feture_Itqan.Add(feture_Itqan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", feture_Itqan.id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", feture_Itqan.Lang);
            return View(feture_Itqan);
        }

        // GET: Feture_Itqan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feture_Itqan feture_Itqan = db.Feture_Itqan.Find(id);
            if (feture_Itqan == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", feture_Itqan.id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", feture_Itqan.Lang);
            return View(feture_Itqan);
        }

        // POST: Feture_Itqan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Feutre,Descreption_Feture,id_define,Lang")] Feture_Itqan feture_Itqan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feture_Itqan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", feture_Itqan.id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", feture_Itqan.Lang);
            return View(feture_Itqan);
        }

        // GET: Feture_Itqan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feture_Itqan feture_Itqan = db.Feture_Itqan.Find(id);
            if (feture_Itqan == null)
            {
                return HttpNotFound();
            }
            return View(feture_Itqan);
        }

        // POST: Feture_Itqan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feture_Itqan feture_Itqan = db.Feture_Itqan.Find(id);
            db.Feture_Itqan.Remove(feture_Itqan);
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
