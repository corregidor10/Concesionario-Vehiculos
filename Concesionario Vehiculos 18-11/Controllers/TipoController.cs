using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Concesionario_Vehiculos_18_11.Models;

namespace Concesionario_Vehiculos_18_11.Controllers
{
    [Authorize]
    public class TipoController : Controller
    {
        private Concesionario20Entities db= new Concesionario20Entities();

        // GET: Tipo
        public ActionResult Index()
        {
         
            return View(db.Tipo.ToList());
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

        public ActionResult Alta()
        {
            return View(new Tipo());
        }

        [HttpPost]
        public ActionResult Alta(Tipo model)
        {
            if (ModelState.IsValid)
            {
                db.Tipo.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}