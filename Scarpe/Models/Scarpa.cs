using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Scarpe.Models
{
    public class Scarpa
    {
        public string Nome {  get; set; }
        public decimal Prezzo { get; set; }
        public string Descrizione { get; set; }
        public string ImgCopertina {  get; set; }
        public string ImgA {  get; set; }
        public string ImgB { get; set;}
        public bool Attivo {  get; set; }

        public Scarpa() { }

        public Scarpa(string nome, decimal prezzo, string descrizione, string imgCopertina, string imgA, string imgB, bool attivo)
        {
            Nome = nome;
            Prezzo = prezzo;
            Descrizione = descrizione;
            ImgCopertina = imgCopertina;
            ImgA = imgA;
            ImgB = imgB;
            Attivo = attivo;
        }
    }

    

}