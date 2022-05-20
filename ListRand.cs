using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ListSerialize
{
    class ListRand
    {
        public ListNode Head = null;
        public ListNode Tail = null;
        public int Count = 0;

        public void Serialize(Stream s)
        {
            using (BinaryWriter writer = new BinaryWriter(s, Encoding.UTF8, false))
            {
                ListNode temp = Head;
                writer.Write(Count);
                for (int i = 0; i < Count; i++)
                {
                    writer.Write(temp.Data);
                    writer.Write(GetNodeId(temp.Rand));
                    temp = temp.Next;
                }
            }
        }

        public void Deserialize(Stream s)
        {
            List<int> list = new List<int>();
            
            using (BinaryReader reader = new BinaryReader(s, Encoding.UTF8, false))
            {
                for (int i = 0, u = reader.ReadInt32(); i < u; i++)
                {
                    PushBack(reader.ReadString());
                    list.Add(reader.ReadInt32());
                }
            }
            ListNode temp = Head;
            foreach (int i in list)
            {
                temp.Rand = GetNodeById(i);
                temp = temp.Next;
            }
        }

        public void PushFront(string data = "")
        {
            if (Count == 0)
            {
                Head = Tail = new ListNode(data);
            }
            else
            {
                ListNode temp = new ListNode(null, Head, null, data);
                Head.Prev = temp;
                Head = temp;
            }

            Count++;
        }

        public void PushBack(string data = "")
        {
            if (Count == 0)
            {
                Head = Tail = new ListNode(data);
            }
            else
            {
                ListNode temp = new ListNode(Tail, null, null, data);
                Tail.Next = temp;
                Tail = temp;
            }

            Count++;
        }

        public int GetNodeId(ListNode node)
        {
            int id = 0;
            ListNode temp = Head;
            while (id < Count)
            {
                if (temp != node)
                    temp = temp.Next;
                else
                    return id;
                id++;
            }
            return -1;
        }

        public ListNode GetNodeById(int id)
        {
            if (id > Count || id == -1)
                return null;

            if (id > Count / 2)
            {
                int i = Count - 1;
                ListNode temp = Tail;
                 while (i > id)
                {
                    temp = temp.Prev;
                    i--;
                }
                return temp;
            }
            else
            {
                int i = 0;
                ListNode temp = Head;
                while (i < id)
                {
                    temp = temp.Next;
                    i++;
                }
                return temp;
            }
        }

        public void ClearList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void AddRandom()
        {
            Random random = new Random();
            ListNode temp = Head;
            
            for (int i = 0; i < Count; i++)
            {
                int rand = random.Next(-1, Count);
                
                if (rand == -1)
                    temp.Rand = null;
                else
                {
                    temp.Rand = GetNodeById(rand);
                }

                temp = temp.Next;
            }
        }
    }
}
