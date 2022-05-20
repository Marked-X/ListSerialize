using System;
using System.IO;

namespace ListSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            ListRand list = new ListRand();

            list.PushFront("Tail");

            list.PushFront("oof1");
            list.PushFront("oof2");
            list.PushFront("oof3");

            list.PushFront("Head");

            list.AddRandom();

            FileStream s = new FileStream("/repos/ListSerialize/out", FileMode.Create);

            list.Serialize(s);

            Console.WriteLine(list.GetNodeId(list.Tail.Prev));

            Console.WriteLine(list.GetNodeById(0).Data);

            Console.WriteLine("End;");
            list.ClearList();

            s = new FileStream("/repos/ListSerialize/out", FileMode.Open);
            
            list.Deserialize(s);

            Console.WriteLine("End again");

        }
    }
}
