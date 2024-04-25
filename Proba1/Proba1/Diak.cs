using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba1
{
    internal class Diak
    {
        public string neptunkod;
        private string nev;
        public DateTime szulDatum;
        public Gender gender;
        private double atlag;

        private void SetAtlag(double value)
        {
            if (value < 1)
                throw new Exception("Az atlag k m 1");
            atlag = value;
        }

        public string Nev
        {
            set 
            {
                if (!value.Contains(' '))
                    throw new Exception("A nev n t spacet");
                string[] nevDarab = value.Split(' ');
                foreach (var item in nevDarab)
                {
                    if (item.Length < 2)
                        throw new Exception("A nev reszl hssz kiss mint 2 char");
                }
                nev = value;
            }
            get { return nev; }
        }
        public override string ToString()
        {
            string st = string.Empty;
            st += $"A nev: {nev}\n";
            st += $"A NK: {neptunkod}\n";
            st += $"A szulDatum: {szulDatum}\n";
            st += $"Az atlag: {atlag}\n";
            return st;
        }
    }
}
