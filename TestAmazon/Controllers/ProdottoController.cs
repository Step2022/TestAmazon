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

            return View(Prodotto.GetProdotto(id));
        }

        public ActionResult Add()
        {
            long IdUtente = long.Parse(Request.Params["IdUtente"]);
            long IdProdotto = long.Parse(Request.Params["IdProdotto"]);
            pref.AddPreferiti(IdUtente, IdProdotto);
            return View("Singolo", Prodotto.GetProdotto(IdProdotto));
        }
        public ActionResult Remove()
        {
            long IdUtente = long.Parse(Request.Params["IdUtente"]);
            long IdProdotto = long.Parse(Request.Params["IdProdotto"]);
            pref.RemovePreferiti(IdUtente, IdProdotto);
            return View("Singolo", Prodotto.GetProdotto(IdProdotto));
        }

        public ActionResult Buy()
        {
            long IdUtente = long.Parse(Request.Params["IdUtente"]);
            long IdProdotto = long.Parse(Request.Params["IdProdotto"]);
            return View("Singolo", Prodotto.GetProdotto(IdProdotto));
        }
    }
}