using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;

namespace MyLib
{
    public class Manager
    {
        public LinkedList<Evenement> Histoire = new LinkedList<Evenement>();
        private ObservableCollection<Element> mesElements = new ObservableCollection<Element>();

        public ObservableCollection<Element> MesElements
        {
            get { return mesElements; }
            set { mesElements = value; }
        }

        //Fonction pour la liste d'éléments
        public void AjouterElement(Element e) => MesElements.Add(e);
        public void SupprimerElement(Element e) => MesElements.Remove(e);
        public void ModifierElement(Element e, string nom, string description,bool favoris) => e.ModifierAttribut(nom, description, favoris);

        //Fonctions pour l'histoire (la liste d'événement)
        public void AjouterEvenementAHistoire(Evenement ev) => Histoire.AddLast(ev);
        public void SupprimerEvenementAHistoire(Evenement ev) => Histoire.Remove(ev);
        public void ModifierEvenementAHistoire(Evenement ev, string lieu, DateTime date)
        {
            ev.ModifierLieu(lieu);
            ev.ModifierDate(date);
        }
    }
}
