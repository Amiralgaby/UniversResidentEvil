using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class Creature : Element
    {
        public Creature(string nom, string description,Dangerosité dangerosité) 
            : base(nom,description)
        {
            Dangerosité = dangerosité;
        }
        public void Modifier(Dangerosité dangerosité) => Dangerosité = dangerosité;
        public Dangerosité Dangerosité { get; private set; }
    }
}
