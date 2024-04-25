using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp2_ZH1_Borsos_Laszlo
{
    internal class HaztartasiBolt
    {
        private List<HaztartasiGep> haztartasiGepek = new List<HaztartasiGep>();
        public string BoltNeve { get; set; }

        public void GepHozzaadasa(HaztartasiGep haztGep)
        {
            if (haztartasiGepek.Contains(haztGep))
                throw new Exception("mar szerepel a listaba");
            haztartasiGepek.Add(haztGep);
        }

        public List<HaztartasiGep> OtEvnelOregebb
        {
            get
            {
                List<HaztartasiGep> temp = new List<HaztartasiGep>();
                foreach (HaztartasiGep item in haztartasiGepek)
                {
                    if (item.GyartasiEv < 2019)
                    {
                        temp.Add(item);
                    }
                }
                return temp;
            }
        }
        public List<HaztartasiGep> AdottEnergOsztTartMos(int energiaO)
        {
            {
                List<HaztartasiGep> temp = new List<HaztartasiGep>();
                foreach (HaztartasiGep item in haztartasiGepek)
                {
                    Mosogep mosGep = item as Mosogep;
                    if (mosGep != null)
                    {
                        if (mosGep.Energiaosztaly() == energiaO)
                        {
                            temp.Add(mosGep);
                        }
                    }
                }
                return temp;
            }
        }

        public HaztartasiGep IndexOf(string kod)
        {
            foreach (HaztartasiGep item in haztartasiGepek)
            {
                if (item.Kod == kod)
                {
                    return item;
                }
            }
            throw new Exception("Nincs ilyen haztartasi gep!");

        }

    }
}
