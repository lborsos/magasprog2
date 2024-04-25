using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Diak d = new Diak();
            d.neptunkod = "F4MQFM";
            //d.nev = "Matyi";
            d.Nev = "Kati Pati";
            Console.WriteLine(d);
            Console.ReadLine();
        }
    }
}
