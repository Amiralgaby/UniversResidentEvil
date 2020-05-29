using System;
using System.Collections.Generic;
using MyLib;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager m = new Manager();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Hello World!");
            
            //Initialisation pour test la liste d'éléments
            Element e = new Element("Leon", "Homme", true);
            Evenement ev = new Evenement("naissance de mon fraté", "il est né", "Moulins", DateTime.Parse("1/4/2003"));
            m.AjouterElement(ev);
            m.AjouterElement(new Element("Jean Bon", "L'homme le plus cool de l'univers"));
            m.AjouterElement(new Element("Moldu", "Truc", true));
            m.AjouterElement(new Element("Le dernier essai", "il n'a pas fait long feu", false));
            m.AjouterElement(new Personnage("Chaplin", "Charlie", "un génie"));
            m.AjouterElement(new Personnage("Tolvarld", "Linus", "un hacker"));
            m.AjouterElement(new Personnage("PlaceholderName", "PlaceHolderPrenom", "c'est a supprimer"));
            m.AjouterElement(e);
            /*
            Evenement ev1 = new Evenement("Rien", "il ne sait r passé", "nulle part");
            Evenement ev2 = new Evenement("Ma naissance", "je suis né", "Moulins", DateTime.FromOADate(16 / 09 / 2001));
            m.AjouterElement(ev1);
            m.AjouterElement(ev2);
            m.AjouterEvenementAHistoire(ev);
            m.AjouterEvenementAHistoire(ev1);
            m.AjouterEvenementAHistoire(ev2);
            */
            m.ElementSelectionné = e;
            foreach(Element o in m.MesElements)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine("**********");
            string Jean = "je suis qu'un test";
            Console.WriteLine(string.IsNullOrWhiteSpace(Jean));
            m.AjouterElement(new Element(Jean, ""));
            foreach (Element o in m.MesElements)
            {
                Console.WriteLine(o);
            }


            List<Element> listDelement;
            listDelement = m.RechercherElementParNom("Linus");
            Console.WriteLine(listDelement.Count);
            foreach(Element o in listDelement)
            {
                Console.WriteLine(o);
            }
        }
    }
}
