using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzigoHelperConsole.Assests;

namespace SzigoHelperConsole
{
    public class OsszetettProgTetelek
    {
        /// <summary>
        /// Egy bemeneti tömb minden egyes elemét szeretnénk átmásolni egy y kimeneti tömbbe, vagy egy tömb minden elemének egy függvény által módosított értékét
        /// </summary>
        /// <param name="inputArray">Feldolgozandó tömb</param>
        /// <returns>Bementi tömb elemeinek 2x értéke</returns>
        public static T[] MasolasTetel<T>(T[] inputArray)
        {
            T[] yKimenetiTomb = new T[inputArray.Length];

            for (int i = 0; i < inputArray.Length; i++)
            {
                yKimenetiTomb[i] = inputArray[i];
            }

            return yKimenetiTomb;
        }

        /// <summary>
        /// Egy tömbből kiválogatjuk azon elemeket, amelyek megfelelnek a feltételnek
        /// </summary>
        /// <param name="inputArray">Vizsgált tömb</param>
        /// <param name="P">Kiválogatási feltétel</param>
        /// <returns>(Darabszám, tömb)</returns>
        public static (int, T[]) KivalogatasTetel<T>(T[] inputArray, Func<T, bool> P)
        {
            T[] y = new T[inputArray.Length];
            int darab = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (P(inputArray[i]))
                {
                    y[darab] = inputArray[i];
                    darab++;
                }
            }

            return (darab, y);
        }

        /// <summary>
        /// Egy tömbből kiválogatjuk azon elemeket, amelyek megfelelnek a feltételnek. Ezeket az eredeti tömbben adjuk vissza
        /// </summary>
        /// <param name="inputArray">A vizsgált tömb</param>
        /// <param name="P">Kiválogatási feltétel</param>
        /// <returns>A kiválogatást követően a bementi tömbben található elemek száma</returns>
        public static int KivalogatasHelybenTetel<T>(ref T[] inputArray, Func<T, bool> P)
        {
            int darab = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (P(inputArray[i]))
                {
                    inputArray[darab] = inputArray[i];
                    darab++;
                }
            }

            return darab;
        }

        /// <summary>
        /// Egy tömbből kiválogatjuk azon elemeket, amelyek megfelelnek a feltételnek. Ezek a tömb elejére kerülnek, cserével
        /// </summary>
        /// <param name="tomb">A vizsgált tömb</param>
        /// <param name="P">Kiválogatási feltétel</param>
        /// <returns>A kiválogatást követően a bementi tömbben található elemek száma</returns>
        public static int KivalogatasHelybenCserevelTetel<T>(ref T[] tomb, Func<T, bool> P)
        {
            int darab = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (P(tomb[i]))
                {
                    T temp = tomb[darab];
                    tomb[darab] = tomb[i];
                    tomb[i] = temp;
                    darab++;
                }
            }
            return darab;
        }

        /// <summary>
        /// A bemeneti tömb elemeit válogatjuk szét két különálló tömbbe
        /// </summary>
        /// <param name="inputArray">A vizsgált tömb</param>
        /// <param name="P">Szétválogatási feltétel</param>
        /// <returns>(int[], int, int[], int) Y1 tömb, db1, Y2 tömb, db2</returns>
        public static (T[], int, T[], int) SzetvalogatasTetel<T>(T[] inputArray, Func<T, bool> P)
        {
            int darab1 = 0;
            T[] y1 = new T[inputArray.Length];

            T[] y2 = new T[inputArray.Length];
            int darab2 = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (P(inputArray[i]))
                {
                    y1[darab1] = inputArray[i];
                    darab1++;
                }
                else
                {
                    y2[darab2] = inputArray[i];
                    darab2++;
                }
            }

            return (y1, darab1, y2, darab2);
        }

        /// <summary>
        /// A bemeneti tömb elemeit válogatjuk szét egy tömbbe
        /// </summary>
        /// <param name="inputArray">A vizsgált tömb</param>
        /// <param name="P">Szétválogatási feltétel</param>
        /// <returns>(int[], int, int[], int) Y1 tömb, db1</returns>
        public static (T[], int) SzetvalogatasEgyTombben<T>(T[] inputArray, Func<T, bool> P)
        {
            T[] y = new T[inputArray.Length];
            int jobb = inputArray.Length - 1;
            int darab = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (P(inputArray[i]))
                {
                    y[darab] = inputArray[i];
                    darab++;
                }
                else
                {
                    y[jobb] = inputArray[i];
                    jobb--;
                }
            }

            return (y, darab);
        }

        /// <summary>
        /// A szétválogatás memória helyfoglalás szempontjából leghatékonyabb megoldása az, amikor az eredeti tömbön belül végezzük el.
        /// </summary>
        /// <param name="inputArray">Feldolgozandó tömb</param>
        /// <param name="P">Logikai értéku tulajdonság függvény</param>
        /// <returns>A P tulajdonságú elemek száma a tömbben</returns>
        public static int SzetvalogatasHelybenCsereNelkul<T>(ref T[] inputArray, Func<T, bool> P)
        {
            int bal = 0;
            int jobb = inputArray.Length - 1;
            T seged = inputArray[0];

            while (bal < jobb)
            {
                while (bal < jobb && !P(inputArray[jobb]))
                {
                    jobb--;
                }
                if (bal < jobb)
                {
                    inputArray[bal] = inputArray[jobb];
                    bal++;
                    while (bal < jobb && P(inputArray[bal]))
                    {
                        bal++;
                    }
                    if (bal < jobb)
                    {
                        inputArray[jobb] = inputArray[bal];
                        jobb--;
                    }

                }
            }

            inputArray[bal] = seged;
            int darab = 0;

            if (P(inputArray[bal]))
            {
                darab = bal + 1;
            }
            else
            {
                darab = bal;
            }

            return darab;
        }

        /// <summary>
        /// Két tömbből a közös elemeket kiválogatjuk egy harmadik tömbbe
        /// </summary>
        /// <param name="inputArrayA">Egyik bemeneti tömb</param>
        /// <param name="inputArrayB">Másik bemeneti tömb</param>
        /// <returns>(int[], int) (Kimeneti tömb, releváns elemek száma)</returns>
        public static (T[], int) MetszetTetel<T>(T[] inputArrayA, T[] inputArrayB) where T : IComparable
        {
            T[] y = new T[inputArrayA.Length];
            int darab = 0;

            for (int i = 0; i < y.Length; i++)
            {
                int j = 0;

                while (j < inputArrayB.Length && inputArrayA[i].CompareTo(inputArrayB[j]) != 0)
                {
                    j++;
                }

                if (j < inputArrayB.Length)
                {
                    y[darab] = inputArrayA[i];
                    darab++;
                }
            }

            return (y, darab);
        }

        /// <summary>
        /// Két tömbben van-e közös elem
        /// </summary>
        /// <param name="inputArrayA">Egyik bemeneti tömb</param>
        /// <param name="inputArrayB">Másik bemeneti tömb</param>
        /// <returns>True: van közös elem</returns>
        public static bool MetszetKozosElemVizsalataTetel<T>(T[] inputArrayA, T[] inputArrayB) where T : IComparable
        {
            bool van = false;
            int i = 0;

            while (i < inputArrayA.Length && !van)
            {

                int j = 0;

                while (j < inputArrayB.Length && inputArrayA[i].CompareTo(inputArrayB[j]) != 0)
                {
                    j++;
                }

                if (j < inputArrayB.Length)
                {
                    van = true;
                }
                else
                {
                    i++;
                }
            }
            return van;
        }

        /// <summary>
        /// Két tömbből ki akarjuk válogatni az összes eloforduló elemet, tehát azokat, amik akár az egyikben, akár a másikban benne vannak
        /// </summary>
        /// <param name="inputArrayA">Egyik bemeneti tömb</param>
        /// <param name="inputArrayB">Másik bemeneti tömb</param>
        /// <returns>(int[], int) (Kimeneti tömb, releváns elemek száma)</returns>
        public static (T[], int) UnioTetel<T>(T[] inputArrayA, T[] inputArrayB) where T : IComparable
        {
            T[] y = new T[inputArrayA.Length + inputArrayB.Length];

            for (int i = 0; i < inputArrayA.Length; i++)
            {
                y[i] = inputArrayA[i];
            }

            int darab = inputArrayA.Length;

            for (int j = 0; j < inputArrayB.Length; j++)
            {
                int i = 0;
                while (i < inputArrayA.Length && inputArrayA[i].CompareTo(inputArrayB[j]) != 0)
                {
                    i++;
                }
                if (i >= inputArrayA.Length)
                {
                    y[darab] = inputArrayB[j];
                    darab++;
                }
            }
            return (y, darab);
        }

        /// <summary>
        /// Egy tömbből kiszűri az ismétlődéseket
        /// </summary>
        /// <param name="inputArray">Tömb, melyet az algoritmus úgy alakít, hogy az ismétlődő elemekből pontosan egy maradjon</param>
        /// <returns>Az tömbben az átalakítást követően megmaradó elemek száma</returns>
        public static int IsmetlodesekKiszureseTetel<T>(ref T[] inputArray) where T : IComparable
        {
            int darab = 1;

            for (int i = 1; i < inputArray.Length; i++)
            {
                int j = 0;
                while (j <= darab && inputArray[i].CompareTo(inputArray[j]) != 0)
                {
                    j++;
                }
                if (j >= darab)
                {
                    inputArray[darab] = inputArray[i];
                    darab++;
                }
            }
            return darab;
        }

        /// <summary>
        /// Ugyan azt csinálja, mint az unió tétel, viszont két rendezett tömbből, megpróbálja kiszűrni az ismétlődéseket
        /// </summary>
        /// <param name="inputArrayA">Egyik rendezett bemeneti tömb</param>
        /// <param name="inputArrayB">Másik rendezett bemeneti tömb</param>
        /// <returns>(int[], int)  (rendezett kimeneti tömb, releváns elemek száma)</returns>
        public static (T[], int) OsszeFuttatasTetel<T>(T[] inputArrayA, T[] inputArrayB) where T : IComparable
        {
            T[] y = new T[inputArrayA.Length + inputArrayB.Length];
            int i = 0;
            int j = 0;
            int darab = 0;

            while (i < inputArrayA.Length && j < inputArrayB.Length)
            {
                if (inputArrayA[i].CompareTo(inputArrayB[j]) < 0)
                {
                    y[darab] = inputArrayA[i];
                    i++;
                }
                else
                {
                    if (inputArrayA[i].CompareTo(inputArrayB[j]) > 0)
                    {
                        y[darab] = inputArrayB[j];
                        j++;
                    }
                    else
                    {
                        y[darab] = inputArrayA[i];
                        i++;
                        j++;
                    }
                }
                darab++;
            }

            while (i < inputArrayA.Length)
            {
                y[darab] = inputArrayA[i];
                i++;
                darab++;
            }

            while (j < inputArrayB.Length)
            {
                y[darab] = inputArrayB[j];
                j++;
                darab++;
            }

            return (y, darab);
        }

        /// <summary>
        /// Ugyan azt csinálja, mint az unió tétel, viszont két rendezett tömbből, megpróbálja kiszűrni az ismétlődéseket. A tömb végére beszúrt végtelennek köszönhetően az algoritmus egyszerűbb lesz
        /// </summary>
        /// <param name="inputArrayA">Egyik rendezett bemeneti tömb</param>
        /// <param name="inputArrayB">Másik rendezett bemeneti tömb</param>
        /// <returns>(int[], int)  (rendezett kimeneti tömb, releváns elemek száma)</returns>
        public static (T[], int) ModositottOsszeFuttatasTetel<T>(T[] inputArrayA, T[] inputArrayB) where T : IComparable
        {
            T[] yKimenetiTomb = new T[inputArrayA.Length + inputArrayB.Length];

            Array.Resize<T>(ref inputArrayA, inputArrayA.Length + 1);
            Array.Resize<T>(ref inputArrayB, inputArrayB.Length + 1); //ez a két sor csak azért szükséges, hogy a végtelen-t el tudjuk tárolni
            //listával nyilván egyszerűbb

            inputArrayA[inputArrayA.Length - 1] = inputArrayA.Max();
            inputArrayB[inputArrayB.Length - 1] = inputArrayB.Max();

            int i = 0;
            int j = 0;
            int darab = 0;

            while (i < inputArrayA.Length - 1 || j < inputArrayB.Length - 1)
            {
                if (inputArrayA[i].CompareTo(inputArrayB[j]) < 0)
                {
                    yKimenetiTomb[darab] = inputArrayA[i];
                    i++;
                }
                else if (inputArrayA[i].CompareTo(inputArrayB[j]) > 0)
                {
                    yKimenetiTomb[darab] = inputArrayB[j];
                    j++;
                }
                else
                {
                    yKimenetiTomb[darab] = inputArrayA[i];
                    i++;
                    j++;
                }
                darab++;
            }

            return (yKimenetiTomb, darab);
        }
    }
}
