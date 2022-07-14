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
            long idOrdine = Ordine.GetIdOrdine(1/*(long)Session["IdUtente"]*/);
            ViewBag.preferiti = PreferitiPartial.GetPreferiti(1/*(long)Session["IdUtente"]*/);
            return View(Carrello.GetCarrello(idOrdine));
        }
    }
}