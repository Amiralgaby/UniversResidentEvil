using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace MyLib
{
    [KnownType(typeof(Evenement))]
    [DataContract]
    public class Evenement : Element, IComparable, IComparable<Evenement>
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
        private string lieu;
        [DataMember]
        public string Lieu { 
            get { return lieu; }
            private set 
            {
                lieu = (value ?? "lieu indéterminé");
            } 
        }

        [DataMember]
        public DateTime Date { get; private set; }
        public void ModifierLieu(string lieu) => Lieu = lieu;
        public void ModifierDate(DateTime date) => Date = date;

        public int CompareTo(Evenement other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}
