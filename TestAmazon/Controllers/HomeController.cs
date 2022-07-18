using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAmazon.Models;
using TestAmazon.Utility;
namespace TestAmazon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int offset = 1;
            int numeroPagineTotali = (int)Math.Ceiling(((decimal)Prodotto.GetProdotti().Count) / 5);
            if (Request.Params["pag"] != null&&RegularExp.IsInt(Request.Params["pag"].ToString()) && int.Parse(Request.Params["pag"].ToString()) >0)
            {
                offset = int.Parse(Request.Params["pag"].ToString());
                if (offset > numeroPagineTotali)
                {
                    offset = numeroPagineTotali;
                }
            }
            ViewBag.pag = offset;
            ViewBag.NumeroPagine = numeroPagineTotali;
            if (TempData["ErrAggiunta"] != null)
            {
                ViewBag.Errore = TempData["ErrAggiunta"].ToString();
            }
            return View(Prodotto.GetProdotti(offset));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       

    }
}