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
    public class Libro_tiendaController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();

        // GET: Libro_tienda
        public ActionResult Index()
        {
            var libro_tienda = db.Libro_tienda.Include(l => l.Libros).Include(l => l.Tiendas);
            return View(libro_tienda.ToList());
        }

        // GET: Libro_tienda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro_tienda libro_tienda = db.Libro_tienda.Find(id);
            if (libro_tienda == null)
            {
                return HttpNotFound();
            }
            return View(libro_tienda);
        }

        // GET: Libro_tienda/Create
        public ActionResult Create()
        {
            ViewBag.isbnfk = new SelectList(db.Libros, "isbn", "desc_libro");
            ViewBag.id_tienda = new SelectList(db.Tiendas, "id_tienda", "desc_tienda");
            return View();
        }

        // POST: Libro_tienda/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "isbnfk,id_tienda,urllibro,precio,idlb")] Libro_tienda libro_tienda)
        {
            if (ModelState.IsValid)
            {
                db.Libro_tienda.Add(libro_tienda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.isbnfk = new SelectList(db.Libros, "isbn", "desc_libro", libro_tienda.isbnfk);
            ViewBag.id_tienda = new SelectList(db.Tiendas, "id_tienda", "desc_tienda", libro_tienda.id_tienda);
            return View(libro_tienda);
        }

        // GET: Libro_tienda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro_tienda libro_tienda = db.Libro_tienda.Find(id);
            if (libro_tienda == null)
            {
                return HttpNotFound();
            }
            ViewBag.isbnfk = new SelectList(db.Libros, "isbn", "desc_libro", libro_tienda.isbnfk);
            ViewBag.id_tienda = new SelectList(db.Tiendas, "id_tienda", "desc_tienda", libro_tienda.id_tienda);
            return View(libro_tienda);
        }

        // POST: Libro_tienda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "isbnfk,id_tienda,urllibro,precio,idlb")] Libro_tienda libro_tienda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro_tienda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.isbnfk = new SelectList(db.Libros, "isbn", "desc_libro", libro_tienda.isbnfk);
            ViewBag.id_tienda = new SelectList(db.Tiendas, "id_tienda", "desc_tienda", libro_tienda.id_tienda);
            return View(libro_tienda);
        }

        // GET: Libro_tienda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro_tienda libro_tienda = db.Libro_tienda.Find(id);
            if (libro_tienda == null)
            {
                return HttpNotFound();
            }
            return View(libro_tienda);
        }

        // POST: Libro_tienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libro_tienda libro_tienda = db.Libro_tienda.Find(id);
            db.Libro_tienda.Remove(libro_tienda);
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
