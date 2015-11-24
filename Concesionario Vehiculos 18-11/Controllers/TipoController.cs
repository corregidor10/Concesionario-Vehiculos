using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Concesionario_Vehiculos_18_11.Models;

namespace Concesionario_Vehiculos_18_11.Controllers
{
    public class TipoController : Controller
    {
        private Concesionario20Entities db= new Concesionario20Entities();

        // GET: Tipo
        public ActionResult Index()
        {
            var data = db.Tipo;
            ViewBag.losvehiculos = db.Vehiculo;

            return View(data);
        }


        public ActionResult Detalle(int id)
        {
            var data = db.Vehiculo.Where(o=>o.IdTipo==id);

            return View(data);
        }
        [OutputCache(Duration = 0, VaryByParam = "*")]
        public ActionResult BuscarMarca(String marca)
        {
            var coche = db.Vehiculo.Where(o => o.Marca.Contains(marca));

            return PartialView("_listadoVehiculos", coche);

        }
        [OutputCache(Duration = 0, VaryByParam = "*")]
        public ActionResult BuscarMatricula (String matricula)
        {
            var coche = db.Vehiculo.Where(o => o.Matricula.Contains(matricula));

            return PartialView("_listadoVehiculos", coche);

        }

        public ActionResult Modificar(int id)
        {
            Tipo tp = db.Tipo.Find(id);
            if (tp==null)
            {
                return RedirectToAction("Index");
            }
            return View(tp);
        }

        [HttpPost]
        public ActionResult Modificar(Tipo tp)
        {
            if (ModelState.IsValid)
            {
             db.Entry(tp).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tp);
        }

    }
}