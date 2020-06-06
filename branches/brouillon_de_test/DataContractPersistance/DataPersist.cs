using MyLib;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DataContractPersistance
{
    [DataContract]
    class DataPersist
    {
        [DataMember]
        public List<Element> Elements { get; set; } = new List<Element>();

        [DataMember]
        public List<Evenement> Evenements { get; set; } = new List<Evenement>();
    }
}
