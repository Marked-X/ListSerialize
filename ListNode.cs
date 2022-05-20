using System;
using System.Collections.Generic;
using System.Text;

namespace ListSerialize
{
    class ListNode
    {
        public ListNode Prev;
        public ListNode Next;
        public ListNode Rand;
        public string Data;

        public ListNode(ListNode prev = null, ListNode next = null, ListNode rand = null, string data = "")
        {
            Prev = prev;
            Next = next;
            Rand = rand;
            Data = data;
        }

        public ListNode(string data) : this(null, null, null, data) { }
    }
}
