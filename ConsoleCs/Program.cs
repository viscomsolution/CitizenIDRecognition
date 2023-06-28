using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGMT;

namespace ConsoleCs
{
    class Program
    {
        public static int Main(string[] args)
        {
            if(args.Length == 1)
            {
                CitizenIDReader reader = new CitizenIDReader();
                string result = reader.Read(args[0]);
                //Console.WriteLine(result);

                return int.Parse(result);
            }
            return 0;
        }
    }
}
