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

    public class LinksController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Links
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var links = db.Links.Include(l => l.Define_Itqan).Include(l => l.Lang1);
            return View(links.ToList());
        }
        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var links = db.Links.Include(l => l.Lang1).Where(e => e.Lang == Lang);
            return View(links.ToList());

        }


        // GET: Links/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links links = db.Links.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            return View(links);
        }

        // GET: Links/Create
        public ActionResult Create()
        {
            ViewBag.Defien_id = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Links/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Link,Descreption_Link,link,IMG_link,Defien_id,Lang")] Links links,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                links.IMG_link = upload.FileName;
                db.Links.Add(links);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Defien_id = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", links.Defien_id);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", links.Lang);
            return View(links);
        }

        // GET: Links/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links links = db.Links.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            ViewBag.Defien_id = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", links.Defien_id);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", links.Lang);
            return View(links);
        }

        // POST: Links/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Link,Descreption_Link,link,IMG_link,Defien_id,Lang")] Links links ,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldIMG = Path.Combine(Server.MapPath("~/Uploads"),links.IMG_link); 
                if(upload != null)
                {//اذ تم اختيار صورة جديدة احذف القديمة

                    System.IO.File.Delete(oldIMG);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                    upload.SaveAs(path);
                    links.IMG_link = upload.FileName;

                }
               
                db.Entry(links).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Defien_id = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", links.Defien_id);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", links.Lang);
            return View(links);
        }

        // GET: Links/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links links = db.Links.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            return View(links);
        }

        // POST: Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Links links = db.Links.Find(id);
            db.Links.Remove(links);
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
