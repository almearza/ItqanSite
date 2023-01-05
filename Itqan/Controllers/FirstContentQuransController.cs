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

    public class FirstContentQuransController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: FirstContentQurans
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var firstContentQuran = db.FirstContentQuran.Include(f => f.Lang1);
            return View(firstContentQuran.ToList());
        }
        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            var FirstContent = db.FirstContentQuran.Include(c => c.Lang1).Where(a => a.Lang == Lang);
            return View(FirstContent.ToList());

        }


        // GET: FirstContentQurans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstContentQuran firstContentQuran = db.FirstContentQuran.Find(id);
            if (firstContentQuran == null)
            {
                return HttpNotFound();
            }
            return View(firstContentQuran);
        }

        // GET: FirstContentQurans/Create
        public ActionResult Create()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: FirstContentQurans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Content,Lang,FirstContent")] FirstContentQuran firstContentQuran)
        {
            if (ModelState.IsValid)
            {
                db.FirstContentQuran.Add(firstContentQuran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", firstContentQuran.Lang);
            return View(firstContentQuran);
        }

        // GET: FirstContentQurans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstContentQuran firstContentQuran = db.FirstContentQuran.Find(id);
            if (firstContentQuran == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", firstContentQuran.Lang);
            return View(firstContentQuran);
        }

        // POST: FirstContentQurans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Content,Lang,FirstContent")] FirstContentQuran firstContentQuran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firstContentQuran).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", firstContentQuran.Lang);
            return View(firstContentQuran);
        }

        // GET: FirstContentQurans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstContentQuran firstContentQuran = db.FirstContentQuran.Find(id);
            if (firstContentQuran == null)
            {
                return HttpNotFound();
            }
            return View(firstContentQuran);
        }

        // POST: FirstContentQurans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FirstContentQuran firstContentQuran = db.FirstContentQuran.Find(id);
            db.FirstContentQuran.Remove(firstContentQuran);
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
