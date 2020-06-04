using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public interface IPersistanceManager
    {
        (IEnumerable<Element> elements, IEnumerable<Evenement> evenements) ChargerLesDonnées();
        void SauvegarderLesDonnées(IEnumerable<Element> elements, IEnumerable<Evenement> evenements);
    }
}
