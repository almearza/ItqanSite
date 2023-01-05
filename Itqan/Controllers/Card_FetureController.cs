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

    public class Card_FetureController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Card_Feture
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var card_Feture = db.Card_Feture.Include(c => c.Define_Itqan).Include(c => c.Lang1);
            return View(card_Feture.ToList());
        }
        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var card_Feture = db.Card_Feture.Include(c => c.Lang1).Where(i=>i.Lang==Lang);

            return View(card_Feture.ToList());

        }


        // GET: Card_Feture/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card_Feture card_Feture = db.Card_Feture.Find(id);
            if (card_Feture == null)
            {
                return HttpNotFound();
            }
            return View(card_Feture);
        }

        // GET: Card_Feture/Create
        public ActionResult Create()
        {
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Card_Feture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Star,Star_card,id_define,Lang,ImageCard")] Card_Feture card_Feture,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                card_Feture.ImageCard = upload.FileName;
                db.Card_Feture.Add(card_Feture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", card_Feture.id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", card_Feture.Lang);
            return View(card_Feture);
        }

        // GET: Card_Feture/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card_Feture card_Feture = db.Card_Feture.Find(id);
            if (card_Feture == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", card_Feture.id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", card_Feture.Lang);
            return View(card_Feture);
        }

        // POST: Card_Feture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Star,Star_card,id_define,Lang,ImageCard")] Card_Feture card_Feture, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldimg =  Path.Combine(Server.MapPath("~/Uploads"), card_Feture.ImageCard);
                if(upload !=null)
                {
                    string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                    upload.SaveAs(path);
                    card_Feture.ImageCard = upload.FileName;

                }
               
                db.Entry(card_Feture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", card_Feture.id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", card_Feture.Lang);
            return View(card_Feture);
        }

        // GET: Card_Feture/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card_Feture card_Feture = db.Card_Feture.Find(id);
            if (card_Feture == null)
            {
                return HttpNotFound();
            }
            return View(card_Feture);
        }

        // POST: Card_Feture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Card_Feture card_Feture = db.Card_Feture.Find(id);
            db.Card_Feture.Remove(card_Feture);
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
