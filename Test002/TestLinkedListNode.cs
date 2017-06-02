using NFX;
using NFX.ApplicationModel.Pile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPile.Test002
{
    public class TestLinkedListNode<T>
    {
        PilePointer pp_next { get; set; } = PilePointer.Invalid;
        PilePointer pp_prev { get; set; } = PilePointer.Invalid;
        PilePointer pp_value { get; set; } = PilePointer.Invalid;
        protected PilePointer pp_self { get; set; } = PilePointer.Invalid;

        public TestLinkedListNode() 
        {
            pp_self = PileSinglton.PILE.Put(this);
        }


        public TestLinkedListNode<T> Next {
            get
            {
                return pp_next != PilePointer.Invalid ? (TestLinkedListNode<T>)PileSinglton.PILE.Get(pp_next) : null;
            }
            set
            {
                this.pp_next = value.pp_self;
                PileSinglton.PILE.Put(this.pp_self,this);
            }
        }
        public TestLinkedListNode<T> Previous
        {
            get
            {
                return pp_prev != PilePointer.Invalid ? (TestLinkedListNode<T>)PileSinglton.PILE.Get(pp_prev) : null;
            }
            set
            {
                this.pp_prev = value.pp_self;
                PileSinglton.PILE.Put(this.pp_self, this);
            }
        }

        public T Value
        {
            get
            {
                return pp_value != PilePointer.Invalid ? (T)PileSinglton.PILE.Get(pp_value) : default(T);
            }
            set
            {
                if (pp_value != PilePointer.Invalid)
                {
                    PileSinglton.PILE.Put(pp_value, value);
                } else
                {
                    pp_value = PileSinglton.PILE.Put(value);
                }
                
            }
        }
        

    }
}
