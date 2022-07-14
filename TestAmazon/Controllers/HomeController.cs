﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAmazon.Models;

namespace TestAmazon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Prodotto.GetProdotti());
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
        public JsonResult GetCategorys()
        {
            var result = new JsonResult();
            result.Data = Categoria.GetCategorie();
            return Json(result);
        }
    }
}