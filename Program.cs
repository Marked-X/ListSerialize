using System;
using System.IO;

namespace ListSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            ListRand list = new ListRand();

            list.PushBack("first"); //Head
            list.PushBack("second");
            list.PushBack("third");
            list.PushBack("fourth");
            list.PushBack("fifth"); //Tail

            list.AddRandom();

            FileStream s = new FileStream("/repos/ListSerialize/out", FileMode.Create);

            list.Serialize(s);

            list.ClearList();

            s = new FileStream("/repos/ListSerialize/out", FileMode.Open);
            
            list.Deserialize(s);

            Console.WriteLine("End.");

        }
    }
}
