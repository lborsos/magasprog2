using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp2_ZH1_Borsos_Laszlo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Itt inicializálja a boltot!
            HaztartasiBolt haztartasiB = new HaztartasiBolt();
            haztartasiB.BoltNeve = "Borsos Laszlo boltja";

            StreamReader sr = new StreamReader("haztartasigepek_pont.csv");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                if (adatok[0] == "H")
                {
                    //Itt hozzon létre egy háztartási gép példányt és adja hozzá a bolthoz
                    HaztartasiGep haztG = new HaztartasiGep(adatok[1], int.Parse(adatok[2]), adatok[3]=="kisgep", double.Parse(adatok[4]));
                    haztartasiB.GepHozzaadasa(haztG);
                }
                else
                {
                    //Itt hozzon létre egy mosógép példányt és adja hozzá a bolthoz
                    SzinEnum myEnum = (SzinEnum)Enum.Parse(typeof(SzinEnum), adatok[6]);
                    Mosogep mosoG = new Mosogep(adatok[1], int.Parse(adatok[2]), double.Parse(adatok[3]), int.Parse(adatok[4]), double.Parse(adatok[5]), myEnum);
                }
            }
            sr.Close();

            //Itt jelenítse meg az implementált lekérdezések eredményeit!

            foreach (HaztartasiGep item in haztartasiB.OtEvnelOregebb)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---");
            foreach (Mosogep item in haztartasiB.AdottEnergOsztTartMos(2))
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---");
            string idx = "RT-4-ROF71";
            HaztartasiGep hg;
            hg = haztartasiB.IndexOf(idx);
            Console.WriteLine(hg.ToString());
            Console.ReadLine();
        }
    }
}
