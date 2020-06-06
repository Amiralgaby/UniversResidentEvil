using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MyLib
{
    [KnownType(typeof(Creature))]
    [DataContract]
    public class Creature : Element
    {
        public Creature(string nom, string description,Dangerosité dangerosité) 
            : base(nom,description)
        {
            Dangerosité = dangerosité;
        }
        public void Modifier(Dangerosité dangerosité) => Dangerosité = dangerosité;
        [DataMember]
        public Dangerosité Dangerosité { get; private set; }
    }
}
