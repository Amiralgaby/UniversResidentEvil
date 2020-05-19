using System;
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
            Element e = new Element("Leon", "Homme", true);
            Evenement ev = new Evenement("naissance de mon fraté", "il est né", "Moulins", DateTime.Parse("1/4/2003"));
            m.AjouterElement(ev);
            m.AjouterElement(new Element("Jean Bon", "L'homme le plus cool de l'univers"));
            m.AjouterElement(new Element("Moldu", "Truc", true));
            m.AjouterElement(new Element("Le dernier essai", "il n'a pas fait long feu", false));
            m.AjouterElement(new Personnage("Chaplin", "Charlie", "un génie"));
            m.AjouterElement(new Personnage("Tolvarld", "Linus", "un hacker"));
            m.AjouterElement(new Personnage("PlaceholderName", "PlaceHolderPrenom", "c'est a supprimer"));
            m.AjouterElement(new Evenement("Rien", "il ne sait r passé", "nulle part"));
            m.AjouterElement(new Evenement("Ma naissance", "je suis né", "Moulins", DateTime.FromOADate(16 / 09 / 2001)));
            m.AjouterElement(e);
            m.listerLesElement();
            Console.WriteLine("@@@@@@@@@@@@@@@@@@");
            string rep = Console.ReadLine();
            string repdeux = Console.ReadLine();
            int carac = Console.Read();
            if(carac == 'y') { ev.BasculerFavoris(); }
            m.ModifierElement(ev, rep, repdeux, ev.Favoris);
            Console.WriteLine(ev.ToString());
        }
    }
}
