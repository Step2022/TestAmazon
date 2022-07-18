using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;
using TestAmazon.Utility;
using TestAmazon.Models;



namespace TestAmazon.Controllers

{

    public class PreferitiController : Controller

    {

 
        public ActionResult Preferiti(long id)
        {
            //LOADING PAGINA PREFERITI
            if (Session["IdUtente"] == null)
            {
                return RedirectToAction("index", "Home");
            }
            else

            {
                return View(PreferitiPartial.GetPreferiti(id));
            }
        }

 
        public ActionResult RemovePreferiti(long IdUtente, long IdProdotto)
        {
            IdUtente = long.Parse(Request.Params["IdUtente"]);
            IdProdotto = long.Parse(Request.Params["IdProdotto"]);
            long IdProdottoFinale = IdUtente;
            pref.RemovePreferiti(IdUtente, IdProdotto);
            IdUtente = 0;
            IdProdotto = 0;
            return View("Preferiti", PreferitiPartial.GetPreferiti(IdProdottoFinale));
        }

        public ActionResult AggiungiCarrello(long IdUtente, long IdProdotto)
        {
            IdUtente = long.Parse(Request.Params["IdUtente"]);
            IdProdotto = long.Parse(Request.Params["IdProdotto"]);
            int Quantita = 1;
            long IdOrdine = Ordine.GetIdOrdine(IdUtente);
            Carrello.AddInCarrello(IdOrdine, IdProdotto, Quantita);
            return View("Preferiti", PreferitiPartial.GetPreferiti(IdUtente));
        }



    }

}