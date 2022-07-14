using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAmazon.Models;

namespace TestAmazon.Controllers
{
    public class CarrelloController : Controller
    {
        public ActionResult CarrelloUtente()
        {
            //Utente utente = (Utente)Session["utente"];
            long idOrdine = Ordine.GetIdOrdine(1);
            ViewBag.idOrdine = idOrdine;
            return View(Carrello.GetCarrello(idOrdine));
        }
    }
}