using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conexion.Models;

namespace DLPCliente.Controllers
{
    public class FAQController : Controller
    {
        LibroOnlineEntities db = new LibroOnlineEntities();
        // GET: FAQ
        /// <summary>
        /// Carga Categorias
        /// </summary>
        /// <returns>Crear viewbag de categorias la cual es usada en el layout</returns>
        public ActionResult FAQ()
        {
            List<Categorias> categorias = db.Categorias.Where(x => x.id_cat == x.id_cat).ToList();
            ViewBag.categorias = categorias;
            return View();
        }
    }
}