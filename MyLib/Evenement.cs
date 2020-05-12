using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MyLib
{
    public class Evenement : Element
    {
        public Evenement(string nom, string description, string lieu)
            : this(nom,description,lieu,DateTime.Now)
        {
        }
        public Evenement(string nom, string description,string lieu, DateTime date)
            : base(nom,description)
        {
            Lieu = lieu;
            Date = date;
        }
        public void ModifierLieu(string lieu) => Lieu = lieu;
        public void ModifierDate(DateTime date) => Date = date;
        public string Lieu { get; private set; }
        public DateTime Date { get; private set; }
    }
}
