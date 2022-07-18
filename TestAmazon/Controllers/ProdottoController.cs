using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Mvc;
using TestAmazon.Models;
using TestAmazon.Utility;

namespace TestAmazon.Controllers
{
    public class ProdottoController : Controller
    {
        // GET: Prodotto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Singolo(long id)
        {
            if (Session["IdUtente"] != null) { 
                ViewBag.IdOrdine = Ordine.GetIdOrdine(long.Parse(Session["IdUtente"].ToString()));
            }
            return View(Prodotto.GetProdotto(id));
        }

        public ActionResult Add()
        {
            long IdUtente = long.Parse(Request.Params["IdUtente"]);
            long IdProdotto = long.Parse(Request.Params["IdProdotto"]);
            long IdProdottoFinale = IdProdotto;
            pref.AddPreferiti(IdUtente, IdProdotto);
            IdUtente = 0;
            IdProdotto = 0;
            return View("Singolo", Prodotto.GetProdotto(IdProdottoFinale));
        }

        public ActionResult RemovePreferiti(long IdUtente, long IdProdotto)
        {
            IdUtente = long.Parse(Request.Params["IdUtente"]);
            IdProdotto = long.Parse(Request.Params["IdProdotto"]);
            long IdProdottoFinale = IdProdotto;
            pref.RemovePreferiti(IdUtente, IdProdotto);
            IdUtente = 0;
            IdProdotto = 0;
            return View("Singolo", Prodotto.GetProdotto(IdProdottoFinale));
        }

        public ActionResult RemoveProduct()
        {
            long IdProdotto = long.Parse(Request.Params["IdProdotto"]);
            Prodotto.RemoveProdotto(IdProdotto);
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Buy(long idOrdine, long idProdotto, int quantita)
        {
            long IdOrdine = idOrdine;
            long IdProdotto = idProdotto;
            int Quantita = quantita;

            Carrello.AddInCarrello(IdOrdine, IdProdotto, Quantita);
            ViewBag.IdOrdine = IdOrdine;
            return View("Singolo", Prodotto.GetProdotto(IdProdotto));
        }

    }
}