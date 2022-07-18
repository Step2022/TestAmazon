using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TestAmazon.Models
{
    public partial class UtentePartial
    {
        public long Id_Utente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Id_Ruolo { get; set; }
        //public static object Session { get; private set; }



        public static bool AddUtente(Utente utente)
        {

            using (var context = new CorsoRoma2022Entities())
            {
                try
                {
                    if (CheckEmail(utente.Email) && context.Utente.FirstOrDefault(x => x.Email == utente.Email) == null && CheckPassword(utente.Password))
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

        public static bool AddAmministratore(Utente utente)
        {

            using (var context = new CorsoRoma2022Entities())
            {
                try
                {
                    if (CheckEmail(utente.Email) && context.Utente.FirstOrDefault(x => x.Email == utente.Email) == null)
                    {
                        utente.Id_Ruolo = 2;
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
        private static bool CheckPassword(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            return (hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password));
        }

        public static List<Utente> GetAllUtenti()
        {
            using (var context = new CorsoRoma2022Entities())
            {
                return context.Utente.ToList().Join(context.Ruolo.ToList(),
                                                 a => a.Id_Ruolo,
                                                 b => b.Id_Ruolo,
                                                 (a, b) => new Utente()
                                                 {
                                                     Id_Utente = a.Id_Utente,
                                                     Id_Ruolo = a.Id_Ruolo,
                                                     Nome = a.Nome,
                                                     Cognome = a.Cognome,
                                                     Email = a.Email,
                                                     Password = a.Password,
                                                     Ruolo = b
                                                 }).OrderBy(x => x.Nome).ToList();
            }
        }

        public static bool CheckLogin(Utente utente)
        {
            using (var context = new CorsoRoma2022Entities())
            {
                return (context.Utente.FirstOrDefault(x => x.Email.ToLower() == utente.Email.ToLower() && x.Password == utente.Password) != null) ? true : false;

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
                return context.Utente.ToList().Where(x => x.Email == email).Select(x => new Utente() { Nome = x.Nome, Cognome = x.Cognome, Email = x.Email, Password = x.Password, Id_Ruolo = x.Id_Ruolo, Id_Utente = x.Id_Utente }).FirstOrDefault();

                #region commento
                //  return context.Utente.FirstOrDefault(x => x.Email == email);
                /*      return context.Utente.ToList().Where(x => x.Email == email).Join(context.Ruolo.ToList(),
                                                          a => a.Id_Ruolo,
                                                          b => b.Id_Ruolo,
                                                          (a, b) => new Utente()
                                                          {
                                                              Nome = a.Nome,
                                                              Cognome = a.Cognome,
                                                              Email = a.Email,
                                                              Password = a.Password,
                                                              Id_Ruolo=a.Id_Ruolo,
                                                              Id_Utente=a.Id_Utente,
                                                              Ruolo = b
                                                          }).FirstOrDefault();*/
                #endregion
            }
        }

        public static bool RemoveUtentebyId(long id)
        {

            using (var context = new CorsoRoma2022Entities())
            {
                try
                {

                    context.Utente.Remove(context.Utente.FirstOrDefault(x => x.Id_Utente == id));
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static Utente GetUtenteById(long id)
        {
            using (var context = new CorsoRoma2022Entities())
            {
                //  return context.Utente.ToList().Where(x => x.Id_Utente == id).Select(x => new Utente() { Nome = x.Nome, Cognome = x.Cognome, Email = x.Email, Password = x.Password, Id_Ruolo = x.Id_Ruolo, Id_Utente = x.Id_Utente }).FirstOrDefault();
                return context.Utente.ToList().Where(x => x.Id_Utente == id).Join(context.Ruolo.ToList(),
                                                    a => a.Id_Ruolo,
                                                    b => b.Id_Ruolo,
                                                    (a, b) => new Utente()
                                                    {
                                                        Id_Utente = a.Id_Utente,
                                                        Id_Ruolo = a.Id_Ruolo,
                                                        Nome = a.Nome,
                                                        Cognome = a.Cognome,
                                                        Email = a.Email,
                                                        Password = a.Password,
                                                        Ruolo = b
                                                    }).FirstOrDefault();
            }


            /*  public static UtentePartial ConvertUtPart(Utente utente)
            {
                return new UtentePartial()
                {
                    Nome = utente.Nome,
                    Cognome = utente.Cognome,
                    Email = utente.Email,
                    Id_Utente = utente.Id_Utente,
                    Id_Ruolo = utente.Id_Ruolo,
                    Password = utente.Password

                };
            }*/
        }

        public static bool RecuperaPassword(string email, string password, string password2)
        {
            using (var context = new CorsoRoma2022Entities())
            {
                var ut = context.Utente.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
                try
                {
                    if (ut != null && password.ToLower() == password2.ToLower())
                    {
                        ut.Password = password;
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


        /*    public static List<Utente> RicercaUtenti(Utente utente)
            {

                using (var context = new CorsoRoma2022Entities())
                {
                    return utente.Id_Ruolo != 0 ?
                        context.Utente.ToList().Where(x => x.Nome.Contains(utente.Nome == null ? "" : utente.Nome) && x.Cognome.Contains(utente.Cognome == null ? "" : utente.Cognome) && x.Email.Contains(utente.Email == null ? "" : utente.Email) && x.Id_Ruolo == utente.Id_Ruolo).Select(x => new Utente()
                        {
                            Nome = x.Nome,
                            Cognome = x.Cognome,
                            Email = x.Email,
                            Id_Ruolo = x.Id_Ruolo,
                            Id_Utente = x.Id_Utente,
                            Password = x.Password
                        }).ToList()

                        : context.Utente.ToList().Where(x => x.Nome.Contains(utente.Nome == null ? "" : utente.Nome) && x.Cognome.Contains(utente.Cognome == null ? "" : utente.Cognome) && x.Email.Contains(utente.Email == null ? "" : utente.Email)).Select(x => new Utente()
                        {
                            Nome = x.Nome,
                            Cognome = x.Cognome,
                            Email = x.Email,
                            Id_Ruolo = x.Id_Ruolo,
                            Id_Utente = x.Id_Utente,
                            Password = x.Password
                        }).ToList();
                }
            }*/


        public static List<Utente> RicercaUtenti(Utente utente)
        {

            using (var context = new CorsoRoma2022Entities())
            {
                return utente.Id_Ruolo != 0 ?
                    context.Utente.ToList().Where(x => x.Nome.Contains(utente.Nome == null ? "" : utente.Nome) && x.Cognome.Contains(utente.Cognome == null ? "" : utente.Cognome) && x.Email.Contains(utente.Email == null ? "" : utente.Email) && x.Id_Ruolo == utente.Id_Ruolo)
                    .Join(context.Ruolo.ToList(),
                                                 a => a.Id_Ruolo,
                                                 b => b.Id_Ruolo,
                                                 (a, b) => new Utente()
                                                 {




                                                     Nome = a.Nome,
                                                     Cognome = a.Cognome,
                                                     Email = a.Email,
                                                     Id_Ruolo = a.Id_Ruolo,
                                                     Id_Utente = a.Id_Utente,
                                                     Password = a.Password,
                                                     Ruolo = b

                                                 }).ToList()

                    : context.Utente.ToList().Where(x => x.Nome.Contains(utente.Nome == null ? "" : utente.Nome) && x.Cognome.Contains(utente.Cognome == null ? "" : utente.Cognome) && x.Email.Contains(utente.Email == null ? "" : utente.Email))
                     .Join(context.Ruolo.ToList(),
                                                 a => a.Id_Ruolo,
                                                 b => b.Id_Ruolo,
                                                 (a, b) => new Utente()
                                                 {




                                                     Nome = a.Nome,
                                                     Cognome = a.Cognome,
                                                     Email = a.Email,
                                                     Id_Ruolo = a.Id_Ruolo,
                                                     Id_Utente = a.Id_Utente,
                                                     Password = a.Password,
                                                     Ruolo = b

                                                 }).ToList();

            }
        }

        public static int GetNumeroPref(long idutente)
        {
            using (var context = new CorsoRoma2022Entities())
            {

                return context.Preferiti.Where(x => x.Id_Utente == idutente).Count();
            }
        }

        public static string GetCarelloAttivi(long idutente)
        {
            using (var context = new CorsoRoma2022Entities())
            {

                var query = from u in context.Utente.ToList()
                            join o in context.Ordine.ToList() 
                            on u.Id_Utente equals o.Id_Utente where u.Id_Utente==idutente
                            join c in context.Carrello.ToList()
                            on o.Id_Ordine equals c.Id_Ordine
                            select new
                            {
                                c.Id_Carrello
                            };
                return query.Count() > 0 ? "SI" : "NO";
            }

        }
    }
}