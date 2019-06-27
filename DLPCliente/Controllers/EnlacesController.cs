using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conexion.Models;

namespace DLPCliente.Controllers
{
    public class EnlacesController : Controller
    {
        private LibroOnlineEntities db = new LibroOnlineEntities();


        /// <summary>
        /// Listar tiendas y categorias
        /// </summary>
        /// <returns>Crea una lista de tiendas para desplegarse en la view, y ademas carga una viewbag de categorias para desplegarse en el layout, como en todos los controladores</returns>
        public ActionResult Enlaces()
        {
            List<Tiendas> tiendas = db.Tiendas.Where(x => x.id_tienda == x.id_tienda)
                .OrderBy(x => x.id_tienda)
                .ToList();

            List<Categorias> categorias = db.Categorias.Where(x => x.id_cat == x.id_cat).ToList();
            ViewBag.categorias = categorias;

            return View(tiendas);
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