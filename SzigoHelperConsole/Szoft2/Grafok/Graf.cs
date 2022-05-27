using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole.Szoft2.Grafok
{
    public abstract class Graf<T>
    {
        protected abstract int CsucsokSzama { get; }

        protected class El
        {
            public T hova;

            public double suly;
        }

        public abstract void UjCsucs(T tartalom);

        public abstract void UjEl(T from, T to, double weight = 1, bool isDirected = false);

        protected abstract List<El> Szomszedok(T csucs);

        public void SzelessegiBejaras(T honnan)
        {
            Queue<T> S = new Queue<T>();
            List<T> F = new List<T>();

            S.Enqueue(honnan);
            F.Add(honnan);

            while (S.Count != 0)
            {
                T k = S.Dequeue(); //a sorból vegyük ki az elemet, amit legrégebben tettünk bele
                Console.WriteLine(k.ToString()); //Feldolgoz (pszeudóban)

                foreach (var x in Szomszedok(k))
                {
                    if (!F.Contains(x.hova))
                    {
                        S.Enqueue(x.hova);
                        F.Add(x.hova);
                    }
                }
            }

        }

        public void MelysegiBejaras(T honnan)
        {
            List<T> F = new List<T>();
            MelysegiBejarasRekurzivan(honnan, ref F);
        }

        private void MelysegiBejarasRekurzivan(T start, ref List<T> F)
        {
            F.Add(start);
            Console.WriteLine(start.ToString());//feldolgoz

            foreach (var x in Szomszedok(start))
            {
                if (!F.Contains(x.hova))
                {
                    MelysegiBejarasRekurzivan(x.hova, ref F);
                }
            }

        }

        protected abstract T AdottIndexuCsucs(int index);

        protected abstract int AdottCsucsIndexe(T csucs);

        public (List<T>, double) Dijkstra(T start, T cel)
        {
            double[] d = new double[CsucsokSzama];
            T[] pi = new T[CsucsokSzama];
            List<T> S = new List<T>(); //prioritásos sor

            for (int i = 0; i < CsucsokSzama; i++)
            {
                T x = AdottIndexuCsucs(i);
                d[i] = double.PositiveInfinity;
                pi[i] = default(T); //T-től függően null-t vagy 0-t szeretne 
                S.Add(x);
            }

            d[AdottCsucsIndexe(start)] = 0;

            while (S.Count != 0) 
            {
                T u = MinKivesz(S, d);

                foreach (El x in Szomszedok(u))
                {
                    int ind_x = AdottCsucsIndexe(x.hova);
                    int ind_u = AdottCsucsIndexe(u);

                    if(d[ind_u] + x.suly < d[ind_x])
                    {
                        d[ind_x] = d[ind_u] + x.suly;
                        pi[ind_x] = u;
                    }
                }
            }

            List<T> erintettPontok = new List<T>();

            int celIndex = AdottCsucsIndexe(cel);
            double hossz = d[celIndex];

            while (!cel.Equals(start))
            {
                erintettPontok.Add(cel);
                cel = pi[celIndex];
                celIndex = AdottCsucsIndexe(cel);
            }

            erintettPontok.Add(start);
            erintettPontok.Reverse();

            return (erintettPontok, hossz);
        }

        private T MinKivesz(List<T> S, double[] d)
        {
            int minIndex = 0;
            double min = double.PositiveInfinity;


            for (int i = 0; i < S.Count; i++)
            {
                int idx = AdottCsucsIndexe(S[i]);
                double sulyertek = d[idx];

                if(sulyertek < min)
                {
                    min = sulyertek;
                    minIndex = i;
                }
            }

            var torlendo = S[minIndex];
            S.RemoveAt(minIndex);

            return torlendo;
        }
    }
}
