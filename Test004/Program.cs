using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPile.Test004
{
    public class Program
    {
        static void Main(string[] args)
        {
            test001();
            GC.Collect();
            test002();
            GC.Collect();
            Console.ReadLine();
        }

        private static void test002()
        {
            List<string> test = new List<string>();
            while(true)
            {
                try
                {
                    test.Add(Guid.NewGuid().ToString());
                } catch(Exception ex)
                {
                    Console.WriteLine(test.Count);
                    Console.WriteLine("---");
                    Console.WriteLine(ex);
                    break;
                }
            }
        }

        private static void test001()
        {
            LinkedList<string> test = new LinkedList<string>();
            LinkedListNode<string> current = test.AddFirst(Guid.NewGuid().ToString());
            while (true)
            {
                try
                {
                    current = test.AddAfter(current, Guid.NewGuid().ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(test.Count);
                    Console.WriteLine("---");
                    Console.WriteLine(ex);
                    break;
                }
            }

        }
    }
}
