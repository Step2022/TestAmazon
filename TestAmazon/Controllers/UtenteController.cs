using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using TestAmazon.Models;
using TestAmazon.Utility;
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
                ViewBag.Login = "Registrazione effetuta corretamente!";
                return RedirectToAction("Login");
               

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
                var ut = UtentePartial.GetUtentebyEmail(utente.Email);


                Session["U"] = Utility.SerDes.Serialize(ut);
              //  var a = Utility.SerDes.DeSerialize<Utente>(Session["U"].ToString());
                Session["Utente"] = $"{ut.Nome} {ut.Cognome}";
                Session["Ruolo"] = UtentePartial.GetRuolobyId((int)ut.Id_Utente);
                Session["IdUtente"] = ut.Id_Utente.ToString();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Errore = "Errore durante il Login! I campi inseriti non sono validi";
                return View();
            }
        }



        public ActionResult Logout()
        {

            Session.Remove("Utente");
            Session.Remove("Ruolo");
            Session.Remove("IdUtente");
            Session.Remove("U");
            return RedirectToAction("Index","Home");
        }
        //creare view con la gestione di tutti utenti

        //[Authorize()]
        public ActionResult GestioneUtenti()
        {
            if (Session["Ruolo"] != null && Session["Ruolo"].ToString() == "admin")
            {
                ViewBag.Ruolo = "";
               // UtentePartial.GetAllUtenti();
                return View(UtentePartial.GetAllUtenti());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]
        public ActionResult GestioneUtenti(Utente utente)
        {
            if (Session["Ruolo"] != null && Session["Ruolo"].ToString() == "admin")
            {
                var l = UtentePartial.RicercaUtenti(utente);
                // UtentePartial.GetAllUtenti();
                return View(l);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Delete(long id)
        {
            ViewBag.Success =UtentePartial.RemoveUtentebyId(id) ? "Utente eliminato corretamente" : "Errore nell 'eliminazione Utente";
            return View("GestioneUtenti",UtentePartial.GetAllUtenti());
        }
        
        public ActionResult Details(long id)
        {
            
            return View(UtentePartial.GetUtenteById(id));
        }
        [HttpGet]
        public ActionResult Recupera()
        {
            return View();
            //da implementare
        }
        [HttpPost]
        public ActionResult Recupera(Utente ut,string pass)
        {
            ViewBag.Rec = UtentePartial.RecuperaPassword(ut.Email, ut.Password,pass) ? "Nuova password impostata corretamente " : "Errore nell' impostazione della nuova password ! riprovare";
            return View();
         
        }




    }
}