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

    public class IMAGE_headerController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: IMAGE_header
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var dataimage = db.IMAGE_header.Include(a => a.Lang1);

            return View(dataimage.ToList());
        }

        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1,"ID_lang", "Name_lang");
            var dataimage = db.IMAGE_header.Include(a => a.Lang1).Where(b => b.Lang == Lang);
            return View(dataimage.ToList());
        }

        // GET: IMAGE_header/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGE_header iMAGE_header = db.IMAGE_header.Find(id);
            if (iMAGE_header == null)
            {
                return HttpNotFound();
            }
            return View(iMAGE_header);
        }

        // GET: IMAGE_header/Create
        public ActionResult Create()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");

            return View();
        }

        // POST: IMAGE_header/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Image,Titile,descreption,IMG_Path,Lang")] IMAGE_header iMAGE_header,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {/*string path = Path.Combine(Server.MapPath("~/IMG"), upload.FileName);
                    upload.SaveAs(path);
                    course.IMG_course = upload.FileName;*/

                string path = Path.Combine(Server.MapPath("~/IMG"), upload.FileName);
                upload.SaveAs(path);
                iMAGE_header.IMG_Path = upload.FileName;
                db.IMAGE_header.Add(iMAGE_header);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang",iMAGE_header.Lang);


            return View(iMAGE_header);
        }

        // GET: IMAGE_header/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGE_header iMAGE_header = db.IMAGE_header.Find(id);
            if (iMAGE_header == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang",iMAGE_header.Lang);

            return View(iMAGE_header);
        }

        // POST: IMAGE_header/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Image,Titile,descreption,IMG_Path,Lang")] IMAGE_header iMAGE_header, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldIMG = Path.Combine(Server.MapPath("~/IMG"),iMAGE_header.IMG_Path);
                if(upload !=null)
                {
                    string path = Path.Combine(Server.MapPath("~/IMG"), upload.FileName);
                    upload.SaveAs(path);
                    iMAGE_header.IMG_Path = upload.FileName;

                }

               
                db.Entry(iMAGE_header).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", iMAGE_header.Lang);

            return View(iMAGE_header);
        }

        // GET: IMAGE_header/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGE_header iMAGE_header = db.IMAGE_header.Find(id);
            if (iMAGE_header == null)
            {
                return HttpNotFound();
            }
            return View(iMAGE_header);
        }

        // POST: IMAGE_header/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IMAGE_header iMAGE_header = db.IMAGE_header.Find(id);
            db.IMAGE_header.Remove(iMAGE_header);
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
