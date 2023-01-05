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

    public class Required_ITController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Required_IT
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var required_IT = db.Required_IT.Include(r => r.Define_Itqan).Include(r => r.Lang1);
            return View(required_IT.ToList());
        }

        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var required_IT = db.Required_IT.Include(r => r.Lang1).Where(a => a.Lang == Lang);
            return View(required_IT.ToList());
        }


        // GET: Required_IT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Required_IT required_IT = db.Required_IT.Find(id);
            if (required_IT == null)
            {
                return HttpNotFound();
            }
            return View(required_IT);
        }

        // GET: Required_IT/Create
        public ActionResult Create()
        {
            ViewBag.Id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Required_IT/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Required_id,Required_Descreption,Id_define,Lang")] Required_IT required_IT)
        {
            if (ModelState.IsValid)
            {
                db.Required_IT.Add(required_IT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", required_IT.Id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", required_IT.Lang);
            return View(required_IT);
        }

        // GET: Required_IT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Required_IT required_IT = db.Required_IT.Find(id);
            if (required_IT == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", required_IT.Id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", required_IT.Lang);
            return View(required_IT);
        }

        // POST: Required_IT/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Required_id,Required_Descreption,Id_define,Lang")] Required_IT required_IT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(required_IT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", required_IT.Id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", required_IT.Lang);
            return View(required_IT);
        }

        // GET: Required_IT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Required_IT required_IT = db.Required_IT.Find(id);
            if (required_IT == null)
            {
                return HttpNotFound();
            }
            return View(required_IT);
        }

        // POST: Required_IT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Required_IT required_IT = db.Required_IT.Find(id);
            db.Required_IT.Remove(required_IT);
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
