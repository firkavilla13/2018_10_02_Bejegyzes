using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Bejegyzes valami = new Bejegyzes("valami", "xzy");

            /*
            Console.WriteLine(valami);
            valami.Tartalom = "asd";
            Console.WriteLine(valami);
            Console.ReadKey();
            */

            List<Bejegyzes> lista = new List<Bejegyzes>();
            lista.Add(new Bejegyzes("Albert Hoffmann", "LSD"));
            lista.Add(new Bejegyzes("Dan Millmann", "Szókratész utazásai"));
            Console.WriteLine("Kérem adja meg hány darab új bejegyzést szeretne felvenni");
            int db = int.Parse(Console.ReadLine());
            for (int i = 0; i < db; i++)
            {
                Console.WriteLine("Kérem adja meg az {0}.bejegyzés szerzőjét", i + 1);
                string szerzo = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Kérem adja meg az {0}.bejegyzés tartalmát", i + 1);
                string tartalom = Convert.ToString(Console.ReadLine());
                lista.Add(new Bejegyzes(szerzo, tartalom));
            }

            Console.WriteLine();
            StreamReader beolvas = new StreamReader("bejegyzesek.txt");
            while (!beolvas.EndOfStream)
            {
                string sor = beolvas.ReadLine();
                string[] adatok = sor.Split(';');

                lista.Add(new Bejegyzes(adatok[0], adatok[1]));
            }
            beolvas.Close();

            int likeszorzo = lista.Count * 20;
            Random rnd = new Random();
            for (int i = 0; i < likeszorzo; i++)
            {
                int likeotkapo = rnd.Next(lista.Count);
                lista[likeotkapo].Like();
            }
            Console.WriteLine();
            Console.WriteLine("Modositsa a 2. bejegyzést");
            lista[1].Tartalom = Console.ReadLine();
            Console.WriteLine();
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine(lista[i]);
            }

            Bejegyzes max;
            max = lista[0];
            for (int i = 1; i < lista.Count; i++)
            {
                Bejegyzes aktual = lista[i];

                if (max.Likeok < aktual.Likeok)
                {
                    aktual = max;
                }


            }
            Console.WriteLine(max.Likeok);
            Console.WriteLine("Van e olyan bejegyzés ami 35 nél több likeot kapott");
            if (max.Likeok > 35)
            {
                Console.WriteLine("Igen van! Pontosan : {0}", max.Likeok);
            }
            else
            {
                Console.WriteLine("Nincs! A legtöbb likeot kapott száma:{0}", max.Likeok);
            }
            int kevesebbmint15 = 0;
            for (int i = 0; i < lista.Count; i++)
            {


                if (lista[i].Likeok < 15)
                {
                    kevesebbmint15++;
                }


            }
            Console.WriteLine("Összesen {0} bejegyzés kapott 15-nél kevesebb likeot", kevesebbmint15);

            Bejegyzes swap;
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = i + 1; j < lista.Count; j++)
                {
                    if (lista[j].Likeok > lista[i].Likeok)
                    {
                        swap = lista[i];
                        lista[i] = lista[j];
                        lista[j] = swap;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine(lista[i]);
            }
            StreamWriter sw = new StreamWriter("bejegyzesek_rendezett.txt");
            for (int i = 0; i < lista.Count; i++)
            {
                sw.WriteLine(i);
                sw.Write(Convert.ToString(lista[i].Szerzo));
                sw.Write(lista[i].Tartalom);
                sw.Write(lista[i].Likeok);
                sw.Write(lista[i].Letrejot);
                sw.Write(lista[i].Szerkesztve);

            }
            Console.ReadKey();





        }
    }
}
