using System;

namespace SzigoHelperConsole
{
    public class EgyszeruProgTetelek
    {
        /*
        példa meghívása:
            
        int[] array = { 1, 2, 3, 4, 5, 6, 7 };
        bool van = EgyszeruProgTetelek.EldontesTetel(array, x => x % 5 == 0); //keressük meg

         */

        /// <summary>
        /// Egy tömb összes eleme között elvégez egy műveletet. Jelenleg <c>összeadást</c>
        /// </summary>
        /// <param name="bemenetiTomb">Vizsgált tömb</param>
        /// <returns>Az adott műveletnek (+) a tömb összes elemére történő alkalmazását követően előálló eredmény</returns>
        public static int SorozatSzamitasTetel(int[] bemenetiTomb)
        {
            int ertek = 0;

            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                ertek += bemenetiTomb[i];
            }

            return ertek;
        }

        /// <summary>
        /// El akarjuk dönteni, hogy egy tömbben van-e legalább egy adott tulajdonságú elem
        /// </summary>
        /// <param name="bemenetiTomb">Vizsgált tömb</param>
        /// <param name="pLogikaiTulajdonsag">Tulajdonság függvény, amely minden T típusú érték esetén igaz vagy hamis értéket ad vissza</param>
        /// <returns><c>True</c>: ha van P tulajdonságú elem a tömbben</returns>
        public static bool EldontesTetel<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag)
        {
            int i = 0;

            while (i < bemenetiTomb.Length && !pLogikaiTulajdonsag(bemenetiTomb[i]))
            {
                i++;
            }


            bool van = i < bemenetiTomb.Length;

            return van;
        }

        /// <summary>
        /// Feltételezzük, hogy a tömbben egy adott elem mindenképpen előfordul
        /// </summary>
        /// <param name="bemenetiTomb">Vizsgált tömb</param>
        /// <param name="pLogikaiTulajdonsag">Tulajdonság függvény, amely minden T típusú érték esetén igaz vagy hamis értéket ad vissza</param>
        /// <returns>Az első P tulajdonságú tömbelem indexe</returns>
        public static int KivalasztasTetel<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag)
        {
            int i = 0;
            while (!pLogikaiTulajdonsag(bemenetiTomb[i]))
            {
                i++;
            }
            int index = i;

            return index;
        }

        /// <summary>
        /// Egy tömbben van-e valamilyen tulajdonságú elem, és ha van, akkor hol található az első ilyen.
        /// </summary>
        /// <param name="bemenetiTomb">Vizsgált tömb</param>
        /// <param name="pLogikaiTulajdonsag">Az első P tulajdonságú tömbelem indexe</param>
        /// <returns>True + index: ha van adott tulajdonságú elem. Index (null) amennyiben nincs ilyen elem</returns>
        public static (bool van, int? idx) LinearisKeresesTetel<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag)
        {

            int i = 0;
            while (i < bemenetiTomb.Length && !pLogikaiTulajdonsag(bemenetiTomb[i]))
            {
                i++;
            }

            bool van = i < bemenetiTomb.Length;
            if (van)
            {
                int index = i;
                return (van, i);
            }
            else
            {
                return (van, null);
            }
        }

        /// <summary>
        /// Egy tömbben szeretnénk adott tulajdonságú elemek számát meghatározni
        /// </summary>
        /// <param name="bemenetiTomb">Feldolgozandó tömb</param>
        /// <param name="pLogikaiTulajdonsag">Keresési feltétel</param>
        /// <returns>P tulajdonságú elemek darabszáma</returns>
        public static int MegszamlalasTetel<T>(T[] bemenetiTomb, Func<T, bool> pLogikaiTulajdonsag)
        {
            int darabSzam = 0;
            for (int i = 0; i < bemenetiTomb.Length; i++)
            {
                if (pLogikaiTulajdonsag(bemenetiTomb[i]))
                {
                    darabSzam++;
                }
            }

            return darabSzam;
        }

        /// <summary>
        /// Adott egy tömb, amelyben az elemek összehasonlíthatók és megkeressük a legnagyobb elemet
        /// </summary>
        /// <param name="bemenetiTomb">Legalább 1 elemu tömb, melyben a legnagyobb elemet keressük</param>
        /// <returns>Legnagyobb értékű elem indexe</returns>
        public static int MaximumKivalasztas<T>(T[] bemenetiTomb) where T : IComparable
        {
            int maxIndex = 0;

            for (int i = 1; i < bemenetiTomb.Length; i++)
            {
                if (bemenetiTomb[maxIndex].CompareTo(bemenetiTomb[i]) < 0) // relációs jel megfordításával minimumkiválasztás érhető el
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }

}
