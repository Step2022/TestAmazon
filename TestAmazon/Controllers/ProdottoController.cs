using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAmazon.Models;
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
            ViewBag.Message = "Pagina del prodotto singolo.";

            return View(Prodotto.GetProdotto(id));
        }

    }
}