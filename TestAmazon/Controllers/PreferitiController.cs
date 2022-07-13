using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAmazon.Models;

namespace TestAmazon.Controllers
{
    public class PreferitiController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Preferiti(long id)
        {
            
            return View(PreferitiPartial.GetPreferiti(id));
        }

        public ActionResult Remove(long id_utente,long id_prodotto)
        {


            string ciao = PreferitiPartial.RemovePreferiti(id_utente, id_prodotto);

            return View("Preferiti");
            
        }

    }
}