using NFX.ApplicationModel.Pile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPile.Test003
{
    class Program
    {
        static void Main(string[] args)
        {
            DefaultPile m_Pile = new DefaultPile();
            m_Pile.Configure(null);
            m_Pile.AllocMode = AllocationMode.ReuseSpace;
            m_Pile.SegmentSize = 256 * 1025 * 1024;
            m_Pile.Start();
            int i = 0;
            while(true)
            {
                try
                {
                    m_Pile.Put(Guid.NewGuid().ToString());
                    i++;
                } catch(Exception ex)
                {
                    Console.WriteLine(m_Pile.SegmentCount);
                    Console.WriteLine(m_Pile.ObjectCount);
                    Console.WriteLine(i);
                    Console.WriteLine("---");
                    Console.WriteLine(ex);
                    break;
                }
            }

            m_Pile.WaitForCompleteStop();
            Console.ReadLine();
        }
    }
}
