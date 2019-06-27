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
    public class TapasController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();

        // GET: Tapas
        public ActionResult Index()
        {
            return View(db.Tapa.ToList());
        }

        // GET: Tapas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tapa tapa = db.Tapa.Find(id);
            if (tapa == null)
            {
                return HttpNotFound();
            }
            return View(tapa);
        }

        // GET: Tapas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tapas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tapa,nom_tapa")] Tapa tapa)
        {
            if (ModelState.IsValid)
            {
                db.Tapa.Add(tapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tapa);
        }

        // GET: Tapas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tapa tapa = db.Tapa.Find(id);
            if (tapa == null)
            {
                return HttpNotFound();
            }
            return View(tapa);
        }

        // POST: Tapas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tapa,nom_tapa")] Tapa tapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tapa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tapa);
        }

        // GET: Tapas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tapa tapa = db.Tapa.Find(id);
            if (tapa == null)
            {
                return HttpNotFound();
            }
            return View(tapa);
        }

        // POST: Tapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tapa tapa = db.Tapa.Find(id);
            db.Tapa.Remove(tapa);
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
