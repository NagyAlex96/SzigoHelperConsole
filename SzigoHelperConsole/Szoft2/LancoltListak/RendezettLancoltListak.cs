using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole.LancoltListak
{
    public class RendezettLancoltListak<T> where T : class, IComparable
    {
        ListaElem<T> fej;

        public void BeszurasHosszabbValtozat(string kulcs, T ertek)
        {
            ListaElem<T> uj = new ListaElem<T>();

            uj.Kulcs = kulcs;
            uj.Tartalom = ertek;

            if (this.fej == null) //üres a lista
            {
                uj.Kovetkezo = null;
                fej = uj;
            }
            else
            {
                if (string.Compare(this.fej.Kulcs, kulcs) > 0) //első elem elé
                {
                    uj.Kovetkezo = this.fej;
                    this.fej = uj;
                }
                else
                {
                    ListaElem<T> p = this.fej;
                    ListaElem<T> e = null;

                    while (p != null && string.Compare(p.Kulcs, kulcs) < 0)
                    {
                        e = p;
                        p = p.Kovetkezo;
                    }

                    if (p == null) //Utolsó elem mögé
                    {
                        uj.Kovetkezo = null;
                        e.Kovetkezo = uj;
                    }
                    else //két elem közé
                    {
                        uj.Kovetkezo = p;
                        e.Kovetkezo = uj;
                    }
                }
            }

        }

        public void BeszurasRovidebbValtozat(string kulcs, T ertek)
        {
            ListaElem<T> uj = new ListaElem<T>();

            uj.Kulcs = kulcs;
            uj.Tartalom = ertek;

            ListaElem<T> p = fej;
            ListaElem<T> e = null;

            while (p != null && string.Compare(p.Kulcs, kulcs) < 0)
            {
                e = p;
                p = p.Kovetkezo;
            }

            if (e == null)
            {
                uj.Kovetkezo = this.fej;
                fej = uj;
            }
            else
            {
                uj.Kovetkezo = p;
                e.Kovetkezo = uj;
            }
        }

        public (bool, T) Kereses(string keresettKulcs)
        {
            ListaElem<T> p = fej;

            while (p != null && string.Compare(p.Kulcs, keresettKulcs) < 0)
            {
                p = p.Kovetkezo;
            }

            bool van = p != null && (string.Compare(p.Kulcs, keresettKulcs) == 0);

            if (van)
            {
                return (van, p.Tartalom);
            }
            else
            {
                return (van, null);
            }
        }
    }
}
