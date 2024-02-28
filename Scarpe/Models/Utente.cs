using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scarpe.Models
{
    public class Utente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int TipoUtente { get; set; }

        public Utente() { }

        public Utente(string nome, string cognome, string email, string username, string password, int tipoUtente)
        {
            Nome = nome;
            Cognome = cognome;
            Email = email;
            Username = username;
            Password = password;
            TipoUtente = tipoUtente;
        }
    }
}