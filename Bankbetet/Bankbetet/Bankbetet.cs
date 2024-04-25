using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankbetet
{
    internal class Bankbetet
    {
        private string id;
        private int kezdotoke;
        private double kamatlab;
        private int lekotesIdo;
        // private bool hosszutavuLekotes;

        private bool kezdotokeBeallitva = false;

        public string Id
        {
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Nem lehet NULL vagy ures!");
                if (!char.IsUpper(value[0]))
                    throw new Exception("Az elso chr nem nagybetu!");
                if (value[value.Length - 1] == '/')
                    throw new Exception("Az utoloso chr nem lehet \\!");
                for (int i = 1; i < value.Length; i++)
                {
                    char c = value[i];
                    if (!char.IsUpper(c) && !char.IsDigit(c) && c != '/')
                        throw new Exception("Nem nagybetu vagy szam...");
                }
                this.id = value;
            }
            get
            {
                return this.id;
            }
        }

        public int Kezdotoke
        {
            get
            {
                return this.kezdotoke;
            }
            set
            {
                if (kezdotokeBeallitva)
                    throw new Exception("Bevolt mar alitva a kezdotoke!");
                if (value < 50000 || value > 1e8)
                    throw new Exception("5000 es 1e8 interbaluma kel leen a kezdotoke");
                this.kezdotoke = value;
                this.kezdotokeBeallitva = true;
            }
        }

        public double Kamatlab
        {
            private set
            {
                if (value < 0.01)
                    throw new Exception("Kezdotoke kisseb mint 0.01!");
                if (value > 0.99)
                    throw new Exception("Kezdotoke nagyobb mint 0.99!");
                this.kamatlab = value;
            }
            get
            {
                return this.kamatlab;
            }
        }

        public virtual int GetLekotesIdeje()
        {
            return this.lekotesIdo;
        }
        private void SetLekotesIdeje(int value)
        {
            if (value < 1 || value > 20)
                throw new Exception("Lekotes ideje hibas!");
            this.lekotesIdo = value;
        }

        public bool HosszutavuLekotes
        {
           
            get
            {
                return this.lekotesIdo > 10;
            }
        }

        public Bankbetet(string id, int kezdotoke, double kamatlab, int lekotesIdo)
        {
            Id = id;
            Kezdotoke = kezdotoke;
            Kamatlab = kamatlab;
            SetLekotesIdeje(lekotesIdo);
            // HosszutavuLekotes = true;
        }
        public Bankbetet(string id, int kezdotoke, double kamatlab) : this(id, kezdotoke, kamatlab, 5) { }

        public virtual int Hozam(int value)
        {
            double var = 0;
            var = Kezdotoke * (1 + (Kamatlab / 100));
            if (value >= lekotesIdo)
            {
            }
            else
            {
                var -= (lekotesIdo - value) * Kezdotoke / 100;
            }
            return (int)var;
        }

        public override string ToString()
        {
            return $"Azonosito: {Id}, Kezdotoke: {Kezdotoke}, Kamatlab: {Kamatlab}, Lekotes ideje: {lekotesIdo}, {(HosszutavuLekotes ? "Hosszutavu" : "nem Hosszutavu")}";
        }

        public override bool Equals(object obj)
        {
            /*
                        if (obj == null) return false;
                        if (this == obj) return true;
                        if (!(obj is Bankbetet)) return false;
                        Bankbetet masik = obj as Bankbetet;
                        return this.Id == masik.Id;
            */
            Bankbetet tmp;
            if (obj is Bankbetet)
            {
                tmp = obj as Bankbetet;
            }
            if (!(obj is Bankbetet bankbetet))
            {
                return false;
            }
            return Id.Equals(bankbetet.Id);
        }
    }
}