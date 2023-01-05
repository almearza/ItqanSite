using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Itqan.Models;
using System.IO;
using Microsoft.AspNet.Identity;


namespace Itqan.Controllers
{
    [Authorize]

    public class CoursesController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Courses
        public ActionResult Index()
        {
            var course = db.Course.Include(c => c.Define_Itqan);
            return View(course.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course , HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                    string path = Path.Combine(Server.MapPath("~/IMG"), upload.FileName);
                    upload.SaveAs(path);
                    course.IMG_course = upload.FileName;
                    course.dateStart = DateTime.Now;
                    course.endDate = DateTime.Now;
                    course.id_define = 3;
                    db.Course.Add(course);
                    db.SaveChanges();              
                return RedirectToAction("Index");
            }

            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", course.id_define);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", course.id_define);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_course,Name_Course,Descreption_Course,IMG_course,dateStart,id_define,endDate")] Course course , HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/IMG"), upload.FileName);
                upload.SaveAs(path);
                course.IMG_course = upload.FileName;
                course.id_define = 3;
                course.dateStart = DateTime.Now;
                course.endDate = DateTime.Now;
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", course.id_define);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Course.Find(id);
            db.Course.Remove(course);
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
