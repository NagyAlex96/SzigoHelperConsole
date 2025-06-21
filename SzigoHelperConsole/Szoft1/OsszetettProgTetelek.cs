using System;
using System.Linq;

namespace SzigoHelperConsole
{
    public class OsszetettProgTetelek
    {
        /* PL: Kiválogatás tételnél
         * a pLogikaiTulajdonság olyan, mintha azt mondanám, hogy válogassuk ki a páros elemeket, ami if-ben így nézne ki:
         * if (bemenetiTomb[i] % 2 == 0)
         * jelen esetben ezt lambdával adjuk meg, tehát, meghívásnál: OsszetettProgTetelek.KivalogatasTetel(array, x => x % 2 == 0);
         * ahol az x egy integer lesz
         * bővebben érteni akarod, akkor nézz utána egy hivatalos doksiban --> vagy ChatGPT
         * 
         * (a bemenetiTombA[i].CompareTo(bemenetiTombB[j]) < 0 szebb lenne, ha ki lenne téve egy külön változóba, de a könyvben így van leírva)
         */

        /// <summary>
        /// Egy bemeneti tömb minden egyes elemét szeretnénk átmásolni egy y kimeneti tömbbe, vagy egy tömb minden elemének egy függvény által módosított értékét
        /// </summary>
        /// <param name="bemenetiTomb">Feldolgozandó tömb</param>
        /// <returns>Bementi tömb elemeinek másolata</returns>
        public static T[] MasolasTetel<T>(T[] bemenetiTomb)
        {
            T[] yKimenetiTomb = new T[bemenetiTomb.Length];

            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                yKimenetiTomb[i] = bemenetiTomb[i];
            }

            return yKimenetiTomb;
        }

        /// <summary>
        /// Egy tömbből kiválogatjuk azon elemeket, amelyek megfelelnek a feltételnek
        /// </summary>
        /// <param name="bemenetiTomb">Vizsgált tömb</param>
        /// <param name="pLogikaiTulajdonsag">Kiválogatási feltétel</param>
        /// <returns><c>y1KimenetiTomb</c> <paramref name="bemenetiTomb"/>ből <paramref name="pLogikaiTulajdonsag"/> alapján kiválogatott elemek. <c>darab</c> pedig a tulajdonság alapján kiválogatott elemszám</returns>
        public static (T[] yKimenetiTomb, int darab) KivalogatasTetel<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag)
        {
            T[] yKimenetiTomb = new T[bemenetiTomb.Length];
            int darab = 0;

            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                if (pLogikaiTulajdonsag(bemenetiTomb[i]))
                {
                    yKimenetiTomb[darab] = bemenetiTomb[i];
                    darab++;
                }
            }

            return (yKimenetiTomb, darab);
        }

        /// <summary>
        /// Egy tömbből kiválogatjuk azon elemeket, amelyek megfelelnek a feltételnek. Ezeket az eredeti tömbben adjuk vissza
        /// </summary>
        /// <param name="bemenetiTomb">A vizsgált tömb</param>
        /// <param name="pLogikaiTulajdonsag">Kiválogatási feltétel</param>
        /// <returns>A kiválogatást követően a bementi tömbben található elemek száma</returns>
        public static int KivalogatasHelybenTetel<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag)
        {
            int darab = 0;

            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                if (pLogikaiTulajdonsag(bemenetiTomb[i]))
                {
                    bemenetiTomb[darab] = bemenetiTomb[i];
                    darab++;
                }
            }

            return darab;
        }

        /// <summary>
        /// Egy tömbből kiválogatjuk azon elemeket, amelyek megfelelnek a feltételnek. Ezek a tömb elejére kerülnek, cserével
        /// </summary>
        /// <param name="bemenetiTomb">A vizsgált tömb</param>
        /// <param name="pLogikaiTulajdonsag">Kiválogatási feltétel</param>
        /// <returns>A kiválogatást követően a bementi tömbben található elemek száma</returns>
        public static int KivalogatasHelybenCserevelTetel<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag)
        {
            int darab = 0;
            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                if (pLogikaiTulajdonsag(bemenetiTomb[i]))
                {
                    T temp = bemenetiTomb[darab];
                    bemenetiTomb[darab] = bemenetiTomb[i];
                    bemenetiTomb[i] = temp;
                    darab++;
                }
            }
            return darab;
        }

        /// <summary>
        /// A bemeneti tömb elemeit válogatjuk szét két különálló tömbbe
        /// </summary>
        /// <param name="bemenetiTomb">A vizsgált tömb</param>
        /// <param name="pLogikaiTulajdonsag">Szétválogatási feltétel</param>
        /// <returns><c>y1KimenetiTomb</c> <paramref name="bemenetiTomb"/>ből <paramref name="pLogikaiTulajdonsag"/> alapján szétválogatott elemek. <c>darab1</c> pedig a tulajdonság alapján szétválogatott elemszám</returns>
        public static (T[] y1KimenetiTomb, int darab1, T[] y2KimenetiTomb, int darab2) SzetvalogatasTetel<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag)
        {
            int darab1 = 0;
            T[] y1KimenetiTomb = new T[bemenetiTomb.Length];

            T[] y2KimenetiTomb = new T[bemenetiTomb.Length];
            int darab2 = 0;

            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                if (pLogikaiTulajdonsag(bemenetiTomb[i]))
                {
                    y1KimenetiTomb[darab1] = bemenetiTomb[i];
                    darab1++;
                }
                else
                {
                    y2KimenetiTomb[darab2] = bemenetiTomb[i];
                    darab2++;
                }
            }

            return (y1KimenetiTomb, darab1, y2KimenetiTomb, darab2);
        }

        /// <summary>
        /// A bemeneti tömb elemeit válogatjuk szét egy tömbbe
        /// </summary>
        /// <param name="bemenetiTomb">A vizsgált tömb</param>
        /// <param name="pLogikaiTulajdonsag">Szétválogatási feltétel</param>
        /// <returns><c>yKimenetiTomb</c> <paramref name="bemenetiTomb"/>ből <paramref name="pLogikaiTulajdonsag"/> alapján szétválogatott elemek. <c>darab</c> pedig a tulajdonság alapján szétválogatott elemszám</returns>
        public static (T[] yKimenetiTomb, int darab) SzetvalogatasEgyTombben<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag)
        {
            T[] yKimenetiTomb = new T[bemenetiTomb.Length];
            int jobb = bemenetiTomb.Length - 1;
            int darab = 0;

            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                if (pLogikaiTulajdonsag(bemenetiTomb[i]))
                {
                    yKimenetiTomb[darab] = bemenetiTomb[i];
                    darab++;
                }
                else
                {
                    yKimenetiTomb[jobb] = bemenetiTomb[i];
                    jobb--;
                }
            }

            return (yKimenetiTomb, darab);
        }

        /// <summary>
        /// A szétválogatás memória helyfoglalás szempontjából leghatékonyabb megoldása az, amikor az eredeti tömbön belül végezzük el.
        /// </summary>
        /// <param name="bemenetiTomb">Feldolgozandó tömb</param>
        /// <param name="pLogikaiTulajdonsag">Logikai értéku tulajdonság függvény</param>
        /// <returns>A P tulajdonságú elemek száma a tömbben</returns>
        public static int SzetvalogatasHelybenCsereNelkul<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag)
        {
            int bal = 0;
            int jobb = bemenetiTomb.Length - 1;
            T seged = bemenetiTomb[0];

            while (bal < jobb)
            {
                while (bal < jobb && !pLogikaiTulajdonsag(bemenetiTomb[jobb]))
                {
                    jobb--;
                }
                if (bal < jobb)
                {
                    bemenetiTomb[bal] = bemenetiTomb[jobb];
                    bal++;
                    while (bal < jobb && pLogikaiTulajdonsag(bemenetiTomb[bal]))
                    {
                        bal++;
                    }
                    if (bal < jobb)
                    {
                        bemenetiTomb[jobb] = bemenetiTomb[bal];
                        jobb--;
                    }

                }
            }

            bemenetiTomb[bal] = seged;
            int darab = 0;

            if (pLogikaiTulajdonsag(bemenetiTomb[bal]))
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
        /// <param name="bemenetiTombA">Egyik bemeneti tömb</param>
        /// <param name="bemenetiTombB">Másik bemeneti tömb</param>
        /// <returns><c>yKiementiTomb</c> a tartalmazza a <paramref name="bemenetiTombA"/> és a <paramref name="bemenetiTombB"/> közös elemeit, míg a <c>darab</c> a metszet elemszámát</returns>
        public static (T[] yKiementiTomb, int darab) MetszetTetel<T>(T[] bemenetiTombA, T[] bemenetiTombB) where T : IComparable<T>
        {
            // comparable nem szükséges, ha kikötöd, hogy mondjuk: int, string, double vagy akármi. IComparable<T> azért kell, hogy bármilyen "tömb" jó legyen
            T[] yKiementiTomb = new T[bemenetiTombA.Length];
            int darab = 0;

            for (int i = 0; i < yKiementiTomb.Length; i++)
            {
                int j = 0;

                while (j < bemenetiTombB.Length && bemenetiTombA[i].CompareTo(bemenetiTombB[j]) != 0)
                {
                    j++;
                }

                if (j < bemenetiTombB.Length)
                {
                    yKiementiTomb[darab] = bemenetiTombA[i];
                    darab++;
                }
            }

            return (yKiementiTomb, darab);
        }

        /// <summary>
        /// Két tömbben van-e közös elem
        /// </summary>
        /// <param name="bemenetiTombA">Egyik bemeneti tömb</param>
        /// <param name="bemenetiTombB">Másik bemeneti tömb</param>
        /// <returns><c>True</c> van közös elem</returns>
        public static bool MetszetKozosElemVizsalataTetel<T>(T[] bemenetiTombA, T[] bemenetiTombB) where T : IComparable<T>
        {
            bool van = false;
            int i = 0;

            while (i < bemenetiTombA.Length && !van)
            {

                int j = 0;

                while (j < bemenetiTombB.Length && bemenetiTombA[i].CompareTo(bemenetiTombB[j]) != 0)
                {
                    j++;
                }

                if (j < bemenetiTombB.Length)
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
        /// <param name="bemenetiTombA">Egyik bemeneti tömb</param>
        /// <param name="bemenetiTombB">Másik bemeneti tömb</param>
        /// <returns><c>yKiementiTomb</c>be kerül <paramref name="bemenetiTombA"/> és <paramref name="bemenetiTombB"/> elemei, <c>darab</c> pedig a hozzá tartozó kimeneti elemszám</returns>
        public static (T[] yKiementiTomb, int darab) UnioTetel<T>(T[] bemenetiTombA, T[] bemenetiTombB) where T : IComparable<T>
        {
            T[] yKiementiTomb = new T[bemenetiTombA.Length + bemenetiTombB.Length];

            for (int i = 0; i < bemenetiTombA.Length; i++)
            {
                yKiementiTomb[i] = bemenetiTombA[i];
            }

            int darab = bemenetiTombA.Length;

            for (int j = 0; j < bemenetiTombB.Length; j++)
            {
                int i = 0;
                while (i < bemenetiTombA.Length && bemenetiTombA[i].CompareTo(bemenetiTombB[j]) != 0)
                {
                    i++;
                }
                if (i >= bemenetiTombA.Length)
                {
                    yKiementiTomb[darab] = bemenetiTombB[j];
                    darab++;
                }
            }
            return (yKiementiTomb, darab);
        }

        /// <summary>
        /// Egy tömbből kiszűri az ismétlődéseket
        /// </summary>
        /// <param name="bemenetiTombA">Tömb, melyet az algoritmus úgy alakít, hogy az ismétlődő elemekből pontosan egy maradjon</param>
        /// <returns>Az tömbben az átalakítást követően megmaradó elemek száma (itt már nincs ismétlődés az "int" értékéig) </returns>
        public static int IsmetlodesekKiszureseTetel<T>(T[] bemenetiTombA) where T : IComparable<T>
        {
            int darab = 1;

            for (int i = 1; i < bemenetiTombA.Length; i++)
            {
                int j = 0;
                while (j <= darab && bemenetiTombA[i].CompareTo(bemenetiTombA[j]) != 0)
                {
                    j++;
                }
                if (j >= darab)
                {
                    bemenetiTombA[darab] = bemenetiTombA[i];
                    darab++;
                }
            }
            return darab;
        }

        /// <summary>
        /// Ugyan azt csinálja, mint az unió tétel, viszont két rendezett tömbből, megpróbálja kiszűrni az ismétlődéseket
        /// </summary>
        /// <param name="bemenetiTombA">Egyik rendezett bemeneti tömb</param>
        /// <param name="bemenetiTombB">Másik rendezett bemeneti tömb</param>
        /// <returns><c>yKiementiTomb</c>be kerül <paramref name="bemenetiTombA"/> és <paramref name="bemenetiTombB"/> elemei, <c>darab</c> pedig a hozzá tartozó kimeneti elemszám</returns>
        public static (T[] yKiementiTomb, int darab) OsszeFuttatasTetel<T>(T[] bemenetiTombA, T[] bemenetiTombB) where T : IComparable<T>
        {
            T[] yKiementiTomb = new T[bemenetiTombA.Length + bemenetiTombB.Length];
            int i = 0;
            int j = 0;
            int darab = 0;

            while (i < bemenetiTombA.Length && j < bemenetiTombB.Length)
            {
                if (bemenetiTombA[i].CompareTo(bemenetiTombB[j]) < 0)
                {
                    yKiementiTomb[darab] = bemenetiTombA[i];
                    i++;
                }
                else
                {
                    if (bemenetiTombA[i].CompareTo(bemenetiTombB[j]) > 0)
                    {
                        yKiementiTomb[darab] = bemenetiTombB[j];
                        j++;
                    }
                    else
                    {
                        yKiementiTomb[darab] = bemenetiTombA[i];
                        i++;
                        j++;
                    }
                }
                darab++;
            }

            while (i < bemenetiTombA.Length)
            {
                yKiementiTomb[darab] = bemenetiTombA[i];
                i++;
                darab++;
            }

            while (j < bemenetiTombB.Length)
            {
                yKiementiTomb[darab] = bemenetiTombB[j];
                j++;
                darab++;
            }

            return (yKiementiTomb, darab);
        }

        /// <summary>
        /// Ugyan azt csinálja, mint az unió tétel, viszont két rendezett tömbből, megpróbálja kiszűrni az ismétlődéseket. A tömb végére beszúrt végtelennek köszönhetően az algoritmus egyszerűbb lesz
        /// </summary>
        /// <param name="bemenetiTombA">Egyik rendezett bemeneti tömb</param>
        /// <param name="bemenetiTombB">Másik rendezett bemeneti tömb</param>
        /// <returns><c>yKiementiTomb</c>be kerül <paramref name="bemenetiTombA"/> és <paramref name="bemenetiTombB"/> elemei, <c>darab</c> pedig a hozzá tartozó kimeneti elemszám)</returns>
        public static (double[] yKimenetiTomb, int darab) ModositottOsszeFuttatasTetel(double[] bemenetiTombA, double[] bemenetiTombB)
        {
            //nem kötelező double-re megcsinálni, de érdemes olyanra ahol van Infinity.

            double[] yKimenetiTomb = new double[bemenetiTombA.Length + bemenetiTombB.Length];

            Array.Resize(ref bemenetiTombA, bemenetiTombA.Length + 1);
            Array.Resize(ref bemenetiTombB, bemenetiTombB.Length + 1); //ez a két sor csak azért szükséges, hogy a végtelent el tudjuk tárolni
            //listával nyilván egyszerűbb

            bemenetiTombA[bemenetiTombA.Length - 1] = double.PositiveInfinity;
            bemenetiTombB[bemenetiTombB.Length - 1] = double.PositiveInfinity;

            int i = 0;
            int j = 0;
            int darab = 0;

            while (i < bemenetiTombA.Length - 1 || j < bemenetiTombB.Length - 1)
            {
                if (bemenetiTombA[i].CompareTo(bemenetiTombB[j]) < 0)
                {
                    yKimenetiTomb[darab] = bemenetiTombA[i];
                    i++;
                }
                else if (bemenetiTombA[i].CompareTo(bemenetiTombB[j]) > 0)
                {
                    yKimenetiTomb[darab] = bemenetiTombB[j];
                    j++;
                }
                else
                {
                    yKimenetiTomb[darab] = bemenetiTombA[i];
                    i++;
                    j++;
                }
                darab++;
            }

            return (yKimenetiTomb, darab);
        }
    }
}