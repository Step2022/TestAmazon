using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAmazon.Models
{
    public partial class Ordine
    {
        public static void AddOrdine(int idUtente)
        {
            Ordine ord = new Ordine();
            ord.Acquistato = false;

            using(var db = new CorsoRoma2022Entities())
            {
                ord.Id_Utente = idUtente;
                db.Ordine.Add(ord);
                db.SaveChanges();
            }
        }

        public static void SetOrdine(int idOrdine)
        {
            using(var db = new CorsoRoma2022Entities())
            {
                Ordine ord = db.Ordine.SingleOrDefault(o => o.Id_Ordine == idOrdine);
                if (ord != null)
                {
                    ord.Acquistato = true;
                    db.SaveChanges();
                }
            }
        }
    }
}