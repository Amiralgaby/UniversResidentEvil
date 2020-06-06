using MyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
namespace DataContractPersistance
{
    public class DataContractPers : IPersistanceManager
    {
        public KnownTypeAttribute Attribute;
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), " ..//JSON");
        public string FileName { get; set; } = "UniversRE.json";
        string PersFile => Path.Combine(FilePath, FileName);
        public (IEnumerable<Element> elements, IEnumerable<Evenement> evenements) ChargerLesDonnées()
        {
            if (!File.Exists(PersFile))
            {
                throw new FileNotFoundException("Le fichier n'a pas été trouvée");
            }
            var serializer = new DataContractJsonSerializer(typeof(DataPersist));

            DataPersist data;
            using (Stream s = File.OpenRead(PersFile))
            {
                data = serializer.ReadObject(s) as DataPersist;
            }

            return (data.Elements, data.Evenements);
        }

        public void SauvegarderLesDonnées(IEnumerable<Element> elements, IEnumerable<Evenement> evenements)
        {
            var serializer = new DataContractJsonSerializer(typeof(DataPersist));

            if (!Directory.Exists(FilePath)) Directory.CreateDirectory(FilePath);

            DataPersist data = new DataPersist();
            data.Elements.AddRange(elements);
            data.Evenements.AddRange(evenements);

            using (Stream s = File.Create(PersFile))
            {
                serializer.WriteObject(s, data);
            }
        }
    }
}
