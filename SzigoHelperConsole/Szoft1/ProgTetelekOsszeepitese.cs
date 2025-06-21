using System;

namespace SzigoHelperConsole
{
    public class ProgTetelekOsszeepitese
    {
        /* PL: KivalogatasEsMasolasTetel tételnél
         * a pLogikaiTulajdonság olyan, mintha azt mondanám, hogy válogassuk ki a páros elemeket, ami if-ben így nézne ki:
         * if (bemenetiTomb[i] % 2 == 0)
         * jelen esetben ezt lambdával adjuk meg, tehát, meghívásnál: ProgTetelekOsszeepitese.KivalogatasEsMasolasTetel(array, x => x % 2 == 0);
         * ahol az x egy integer lesz
         * bővebben érteni akarod, akkor nézz utána egy hivatalos doksiban --> vagy ChatGPT
         * 
         * a compareTo szebb lenne, ha ki lenne téve egy külön változóba, de a könyvben így van leírva)
         */

        /// <summary>
        /// Egy tömb minden elemét átmásolja egy másik tömbbe úgy, hogy a másolás közben egy adott függvény esetlegesen módosítást hajt végre az elemeken
        /// </summary>
        /// <param name="bemenetiTomb">Feldolgozandó tömb</param>
        /// <returns>A tömb összes elemén végrehajtott művelet utáni eredmény</returns>
        public static int MasolasEsSorozatSzamitasTetel(int[] bemenetiTomb)
        {
            int ertek = 0;

            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                ertek = ertek + (bemenetiTomb[i] * bemenetiTomb[i]);
            }

            return ertek;
        }

        /// <summary>
        /// Egy tömb elemeinek egy függvény által módosított értékei közül szeretnénk a maximális értékű elemet kiválasztani.
        /// </summary>
        /// <param name="bemenetiTomb">Feldolgozandó tömb</param>
        /// <returns><c>max</c> a maximum helyének indexe <c>maxErtek</c> a indexhez tartozó tényleges érték</returns>
        public static (int max, int maxErtek) MasolasEsMaximumKivalasztasTetel(int[] bemenetiTomb)
        {
            int max = 0; //Indexként szolgál
            int maxErtek = (bemenetiTomb[0] * bemenetiTomb[0]);

            for (int i = 1; i < bemenetiTomb.Length; i++)
            {
                var seged = (bemenetiTomb[i] * bemenetiTomb[i]);
                if (maxErtek < seged)
                {
                    maxErtek = seged;
                    max = i;
                }
            }

            return (max, maxErtek);
        }

        /// <summary>
        /// Olyan, mint a lineáris keresés, itt viszont azt szeretnénk megvizsgálni, hogy egy tömbben van-e legalább <paramref name="kDarab"/> <paramref name="pLogikaiTulajdonsag"/>ú elem
        /// </summary>
        /// <param name="bemenetiTomb">Feldolgozandó tömb</param>
        /// <param name="pLogikaiTulajdonsag">Tulajdonságfüggvény</param>
        /// <param name="kDarab">P tulajdonságú elemek száma</param>
        /// <returns><c>van -> True</c>, amennyiben van <paramref name="kDarab"/> <paramref name="pLogikaiTulajdonsag"/>u elem. <c>idx</c> azt mutatja meg, hogy hányadik elemig találhatóak meg</returns>
        public static (bool van, int? idx) MegszamolasEsKeresesTetel<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag, int kDarab)
        {
            int darab = 0;
            int i = 0;

            while (i < bemenetiTomb.Length && darab < kDarab)
            {
                if (pLogikaiTulajdonsag(bemenetiTomb[i]))
                {
                    darab++;
                }

                i++;
            }
            int index = 0;
            bool van = (darab == kDarab);

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
        /// <param name="bemenetiTomb">Feldolgozandó tömb</param>
        /// <returns><c>yKimenetiTomb</c>, amibe belekerül az összes <c>maxErtek</c> értékű elem. <c>darab</c> ezeknek a számossága</returns>
        public static (T[] yKimenetiTomb, T, int) MaximumKivalasztasEsKivalogatasTetel<T>(T[] bemenetiTomb) where T : IComparable<T>
        {
            T[] yKimenetiTomb = new T[bemenetiTomb.Length];
            T maxErtek = bemenetiTomb[0];
            int darab = 0;
            yKimenetiTomb[darab] = yKimenetiTomb[0];

            for (int i = 1; i < bemenetiTomb.Length; i++)
            {
                if (bemenetiTomb[i].CompareTo(maxErtek) > 0)
                {
                    maxErtek = bemenetiTomb[i];
                    darab = 0;
                    yKimenetiTomb[darab] = yKimenetiTomb[i];
                }
                else
                {
                    if (bemenetiTomb[i].CompareTo(maxErtek) == 0)
                    {
                        darab++;
                        yKimenetiTomb[darab] = yKimenetiTomb[i];
                    }
                }
            }
            return (yKimenetiTomb, maxErtek, darab);

        }

        /// <summary>
        /// Egy tömbben található, adott tulajdonságú elemekre szeretnénk egy műveletet végrehajtani
        /// </summary>
        /// <param name="bemenetiTomb">A feldolgozandó tömb</param>
        /// <param name="pLogikaiTulajdonsag">Tulajdonságfüggvény</param>
        /// <returns>Az tömb minden <paramref name="pLogikaiTulajdonsag"/> elem között elvégzett művelet eredménye</returns>
        public static int KivalogatasEsSorozatSzamitasTetel<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag)
        {
            int ertek = 0;
            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                if (pLogikaiTulajdonsag(bemenetiTomb[i]))
                {
                    ertek += (bemenetiTomb[i].GetHashCode() * bemenetiTomb[i].GetHashCode());
                }
            }
            return ertek;
        }

        /// <summary>
        /// Tömb adott <paramref name="pLogikaiTulajdonsag"/> tulajdonságú elemei közül kell a maximális értékűt kiválasztani
        /// </summary>
        /// <param name="bemenetiTomb">feldolgozandó tömb, melynek elemei összehasonlíthatók</param>
        /// <param name="pLogikaiTulajdonsag">Tulajdonságfüggvény</param>
        /// <returns>(bool, int, int) True: (van, max(index), maxÉrték), False (van, null, null <--> Default(T)) </returns>
        public static (bool, int?, T?) KivalogatasEsMaximumKivalasztasTetel<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag) where T : IComparable<T>
        {
            T maxErtek = default(T);
            int? max = null;

            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                if (pLogikaiTulajdonsag(bemenetiTomb[i]) && bemenetiTomb[i].CompareTo(maxErtek) > 0)
                {
                    maxErtek = bemenetiTomb[i];
                    max = i;
                }
            }

            bool van = (max != null ? true : false);

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
        /// Ha egy elem <paramref name="pLogikaiTulajdonsag"/> tulajdonságú, azaz kiválogatásra kerül, akkor ne az elemet, hanem annak valamely f függvény által módosított értékét másoljuk be a kimeneti tömbbe.
        /// </summary>
        /// <param name="bemenetiTomb">Feldolgozandó tömb</param>
        /// <param name="pLogikaiTulajdonsag">Tulajdonságfüggvény</param>
        /// <returns>(int, int[]) (darabszám, kimenetiTömb)</returns>
        public static (int, T[]) KivalogatasEsMasolasTetel<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag)
        {
            T[] y = new T[bemenetiTomb.Length];
            int darab = 0;

            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                if (pLogikaiTulajdonsag(bemenetiTomb[i]))
                {
                    y[darab] = (dynamic)bemenetiTomb[i] * bemenetiTomb[i]; //TODO stringre tesztelés
                    darab++;
                }
            }

            return (darab, y);
        }
    }
}
