using MyLib;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Test
{
    class ProgramPersistance
    {
        internal static void MainPers(string[] args)
        {
            Manager man = new Manager(new Stub.StubDataManager());
            man.ChargeLesDonnées();
            man.Persistance = new DataContractPersistance.DataContractPers();
            man.SauvegarderLesDonnées();

            //Manager man2 = new Manager(new DataContractPersistance.DataContractPers());
            //man2.ChargeLesDonnées();
        }
    }
}
