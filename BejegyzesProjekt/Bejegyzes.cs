using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    class Bejegyzes
    {
        private string szerzo;
        private string tartalom;
        private int likeok;
        private DateTime letrejot;
        private DateTime szerkesztve;

        public Bejegyzes(string szerzo, string tartalom)
        {
            this.szerzo = szerzo;
            this.tartalom = tartalom;
            this.likeok = 0;
            this.letrejot = DateTime.Now;
            this.szerkesztve = letrejot;
        }

        public string Szerzo
        {
            get
            {
                return szerzo;
            }

        }

        public string Tartalom
        {
            get
            {
                return tartalom;
            }

            set
            {
                tartalom = value;
                this.szerkesztve = DateTime.Now;
            }

        }

        public int Likeok
        {
            get
            {
                return likeok;
            }

        }

        public DateTime Letrejot
        {
            get
            {
                return letrejot;
            }

        }

        public DateTime Szerkesztve
        {
            get
            {
                return szerkesztve;
            }
        }
        public void Like()
        {
            likeok++;
        }
        public string Kiir()
        {
            return szerzo + "-" + likeok + letrejot + "\n" + "Szerkesztve:" + szerkesztve + "\n" + tartalom;
        }
        public override string ToString()
        {
            if (letrejot == szerkesztve)
            {
                return szerzo + "-" + likeok + "-" + letrejot + "\n" + tartalom;
            }
            else
            {
                return szerzo + "-" + likeok + letrejot + "\n" + "Szerkesztve:" + szerkesztve + "\n" + tartalom;
            }

        }
    }
}
