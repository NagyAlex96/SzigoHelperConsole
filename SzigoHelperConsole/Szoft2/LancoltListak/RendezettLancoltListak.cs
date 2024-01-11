using System;
using System.Collections.Generic;

namespace SzigoHelperConsole.LancoltListak
{
    public class RendezettLancoltListak<TTartalom, TKulcs> 
        where TKulcs : IComparable
        where TTartalom : class, IComparable
    {
        ListaElem<TTartalom,TKulcs> fej;

        public void BeszurasHosszabbValtozat(TKulcs kulcs, TTartalom ertek)
        {
            ListaElem<TTartalom,TKulcs> uj = new ListaElem<TTartalom,TKulcs>();

            uj.Kulcs = kulcs;
            uj.Tartalom = ertek;

            if (this.fej == null) //üres a lista
            {
                uj.Kovetkezo = null;
                fej = uj;
            }
            else
            {
                if (this.fej.Kulcs.CompareTo(kulcs) > 0) //első elem elé
                {
                    uj.Kovetkezo = this.fej;
                    this.fej = uj;
                }
                else
                {
                    ListaElem<TTartalom,TKulcs> p = this.fej;
                    ListaElem<TTartalom,TKulcs> e = null;

                    while (p != null && p.Kulcs.CompareTo(kulcs) < 0)
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

        public void BeszurasRovidebbValtozat(TKulcs kulcs, TTartalom ertek)
        {
            ListaElem<TTartalom,TKulcs> uj = new ListaElem<TTartalom,TKulcs>();

            uj.Kulcs = kulcs;
            uj.Tartalom = ertek;

            ListaElem<TTartalom,TKulcs> p = fej;
            ListaElem<TTartalom,TKulcs> e = null;

            while (p != null && p.Kulcs.CompareTo(kulcs) < 0)
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

        public (bool, TTartalom) Kereses(TKulcs keresettKulcs)
        {
            ListaElem<TTartalom,TKulcs> p = fej;

            while (p != null && p.Kulcs.CompareTo(keresettKulcs) < 0)
            {
                p = p.Kovetkezo;
            }

            bool van = p != null && (p.Kulcs.CompareTo(keresettKulcs) == 0);

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
