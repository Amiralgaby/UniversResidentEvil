using System;

namespace MyLib
{
    public class Element
    {
        public Element(string nom, string description)
            : this(nom,description,false)
        {
        }
        public Element(string nom, string description, Boolean favoris)
        {
            Nom = nom;
            Description = description;
            Favoris = favoris;
        }
        public string Nom{ get; private set; }
        public string Description{ get; private set; }
        public Boolean Favoris { get; private set; }
        public override string ToString()
        {
            return $"{Nom}\t {Favoris}\n{Description}";
        }
    }
}
