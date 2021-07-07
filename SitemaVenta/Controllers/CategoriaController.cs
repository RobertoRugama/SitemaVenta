using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitemaVenta.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaNeg objCategoriaNeg;

        public CategoriaController(){
            objCategoriaNeg = new CategoriaNeg();
        }
        // GET: Categoria
        public ActionResult Index()
        {
            List<Categoria> ListarCategoria = objCategoriaNeg.FindAll();
            return View(ListarCategoria);
        }

        [HttpGet]
        public ActionResult Create() {
            MostrarMensajeInicio();
            return View();        
        }

        private void MostrarMensajeInicio()
        {
            ViewBag.MensajeInicio = "Ingrese Datos de la Categoria y clic en Guardar";
        }

        public ActionResult Create(Categoria objCategoria) {
            ModelState.Clear();
            MostrarMensajeInicio();
            objCategoriaNeg.Create(objCategoria);
            MensajeErrorRegistrar(objCategoria);

            return View("Create");
        }

        private void MensajeErrorRegistrar(Categoria objCategoria)
        {
            switch (objCategoria.Estado) {
                case 10:
                    ViewBag.MensajeError ="Debe agregar un nombre a la categoria";
                    break;
                case 1:
                    ViewBag.MensajeError = "No se permiten mas de 30 caracter en el campo Nombre  de la categoria";
                    break;

                case 20:
                    ViewBag.MensajeError = "Debe agregar una descripcion a la categoria";
                    break;
                case 2:
                    ViewBag.MensajeError = "ha Sobre pasado el maximo de caracteres";
                    break;
                        case 3:
                    ViewBag.MensajeError ="Ya existe una categoria con el nombre [ "+objCategoria.Nombre+" ]";
                    break;
                case 99:
                    ViewBag.MensajeError = "La Categoria [ " + objCategoria.Nombre + "] fue registrada Con exito";
                    break;
            }
        }
    }
}