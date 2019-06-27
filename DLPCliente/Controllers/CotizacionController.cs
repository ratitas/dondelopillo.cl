using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Conexion.Models;

namespace DLPCliente.Controllers
{
    public class CotizacionController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();

        //Get: Cotizacion, ademas, llama a categorias para poder cargarlas en el layout
        /// <summary>
        /// Carga libros, y libro tiendas
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns>crea Viewbag de categorias y libro_tienda para poder cargar en cotizacion, ademas de los datos de libro.</returns>
        public ActionResult Cotizacion(string isbn)
        {
            List<Libros> libros = db.Libros.Where(y => y.isbn == y.isbn).ToList();

            List<Libro_tienda> libro_tienda = db.Libro_tienda.Where(x => x.isbnfk == x.isbnfk).ToList();
            ViewBag.libro_tienda = libro_tienda;

            List<Categorias> categorias = db.Categorias.Where(z => z.id_cat == z.id_cat).ToList();
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