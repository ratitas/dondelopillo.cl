using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Conexion.Models;

namespace DLPCliente.Controllers
{
    public class PortadaController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();

        /// <summary>
        /// Mostrar Libros y Categorias
        /// </summary>
        /// <returns>Crear viewbag de categorias para desplegarlas en el layout, y hace una lista de libros para enseñar en la portada</returns>
        public ActionResult Index()
        {
            List<Libros> libros = db.Libros.Where(x => x.isbn == x.isbn)
                .OrderBy(x => x.isbn)
                .ToList();

            List<Categorias> categorias = db.Categorias.Where(x => x.id_cat == x.id_cat).ToList();
            ViewBag.categorias = categorias;

            return View(libros);
        }

        /// <summary>
        /// Busqueda Cotizacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Regresa un error 404 en caso de que la id(isbn) del libro no coincida con alguna cotización hecha</returns>
        public ActionResult Cotizacion(string id)
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

            List<Libro_tienda> libro_tienda = db.Libro_tienda.Where(x => x.isbnfk == id).ToList();
            ViewBag.libro_tienda = libro_tienda;

            List<Categorias> categorias = db.Categorias.Where(x => x.id_cat == x.id_cat).ToList();
            ViewBag.categorias = categorias;

            return View(libros);
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