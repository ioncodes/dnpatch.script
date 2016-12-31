using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delete the next 2 lines");
            Console.WriteLine("Delete this line");
            Console.WriteLine("And this line");

            Print();

            Console.Read();
        }

        private static void Print()
        {
            Console.WriteLine("Empty this function");
        }
    }
}
