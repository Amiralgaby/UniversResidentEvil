using System;

namespace MyLib
{
    public class Element : IEquatable<Element>, IComparable, IComparable<Element>
    {
        private string nom;
        private string description;

        public Element(string nom, string description)
            : this(nom,description,false){}
        public Element(string nom, string description, bool favoris)
        {
            Nom = nom;
            Description = description;
            Favoris = favoris;
        }


        public void BasculerFavoris() => Favoris = !Favoris;
        public string Nom{
            get => nom;
            private set
            {
                
                if (string.IsNullOrWhiteSpace(nom) != true)
                    nom = "sans nom";
                else
                    nom = value;
            }
        }
        
        public string Description {
            get => description;
            private set 
            {
                if (string.IsNullOrWhiteSpace(description) != true)
                    this.description = "sans description";
                else
                    this.description = value;
            }
        }
        
        public bool Favoris { get; private set; }

        public void ModifierNom(string nom) => Nom = nom;
        public void ModifierDescription(string description) => Description = description;
        public void ModifierAttribut(string nom, string description, bool favoris)
        {
            Nom = nom;
            Description = description;
            Favoris = favoris;
        }
        public override string ToString()
        {
            if (Favoris) return $"{Nom} \'{Description}\' (Favoris)";
            return $"{Nom} \'{Description}\'";
        }

        public bool Equals(Element other)
        {
            return Nom.Equals(other.Nom) && Description.Equals(other.Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Element);
        }

        public override int GetHashCode() => Nom.GetHashCode();

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Element other)
        {
            return Nom.CompareTo(other.Nom);
        }
    }
}
