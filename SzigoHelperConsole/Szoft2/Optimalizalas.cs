using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole
{
    public class Optimalizalas
    {
        /// <summary>
        /// Visszalépéses keresés általános esete
        /// </summary>
        /// <param name="szint">Az aktuális szint, ahol keresünk</param>
        /// <param name="inputArray">Bementi fürészfogas tömb</param>
        /// <param name="outputArray">C#-ban bármilyen tömb referencia típus, ezért nincs Ref a inputArraynél</param>
        /// <param name="van">Folyamatosan azt mutatja, hogy találtunk-e már teljes megoldást</param>
        public static void VisszaLepesesKereses<T>(int szint, T[][] inputArray, T[] outputArray, ref bool van) where T : IComparable
        {
            int i = -1;

            while (!van && i < inputArray[szint].Length - 1)
            {
                i++;

                if (FkBTS<T>(szint, inputArray[szint][i], outputArray))
                {
                    outputArray[szint] = inputArray[szint][i];
                    if (szint == inputArray.Length - 1)
                    {
                        van = true;
                    }
                    else
                    {
                        VisszaLepesesKereses<T>(szint + 1, inputArray, outputArray, ref van);
                    }
                }
            }
        }

        /// <summary>
        /// Meghatározza, hogy a szint-edik részfeladat esetében lehetséges megoldás-e
        /// </summary>
        /// <param name="szint">Az aktuális szint, ameddig keresünk/param>
        /// <param name="nev">Ezt az elemet hozzáadhatjuk-e az adott szinten a részeredményekhez</param>
        /// <param name="reszEredmenyek">Eddigi eredmények</param>
        /// <returns>True: a részmegoldás elfogadható az adott szinten</returns>
        static bool FkBTS<T>(int szint, T nev, T[] reszEredmenyek) where T : IComparable //visszalépéses keresés alapesetéhez
        {
            bool ok = true;

            for (int i = 0; i < szint; i++)
            {
                if (nev.CompareTo(reszEredmenyek[i]) == 0)
                {
                    ok = false;
                }
            }
            return ok;
        }
    }
}
