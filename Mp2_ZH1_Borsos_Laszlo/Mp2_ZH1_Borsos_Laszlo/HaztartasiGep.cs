using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp2_ZH1_Borsos_Laszlo
{
    internal class HaztartasiGep
    {
        private string kod;

        public string Kod
        {
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Nem lehet NULL vagy ures!");
                if (value.Length > 13)
                    throw new Exception("Hossz > 13!");
                this.kod = value;
            }
            get
            {
                return this.kod;
            }
        }

        private int gyartasiEv;
        public int GyartasiEv 
        {
            private set
            {
                if (value > DateTime.Now.Year)
                    throw new Exception("Datum nagyobb az akt evnel!");
                if (value < DateTime.Now.Year - 10)
                    throw new Exception("Datum kisseb az akt evnel 10 evvel!");
                this.gyartasiEv = value;
            }
            get
            {
                return this.gyartasiEv;
            }
        }

        private bool kisgepe;
        private bool kisgepeBeallitva = false;

        public bool KisgepeBeallitva
        {
            set
            {
                if (kisgepeBeallitva)
                    throw new Exception("mar belett allitva!");
                kisgepe = value;
                kisgepeBeallitva = true;
            }
            get
            {
                return kisgepe;
            }
        }

        private double fogyasztas;

        public double GetFogyasztas()
        {
            return fogyasztas;
        }
        protected virtual void SetFogyasztas(double value)
        {
            if (value < 0.2)
                throw new Exception("Fogy <");
            if (value > 2.5)
                throw new Exception("Fogy >");
            fogyasztas = value;
        }
        public HaztartasiGep(string kod, int gyartasiEv, bool kisgepe, double fogyasztas)
        {
            Kod = kod;
            GyartasiEv = gyartasiEv;
            this.kisgepe = kisgepe;
            this.fogyasztas = fogyasztas;
        }
        public HaztartasiGep(string kod, bool kisgepe, double fogyasztas) : this(kod, 2024, kisgepe, fogyasztas)
        {
        }

        public virtual int Energiaosztaly()
        {
            int oo = 0;
            if (fogyasztas >= 0.2 && fogyasztas < 0.6)
                oo = 1;
            if (fogyasztas >= 0.6 && fogyasztas < 1.0)
                oo = 2;
            if (fogyasztas >= 1.0 && fogyasztas < 1.5)
                oo = 3;
            if (fogyasztas >= 1.5 && fogyasztas < 2.0)
                oo = 4;
            if (fogyasztas >= 2.0 && fogyasztas < 2.5)
                oo = 5;

            if (DateTime.Now.Year - GyartasiEv > 5)
            {
                if (oo > 1)
                    oo--;
            }
            return oo;
        }

        public override string ToString()
        {
            return $"Kod: {Kod}, Gyartas eve: {GyartasiEv}, {(kisgepe ? "Kisgep" : "nem kisgep")}, Fogyasztas: {fogyasztas}";
        }

        public override bool Equals(object obj)
        {
            HaztartasiGep tmp;
            if (obj is HaztartasiGep)
            {
                tmp = obj as HaztartasiGep;
            }
            if (!(obj is HaztartasiGep hazt))
            {
                return false;
            }
            return Kod.Equals(hazt.Kod);
        }
    }
}
