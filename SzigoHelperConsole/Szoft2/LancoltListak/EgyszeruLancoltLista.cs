using System;
using System.Collections.Generic;

namespace SzigoHelperConsole.LancoltListak
{
    public class EgyszeruLancoltLista<TTartalom,TKulcs> 
        where TKulcs : IComparable 
        where TTartalom : class, IComparable
    {
        ListaElem<TTartalom,TKulcs> fej;

        /// <summary>
        /// Legegyszerűbben megvalósítható beszúrás. Az elemek a listában a beszúrás sorrendjével ellentétes sorrendben tárolódnak
        /// </summary>
        /// <param name="ertek">Beszúrandó tartalom</param>
        public void BeszurasElsoElemEle(TTartalom ertek)
        {
            ListaElem<TTartalom,TKulcs> uj = new ListaElem<TTartalom,TKulcs>();

            uj.Tartalom = ertek;
            uj.Kovetkezo = this.fej;
            fej = uj;
        }

        /// <summary>
        /// A lista pont ugyanabban a sorrendben tárolja az elemeket, mint ahogy azokat elhelyeztük benne
        /// </summary>
        /// <param name="ertek">Beszúrandó tartalom</param>
        public void BeszurasUtolsoElemMoge(TTartalom ertek)
        {
            ListaElem<TTartalom,TKulcs> uj = new ListaElem<TTartalom,TKulcs>();

            uj.Tartalom = ertek;
            uj.Kovetkezo = null;

            if (this.fej == null) //üres a lista
            {
                fej = uj;
            }
            else //utolsó elem megkeresése
            {
                var p = fej;

                while (p.Kovetkezo != null)
                {
                    p = p.Kovetkezo;
                }
                p.Kovetkezo = uj;
            }

        }

        /// <summary>
        /// A lista két, már meglévő eleme közé kell elhelyeznünk egy új elemet
        /// </summary>
        /// <param name="ertek">Beszúrandó tartalom</param>
        /// <param name="N">Meghatározza a beszúrandó elem helyét</param>
        public void BeszurasNedikHelyre(TTartalom ertek, int N)
        {
            ListaElem<TTartalom,TKulcs> uj = new ListaElem<TTartalom,TKulcs>();

            uj.Tartalom = ertek;

            if (this.fej == null || N == 1)
            {
                uj.Kovetkezo = this.fej;
                this.fej = uj;
            }
            else //legalább 1 elem van már a tömbben
            {
                var p = fej;
                int i = 2;

                while (p.Kovetkezo != null && i < N)
                {
                    p = p.Kovetkezo;
                    i = i + 1;
                }

                uj.Kovetkezo = p.Kovetkezo;
                p.Kovetkezo = uj;
            }
        }

        /// <summary>
        /// A már meglévő lista elemeinek feldolgozása
        /// </summary>
        public void Bejaras()
        {
            ListaElem<TTartalom,TKulcs> p = fej;

            while (p != null)
            {
                Console.WriteLine(p.Tartalom.ToString()); //pszeudó kódban ez a Feldolgoz(p)
                p = p.Kovetkezo;
            }
        }

        /// <summary>
        /// Megadott feltétel szerinti keresés. Hasonlít a Lineáris keresésre (egyszerű prog tételek)
        /// </summary>
        /// <param name="F">A keresési feltétel, ami megadja, hogy minek kell megfelelnie a keresett elem tartalmának</param>
        /// <returns>(Bool, T class) (True: van ilyen elem, T class-nak a ToString metódusa)</returns>
        public (bool, TTartalom) Kereses(Func<TTartalom, bool> F)
        {
            ListaElem<TTartalom,TKulcs> p = this.fej;

            while (p != null && !F(p.Tartalom))
            {
                p = p.Kovetkezo;
            }

            bool van = (p != null);

            if (van)
            {
                return (true, p.Tartalom);
            }
            else
            {
                return (false, null);
            }
        }

        /// <summary>
        /// Nem csak a lista elemen belül megtalálható tartalmat töröljük( hanem az egész lista elemet eltávolítjuk
        /// </summary>
        /// <param name="torlendo">Törlendő érték</param>
        /// <exception cref="Exception">A törlendő érték nem szerepel a listában</exception>
        public void Torles(TTartalom torlendo)
        {
            ListaElem<TTartalom,TKulcs> p = this.fej;
            ListaElem<TTartalom,TKulcs> e = null;

            while (p != null && !p.Tartalom.Equals(torlendo))
            {
                e = p;
                p = p.Kovetkezo;
            }

            if (p != null)
            {
                if (e == null)
                {
                    this.fej = p.Kovetkezo;
                }
                else
                {
                    e.Kovetkezo = p.Kovetkezo;
                }
            }
            else
            {
                throw new Exception("Nincs ilyen törlendő adat.");
            }
        }

        /// <summary>
        /// Láncolt lista összes elemének törlése
        /// </summary>
        public void TeljesTorles()
        {
            while (this.fej!=null)
            {
                this.fej = fej.Kovetkezo;
            }
        }
    }
}
