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
            //Funzione che restituisce i prodotti del carrello associato ad un ordine specifico
            List<Prodotto> prodotti = new List<Prodotto>();
            using (var db = new CorsoRoma2022Entities())
            {
                //Effettua un controllo sull'ordine per vedere se non è acquistato,
                //solo in quel caso riempe la lista con i prodotti
                if (!db.Ordine.Where(i => i.Id_Ordine == idOrdine)
                    .Select(i => i.Acquistato).FirstOrDefault())
                    prodotti.AddRange(db.Carrello.Where(i => i.Id_Ordine == idOrdine)
                        .Join(db.Prodotto, car => car.Id_Prodotto, prod => prod.Id_Prodotto, (car, prod) => prod));
            }
            return prodotti;
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
        public static void RemoveFromCarrello(long idOrdine, long idProdotto)
        {
            //Funzione che rimuove un elemento dal carrello di un ordine specifico
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