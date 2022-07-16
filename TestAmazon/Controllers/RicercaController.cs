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
            //variabili di impaginazione
            int offset = 1;       
            int numeroPagineTotali = (int)Math.Floor(((decimal)Prodotto.GetProdotti().Count) / 5) + 1;
            //controlli
            if (Request.Params["pag"] != null && RegularExp.IsInt(Request.Params["pag"].ToString()) && int.Parse(Request.Params["pag"].ToString()) > 0)
            {
                offset = int.Parse(Request.Params["pag"].ToString());
                if (offset > numeroPagineTotali)
                {
                    offset = numeroPagineTotali;
                }
            }
            //invio dati alla pagina
            ViewBag.pag = offset;
            ViewBag.NumeroPagine = numeroPagineTotali;
            //invio categorie alla pagina
            ViewBag.Categorie = Categoria.GetCategorie();
            if (Request.Params["searchCategory"] != null && RegularExp.IsInt(Request.Params["searchCategory"].ToString()))
            {
                //se il parametro passato è valido
                id_category = long.Parse(Request.Params["searchCategory"].ToString());
                ViewBag.id_category = id_category;
                if (Request.Params["searchText"] != null)
                {
                    flag = true;
                    if (!string.IsNullOrWhiteSpace(Request.Params["searchText"].ToString())) {
                        //se il parametro passato non è uno spazio vuoto
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
                return View(Prodotto.GetProdotti(offset));
            }
            else
            {
                if(id_category == 0)
                {
                    //se l'id è 0 allora l'utente ha chiesto una ricerca su tutti i prodotti
                    return View(Prodotto.GetProdotti(searchtest,offset));
                }
                else
                {
                    //entro qui se la ricerca va fatta su una categoria particolare
                    return View(Prodotto.GetProdotti(id_category, searchtest,offset));
                }
                
            }
        }
    }
}