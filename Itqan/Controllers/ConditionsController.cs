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

    public class ConditionsController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Conditions
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            var condition = db.Condition.Include(c => c.Define_Itqan).Include(c => c.Lang1);
            return View(condition.ToList());
        }

        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var condition = db.Condition.Include(c => c.Lang1).Where(a => a.Lang == Lang);
            return View(condition.ToList());
        }


        // GET: Conditions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condition condition = db.Condition.Find(id);
            if (condition == null)
            {
                return HttpNotFound();
            }
            return View(condition);
        }

        // GET: Conditions/Create
        public ActionResult Create()
        {
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Conditions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_register,Descreption_condition,ID_define,Lang")] Condition condition)
        {
            if (ModelState.IsValid)
            {
                db.Condition.Add(condition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", condition.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", condition.Lang);
            return View(condition);
        }

        // GET: Conditions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condition condition = db.Condition.Find(id);
            if (condition == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", condition.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", condition.Lang);
            return View(condition);
        }

        // POST: Conditions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_register,Descreption_condition,ID_define,Lang")] Condition condition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", condition.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", condition.Lang);
            return View(condition);
        }

        // GET: Conditions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condition condition = db.Condition.Find(id);
            if (condition == null)
            {
                return HttpNotFound();
            }
            return View(condition);
        }

        // POST: Conditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Condition condition = db.Condition.Find(id);
            db.Condition.Remove(condition);
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
