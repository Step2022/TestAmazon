using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TestAmazon.Models
{
    public partial class Carrello
    {
        public static List<Prodotto> GetCarrello(long idOrdine)
        {
            List<Prodotto> prodotti = new List<Prodotto>();
            using (var db = new CorsoRoma2022Entities())
            {
                prodotti.AddRange(db.Carrello.Where(c => c.Id_Ordine == idOrdine)
                    .Join(db.Prodotto, c => c.Id_Prodotto, p => p.Id_Prodotto, (c, p) => p));
            }
            return prodotti.Distinct().ToList();
        }

        public static List<Carrello> GetQuantita(long idOrdine)
        {
            List<Carrello> car = new List<Carrello>();
            using(var db = new CorsoRoma2022Entities())
            {
                car.AddRange(db.Carrello.Where(c => c.Id_Ordine == idOrdine));
            }
            var quantita = (from c in car
                           group c.Quantita by c.Id_Prodotto into groupcar
                           select new Carrello()
                           {
                               Id_Prodotto = groupcar.Key,
                               Quantita = groupcar.Sum()
                           }).ToList();
            return quantita;
        }
        public static void AddInCarrello(long idOrdine, long idProdotto, int quantita)
        {
            //funzione che aggiunge un nuovo elemento nel carrello di un ordine specifico
            Carrello carr = new Carrello();
            carr.Id_Ordine = idOrdine;
            carr.Id_Prodotto = idProdotto;
            carr.Quantita = quantita;
            using(var db = new CorsoRoma2022Entities())
            {
                db.Carrello.Add(carr);
                db.SaveChanges();
            }
        }
        public static void RemoveFromCarrello(long idOrdine, long idProdotto, int quantita)
        {
            //Funzione che rimuove un elemento dal carrello di un ordine specifico
            using(var db = new CorsoRoma2022Entities())
            {
                Carrello car = db.Carrello.FirstOrDefault(c => c.Id_Ordine == idOrdine && c.Id_Prodotto == idProdotto);
                if (car != null) {
                    if(car.Quantita > 1 && car.Quantita == quantita || car.Quantita == 1)
                    {
                        db.Carrello.Remove(car);
                        db.SaveChanges();
                    }
                    else
                    {
                        car.Quantita -= quantita;
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}