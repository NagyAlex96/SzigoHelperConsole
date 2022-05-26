using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole.LancoltListak
{
    public class EgyszeruLancoltLista<T> where T : class, IComparable
    {
        ListaElem<T> fej;

        /// <summary>
        /// Legegyszerűbben megvalósítható beszúrás. Az elemek a listában a beszúrás sorrendjével ellentétes sorrendben tárolódnak
        /// </summary>
        /// <param name="ertek">Beszúrandó tartalom</param>
        public void BeszurasElsoElemEle(T ertek)
        {
            ListaElem<T> uj = new ListaElem<T>();

            uj.Tartalom = ertek;
            uj.Kovetkezo = this.fej;
            fej = uj;
        }

        /// <summary>
        /// A lista pont ugyanabban a sorrendben tárolja az elemeket, mint ahogy azokat elhelyeztük benne
        /// </summary>
        /// <param name="ertek">Beszúrandó tartalom</param>
        public void BeszurasUtolsoElemMoge(T ertek)
        {
            ListaElem<T> uj = new ListaElem<T>();

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
        public void BeszurasNedikHelyre(T ertek, int N)
        {
            ListaElem<T> uj = new ListaElem<T>();

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
            ListaElem<T> p = fej;

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
        public (bool, T) Kereses(Func<T, bool> F)
        {
            ListaElem<T> p = this.fej;

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
        public void Torles(T torlendo)
        {
            ListaElem<T> p = this.fej;
            ListaElem<T> e = null;

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
