using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conexion.Models;

namespace DLPCliente.Controllers
{
    public class NosotrosController : Controller
    {
        LibroOnlineEntities db = new LibroOnlineEntities();

        /// <summary>
        /// Carga de Categorias
        /// </summary>
        /// <returns>regresa la viewbag categorias para desplegarse en el layout</returns>
        public ActionResult Nosotros()
        {
            List<Categorias> categorias = db.Categorias.Where(x => x.id_cat == x.id_cat).ToList();
            ViewBag.categorias = categorias;
            return View();
        }
    }
}