using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Xml;

namespace MyLib
{
    public class Manager : INotifyPropertyChanged
    {
        private Element elementSelectionné;
        private Evenement evenementSelectionné;
        private int indice = 0;
        //private string ElementSelectionnéIsFavoris => ElementSelectionné.Favoris != false ? "img/iconeFullstar.png" : "img/iconeEmptystar.png";
        public IPersistanceManager Persistance;
        public List<Evenement> Histoire = new List<Evenement>();
        private ObservableCollection<Element> mesElements = new ObservableCollection<Element>();
        private ObservableCollection<Element> mesFavoris = new ObservableCollection<Element>();
        private ObservableCollection<Element> ColletionActuelle;

        public Manager(IPersistanceManager persistance)
        {
            Persistance = persistance;
        }

        public int Indice { get => indice;
            set
            {
                if(Histoire.Count == 1 || value < 0)
                {
                    indice = 0;
                }
                else indice = (value * 100) / (Histoire.Count - 1);
                OnPropertyChanged(nameof(indice));
            }
        }

        public ObservableCollection<Element> MesFavoris
        {
            get { return mesFavoris; }
            set { mesFavoris = value; }
        }

        public ObservableCollection<Element> MesElements
        {
            get { return mesElements; }
            set { mesElements = value; }
        }

        public ObservableCollection<Element> ListActuelle
        {
            get { return ColletionActuelle; }
            set { ColletionActuelle = value; }
        }

        public Element ElementSelectionné
        {
            get => elementSelectionné;
            set
            {
                if (elementSelectionné != value)
                {
                    elementSelectionné = value;
                    OnPropertyChanged(nameof(elementSelectionné));
                }
            }
        }

        public Evenement EvenementSelectionné
        {
            get => evenementSelectionné;
            set
            {
                if (evenementSelectionné != value)
                {
                    evenementSelectionné = value;
                    Indice = Histoire.IndexOf(value);
                    OnPropertyChanged(nameof(evenementSelectionné));
                }
            }
        }

        public ObservableCollection<Element> MesFavorisLINQ => new ObservableCollection<Element>(MesElements.Where(e => e.Favoris != false));
        
        public void ChargeLesDonnées()
        {
            var données = Persistance.ChargerLesDonnées();
            foreach(var donnée in données.elements)
            {
                mesElements.Add(donnée);
            }
            foreach(var donnée in données.evenements)
            {
                Histoire.Add(donnée);
            }
        }

        public void SauvegarderLesDonnées()
        {
            Persistance.SauvegarderLesDonnées(mesElements,Histoire);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// fonction qui avertit qu'un attribut dans la classe à été modifié
        /// </summary>
        /// <param name="propertyName">le nom de l'événement changé</param>
        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));


        //Fonction pour la liste d'éléments
        public void AjouterElement(Element e) => MesElements.Add(e);
        public bool SupprimerElement(Element e) { return MesElements.Remove(e); }
        public void ModifierElement(Element e, string nom, string description,bool favoris) => e.ModifierAttribut(nom, description, favoris);
        public void BasculerFavoris(Element e) => e.BasculerFavoris();

        //Fonctions pour l'histoire (la liste d'événement)
        public void AjouterEvenementAHistoire(Evenement ev) => Histoire.Add(ev);
        public void SupprimerEvenementAHistoire(Evenement ev) => Histoire.Remove(ev);
        public void ModifierEvenementAHistoire(Evenement ev, string lieu, DateTime date)
        {
            ev.ModifierLieu(lieu);
            ev.ModifierDate(date);
        }

        public void TrierLaListe() => Histoire.Sort();

        /// <summary>
        /// Permet de rechercher un élément composée du nom donné en paramètre
        /// </summary>
        /// <param name="nomAchercher">la chaîne de caractères à chercher dans la liste</param>
        /// <returns>Une liste d'élément ayant des éléments avec une distance de Levenshtein inférieur à 4</returns>
        public List<Element> RechercherElementParNom(string nomAchercher)
        {
            List<Element> listRetourDeLaRecherche = new List<Element>();
            foreach(Element e in mesElements)
            {
                if(SimilaritéLevenshtein(e.Nom,nomAchercher) < 4)
                {
                    listRetourDeLaRecherche.Add(e);
                }
            }
            return listRetourDeLaRecherche;
        }

        public ObservableCollection<Element> RechercherElementParNomLINQ(string nomAchercher) => new ObservableCollection<Element>(MesElements.Where(e => SimilaritéLevenshtein(e.Nom, nomAchercher) < 4));
        /// <summary>
        /// Fonction permettant de trouver la similarité en "distance" entre 2 string
        /// plus la valeur est petite, plus les deux string se ressemblent
        /// </summary>
        /// <param name="a">la valeur à comparer</param>
        /// <param name="b">la valeur de référence à comparer (on peut intervertir les deux aussi)</param>
        /// <returns>un chiffre donnant la distance entre les deux string</returns>
        /// Source : https://blog.sodifrance.fr/algorithme-de-levenshtein-en-c-net/
        private Int32 SimilaritéLevenshtein(String a, String b)
        {
            if (string.IsNullOrEmpty(a))
            {
                if (!string.IsNullOrEmpty(b))
                {
                    return b.Length;
                }
                return 0;
            }

            if (string.IsNullOrEmpty(b))
            {
                if (!string.IsNullOrEmpty(a))
                {
                    return a.Length;
                }
                return 0;
            }

            Int32 cost;
            Int32[,] d = new int[a.Length + 1, b.Length + 1];
            Int32 min1;
            Int32 min2;
            Int32 min3;

            for (Int32 i = 0; i <= d.GetUpperBound(0); i += 1)
            {
                d[i, 0] = i;
            }

            for (Int32 i = 0; i <= d.GetUpperBound(1); i += 1)
            {
                d[0, i] = i;
            }

            for (Int32 i = 1; i <= d.GetUpperBound(0); i += 1)
            {
                for (Int32 j = 1; j <= d.GetUpperBound(1); j += 1)
                {
                    cost = Convert.ToInt32(!(a[i - 1] == b[j - 1]));

                    min1 = d[i - 1, j] + 1;
                    min2 = d[i, j - 1] + 1;
                    min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[d.GetUpperBound(0), d.GetUpperBound(1)];
        }

        /// <summary>
        /// Permet de chager les données au début de l'execution du programme
        /// </summary>
        public void ChargerLesDonnées()
        {
            IEnumerable<Element> sortie1;
            IEnumerable<Evenement> sortie2;
           (sortie1,sortie2) = Persistance.ChargerLesDonnées();
            MesElements = new ObservableCollection<Element>(sortie1);
            Histoire = sortie2.ToList();
            ElementSelectionné = MesElements.Count > 0 ? mesElements[0] : null; //Element sélectionné par défaut
            EvenementSelectionné = Histoire.Count > 0 ? Histoire[0] : null; //Evenement sélectionné par défaut
            ColletionActuelle = MesElements;
        }
    }
}