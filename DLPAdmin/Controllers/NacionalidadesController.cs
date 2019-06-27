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
    public class NacionalidadesController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();
        // GET: Nacionalidades
        public ActionResult Index()
        {
            return View(db.Nacionalidades.ToList());
        }

        // GET: Nacionalidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nacionalidades nacionalidades = db.Nacionalidades.Find(id);
            if (nacionalidades == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidades);
        }

        // GET: Nacionalidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nacionalidades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_nacion,tipo_nacionalidad")] Nacionalidades nacionalidades)
        {
            if (ModelState.IsValid)
            {
                db.Nacionalidades.Add(nacionalidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nacionalidades);
        }

        // GET: Nacionalidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nacionalidades nacionalidades = db.Nacionalidades.Find(id);
            if (nacionalidades == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidades);
        }

        // POST: Nacionalidades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_nacion,tipo_nacionalidad")] Nacionalidades nacionalidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nacionalidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nacionalidades);
        }

        // GET: Nacionalidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nacionalidades nacionalidades = db.Nacionalidades.Find(id);
            if (nacionalidades == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidades);
        }

        // POST: Nacionalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nacionalidades nacionalidades = db.Nacionalidades.Find(id);
            db.Nacionalidades.Remove(nacionalidades);
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
