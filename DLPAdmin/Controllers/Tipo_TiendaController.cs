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
    public class Tipo_TiendaController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();

        // GET: Tipo_Tienda
        public ActionResult Index()
        {
            return View(db.Tipo_Tienda.ToList());
        }

        // GET: Tipo_Tienda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Tienda tipo_Tienda = db.Tipo_Tienda.Find(id);
            if (tipo_Tienda == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Tienda);
        }

        // GET: Tipo_Tienda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Tienda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo,desc_tipo")] Tipo_Tienda tipo_Tienda)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Tienda.Add(tipo_Tienda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Tienda);
        }

        // GET: Tipo_Tienda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Tienda tipo_Tienda = db.Tipo_Tienda.Find(id);
            if (tipo_Tienda == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Tienda);
        }

        // POST: Tipo_Tienda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo,desc_tipo")] Tipo_Tienda tipo_Tienda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Tienda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Tienda);
        }

        // GET: Tipo_Tienda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Tienda tipo_Tienda = db.Tipo_Tienda.Find(id);
            if (tipo_Tienda == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Tienda);
        }

        // POST: Tipo_Tienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Tienda tipo_Tienda = db.Tipo_Tienda.Find(id);
            db.Tipo_Tienda.Remove(tipo_Tienda);
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
