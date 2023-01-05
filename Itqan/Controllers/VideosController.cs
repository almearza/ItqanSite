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

namespace Itqan.Controllers
{
    [Authorize]

    public class VideosController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Videos
        public ActionResult Index()
        {
            var video = db.Video.Include(v => v.Define_Itqan);
            return View(video.ToList());
        }

        // GET: Videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Videos/Create
        public ActionResult Create()
        {
            ViewBag.ID_Define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_video,Video1,ID_Define")] Video video ,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/video"), upload.FileName);
                upload.SaveAs(path);
                video.Video1 = upload.FileName;
                video.ID_Define = 3;
                db.Video.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", video.ID_Define);
            return View(video);
        }

        // GET: Videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", video.ID_Define);
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_video,Video1,ID_Define")] Video video ,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldvideo = Path.Combine(Server.MapPath("~/video"),video.Video1);
                if(upload != null)
                {
                    string path = Path.Combine(Server.MapPath("~/video"), upload.FileName);
                    upload.SaveAs(path);
                    video.Video1 = upload.FileName;

                }
                
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", video.ID_Define);
            return View(video);
        }

        // GET: Videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Video video = db.Video.Find(id);
            db.Video.Remove(video);
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
