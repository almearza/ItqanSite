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

    public class Content_courseController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Content_course
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var content_course = db.Content_course.Include(c => c.Define_Itqan).Include(c => c.Lang1);
            return View(content_course.ToList());
        }
        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var content_course = db.Content_course.Include(c => c.Lang1).Where(a => a.Lang == Lang);
            return View(content_course.ToList());
        }


        // GET: Content_course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content_course content_course = db.Content_course.Find(id);
            if (content_course == null)
            {
                return HttpNotFound();
            }
            return View(content_course);
        }

        // GET: Content_course/Create
        public ActionResult Create()
        {
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Content_course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_content,Content_desc,ID_define,Lang")] Content_course content_course)
        {
            if (ModelState.IsValid)
            {
                db.Content_course.Add(content_course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", content_course.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", content_course.Lang);
            return View(content_course);
        }

        // GET: Content_course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content_course content_course = db.Content_course.Find(id);
            if (content_course == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", content_course.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", content_course.Lang);
            return View(content_course);
        }

        // POST: Content_course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_content,Content_desc,ID_define,Lang")] Content_course content_course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(content_course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", content_course.ID_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", content_course.Lang);
            return View(content_course);
        }

        // GET: Content_course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content_course content_course = db.Content_course.Find(id);
            if (content_course == null)
            {
                return HttpNotFound();
            }
            return View(content_course);
        }

        // POST: Content_course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Content_course content_course = db.Content_course.Find(id);
            db.Content_course.Remove(content_course);
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
