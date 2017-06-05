using NFX.ApplicationModel.Pile;

namespace NFX.Utils
{
    public class LinkedListNode<T>
    {
        protected PilePointer m_pp_next { get; set; } = PilePointer.Invalid;
        protected PilePointer m_pp_prev { get; set; } = PilePointer.Invalid;
        protected PilePointer m_pp_self { get; set; } = PilePointer.Invalid;
        protected PilePointer m_pp_value { get; set; } = PilePointer.Invalid;
        
        
        
    }
}