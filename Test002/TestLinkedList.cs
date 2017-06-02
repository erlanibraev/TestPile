using NFX.ApplicationModel.Pile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPile.Test002
{
    public class TestLinkedList<T> 
    {
        public TestLinkedListNode<T> Last { get; set; } = null;
        public TestLinkedListNode<T> First { get; set; } = null;
        public int Count { get; set; }

        public void AddFirst(TestLinkedListNode<T> first)
        {
            if(First != null)
            {
                first.Next = First.Next;
                First.Previous = first;
            }
            First = first;
            if (Last == null)
            {
                Last = First;
            }
        }

        public TestLinkedListNode<T> AddFirst(T value)
        {
            TestLinkedListNode<T> result = new TestLinkedListNode<T>() { Value = value };
            AddFirst(result);
            return result;
        }

        public void AddLast(TestLinkedListNode<T> last)
        {
            if(Last != null)
            {
                last.Previous = Last;
                Last.Next = last;
            }
            Last = last;
            if(First == null)
            {
                First = Last;
            }
        }

        public TestLinkedListNode<T> AddLast(T value)
        {
            var result = new TestLinkedListNode<T>() { Value = value };
            AddLast(new TestLinkedListNode<T>() { Value = value });
            return result;
        }

        public void AddAfter(TestLinkedListNode<T> current, TestLinkedListNode<T> val)
        {
            var next = current.Next;
            current.Next = val;
            if (next != null)
            {
                next.Previous = val;
                val.Next = next;
            } else
            {
                Last = val;
            }
            val.Previous = current;
        }

        public TestLinkedListNode<T> AddAfter(TestLinkedListNode<T> current, T val)
        {
            var result = new TestLinkedListNode<T>() { Value = val };
            AddAfter(current, result);
            return result;
        }


    }
}
