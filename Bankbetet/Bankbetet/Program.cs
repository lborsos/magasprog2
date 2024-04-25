using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankbetet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Itt inicializálja a bankot!

            Bank bank = new Bank();
            bank.BankNeve = "OTP";


            StreamReader sr = new StreamReader("bankbetetek.csv");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                if (adatok[0] == "B")
                {
                    //Itt hozzon létre egy bankbetét példányt és adja hozzá a bankhoz
                    Bankbetet bankBet = new Bankbetet(adatok[1], int.Parse(adatok[2]), double.Parse(adatok[3].Replace(',','.')), int.Parse(adatok[4]));
                    bank.BankbetetHozzaadasa(bankBet);
                }
                else
                {
                    //Itt hozzon létre egy befektetési jegy példányt és adja hozzá a bankhoz
                    Kock myEnum = (Kock)Enum.Parse(typeof(Kock), adatok[8]);
                    BefektetesiJegy befJegy = new BefektetesiJegy(adatok[1], int.Parse(adatok[2]), adatok[5], double.Parse(adatok[6].Replace(',', '.')), double.Parse(adatok[7].Replace(',', '.')), myEnum);
                    bank.BankbetetHozzaadasa(befJegy);
                }
            }
            sr.Close();

            //Itt jelenítse meg az implementált lekérdezések eredményeit!
            foreach (Bankbetet item in bank.BankbetMagKezdotokevel)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("--------------------------");
            foreach (BefektetesiJegy item in bank.BefJegyAdottHozFol(100000))
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("--------------------------");
            string idx = "LN0GXZM";
            Bankbetet bt;
            bt = bank.IndexOf(idx);
            Console.WriteLine(bt.ToString());

            Console.ReadLine();
        }
    }
}
