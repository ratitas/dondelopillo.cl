using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Conexion.Models;

namespace DLPAdmin.Controllers
{
    public class IdiomasController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();

        // GET: Idiomas
        public ActionResult Index()
        {
            return View(db.Idiomas.ToList());
        }

        // GET: Idiomas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idiomas idiomas = db.Idiomas.Find(id);
            if (idiomas == null)
            {
                return HttpNotFound();
            }
            return View(idiomas);
        }

        // GET: Idiomas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Idiomas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_idiom,desc_idiom")] Idiomas idiomas)
        {
            if (ModelState.IsValid)
            {
                db.Idiomas.Add(idiomas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(idiomas);
        }

        // GET: Idiomas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idiomas idiomas = db.Idiomas.Find(id);
            if (idiomas == null)
            {
                return HttpNotFound();
            }
            return View(idiomas);
        }

        // POST: Idiomas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_idiom,desc_idiom")] Idiomas idiomas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idiomas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idiomas);
        }

        // GET: Idiomas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idiomas idiomas = db.Idiomas.Find(id);
            if (idiomas == null)
            {
                return HttpNotFound();
            }
            return View(idiomas);
        }

        // POST: Idiomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Idiomas idiomas = db.Idiomas.Find(id);
            db.Idiomas.Remove(idiomas);
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
