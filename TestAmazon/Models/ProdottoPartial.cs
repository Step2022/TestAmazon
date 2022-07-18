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
                list.AddRange(db.Prodotto.Where(x => x.Cancellato == false));

            }
            return list;
        }
        public static List<Prodotto> GetProdotti(int offset)
        {
            if (offset <1)
            {
                offset = 1;
            }
            //Questa funzione restituisce tutti i prodotti dal db che non sono stati cancellati
            List<Prodotto> list = new List<Prodotto>();
            using (CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                list.AddRange(db.Prodotto.Where(x=>x.Cancellato==false).OrderBy(x=>x.Id_Prodotto).Skip((offset-1)*5).Take(5));
    
            }
            return list;
        }
        public static List<Prodotto> GetProdotti(long id_category)
        {
            
            //Questa funzione restituisce tutti i prodotti dal db che non sono stati cancellati e corrispondenti alla categoria richiesta
            List<Prodotto> list = new List<Prodotto>();
            using (CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                list.AddRange(db.Prodotto.Where(x => x.Id_Categoria == id_category && x.Cancellato==false));

            }
            return list;
        }
        public static List<Prodotto> GetProdotti(string nome,int offset)
        {
            if (offset < 1)
            {
                offset = 1;
            }
            //Questa funzione restituisce tutti i prodotti dal db che non sono stati cancellati
            // E che corrispondono alla categoria passata
            List<Prodotto> list = new List<Prodotto>();
            using (CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                list.AddRange(db.Prodotto.Where(x => x.Cancellato == false&& x.Nome.Contains(nome)).OrderBy(x => x.Id_Prodotto).Skip((offset - 1) * 5).Take(5));
            }
            return list;
        }
        public static List<Prodotto> GetProdotti(string nome)
        {
            
            //Questa funzione restituisce tutti i prodotti dal db che non sono stati cancellati
            // E che corrispondono alla categoria passata
            List<Prodotto> list = new List<Prodotto>();
            using (CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                list.AddRange(db.Prodotto.Where(x => x.Cancellato == false && x.Nome.Contains(nome)));
            }
            return list;
        }
        public static List<Prodotto> GetProdotti(long id_categoria, int offset) {//non è possibile ricercare per categoria senza offset poiché potrebbe andare in conflitto con la ricerca solo con offset
            if (offset < 1)
            {
                offset = 1;
            }
            //Questa funzione restituisce tutti i prodotti dal db che non sono stati cancellati
            // E che corrispondono all'id della categoria passata
            List<Prodotto> list = new List<Prodotto>();
            using (CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                list.AddRange(list.Where(x=>x.Cancellato==false && x.Id_Categoria==id_categoria).OrderBy(x => x.Id_Prodotto).Skip((offset - 1) * 5).Take(5));
            }
            return list;
        }
        public static List<Prodotto> GetProdotti(long id_categoria, string nome,int offset)
        {
            if (offset < 1)
            {
                offset = 1;
            }
            //Questa funzione restituisce i primi 5 prodotti dopo l'offset dal db che non sono stati cancellati
            // E che corrispondono all'id della categoria passata
            List<Prodotto> list = new List<Prodotto>();
            bool emptySearch = string.IsNullOrEmpty(nome);
            using (CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                if (emptySearch)
                {
                    list.AddRange(db.Prodotto
                        .Where(x => x.Cancellato == false
                        && x.Id_Categoria == id_categoria).OrderBy(x => x.Id_Prodotto).Skip((offset - 1) * 5).Take(5));
                }
                else
                {
                    list.AddRange(db.Prodotto
                        .Where(x => x.Cancellato == false
                        && x.Id_Categoria == id_categoria
                        && x.Nome.Contains(nome)).OrderBy(x => x.Id_Prodotto).Skip((offset - 1) * 5).Take(5));
                }
            }
            return list;
        }
        public static List<Prodotto> GetProdotti(long id_categoria, string nome)
        {
            
            //Questa funzione restituisce tutti i prodotti dal db che non sono stati cancellati
            // E che corrispondono all'id della categoria passata
            List<Prodotto> list = new List<Prodotto>();
            bool emptySearch = string.IsNullOrEmpty(nome);
            using (CorsoRoma2022Entities db = new CorsoRoma2022Entities())
            {
                if (emptySearch)
                {
                    list.AddRange(db.Prodotto
                        .Where(x => x.Cancellato == false
                        && x.Id_Categoria == id_categoria));
                }
                else
                {
                    list.AddRange(db.Prodotto
                        .Where(x => x.Cancellato == false
                        && x.Id_Categoria == id_categoria
                        && x.Nome.Contains(nome)));
                }
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
                    db.SaveChanges();
                }
            }
            return esito;
        }
    }
}