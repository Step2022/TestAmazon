using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAmazon.Models;

namespace TestAmazon.Controllers
{
    public class UtenteController : Controller
    {
        // GET: Utente
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Utente utente)
        {

            if (UtentePartial.AddUtente(utente))
            {
                //return RedirectToAction("Index", "Home");
                return View("Login");

            }
            else
            {
                ViewBag.Errore = "Errore durante la registrazione! riprovare";
               return View();
            }
          

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utente utente)
        {
          if(UtentePartial.CheckLogin(utente))
            {
                Session["Utente"] = utente;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Errore = "Errore durante il Login! I campi inseriti non sono validi";
                return View();
            }
        }
    }
}