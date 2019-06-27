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
    public class LibrosController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();

        // GET: Libros
        public ActionResult Index()
        {
            var libros = db.Libros.Include(l => l.Autores).Include(l => l.Categorias).Include(l => l.Editoriales).Include(l => l.Idiomas).Include(l => l.Sagas1).Include(l => l.Tapa1).Include(l => l.Tipo_Libro);
            return View(libros.ToList());
        }

        // GET: Libros/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            return View(libros);
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            ViewBag.autor = new SelectList(db.Autores, "id_autor", "nom_autor");
            ViewBag.categoria = new SelectList(db.Categorias, "id_cat", "desc_cat");
            ViewBag.editorial = new SelectList(db.Editoriales, "id_edit", "desc_edit");
            ViewBag.idioma = new SelectList(db.Idiomas, "id_idiom", "desc_idiom");
            ViewBag.sagas = new SelectList(db.Sagas, "id_sagas", "nombre_saga");
            ViewBag.tapa = new SelectList(db.Tapa, "id_tapa", "nom_tapa");
            ViewBag.tipo = new SelectList(db.Tipo_Libro, "id_tipo", "desc_tipo");
            return View();
        }

        // POST: Libros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "isbn,desc_libro,autor,editorial,idioma,categoria,tipo,tapa,sagas,urlimagen,npaginas")] Libros libros)
        {
            if (ModelState.IsValid)
            {
                db.Libros.Add(libros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.autor = new SelectList(db.Autores, "id_autor", "nom_autor", libros.autor);
            ViewBag.categoria = new SelectList(db.Categorias, "id_cat", "desc_cat", libros.categoria);
            ViewBag.editorial = new SelectList(db.Editoriales, "id_edit", "desc_edit", libros.editorial);
            ViewBag.idioma = new SelectList(db.Idiomas, "id_idiom", "desc_idiom", libros.idioma);
            ViewBag.sagas = new SelectList(db.Sagas, "id_sagas", "nombre_saga", libros.sagas);
            ViewBag.tapa = new SelectList(db.Tapa, "id_tapa", "nom_tapa", libros.tapa);
            ViewBag.tipo = new SelectList(db.Tipo_Libro, "id_tipo", "desc_tipo", libros.tipo);
            return View(libros);
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            ViewBag.autor = new SelectList(db.Autores, "id_autor", "nom_autor", libros.autor);
            ViewBag.categoria = new SelectList(db.Categorias, "id_cat", "desc_cat", libros.categoria);
            ViewBag.editorial = new SelectList(db.Editoriales, "id_edit", "desc_edit", libros.editorial);
            ViewBag.idioma = new SelectList(db.Idiomas, "id_idiom", "desc_idiom", libros.idioma);
            ViewBag.sagas = new SelectList(db.Sagas, "id_sagas", "nombre_saga", libros.sagas);
            ViewBag.tapa = new SelectList(db.Tapa, "id_tapa", "nom_tapa", libros.tapa);
            ViewBag.tipo = new SelectList(db.Tipo_Libro, "id_tipo", "desc_tipo", libros.tipo);
            return View(libros);
        }

        // POST: Libros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "isbn,desc_libro,autor,editorial,idioma,categoria,tipo,tapa,sagas,urlimagen,npaginas")] Libros libros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.autor = new SelectList(db.Autores, "id_autor", "nom_autor", libros.autor);
            ViewBag.categoria = new SelectList(db.Categorias, "id_cat", "desc_cat", libros.categoria);
            ViewBag.editorial = new SelectList(db.Editoriales, "id_edit", "desc_edit", libros.editorial);
            ViewBag.idioma = new SelectList(db.Idiomas, "id_idiom", "desc_idiom", libros.idioma);
            ViewBag.sagas = new SelectList(db.Sagas, "id_sagas", "nombre_saga", libros.sagas);
            ViewBag.tapa = new SelectList(db.Tapa, "id_tapa", "nom_tapa", libros.tapa);
            ViewBag.tipo = new SelectList(db.Tipo_Libro, "id_tipo", "desc_tipo", libros.tipo);
            return View(libros);
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            return View(libros);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Libros libros = db.Libros.Find(id);
            db.Libros.Remove(libros);
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
