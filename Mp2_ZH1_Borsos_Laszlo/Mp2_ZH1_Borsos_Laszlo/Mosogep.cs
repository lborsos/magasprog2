using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mp2_ZH1_Borsos_Laszlo
{
    internal class Mosogep : HaztartasiGep
    {

        private int minVizHomerseklet;
        public int MinVizHomerseklet
        {
            set
            {
                List<int> allowedNumbers = new List<int> { 20, 25, 30, 35, 40 };
                if (!allowedNumbers.Contains(value))
                    throw new Exception("nem jo adat");
                minVizHomerseklet = value;
            }
            get
            {
                return minVizHomerseklet;
            }
        }

        private double vizfogyMosaskent;
        public double VizfogyMosaskent
        {
            set
            {
                if (value < 4)
                    throw new Exception("nem jo adat < 4");
                if (value > 6)
                    throw new Exception("nem jo adat > 6");
                vizfogyMosaskent = value;
            }
            get
            {
                return minVizHomerseklet;
            }
        }

        private SzinEnum szin;
        public SzinEnum Szin { get; set; }


        public Mosogep(string kod, int gyartasiEv, double fogyasztas, int minVizHomerseklet, double vizfogyMosaskent, SzinEnum szin) : base(kod, gyartasiEv, false, fogyasztas)
        {
            this.MinVizHomerseklet = minVizHomerseklet;
            this.VizfogyMosaskent = vizfogyMosaskent;
            this.Szin = szin;
        }
        public Mosogep(string kod, int gyartasiEv, double fogyasztas, int minVizHomerseklet, double vizfogyMosaskent) : this(kod, gyartasiEv, fogyasztas, minVizHomerseklet, vizfogyMosaskent, SzinEnum.feher)
        {
        }

        protected override void SetFogyasztas(double value)
        {
            if (value < 0.5)
                throw new Exception("Fogy <");
            if (value > 1.5)
                throw new Exception("Fogy >");
            SetFogyasztas(value);
        }

        public override int Energiaosztaly()
        {
            double k = GetFogyasztas() * MinVizHomerseklet * VizfogyMosaskent;
            int oo = 0;
            if (k >= 40 && k < 75)
                oo = 1;
            if (k >= 75 && k < 135)
                oo = 2;
            if (k >= 135 && k < 210)
                oo = 3;
            if (k >= 210 && k < 280)
                oo = 4;
            if (k >= 280 && k < 360)
                oo = 5;

            return oo;
        }

        public override string ToString()
        {
            return $"Kod: {Kod}, Gyartas eve: {GyartasiEv}, Fogyasztas: {GetFogyasztas()}, Min vizh: {MinVizHomerseklet}, Vizfogy: {VizfogyMosaskent}, Szin: {Szin}";
        }

    }
}
