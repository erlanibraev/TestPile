using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPile.Test002
{
    class Program
    {
        static void Main(string[] args)
        {
            test001();
            Console.ReadLine();
        }

        private static void test001()
        {
            TestLinkedList<int> test = new TestLinkedList<int>();
            TestLinkedListNode<int> node = test.AddFirst(0);
            for(int i=1; i <= 20; i++)
            {
                node = test.AddAfter(node, i);
            }

            TestLinkedListNode<int> current = test.First;
            while(current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
            current = test.Last;
            while(current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Previous;
            }
        }
    }
}
