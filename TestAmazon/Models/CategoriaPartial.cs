using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAmazon.Models
{
    public partial class Categoria
    {
        public static List<Categoria> GetCategorie()
        {
            List<Categoria> categorie = new List<Categoria>();
            using(CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                categorie.AddRange(db.Categoria);
            }
            return categorie;
        }
    }
}