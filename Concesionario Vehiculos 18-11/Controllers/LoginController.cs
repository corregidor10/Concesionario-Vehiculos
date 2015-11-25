using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Concesionario_Vehiculos_18_11.Models;

namespace Concesionario_Vehiculos_18_11.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario model)
        {
            if (Membership.ValidateUser(model.Login, model.Password))
            {
                Session["HoraLogin"] = DateTime.Now;
                FormsAuthentication.RedirectFromLoginPage(model.Login, false);
                return null;
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            Session.Clear(); // borra los datos de la sesion
            Session.Abandon(); // abandona la sesion
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }
    }
}