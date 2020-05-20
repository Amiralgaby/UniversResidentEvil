using System;

namespace MyLib
{
    public class Element : IEquatable<Element>
    {
        public Element(string nom, string description)
            : this(nom,description,false){}
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
        public string Nom{
            get { return this.nom; }
            private set
            {
                if (!((value??"inconnu").Equals("")))
                    this.nom = value;
                else
                    this.nom = "sans nom";
            }
        }
        private string nom;
        public string Description {
            get { return this.description; }
            private set 
            {
                if (!((value ?? "inderterminée").Equals("")))
                    this.description = value;
                else
                    this.description = "sans description";
            }
        }
        private string description;
        public bool Favoris { get; private set; }
        public override string ToString()
        {
            if (Favoris) return $"{Nom} \'{Description}\' (Favoris)";
            return $"{Nom} \'{Description}\'";
        }

        public bool Equals(Element other)
        {
            return Nom.Equals(other.Nom) && Description.Equals(other.Nom);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Element);
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
    }
}
