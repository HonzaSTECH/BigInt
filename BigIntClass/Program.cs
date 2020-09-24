using System;
using System.IO;

namespace BigIntClass
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();

                StringInt strint = new StringInt(a);

                strint.Add(b);
                //strint.Subtract(b);
            
                Console.WriteLine(strint.ToString());
            }
            Console.ReadKey(true);
        }
    }
}
