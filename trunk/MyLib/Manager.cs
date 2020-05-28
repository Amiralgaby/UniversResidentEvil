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
        public LinkedList<Evenement> Histoire = new LinkedList<Evenement>();
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
        public void SupprimerElement(Element e) => MesElements.Remove(e);
        public void ModifierElement(Element e, string nom, string description,bool favoris) => e.ModifierAttribut(nom, description, favoris);
        public void BasculerFavoris(Element e) => e.BasculerFavoris();

        //Fonctions pour l'histoire (la liste d'événement)
        public void AjouterEvenementAHistoire(Evenement ev) => Histoire.AddLast(ev);
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
                if(e.Nom == nomAchercher)
                {
                    listRetourDeLaRecherche.Add(e);
                }
            }
            return listRetourDeLaRecherche;
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

            AjouterElement(new Creature("Tyran", "", Dangerosité.Menace));

            AjouterElement(new Creature("Plaga",
                "Contrairement au Virus-t, qui transformait ses victimes en zombies écervelés, les Plagas sont des parasites qui prennent le contrôle du système nerveux des hôtes dans lesquels ils sont implantés." +
                " Les personnes infectées par ce parasite (Ganado comme Majini) deviennent beaucoup plus fortes et très résistantes à la douleur, tout en travaillant collectivement à la poursuite de leurs objectifs." +
                "D'autres effets secondaires incluent la perte complète de raisonnement — sauf chez certains sujets (qui ne sont toutefois pas en mesure de résister à la nécessité d'obéir à des ordres supérieurs) — et la pleine conformité à l’espèce de Plaga dominante.",
                Dangerosité.Dangereux));


            ElementSelectionné = mesElements[0];
        }
    }
}
