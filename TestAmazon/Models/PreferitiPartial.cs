using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAmazon.Models
{
    public partial class PreferitiPartial
    {

        //Funzione per aggiungere preferiti a db
        public static void AddPreferiti(long id_utente, long id_prodotto)
        {
            Preferiti pref = new Preferiti();
            using (var db = new CorsoRoma2022Entities())
            {
                pref.Id_Utente = id_utente;
                pref.Id_Prodotto = id_prodotto;
                db.Preferiti.Add(pref);
                db.SaveChanges();
            }

        }

        public static List<Prodotto> GetPreferiti(long id_utente)
        {

            List<Prodotto> lista = new List<Prodotto>();
            using (var db = new CorsoRoma2022Entities())
            {
                lista.AddRange (from Prodotto in db.Prodotto
                         join Preferiti in db.Preferiti on Prodotto.Id_Prodotto equals Preferiti.Id_Prodotto
                         join Utente in db.Utente on Preferiti.Id_Utente equals Utente.Id_Utente
                         where Prodotto.Id_Prodotto == Preferiti.Id_Preferiti && Utente.Id_Utente == Preferiti.Id_Utente
                         select Prodotto);

            }

            return lista;
        }

        public static void RemovePreferiti(long id_utente,long id_prodotto)
        {
            using (var db = new CorsoRoma2022Entities())
            {
                var remove = (from Prodotto in db.Prodotto
                              join Preferiti in db.Preferiti on Prodotto.Id_Prodotto equals Preferiti.Id_Prodotto
                              join Utente in db.Utente on Preferiti.Id_Utente equals Utente.Id_Utente
                              where Prodotto.Id_Prodotto == Preferiti.Id_Preferiti && Utente.Id_Utente == Preferiti.Id_Utente
                              select Preferiti).FirstOrDefault();

                if(remove != null)
                {
                    db.Preferiti.Remove(remove);
                    db.SaveChanges();
                }

            }
            

        }


    }
}