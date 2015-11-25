using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Concesionario_Vehiculos_18_11.Models;

namespace Concesionario_Vehiculos_18_11.Controllers
{
    [Authorize]
    public class VehiculoController : Controller
    {
        Concesionario20Entities db= new Concesionario20Entities();

        // GET: Vehiculo
        public ActionResult Index(int id)
        {
            ViewBag.idTipo = id;
            var data = db.Vehiculo.Where(o => o.IdTipo == id);

            return View(data);
        }

        public ActionResult Buscar(int idTipo, int campo, String contenido)
        {
            var data = db.Vehiculo.Where(o => o.IdTipo == idTipo); // var data es un iqueryable, con lo cual podemos hacer consultas posteriormente

            if (campo == 1)
            {
                data = data.Where(o => o.Matricula.Contains(contenido));
            }

            else
            {
                data = data.Where(o => o.Marca.Contains(contenido));
            }

            return PartialView("_listadoVehiculos", data.ToList()); // hasta que no ejecutamos el toList no se ejecuta la consulta
        }

        [HttpPost]
        public ActionResult Alta(Vehiculo model)
        {
            db.Vehiculo.Add(model);
            db.SaveChanges();
            return Json(model);
        }
    }
}