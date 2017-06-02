using NFX.ApplicationModel.Pile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPile.Test002
{
    public class PileSinglton
    {
        public static IPile PILE { get; private set; } = initPile();

        private static IPile initPile()
        {
            DefaultPile result = new DefaultPile();
            result.Configure(null);
            result.AllocMode = AllocationMode.ReuseSpace;
            result.Start();
            return result;
        }

        public static void donePile()
        {
            ((DefaultPile)PILE).WaitForCompleteStop(); 
        }
    }
}
