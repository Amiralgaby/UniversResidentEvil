using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Xml;

namespace MyLib
{
    public class Manager : INotifyPropertyChanged
    {
        public List<Evenement> Histoire = new List<Evenement>();
        private ObservableCollection<Element> mesElements = new ObservableCollection<Element>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Element> MesElements
        {
            get { return mesElements; }
            set { mesElements = value; }
        }

        public Element ElementSelectionné 
        { 
            get => elementSelectionné;
            set
            {
                if(elementSelectionné != value)
                {
                    elementSelectionné = value;
                    OnPropertyChanged(nameof(elementSelectionné));
                }
            }
        }
        private Element elementSelectionné;

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

        public void ChargerLesDonnées()
        {
            AjouterElement(new Personnage("Valentine", "Jill", "Elle est experte dans le maniement des armes à feu, le crochetage de serrures et la neutralisation d'explosifs."));

            AjouterElement(new Personnage(" Aiken", "Richard", ""));

            AjouterElement(new Personnage("Chambers", "Rebecca", ""));

            AjouterElement(new Personnage("Coen", "Billy", ""));

            AjouterElement(new Personnage("Dewey", "Edward", ""));

            AjouterElement(new Creature("Nemesis", "MéchantDescription", Dangerosité.Très_dangereux));

            AjouterElement(new Creature("T-00", 
                "Le T-103, aussi appelé communément Mr. X, est l'un des antagonistes de Resident Evil 2 (1998) et Resident Evil 2 (2019). C'est une arme biologique de catégorie Tyran." +
                "Sa mission principale est de récupérer l'échantillon de Virus-G.", 
                Dangerosité.Très_dangereux));

            AjouterElement(new Creature("Tyran","",Dangerosité.Menace));

            AjouterElement(new Creature("Plaga", 
                "Contrairement au Virus-t, qui transformait ses victimes en zombies écervelés, les Plagas sont des parasites qui prennent le contrôle du système nerveux des hôtes dans lesquels ils sont implantés." + 
                " Les personnes infectées par ce parasite (Ganado comme Majini) deviennent beaucoup plus fortes et très résistantes à la douleur, tout en travaillant collectivement à la poursuite de leurs objectifs." + 
                "D'autres effets secondaires incluent la perte complète de raisonnement — sauf chez certains sujets (qui ne sont toutefois pas en mesure de résister à la nécessité d'obéir à des ordres supérieurs) — et la pleine conformité à l’espèce de Plaga dominante.",
                Dangerosité.Dangereux));
            
            
            
            ElementSelectionné = mesElements[0]; //Element sélectionné par défaut
        }
    }
}
