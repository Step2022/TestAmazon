using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAmazon.Models;
using TestAmazon.Utility;
namespace TestAmazon.Controllers
{
    public class RicercaController : Controller
    {
        // GET: Ricerca
        public ActionResult Categorys()
        {
            long id_category = -1;
            string searchtest = null;
            bool flag = false;
            ViewBag.Categorie = Categoria.GetCategorie();
            if (Request.Params["searchCategory"] != null && RegularExp.IsInt(Request.Params["searchCategory"].ToString()))
            {
                id_category = long.Parse(Request.Params["searchCategory"].ToString());
                ViewBag.id_category = id_category;
                if (Request.Params["searchText"] != null)
                {
                    flag = true;
                    if (!string.IsNullOrWhiteSpace(Request.Params["searchText"].ToString())) {
                        searchtest = Request.Params["searchText"].ToString();
                    }
                    else
                    {
                        searchtest = "";
                    }
                    ViewBag.searchtext = searchtest;
                }
            }
            if (!flag)
            {
                return View(Prodotto.GetProdotti());
            }
            else
            {
                if(id_category == 0)
                {
                    //se l'id è 0 allora l'utente ha chiesto una ricerca su tutti i prodotti
                    return View(Prodotto.GetProdotti(searchtest));
                }
                else
                {
                    //entro qui se la ricerca va fatta su una categoria particolare
                    return View(Prodotto.GetProdotti(id_category, searchtest));
                }
                
            }
        }
    }
}