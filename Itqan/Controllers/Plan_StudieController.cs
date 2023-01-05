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

    public class Plan_StudieController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Plan_Studie
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            var plan_Studie = db.Plan_Studie.Include(p => p.Define_Itqan).Include(p => p.Lang1);
            return View(plan_Studie.ToList());
        }

        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            var plan_Studie = db.Plan_Studie.Include(p => p.Lang1).Where(a => a.Lang == Lang);
            return View(plan_Studie.ToList());
        }


        // GET: Plan_Studie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan_Studie plan_Studie = db.Plan_Studie.Find(id);
            if (plan_Studie == null)
            {
                return HttpNotFound();
            }
            return View(plan_Studie);
        }

        // GET: Plan_Studie/Create
        public ActionResult Create()
        {
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Plan_Studie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Plan,Plan_Studie1,ID_define,Lang")] Plan_Studie plan_Studie)
        {
            if (ModelState.IsValid)
            {
                db.Plan_Studie.Add(plan_Studie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", plan_Studie.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", plan_Studie.Lang);
            return View(plan_Studie);
        }

        // GET: Plan_Studie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan_Studie plan_Studie = db.Plan_Studie.Find(id);
            if (plan_Studie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", plan_Studie.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", plan_Studie.Lang);
            return View(plan_Studie);
        }

        // POST: Plan_Studie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Plan,Plan_Studie1,ID_define,Lang")] Plan_Studie plan_Studie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_Studie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", plan_Studie.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", plan_Studie.Lang);
            return View(plan_Studie);
        }

        // GET: Plan_Studie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan_Studie plan_Studie = db.Plan_Studie.Find(id);
            if (plan_Studie == null)
            {
                return HttpNotFound();
            }
            return View(plan_Studie);
        }

        // POST: Plan_Studie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan_Studie plan_Studie = db.Plan_Studie.Find(id);
            db.Plan_Studie.Remove(plan_Studie);
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
