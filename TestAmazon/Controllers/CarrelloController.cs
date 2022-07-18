using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAmazon.Models;
using TestAmazon.Utility;

namespace TestAmazon.Controllers
{
    public class CarrelloController : Controller
    {
        public ActionResult CarrelloUtente()
        {
            long idOrdine = Ordine.GetIdOrdine(long.Parse(Session["IdUtente"].ToString()));
            ViewBag.preferiti = PreferitiPartial.GetPreferiti(long.Parse(Session["IdUtente"].ToString()));
            ViewBag.prodotti = Carrello.GetCarrello(idOrdine);
            ViewBag.quantita = Carrello.GetQuantita(idOrdine);
            ViewBag.idOrdine = idOrdine;
            return View();
        }
        public ActionResult AddPreferito(long idUtente, long idProdotto)
        {
            pref.AddPreferiti(idUtente, idProdotto);
            return RedirectToAction("CarrelloUtente");
        }
        public ActionResult RemovePreferito(long idUtente, long idProdotto)
        {
            pref.RemovePreferiti(idUtente, idProdotto);
            return RedirectToAction("CarrelloUtente");
        }
        public ActionResult RemoveFromCarrello(long idOrdine, long idProdotto, int quantita)
        {
            Carrello.RemoveFromCarrello(idOrdine, idProdotto, quantita);
            return RedirectToAction("CarrelloUtente");
        }
        public ActionResult Acquista(long idOrdine)
        {
            Ordine.SetOrdine(idOrdine);
            return RedirectToAction("CarrelloUtente");
        }
    }
}