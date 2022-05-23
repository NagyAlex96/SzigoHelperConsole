using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole
{
    public class OsszetettProgTetelek
    {
        #region Összetett programozási tételek

        /// <summary>
        /// Egy bemeneti tömb minden egyes elemét szeretnénk átmásolni egy y kimeneti tömbbe, vagy egy tömb minden elemének egy függvény által módosított értékét
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns>Bementi tömb elemeinek 2x értéke</returns>
        static int[] MasolasTetel(int[] inputArray)
        {
            int[] yKimenetiTomb = new int[inputArray.Length];

            for (int i = 0; i < inputArray.Length; i++)
            {
                yKimenetiTomb[i] = inputArray[i] * 2;
            }

            return yKimenetiTomb;
        }

        /// <summary>
        /// Egy tömbből kiválogatjuk azon elemeket, amelyek megfelelnek a feltételnek
        /// </summary>
        /// <param name="inputArray">Keresett elemek halmaza</param>
        /// <param name="P">Logikai feltétel</param>
        /// <returns>(Darabszám, tömb)</returns>
        static (int, int[]) KivalogatasTetel(int[] inputArray, Func<int, bool> P)
        {
            int[] y = new int[inputArray.Length];
            int db = -1;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (P(i))
                {
                    db++;
                    y[db] = inputArray[i];
                }
            }

            return (db, y);
        }

        /// <summary>
        /// Egy tömbből kiválogatjuk azon elemeket, amelyek megfelelnek a feltételnek
        /// </summary>
        /// <param name="bemenetiTomb">Tömb ahol az elemeket keressük</param>
        /// <param name="kimenetiDarab">Kiválogatott elemek száma</param>
        static void KivalogatasHelybenTetel(ref int[] bemenetiTomb, out int kimenetiDarab)
        {
            #region Magyarázat
            /*
             * Ha a feldolgozást követően nincs szükség az eredeti "tomb" tömbre, akkor az eredményt itt is eltárolhatjuk
             * Ez helyben történő kiválogatásnak nevezzük.
             * 
             * Példa: Válogassuk ki a tömb elejére a páros elemeket! 
             
             */
            #endregion

            kimenetiDarab = 0;

            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                if (bemenetiTomb[i] % 2 == 0)
                {
                    bemenetiTomb[kimenetiDarab] = bemenetiTomb[i];
                    kimenetiDarab++;
                }
            }
        }

        /// <summary>
        /// Egy tömbből kiválogatjuk azon elemeket, amelyek megfelelnek a feltételnek
        /// </summary>
        /// <param name="tomb">Tömb ahol az elemeket keressük</param>
        /// <param name="outDarab">Kiválogatott elemek száma</param>
        static void KivalogatasHelybenCserevelTetel(ref int[] tomb, out int outDarab)
        {
            #region Magyarázat
            /*
             * Ha a feldolgozást követően nincs szükség az eredeti "tomb" tömbre, akkor az eredményt itt is eltárolhatjuk
             * Ezt helyben történő kiválogatásnak nevezzük.
             * 
             * Példa: Válogassuk ki a tömb elejére a páros elemeket! 
             
             */
            #endregion


            outDarab = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 2 == 0)
                {
                    var temp = tomb[outDarab];
                    tomb[outDarab] = tomb[i];
                    tomb[i] = temp;
                    outDarab++;
                }
            }
        }

        /// <summary>
        /// Egy "x" méretű tömb elemeit válogatjuk két különálló tömbbe
        /// </summary>
        /// <param name="bemenetiTomb">Eredeti tömb</param>
        /// <param name="xKimenetiTomb">Adott tulajdonsággal rendelkező elemek</param>
        /// <param name="xDarab">Adott tulajdonsággal rendelkező elemek száma</param>
        /// <param name="yKimenetiTomb">Adott tulajdonsággal NEM rendelkező elemek</param>
        /// <param name="yDarab">Adott tulajdonsággal NEM rendelkező elemek száma</param>
        static void SzetvalogatasTetel(int[] bemenetiTomb, out int[] xKimenetiTomb, out int xDarab, out int[] yKimenetiTomb, out int yDarab)
        {
            #region Magyarázat
            /*
             * Egy "x" elemű tömb elemeit válogatjuk ki bizonyos szempont szerint két tömbbe. Az "xKimenet"-i tömb-be kerülnek az adott tulajdonsággal rendelkező elemek, míg a "yKimenet"-i tömbbe, amellyeknek más a tulajdonsága.
             * Mivel nem tudjuk, hogy hány elemet szeretnénk "xKimenet"-i tömbbe másolni, ezért lefoglaljuk neki a lehető legnagyobb helyet. Az "yKimenet"-i tömb esetén ugyanígy járunk el.
             * Tudnunk kell, hogy mennyi elemet másoltunk a "yKimenet"-i és az "xKimenet"-i tömbbe. Ezt jelöli az "xDarab" és az "yDarab"
             * 
             * Megvalósítás: Bejárjuk a bemeneti
             * 
             * Példa: Válogassuk szét a páros és páratlan elemeket. A páratlanok kerüljenek "xKimenet"-i tömbbe, a párosok "yKimenet"-i tömbbe
             
             */
            #endregion

            xDarab = 0;
            xKimenetiTomb = new int[bemenetiTomb.Length];

            yKimenetiTomb = new int[bemenetiTomb.Length];
            yDarab = 0;

            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                if (bemenetiTomb[i] % 2 == 1)
                {
                    xKimenetiTomb[xDarab] = bemenetiTomb[i];
                    xDarab++;
                }
                else
                {
                    yKimenetiTomb[yDarab] = bemenetiTomb[i];
                    yDarab++;
                }
            }


        }

        static void SzetvalogatasEgyTombben(int[] tomb, out int tombElejeDarab, out int tombVegeDarab, out int[] yTombKimenet)
        {
            yTombKimenet = new int[tomb.Length];
            tombVegeDarab = tomb.Length - 1;
            tombElejeDarab = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 2 == 0)
                {
                    yTombKimenet[tombElejeDarab] = tomb[i];
                    tombElejeDarab++;
                }
                else
                {
                    yTombKimenet[tombVegeDarab] = tomb[i];
                    tombVegeDarab--;
                }
            }
        }

        static void SzetvalogatasHelybenCsereNelkul(ref int[] tomb, out int outDarab)
        {

            int bal = 0;
            int jobb = tomb.Length - 1;
            int seged = tomb[0];

            while (bal < jobb)
            {
                while (bal < jobb && (tomb[jobb] % 2 != 0))
                {
                    jobb--; //jobb=jobb-1
                }
                if (bal < jobb)
                {
                    tomb[bal] = tomb[jobb];
                    bal++;
                    while (bal < jobb && (tomb[bal] % 2 == 0))
                    {
                        bal++;
                    }
                    if (bal < jobb)
                    {
                        tomb[jobb] = tomb[bal];
                        jobb--;
                    }

                }
            }

            tomb[bal] = seged;

            if (tomb[bal] % 2 == 0)
            {
                outDarab = bal + 1;
            }
            else
            {
                outDarab = bal;
            }
        }

        static void MetszetTetel(int[] xBemenetiTomb, int[] yBemenetiTomb, out int[] kimenetiTomb, out int kimenetiDarab)
        {
            kimenetiTomb = new int[xBemenetiTomb.Length];
            kimenetiDarab = 0;

            for (int i = 0; i < kimenetiTomb.Length; i++)
            {
                int j = 0;

                while (j < yBemenetiTomb.Length && xBemenetiTomb[i] != yBemenetiTomb[j])
                {
                    j++;
                }

                if (j < yBemenetiTomb.Length)
                {
                    kimenetiTomb[kimenetiDarab] = xBemenetiTomb[i];
                    kimenetiDarab++;
                }
            }
        }

        static void MetszetKozosElemVizsalataTetel(int[] xBemenetiTomb, int[] yBemenetiTomb, out bool vanKozosElem)
        {
            vanKozosElem = false;
            int i = 0;

            while (i < xBemenetiTomb.Length && !vanKozosElem)
            {

                int j = 0;

                while (j < yBemenetiTomb.Length && xBemenetiTomb[i] != yBemenetiTomb[j])
                {
                    j++;
                }

                if (j < yBemenetiTomb.Length)
                {
                    vanKozosElem = true;
                }
                else
                {
                    i++;
                }
            }
        }

        static void UnioTetel(int[] x1BemenetiTomb, int[] x2BemenetiTomb, out int darab, out int[] yKimenetiTomb)
        {
            int kimenetiMeret = x1BemenetiTomb.Length + x2BemenetiTomb.Length;
            yKimenetiTomb = new int[kimenetiMeret];

            for (int i = 0; i < x1BemenetiTomb.Length; i++)
            {
                yKimenetiTomb[i] = x1BemenetiTomb[i];
            }

            darab = x1BemenetiTomb.Length;

            for (int j = 0; j < x2BemenetiTomb.Length; j++)
            {
                int i = 0;
                while (i < x1BemenetiTomb.Length && x1BemenetiTomb[i] != x2BemenetiTomb[j])
                {
                    i++;
                }
                if (i >= x1BemenetiTomb.Length)
                {
                    yKimenetiTomb[darab] = x2BemenetiTomb[j];
                    darab++;
                }
            }
        }

        static void IsmetlodesekKiszureseTetel(ref int[] x1BemenetiTomb, out int darab)
        {
            darab = 1;

            for (int i = 1; i < x1BemenetiTomb.Length; i++)
            {
                int j = 0;
                while (j <= darab && x1BemenetiTomb[i] != x1BemenetiTomb[j])
                {
                    j++;
                }
                if (j >= darab)
                {
                    x1BemenetiTomb[darab] = x1BemenetiTomb[i];
                    darab++;
                }
            }
        }

        static void OsszeFuttatasTetel(int[] x1BemenetiTomb, int[] x2BemenetiTomb, out int[] yKimenetiTomb, out int darab)
        {
            int kimenetiTombMeret = x1BemenetiTomb.Length + x2BemenetiTomb.Length;

            yKimenetiTomb = new int[kimenetiTombMeret];
            int i = 0;
            int j = 0;
            darab = 0;

            while (i < x1BemenetiTomb.Length && j < x2BemenetiTomb.Length)
            {
                if (x1BemenetiTomb[i] < x2BemenetiTomb[j])
                {
                    yKimenetiTomb[darab] = x1BemenetiTomb[i];
                    i++;
                }
                else
                {
                    if (x1BemenetiTomb[i] > x2BemenetiTomb[j])
                    {
                        yKimenetiTomb[darab] = x2BemenetiTomb[j];
                        j++;
                    }
                    else
                    {
                        yKimenetiTomb[darab] = x1BemenetiTomb[i];
                        i++;
                        j++;
                    }
                }
                darab++;
            }

            while (i < x1BemenetiTomb.Length)
            {
                yKimenetiTomb[darab] = x1BemenetiTomb[i];
                i++;
                darab++;
            }

            while (j < x2BemenetiTomb.Length)
            {
                yKimenetiTomb[darab] = x2BemenetiTomb[j];
                j++;
                darab++;
            }
        }

        static void ModositottOsszeFuttatasTetel(int[] x1BemenetiTomb, int[] x2BemenetiTomb, out int[] yKimenetiTomb, out int darab)
        {
            int kimenetiTombMeret = x1BemenetiTomb.Length + x2BemenetiTomb.Length;
            yKimenetiTomb = new int[kimenetiTombMeret];

            Array.Resize<int>(ref x1BemenetiTomb, x1BemenetiTomb.Length + 1);
            Array.Resize<int>(ref x2BemenetiTomb, x2BemenetiTomb.Length + 1); //ez a két sor csak azért szükséges, hogy a végtelen-t el tudjuk tárolnis

            x1BemenetiTomb[x1BemenetiTomb.Length - 1] = int.MaxValue;
            x2BemenetiTomb[x2BemenetiTomb.Length - 1] = int.MaxValue;

            int i = 0;
            int j = 0;
            darab = 0;

            while (i < x1BemenetiTomb.Length - 1 || j < x2BemenetiTomb.Length - 1)
            {
                if (x1BemenetiTomb[i] < x2BemenetiTomb[j])
                {
                    yKimenetiTomb[darab] = x1BemenetiTomb[i];
                    i++;
                }
                else if (x1BemenetiTomb[i] > x2BemenetiTomb[j])
                {
                    yKimenetiTomb[darab] = x2BemenetiTomb[j];
                    j++;
                }
                else
                {
                    yKimenetiTomb[darab] = x1BemenetiTomb[i];
                    i++;
                    j++;
                }
                darab++;
            }

        }

        #endregion




    }
}
