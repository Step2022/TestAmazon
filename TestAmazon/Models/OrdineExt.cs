using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAmazon.Models
{
    public partial class Ordine
    {
        public static long GetIdOrdine(long idUtente)
        {
            long idOrdine = 0;
            using (var db = new CorsoRoma2022Entities())
            {
                var ord = db.Ordine.FirstOrDefault(i => i.Id_Utente == idUtente && i.Acquistato == false);
                if (ord == null)
                {
                    idOrdine = AddOrdine(idUtente, db);
                }
                else
                {
                    idOrdine = ord.Id_Ordine;
                }
                
            }
            return idOrdine;
        }
        public static long AddOrdine(long idUtente, CorsoRoma2022Entities db)
        {
            //Funzione che crea un nuovo ordine associandolo ad un utente specifico
            Ordine ord = new Ordine();
            ord.Acquistato = false;
            ord.Id_Utente = idUtente;
            db.Ordine.Add(ord);
            db.SaveChanges();
            return ord.Id_Ordine;
        }

        public static void SetOrdine(long idOrdine)
        {
            //Funzione che contrassegna come acquistato un ordine specifico
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