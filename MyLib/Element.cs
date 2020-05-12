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

        public void ModifierNom(string nom) => Nom = nom;
        public void ModifierDescription(string description) => Description = description;
        public void ModifierAttribut(string nom, string description, bool favoris)
        {
            Nom = nom;
            Description = description;
            Favoris = favoris;
        }
        public void BasculerFavoris() => Favoris = !Favoris;
        public string Nom{ get; private set; }
        public string Description{ get; private set; }
        public bool Favoris { get; private set; }
        public override string ToString()
        {
            if (Favoris) return $"{Nom} \'{Description}\' (Favoris)";
            return $"{Nom} \'{Description}\'";
        }
    }
}
