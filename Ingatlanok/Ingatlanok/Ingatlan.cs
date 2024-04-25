using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlanok
{
    internal class Ingatlan
    {
        private string helyrajziSzam;

        public string HelyrajziSzam
        {
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Nem lehet NULL vagy ures!");
                if (value[0] == '0' || value[0] == '/')
                    throw new Exception("Az elso chr nem megfelelo!");
                if (value[value.Length - 1] == '/')
                    throw new Exception("Az utoloso chr nem lehet /!");
                for (int i = 1; i < value.Length; i++)
                {
                    char c = value[i];
                    if (!char.IsDigit(c) && c != '/')
                        throw new Exception("Nem szam vagy /");
                }
                this.helyrajziSzam = value;
            }
            get
            {
                return this.helyrajziSzam;
            }
        }

        private int szelesseg;
        private bool szelessegBealitva = false;

        public int Szelesseg
        {
            private set
            {
                if (!szelessegBealitva)
                    throw new Exception("Mar be lett allitva a szelesseg!");
                if (value < 4)
                    throw new Exception("<4");
                if (value > 20)
                    throw new Exception(">20");
                szelessegBealitva = true;
                szelesseg = value;
            }
            get
            {
                return this.szelesseg;
            }

        }
        private int hossz;
        private bool hosszBealitva = false;

        private void SetHossz(int value)
        {
            if (!hosszBealitva)
                throw new Exception("Mar be lett allitva a hossz!");
            if (value < 4)
                throw new Exception("<4");
            if (value > 20)
                throw new Exception(">20");
            hosszBealitva = true;
            this.hossz = value;
        }
        private int GetHossz()
        {
            return this.hossz;
        }

        private AllapotEnum allapot;
        public AllapotEnum Allapot { get; set; }

        public virtual int Alapterulet()
        {
            return Szelesseg * GetHossz();
        }

        public Ingatlan(string helyrajziSzam, int szelesseg, int hossz, AllapotEnum allapot)
        {
            HelyrajziSzam = helyrajziSzam;
            Szelesseg = szelesseg;
            this.hossz = hossz;
            Allapot = allapot;
        }
        public Ingatlan(string helyrajziSzam, int szelesseg, int hossz) : this(helyrajziSzam, szelesseg, hossz, AllapotEnum.Ujepitesu)
        {
        }

    }
}
