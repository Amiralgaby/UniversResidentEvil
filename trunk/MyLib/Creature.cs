using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class Creature :Element
    {
        public Creature(string nom, string description,string dangerosité) 
            : base(nom,description)
        {
            Dangerosité = dangerosité;
        }
        public void Modifier(string dangerosité)
        {
            Dangerosité = dangerosité;
        }
        public string Dangerosité { get; private set; }
    }
}
