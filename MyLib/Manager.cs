using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;

namespace MyLib
{
    public class Manager
    {
        public List<Evenement> Histoire = new List<Evenement>();
        private static ObservableCollection<Element> observableCollection = new ObservableCollection<Element>();
        private readonly ObservableCollection<Element> ListElements = observableCollection;
        
        //Fonction pour la liste d'éléments
        public void AjouterElement(Element e) => ListElements.Add(e);
        public void SupprimerElement(Element e) => ListElements.Remove(e);
        public void ModifierElement(Element e, string nom, string description,bool favoris)
        {
            e.ModifierAttribut(nom, description, favoris);
        }
        public void listerLesElement()
        {
            foreach (Element e in ListElements)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("***********");
            }
        }

        //Fonctions pour l'histoire (la liste d'événement)q
    }
}
