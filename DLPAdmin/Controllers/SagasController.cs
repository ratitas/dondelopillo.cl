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
    public class SagasController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();

        // GET: Sagas
        public ActionResult Index()
        {
            return View(db.Sagas.ToList());
        }

        // GET: Sagas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sagas sagas = db.Sagas.Find(id);
            if (sagas == null)
            {
                return HttpNotFound();
            }
            return View(sagas);
        }

        // GET: Sagas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sagas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_sagas,nombre_saga")] Sagas sagas)
        {
            if (ModelState.IsValid)
            {
                db.Sagas.Add(sagas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sagas);
        }

        // GET: Sagas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sagas sagas = db.Sagas.Find(id);
            if (sagas == null)
            {
                return HttpNotFound();
            }
            return View(sagas);
        }

        // POST: Sagas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_sagas,nombre_saga")] Sagas sagas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sagas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sagas);
        }

        // GET: Sagas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sagas sagas = db.Sagas.Find(id);
            if (sagas == null)
            {
                return HttpNotFound();
            }
            return View(sagas);
        }

        // POST: Sagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sagas sagas = db.Sagas.Find(id);
            db.Sagas.Remove(sagas);
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
