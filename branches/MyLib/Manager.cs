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
            mesElements.Add(new Element("Jean Bon", "L'homme le plus cool de l'univers"));
            mesElements.Add(new Element("Moldu", "Truc", true));
            mesElements.Add(new Element("Le dernier essai", "il n'a pas fait long feu", false));
            mesElements.Add(new Personnage("Chaplin", "Charlie", "un génie"));
            mesElements.Add(new Personnage("Tolvarld", "Linus", "un hacker"));
            mesElements.Add(new Personnage("PlaceholderName", "PlaceHolderPrenom", "c'est a supprimer"));
            ElementSelectionné = mesElements[0];
        }
    }
}
