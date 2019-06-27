using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conexion.Models;

namespace DLPCliente.Controllers
{
    public class ContactoController : Controller
    {
        LibroOnlineEntities db = new LibroOnlineEntities();
        // GET: Contacto, ademas, llama a categorias para poder cargarlas en el layout
        /// <summary>
        /// Carga de categorias
        /// </summary>
        /// <returns>Datos de Categorias en el layout</returns>
        public ActionResult Contacto()
        {

            List<Categorias> categorias = db.Categorias.Where(x => x.id_cat == x.id_cat).ToList();
            ViewBag.categorias = categorias;
            return View();
        }


    }
}