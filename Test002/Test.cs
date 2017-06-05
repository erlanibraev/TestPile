using System;
using NUnit.Framework;

namespace TestPile.Test002
{
    [TestFixture]
    public class Test
    {

        [Test]
        public void simpleTest()
        {
            TestLinkedListNode<int> test = new TestLinkedListNode<int>(){Value = 11};
            Console.WriteLine(test.Value);
            Assert.AreEqual(test.Value, 11);

        }
    }
}