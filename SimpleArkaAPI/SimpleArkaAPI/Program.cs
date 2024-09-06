using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleArkaAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArkaAPI.Init();
            Thread.Sleep(5000);
            ArkaAPI.Inject();
            Console.ReadKey();
        }
    }
}
