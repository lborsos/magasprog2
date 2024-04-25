using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlanok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Itt inicializálja a bankot!

            StreamReader sr = new StreamReader("ingatlanok.csv");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                if (adatok[0] == "B")
                {
                    //Itt hozzon létre egy bankbetét példányt és adja hozzá a bankhoz
                }
                else
                {
                    //Itt hozzon létre egy befektetési jegy példányt és adja hozzá a bankhoz
                }
            }
            sr.Close();

            //Itt jelenítse meg az implementált lekérdezések eredményeit!

            Console.ReadLine();
        }
    }
}
