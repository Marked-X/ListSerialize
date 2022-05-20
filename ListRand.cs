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
                Dictionary<ListNode, int> nodes = new Dictionary<ListNode, int>();

                for (int i = 0; i < Count; i++)
                {
                    nodes.Add(temp, i);
                    temp = temp.Next;
                }

                temp = Head;
                writer.Write(Count);

                for (int i = 0; i < Count; i++)
                {
                    writer.Write(temp.Data);
                    
                    if (temp.Rand == null)
                        writer.Write(-1);
                    else
                        writer.Write(nodes[temp.Rand]);
                    
                    temp = temp.Next;
                }
            }
        }

        public void Deserialize(Stream s)
        {
            using (BinaryReader reader = new BinaryReader(s, Encoding.UTF8, false))
            {
                int j = reader.ReadInt32();
                int[] randId = new int[j];

                Dictionary<int, ListNode> nodes = new Dictionary<int, ListNode>();

                for (int i = 0; i < j; i++)
                {
                    nodes.Add(i, PushBack(reader.ReadString()));
                    randId[i] = reader.ReadInt32();
                }

                ListNode temp = Head;
                for (int i = 0; i < j; i++)
                {
                    if (randId[i] == -1)
                        temp.Rand = null;
                    else
                        temp.Rand = nodes[randId[i]];
                    temp = temp.Next;
                }
            }
        }

        public ListNode PushBack(string data = "")
        {
            if (Count == 0)
            {
                Count++;
                return Head = Tail = new ListNode(data);
            }
            else
            {
                Count++;
                ListNode temp = new ListNode(Tail, null, null, data);
                Tail.Next = temp;
                Tail = temp;
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

        public ListNode GetNodeById(int id)
        {
            if (id > Count || id < 0)
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
    }
}
