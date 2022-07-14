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
            return prodotti;
        }
        public static void AddInCarrello(long idOrdine, long idProdotto, int quantita)
        {
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
        public static void RemoveFromCarrello(long idOrdine, long idProdotto)
        {
            using(var db = new CorsoRoma2022Entities())
            {
                Carrello car = db.Carrello.SingleOrDefault(c => c.Id_Ordine == idOrdine && c.Id_Prodotto == idProdotto);
                if (car != null) {
                    db.Carrello.Remove(car);
                    db.SaveChanges();
                }
            }
        }
    }
}