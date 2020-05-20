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
        private static ObservableCollection<Element> observableCollection = new ObservableCollection<Element>();
        private readonly ObservableCollection<Element> ListElements = observableCollection;
        
        //Fonction pour la liste d'éléments
        public void AjouterElement(Element e) => ListElements.Add(e);
        public void SupprimerElement(Element e) => ListElements.Remove(e);
        public void ModifierElement(Element e, string nom, string description,bool favoris) => e.ModifierAttribut(nom, description, favoris);
        public void listerLesElement()
        {
            foreach (Element e in ListElements)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("***********");
            }
        }

        //Fonctions pour l'histoire (la liste d'événement)
        public void AjouterEvenementAHistoire(Evenement ev) => Histoire.AddLast(ev);
        public void SupprimerEvenementAHistoire(Evenement ev) => Histoire.Remove(ev);
        public void ModifierEvenementAHistoire(Evenement ev, string lieu, DateTime date)
        {
            ev.ModifierLieu(lieu);
            ev.ModifierDate(date);
        }
        public void listerHistoire()
        {
            foreach(Evenement ev in Histoire)
            {
                Console.WriteLine(ev.ToString());
                Console.WriteLine("************");
            }
        }
    }
}
