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
            long idOrdine = Ordine.GetIdOrdine(long.Parse(Session["IdUtente"].ToString()));
            ViewBag.preferiti = PreferitiPartial.GetPreferiti(long.Parse(Session["IdUtente"].ToString()));
            
            return View(Carrello.GetCarrello(idOrdine));
        }
    }
}