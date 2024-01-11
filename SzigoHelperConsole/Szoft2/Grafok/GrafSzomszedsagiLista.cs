using System.Collections.Generic;

namespace SzigoHelperConsole.Szoft2.Grafok
{
    public class GrafSzomszedsagiLista<T> : Graf<T>
    {
        List<T> tartalmak; //csúcsok
        List<List<El>> szomszedok; //élek

        public GrafSzomszedsagiLista()
        {
            tartalmak = new List<T>();
            szomszedok = new List<List<El>>();
        }

        protected override int CsucsokSzama
        {
            get
            {
                return tartalmak.Count;
            }
        }

        public override void UjCsucs(T tartalom)
        {
            tartalmak.Add(tartalom);
            szomszedok.Add(new List<El>());
        }

        public override void UjEl(T from, T to, double weight = 1, bool isDirected = false)
        {
            int index = tartalmak.IndexOf(from);
            szomszedok[index].Add(new Graf<T>.El()
            {
                hova = to,
                suly = weight,
            });

            if (!isDirected) //irányítattlan a gráf 
            {
                index = tartalmak.IndexOf(to);
                szomszedok[index].Add(new Graf<T>.El()
                {
                    hova = from,
                    suly = weight,
                });
            }


        }

        protected override int AdottCsucsIndexe(T csucs)
        {
            return tartalmak.IndexOf(csucs);
        }

        protected override T AdottIndexuCsucs(int index)
        {
            return tartalmak[index];
        }

        protected override List<El> Szomszedok(T csucs)
        {
            int index = tartalmak.IndexOf(csucs);

            return szomszedok[index];
        }
    }
}
