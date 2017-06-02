using NFX;
using NFX.ApplicationModel.Pile;
using NFX.DataAccess.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPile.Test001
{

    public class TestData
    {
        [Field] public string text { get; set; }
        [Field] public int num1 { get; set; }
        [Field] public float num2 { get; set; }
        [Field] public DateTime? date { get; set; }

        public override string ToString()
        {
            return "text = {0}; num1 = {1}; num2 = {2}; date = {3}".Args(text, num1, num2, date);
        }

        public static TestData generate()
        {
            Random rnd = new Random();
            TestData result = new TestData() { text = Guid.NewGuid().ToString(), num1 = rnd.Next(0, 1000000), num2 = (float)rnd.NextDouble() * 1000000, date = DateTime.Now };
            return result;
        }
    }

    class Program
    {
        public static DefaultPile pile { get; set; }

        public static PilePointer[] pps = new PilePointer[100000000];

        public static void initPile()
        {
            Console.WriteLine("Инициализация NFX pile");
            pile = new DefaultPile();
            pile.Configure(null);
            pile.AllocMode = AllocationMode.ReuseSpace;

            Console.WriteLine("Запуск NFX pile" );
            pile.Start();
        }

        public static void donePile()
        {
            Console.WriteLine("Останов NFX pile");
            pile.WaitForCompleteStop();
        }

        public static void test001()
        {
            var pp = pile.Put(TestData.generate());

            Console.WriteLine(pile.Status);

            Console.WriteLine(pp);

            Console.WriteLine(pile.Get(pp).ToString());

            pile.Delete(pp);

            Console.WriteLine(pile.Status);

        }

        static void Main(string[] args)
        {
            initPile();
            pps.ForEach(pps => pps = PilePointer.Invalid);

            test001();
            test002();
            // Console.WriteLine(pile.Get(pp));

            donePile();
            Console.ReadLine();
        }

        private static void test002()
        {
            for(int i=0; i< 1000000; i++)
            {
                Console.WriteLine(i);
                pps[i] = pile.Put(TestData.generate());
            }

           for(int i = 0; i < 1000000; i++)
            {
                Console.WriteLine(pile.Get(pps[i]));
            }

        }
    }
}
