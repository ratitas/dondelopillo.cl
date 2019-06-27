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
    public class TiendasController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();

        // GET: Tiendas
        public ActionResult Index()
        {
            var tiendas = db.Tiendas.Include(t => t.Tipo_Tienda1);
            return View(tiendas.ToList());
        }

        // GET: Tiendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tiendas tiendas = db.Tiendas.Find(id);
            if (tiendas == null)
            {
                return HttpNotFound();
            }
            return View(tiendas);
        }

        // GET: Tiendas/Create
        public ActionResult Create()
        {
            ViewBag.tipo_tienda = new SelectList(db.Tipo_Tienda, "id_tipo", "desc_tipo");
            return View();
        }

        // POST: Tiendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tienda,desc_tienda,direc_tienda,tipo_tienda")] Tiendas tiendas)
        {
            if (ModelState.IsValid)
            {
                db.Tiendas.Add(tiendas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipo_tienda = new SelectList(db.Tipo_Tienda, "id_tipo", "desc_tipo", tiendas.tipo_tienda);
            return View(tiendas);
        }

        // GET: Tiendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tiendas tiendas = db.Tiendas.Find(id);
            if (tiendas == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipo_tienda = new SelectList(db.Tipo_Tienda, "id_tipo", "desc_tipo", tiendas.tipo_tienda);
            return View(tiendas);
        }

        // POST: Tiendas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tienda,desc_tienda,direc_tienda,tipo_tienda")] Tiendas tiendas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiendas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipo_tienda = new SelectList(db.Tipo_Tienda, "id_tipo", "desc_tipo", tiendas.tipo_tienda);
            return View(tiendas);
        }

        // GET: Tiendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tiendas tiendas = db.Tiendas.Find(id);
            if (tiendas == null)
            {
                return HttpNotFound();
            }
            return View(tiendas);
        }

        // POST: Tiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tiendas tiendas = db.Tiendas.Find(id);
            db.Tiendas.Remove(tiendas);
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
