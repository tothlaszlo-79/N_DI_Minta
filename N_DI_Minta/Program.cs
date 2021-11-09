using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_DI_Minta
{
    class Program
    {
        static void Main(string[] args)
        {
            var u = new Ügyfel(new Buborek());

            u.Munka();
            Console.ReadLine();
        }


        public interface IRendez
        {
            List<double> Rendez(List<double> Eredeti, bool Novekvo);
        }

        public class Buborek : IRendez
        {
            public List<double> Rendez(List<double> Eredeti, bool Novekvo)
            {
                var új = new List<double>(Eredeti);
                for (var i = 0; i < új.Count; i++)
                    for (var j = 1; j < új.Count; j++)
                        if ((Novekvo && (új[j - 1] > új[j])) || (!Novekvo && (új[j] > új[j - 1])))
                        {
                            var m = új[j - 1];
                            új[j - 1] = új[j];
                            új[j] = m;
                        }
                return új;
            }
        }

        public class BinalisRendezes : IRendez
        {
            public List<double> Rendez(List<double> Eredeti, bool Novekvo)
            {
                throw new NotImplementedException();
            }
        }

        public class Ügyfel
        {
            IRendez Rendező;
            List<double> Adatok;

            public Ügyfel(IRendez R)
            {
                Rendező = R;
            }

            void Feltölt(int db)
            {
                Adatok = new List<double>();
                var r = new Random();
                for (var i = 0; i < db; i++)
                    Adatok.Add(r.NextDouble());
            }

            public void Kiír(List<Double> Számok)
            {
                foreach (var sz in Számok)
                    Console.Write("{0,5:F3}, ", sz);
                Console.WriteLine();
            }

            public void Munka()
            {
                Feltölt(10);
                Console.WriteLine("Az eredeti számsor:");
                Kiír(Adatok);
                var Növekvő = Rendező.Rendez(Adatok, true);
                Console.WriteLine("Növekvő sorba rendezve:");
                Kiír(Növekvő);
                var Csökkenő = Rendező.Rendez(Adatok, false);
                Console.WriteLine("Csökkenő sorba rendezve:");
                Kiír(Csökkenő);
            }



        }


    }
}
