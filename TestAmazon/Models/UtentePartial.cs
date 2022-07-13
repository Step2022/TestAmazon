﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TestAmazon.Models
{
    public partial class UtentePartial
    {
        public static object Session { get; private set; }

        public static bool AddUtente(Utente utente)
        {

            using (var context = new CorsoRoma2022Entities())
            {
                try
                {
                    if (CheckEmail(utente.Email) && context.Utente.FirstOrDefault(x => x.Email == utente.Email) != null)
                    {
                        utente.Id_Ruolo = 1;
                        context.Utente.Add(utente);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        private static bool CheckEmail(string email)
        {
            Regex regex = new Regex("([\\w-+]+(?:\\.[\\w-+]+)*@(?:[\\w-]+\\.)+[a-zA-Z]{2,7})");
            return regex.IsMatch(email);
        }


        public static List<Utente> GetAllUtenti()
        {
            using (var context = new CorsoRoma2022Entities())
            {
                return context.Utente.ToList();
            }
        }


        public static bool CheckLogin(Utente utente)
        {
            using (var context = new CorsoRoma2022Entities())
            {
                return (context.Utente.FirstOrDefault(x => x.Email == utente.Email && x.Password == utente.Password) != null) ? true : false;

            }
        }

        public static string GetRuolobyId(int idutente)
        {
            using (var context = new CorsoRoma2022Entities())
            {
                var query = context.Utente.Where(x => x.Id_Utente == idutente).Join(context.Ruolo,
                                                 a => a.Id_Ruolo,
                                                 b => b.Id_Ruolo,
                                                 (a, b) => new { b.Nome_ruolo }).FirstOrDefault();
                return query.Nome_ruolo.ToString();
            }
        }

        public static Utente GetUtentebyEmail(string email)
        {
            using (var context = new CorsoRoma2022Entities())
            {
                return context.Utente.FirstOrDefault(x => x.Email == email);
            }








        }
    }
}