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
    public class EditorialesController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();

        // GET: Editoriales
        public ActionResult Index()
        {
            return View(db.Editoriales.ToList());
        }

        // GET: Editoriales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editoriales editoriales = db.Editoriales.Find(id);
            if (editoriales == null)
            {
                return HttpNotFound();
            }
            return View(editoriales);
        }

        // GET: Editoriales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editoriales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_edit,desc_edit")] Editoriales editoriales)
        {
            if (ModelState.IsValid)
            {
                db.Editoriales.Add(editoriales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editoriales);
        }

        // GET: Editoriales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editoriales editoriales = db.Editoriales.Find(id);
            if (editoriales == null)
            {
                return HttpNotFound();
            }
            return View(editoriales);
        }

        // POST: Editoriales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_edit,desc_edit")] Editoriales editoriales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editoriales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editoriales);
        }

        // GET: Editoriales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editoriales editoriales = db.Editoriales.Find(id);
            if (editoriales == null)
            {
                return HttpNotFound();
            }
            return View(editoriales);
        }

        // POST: Editoriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Editoriales editoriales = db.Editoriales.Find(id);
            db.Editoriales.Remove(editoriales);
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
