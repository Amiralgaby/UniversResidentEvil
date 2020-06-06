using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MyLib
{
    [KnownType(typeof(Personnage))]
    [DataContract]
    public class Personnage : Element
    {
        public Personnage(string nom,string prénom,string description)
            :base(nom,description)
        {
            Prénom = prénom;
        }

        public void ModifierPrénom(string prénom) => Prénom = prénom;
        [DataMember]
        public string Prénom { get; private set; }
    }
}
