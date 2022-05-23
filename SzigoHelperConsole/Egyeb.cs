using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole
{
    public class Egyeb
    {

        /// <summary>
        /// Megkeresi két egész szám legnagyobb közös osztóját
        /// </summary>
        /// <param name="nagyobbSzam">Pozitív egész szám, ami kezdetben nagyobb, mint a másik paraméter</param>
        /// <param name="kisebbSzam">Pozitív egész szám, ami kezdetben kisebb, mint a másik paraméter</param>
        /// <returns>Legnagyobb közös osztó értéke</returns>
        static int EukledesziAlgoritmusTetel(int nagyobbSzam, int kisebbSzam)
        {
            int lnko = nagyobbSzam % kisebbSzam;

            while (lnko != 0)
            {
                nagyobbSzam = kisebbSzam;
                kisebbSzam = lnko;
                lnko = nagyobbSzam % kisebbSzam;
            }

            return kisebbSzam;
        }

        /// <summary>
        /// Két számról megmondja, hogy relatív prímjei-e egymásnak
        /// </summary>
        /// <param name="bemenetiTomb">Tömb, ahol azokat a számokat tároljuk, amikhez hasonlítunk</param>
        /// <param name="egeszErtek">Hasonlított szám</param>
        /// <returns>Logikai tömb, ahol minden számra megnéztük, hogy egymás relatív prímjei-e</returns>
        static bool[] RelativPrimVizsgalatTetel(int[] bemenetiTomb, int egeszErtek)
        {
            /*
             * Magyarázat: A matematikában az a és b egész számok esetén azt mondjuk, hogy az "a" a b-hez relatív prím, vagy egyszerűen a és b relatív prímek, ha az 1-en és −1-en kívül nincs más közös osztójuk. Vagy ami ezzel ekvivalens, ha a és b legnagyobb közös osztója 1.
             * 
             * Például a 6 és a 35 relatív prímek, de a 6 és a 27 nem, mert mindkettő osztható 3-mal
             
             */

            bool[] kimenetiLogikaiTomb = new bool[bemenetiTomb.Length];

            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                if (EukledesziAlgoritmusTetel(bemenetiTomb[i], egeszErtek) == 1)
                {
                    kimenetiLogikaiTomb[i] = true;
                }
                else
                {
                    kimenetiLogikaiTomb[i] = false;
                }
            }
            return kimenetiLogikaiTomb;
        }


    }
}
