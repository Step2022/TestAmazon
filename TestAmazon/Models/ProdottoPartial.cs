using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAmazon.Models
{



    public partial class Prodotto
    {
        public string nomecat { get; set; }
        
        public static List<Prodotto> GetProdotti()
        {
            //Questa funzione restituisce tutti i prodotti dal db che non sono stati cancellati
            List<Prodotto> list = new List<Prodotto>();
            using (CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                list.AddRange(db.Prodotto.Where(x=>x.Cancellato==false));
            }
            return list;
        }
        public static List<Prodotto> GetProdotti(string categoria)
        {
            //Questa funzione restituisce tutti i prodotti dal db che non sono stati cancellati
            // E che corrispondono alla categoria passata
            List<Prodotto> list = new List<Prodotto>();
            using (CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                list.AddRange(from prodotto in db.Prodotto
                              where prodotto.Cancellato == false
                              join cat in db.Categoria on prodotto.Id_Categoria equals cat.Id_Categoria
                              where cat.Nome_cat == categoria
                              select prodotto);
            }
            return list;
        }
        public static List<Prodotto> GetProdotti(long id_categoria) {
            //Questa funzione restituisce tutti i prodotti dal db che non sono stati cancellati
            // E che corrispondono all'id della categoria passata
            List<Prodotto> list = new List<Prodotto>();
            using (CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                list.AddRange(list.Where(x=>x.Cancellato==false && x.Id_Categoria==id_categoria));
            }
            return list;
        }
        public static List<Prodotto> GetProdotti(List<long> id_categorie)
        {
            //Questa funzione restituisce tutti i prodotti dal db che non sono stati cancellati
            // E che corrispondono all'id di almeno una delle categorie passate
            List<Prodotto> list = new List<Prodotto>();
            using (CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                list.AddRange(list.Where(x => x.Cancellato == false && id_categorie.Contains(x.Id_Categoria)));
            }
            return list;
        }
        public static Prodotto GetProdotto(long id_prodotto)
        {
            //Questa funziona restituisce il prodotto del db che corrisponde all'id passato
            Prodotto prodotto = new Prodotto();
            using(CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                prodotto= db.Prodotto.FirstOrDefault(x=>x.Id_Prodotto==id_prodotto);
            }
            return prodotto;
        }
        public static bool RemoveProdotto(long id_prodotto)
        {
            //questa funziona restituisce true se il prodotto è stato eliminato o false se non lo è stato
            bool esito = false;
            using(CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                if (db.Prodotto.FirstOrDefault(x => x.Id_Prodotto == id_prodotto) != null)
                {
                    //Eliminazione logica
                    db.Prodotto.FirstOrDefault(x => x.Id_Prodotto == id_prodotto).Cancellato = true;
                    esito = true;
                }
            }
            return esito;
        }
    }
}