using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dnpatch.script.patcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Script script = new Script("patcher.json");
            script.Patch();

            Console.Read();
        }
    }
}
