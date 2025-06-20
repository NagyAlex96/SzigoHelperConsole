using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole
{
    public class ProgTetelekOsszeepitese
    {
        /// <summary>
        /// Egy tömb minden elemét átmásolja egy másik tömbbe úgy, hogy a másolás közben egy adott függvény esetlegesen módosítást hajt végre az elemeken
        /// </summary>
        /// <param name="inputArray">Feldolgozandó tömb</param>
        /// <returns>A tömb összes elemén végrehajtott művelet utáni eredmény</returns>
        public static int MasolasEsSorozatSzamitasTetel(int[] inputArray)
        {
            int ertek = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                ertek = ertek + (inputArray[i] * inputArray[i]);
            }

            return ertek;
        }

        /// <summary>
        /// Egy tömb elemeinek egy függvény által módosított értékei közül szeretnénk a maximális értékű elemet kiválasztani.
        /// </summary>
        /// <param name="intputArray">Feldolgozandó tömb</param>
        /// <returns>(int, int) (max, Maxertek) </returns>
        public static (int, int) MasolasEsMaximumKivalasztasTetel(int[] intputArray)
        {
            int max = 0; //Index
            int maxErtek = (intputArray[0] * intputArray[0]);

            for (int i = 1; i < intputArray.Length; i++)
            {
                var seged = (intputArray[i] * intputArray[i]);
                if (maxErtek < seged)
                {
                    maxErtek = seged;
                    max = i;
                }
            }

            return (max, maxErtek);
        }

        /// <summary>
        /// Olyan, mint a lineáris keresés, itt viszont azt szeretnénk megvizsgálni, hogy egy tömbben van-e legalább k darab P tulajdonságú elem
        /// </summary>
        /// <param name="inputArray">Feldolgozandó tömb</param>
        /// <param name="P">Tulajdonságfüggvény</param>
        /// <param name="k">P tulajdonságú elemek száma</param>
        /// <returns>(bool, int) (van, index) false: index == null</returns>
        public static (bool, int?) MegszamolasEsKeresesTetel<T>(T[] inputArray, Func<T, bool> P, int k)
        {
            int darabSzam = 0;
            int i = 0;

            while (i < inputArray.Length && darabSzam < k)
            {
                if (P(inputArray[i]))
                {
                    darabSzam++;
                }

                i++;
            }
            int index = 0;
            bool van = (darabSzam == k);

            if (van)
            {
                index = i;
                return (van, index);
            }
            else
            {
                van = false;
                return (van, null);
            }

        }

        /// <summary>
        /// Az összes legnagyobb értékű elem index értékeinek kiválogatása, egy másik tömbbe
        /// </summary>
        /// <param name="inputArray">Feldolgozandó tömb</param>
        /// <returns>(int, int[], int) (darab, y, maxérték)</returns>
        public static (int, T[], T) MaximumKivalasztasEsKivalogatasTetel<T>(T[] inputArray)
            where T : IComparable
        {
            T[] y = new T[inputArray.Length];
            T maxErtek = inputArray[0];
            int darab = 0;
            y[darab] = y[0];

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i].CompareTo(maxErtek) > 0)
                {
                    maxErtek = inputArray[i];
                    darab = 0;
                    y[darab] = y[i];
                }
                else
                {
                    if (inputArray[i].CompareTo(maxErtek) == 0)
                    {
                        darab++;
                        y[darab] = y[i];
                    }
                }
            }
            return (darab, y, maxErtek);

        }

        /// <summary>
        /// Egy tömbben található feldolgozandó tulajdonságú elemekre szeretnénk egy műveletet végrehajtani
        /// </summary>
        /// <param name="inputArray">A feldolgozandó tömb</param>
        /// <param name="P">Tulajdonságfüggvény</param>
        /// <returns>Az tömb minden P tulajdonságú eleme között elvégezve művelet eredménye</returns>
        public static int KivalogatasEsSorozatSzamitasTetel<T>(T[] inputArray, Func<T, bool> P)
        {
            int ertek = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (P(inputArray[i]))
                {
                    ertek += (inputArray[i].GetHashCode() * inputArray[i].GetHashCode());
                }
            }
            return ertek;
        }

        /// <summary>
        /// Tömb adott P tulajdonságú elemei közül kell a maximális értékűt kiválasztani
        /// </summary>
        /// <param name="inputArray">feldolgozandó tömb, melynek elemei összehasonlíthatók</param>
        /// <param name="P">Tulajdonságfüggvény</param>
        /// <returns>(bool, int, int) True: (van, max(index), maxÉrték), False (van, null, null <--> Default(T)) </returns>
        public static (bool, int?, T?) KivalogatasEsMaximumKivalasztasTetel<T>(T[] inputArray, Func<T, bool> P)
            where T : IComparable
        {
            T maxErtek = default(T);
            int? max = null;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (P(inputArray[i]) && inputArray[i].CompareTo(maxErtek) > 0)
                {
                    maxErtek = inputArray[i];
                    max = i;
                }
            }

            bool van = (max != null ? true: false);

            if (van)
            {
                return (van, max, maxErtek);
            }
            else
            {
                return (van, null, default(T));
            }
        }

        /// <summary>
        /// Ha egy elem P tulajdonságú, azaz kiválogatásra kerül, akkor ne az elemet, hanem annak valamely f függvény által módosított értékét másoljuk be a kimeneti tömbbe.
        /// </summary>
        /// <param name="inputArray">Feldolgozandó tömb</param>
        /// <param name="P">Tulajdonságfüggvény</param>
        /// <returns>(int, int[]) (darabszám, kimenetiTömb)</returns>
        public static (int, T[]) KivalogatasEsMasolasTetel<T>(T[] inputArray, Func<T, bool> P)
        {
            T[] y = new T[inputArray.Length];
            int darab = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (P(inputArray[i]))
                {
                    y[darab] = (dynamic)inputArray[i] * inputArray[i]; //TODO stringre tesztelés
                    darab++;
                }
            }

            return (darab, y);
        }
    }
}
