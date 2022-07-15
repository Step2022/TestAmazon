using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAmazon.Models;

namespace TestAmazon.Utility
    {
        public class pref
        {

            public static bool CheckPreferiti(long Id_Utente, long Id_Prodotto)
            {

                using (var db = new CorsoRoma2022Entities())
                {
                    var flag = (from Preferiti in db.Preferiti
                                where Preferiti.Id_Prodotto == Id_Prodotto && Preferiti.Id_Utente == Id_Utente
                                select Preferiti).FirstOrDefault();

                    if (flag == null)
                    {
                        return false;
                    }

                    else { return true; }

                }

            }


            public static string AddPreferiti(long id_utente, long id_prodotto)
            {
                Preferiti pref = new Preferiti();
                if (CheckPreferiti(id_utente, id_prodotto))
                {
                    using (var db = new CorsoRoma2022Entities())
                    {
                        pref.Id_Utente = id_utente;
                        pref.Id_Prodotto = id_prodotto;
                    
                        db.Preferiti.Add(pref);
                        db.SaveChanges();
                    }
                    var mess = "AGGIUNTO ALLA LISTA";
                    return mess;
                }
                else{
                    return "RIPETUTO";
                }
        }

            public static string RemovePreferiti(long id_utente, long id_prodotto)
            {
                using (var db = new CorsoRoma2022Entities())
                {

                var remove = (from Preferiti in db.Preferiti
                            where Preferiti.Id_Prodotto == id_prodotto && Preferiti.Id_Utente == id_utente
                              select Preferiti).FirstOrDefault();


                if (remove != null)
                    {
                        db.Preferiti.Remove(remove);
                        db.SaveChanges();
                    }

                }
                var mess = "CANCELLATO";
                return mess;

            }

        }
    }