using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAmazon.Controllers
{
    public class ProdottoController : Controller
    {
        // GET: Prodotto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Singolo()
        {
            ViewBag.Message = "Pagina del prodotto singolo.";

            return View();
        }

    }
}