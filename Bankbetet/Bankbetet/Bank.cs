using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankbetet
{
    internal class Bank
    {
        private List<Bankbetet> bankbetetek = new List<Bankbetet>();
        public string BankNeve { get; set; }

        public void BankbetetHozzaadasa(Bankbetet bankbetet)
        {
            if (bankbetetek.Contains(bankbetet)) 
            {
                throw new Exception("mar szerepel a listaba");
            }
            bankbetetek.Add(bankbetet);
        }

        public List<Bankbetet> BankbetMagKezdotokevel
        {
            /*
            get
            {
                List<Bankbetet> temp = new List<Bankbetet>();
                foreach (Bankbetet item in bankbetetek)
                {
                    if  (item.Kezdotoke > 5e6)
                    {
                        temp.Add(item);
                    }
                }
                return temp;
            }
            */
            get => bankbetetek.Where(x => x.Kezdotoke>5e6).ToList();
        }

        public List<BefektetesiJegy> BefJegyAdottHozFol(double hozam)
        {
            List<BefektetesiJegy> temp = new List<BefektetesiJegy>();
            foreach (Bankbetet item in bankbetetek)
            {
                BefektetesiJegy befJegy = item as BefektetesiJegy;
                if (befJegy != null)
                {
                    if (befJegy.MinHozam > hozam)
                    {
                        temp.Add(befJegy);
                    }
                }
            }
            return temp;
        }

        public Bankbetet IndexOf(string id)
        {
            foreach (Bankbetet item in bankbetetek)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            throw new Exception("Nincs ilyen bankbetet!");

        }
    }
}
