using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public static int EukledesziAlgoritmusTetel(int nagyobbSzam, int kisebbSzam)
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
        public static bool[] RelativPrimVizsgalatTetel(int[] bemenetiTomb, int egeszErtek)
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

        public static void ShellRendezes<T>(ref T[] array) where T : IComparable
        {
            int distance = array.Length / 2;

            while (distance > 0)
            {
                for (int i = distance; i < array.Length; i++)
                {
                    int j = i - distance;
                    T seged = array[i];

                    while (j >= 0 && array[j].CompareTo(seged) > 0)
                    {
                        array[j + distance] = array[j];
                        j -= distance;
                    }
                    array[j + distance] = seged;
                }
                distance = distance / 2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrayP">Tömb, ahol a tárgyakhoz tartozó <c>érték</c> van</param>
        /// <param name="arrayW">Tömb, ahol a tárgyakhoz tartozó <c>súly</c> van</param>
        /// <param name="capacity">Hátizsák mérete</param>
        public static int[,] HatizsakProblema(int[] arrayP, int[] arrayW, int capacity)
        {
            int[,] outArray = new int[arrayP.Length + 1, capacity + 1];

            for (int i = 0; i < capacity; i++)
            {
                outArray[0, i] = 0;
            }

            for (int i = 1; i < capacity; i++)
            {
                outArray[i, 0] = 0;
            }

            for (int i = 1; i <= arrayP.Length; i++)
            {
                for (int j = 1; j <= capacity; j++)
                {
                    if (arrayW[i-1] <= j)
                    {
                        var t1 = outArray[i-1, j];
                        var t2 = outArray[i-1, j - arrayW[i-1]];
                        var t3 = arrayP[i-1];

                        outArray[i, j] = Math.Max(t1, t2 + t3);
                    }
                    else
                    {
                        outArray[i, j] = outArray[i-1, j];
                    }
                }
            }


            return outArray;
        }
    }
}
