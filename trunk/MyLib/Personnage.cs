using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class Personnage : Element
    {
        public Personnage(string nom,string prénom,string description)
            :base(nom,description)
        {
            Prénom = prénom;
        }

        public void ModifierPrénom(string prénom) => Prénom = prénom; 
        public string Prénom { get; private set; }
    }
}
