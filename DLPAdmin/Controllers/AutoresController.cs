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
    public class AutoresController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();

        // GET: Autores
        public ActionResult Index()
        {
            var autores = db.Autores.Include(a => a.Nacionalidades);
            return View(autores.ToList());
        }

        // GET: Autores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autores autores = db.Autores.Find(id);
            if (autores == null)
            {
                return HttpNotFound();
            }
            return View(autores);
        }

        // GET: Autores/Create
        public ActionResult Create()
        {
            ViewBag.nacionalidad = new SelectList(db.Nacionalidades, "id_nacion", "tipo_nacionalidad");
            return View();
        }

        // POST: Autores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_autor,nom_autor,nacionalidad")] Autores autores)
        {
            if (ModelState.IsValid)
            {
                db.Autores.Add(autores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nacionalidad = new SelectList(db.Nacionalidades, "id_nacion", "tipo_nacionalidad", autores.nacionalidad);
            return View(autores);
        }

        // GET: Autores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autores autores = db.Autores.Find(id);
            if (autores == null)
            {
                return HttpNotFound();
            }
            ViewBag.nacionalidad = new SelectList(db.Nacionalidades, "id_nacion", "tipo_nacionalidad", autores.nacionalidad);
            return View(autores);
        }

        // POST: Autores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_autor,nom_autor,nacionalidad")] Autores autores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nacionalidad = new SelectList(db.Nacionalidades, "id_nacion", "tipo_nacionalidad", autores.nacionalidad);
            return View(autores);
        }

        // GET: Autores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autores autores = db.Autores.Find(id);
            if (autores == null)
            {
                return HttpNotFound();
            }
            return View(autores);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autores autores = db.Autores.Find(id);
            db.Autores.Remove(autores);
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
