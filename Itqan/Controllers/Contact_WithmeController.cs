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

    public class Contact_WithmeController : MyController
    {
        private ItqanEntities db = new ItqanEntities();

        // GET: Contact_Withme
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var contact_Withme = db.Contact_Withme.Include(c => c.Define_Itqan).Include(c => c.Lang1);
            return View(contact_Withme.ToList());
        }
        [HttpPost]
        public ActionResult Index(int Lang)
        {
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            var contMesaage = db.Contact_Withme.Include(a => a.Lang1).Where(w => w.Lang == Lang);
            return View(contMesaage.ToList());


        }


        // GET: Contact_Withme/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact_Withme contact_Withme = db.Contact_Withme.Find(id);
            if (contact_Withme == null)
            {
                return HttpNotFound();
            }
            return View(contact_Withme);
        }

        // GET: Contact_Withme/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan");
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang");
            return View();
        }

        // POST: Contact_Withme/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_contact,Email,FullName,Mobile,Subject,Message,Date,id_define,Lang")] Contact_Withme contact_Withme)
        {
            if (ModelState.IsValid)
            {
                contact_Withme.Date = DateTime.Now;


                var userLang = Request.Cookies["userLang"];
                if (userLang != null)
                {
                    contact_Withme.Lang = int.Parse(userLang["langId"]);
                }
                else
                {
                    contact_Withme.Lang = 1;
                }


                contact_Withme.Mobile = "966554472280";
                contact_Withme.id_define = 3;
                db.Contact_Withme.Add(contact_Withme);
                
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", contact_Withme.id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", contact_Withme.Lang);
            return View(contact_Withme);
        }

        // GET: Contact_Withme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact_Withme contact_Withme = db.Contact_Withme.Find(id);
            if (contact_Withme == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", contact_Withme.id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", contact_Withme.Lang);
            return View(contact_Withme);
        }

        // POST: Contact_Withme/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_contact,Email,FullName,Mobile,Subject,Message,Date,id_define,Lang")] Contact_Withme contact_Withme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact_Withme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_define = new SelectList(db.Define_Itqan, "ID", "Name_Itqan", contact_Withme.id_define);
            ViewBag.Lang = new SelectList(db.Lang1, "ID_lang", "Name_lang", contact_Withme.Lang);
            contact_Withme.Date = DateTime.Now;
            return View(contact_Withme);
        }

        // GET: Contact_Withme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact_Withme contact_Withme = db.Contact_Withme.Find(id);
            if (contact_Withme == null)
            {
                return HttpNotFound();
            }
            return View(contact_Withme);
        }

        // POST: Contact_Withme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact_Withme contact_Withme = db.Contact_Withme.Find(id);
            db.Contact_Withme.Remove(contact_Withme);
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
