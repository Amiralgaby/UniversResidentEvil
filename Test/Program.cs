using System;
using System.Collections.Generic;
using MyLib;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Hello World!");
            Element e = new Element("Leon", "Homme", true);

            List<Element> miniatures = new List<Element>()
            {
                new Element("Jean Bon","L'homme le plus cool de l'univers"),
                new Element("Moldu","Truc",true),
                new Element("Le dernier essai","il n'a pas fait long feu",false),
            };

            for(int i=0; i<miniatures.Count; i++)
            {
                Console.WriteLine($"{miniatures[i]}");
            }
        }
    }
}
