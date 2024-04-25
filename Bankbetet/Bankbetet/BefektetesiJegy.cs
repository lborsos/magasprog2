using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankbetet
{
    internal class BefektetesiJegy : Bankbetet
    {
        private string reszvenyAlap;
        public string ReszvenyAlap
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Nem lehet NULL vagy ures!");
                this.reszvenyAlap = value;
            }
            get
            {
                return this.reszvenyAlap;
            }
        }

        private double minHozam;

        public double MinHozam
        {
            set
            {
                if (value < 0.01)
                    throw new Exception("Min hozam nem lehet kisseb mint 0.01!");
                if (value > 0.99)
                    throw new Exception("Min hozam nem lehet nagyobb mint 0.99!");
                this.minHozam = value;
            }
            get
            {
                return minHozam;
            }
        }
        private double maxHozam;

        public double MaxHozam
        {
            set
            {
                if (value < MaxHozam)
                    throw new Exception("Max hozam nem lehet kisseb mint MinHozam!");
                if (value > 0.99)
                    throw new Exception("Max hozam nem lehet nagyobb mint 0.99!");
                this.maxHozam = value;
            }
            get
            {
                return maxHozam;
            }
        }

        private Kock kockazat;

        public BefektetesiJegy(string id, int kezdotoke, double kamatlab, int lekotesIdo) : base(id, kezdotoke, kamatlab, lekotesIdo)
        {
        }

        public Kock Kockazat { get; set; }

        public BefektetesiJegy(string id, int keddotoke, string reszvenyAlap, double minHozam, double maxHozam, Kock kockazat) : base(id, keddotoke, 0.01)
        {
            ReszvenyAlap = reszvenyAlap;
            MinHozam = minHozam;
            MaxHozam = maxHozam;
            this.Kockazat = kockazat;
        }
        public BefektetesiJegy(string id, int keddotoke, string reszvenyAlap, double minHozam, double maxHozam) : this(id, keddotoke, reszvenyAlap, minHozam, maxHozam, Kock.mersekelt)
        {

        }

        public override int GetLekotesIdeje()
        {
            throw new Exception("xxx");
        }

        public override int Hozam(int value)
        {
            return base.Hozam(value);
        }

        public override string ToString()
        {
            return $"Azonosito: {Id}, Kezdotoke: {Kezdotoke}, Kamatlab: {Kamatlab}, {(HosszutavuLekotes ? "Hosszutavu" : "nem Hosszutavu")}, Reszveny alap: {ReszvenyAlap}";
        }

    }




}
