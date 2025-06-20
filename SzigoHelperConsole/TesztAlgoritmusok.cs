using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole
{
    public class TesztAlgoritmusok
    {
        /// <summary>
        /// El akarjuk dönteni, hogy egy gyűjteményben van-e legalább egy adott tulajdonságú elem
        /// </summary>
        /// <param name="Collection">Vizsgált tömb</param>
        /// <param name="P">Tulajdonság függvény, amely minden T típusú érték esetén igaz vagy hamis értéket ad vissza</param>
        /// <returns><c>True</c>: ha van P tulajdonságú elem a tömbben</returns>
        public static bool EldontesTetel<T>(IEnumerable<T> Collection, Func<T, bool> P)
        {
            foreach (T item in Collection)
            {
                if (P(item))
                {
                    return true;
                }
            }


            return false;
        }

        /// <summary>
        /// Feltételezzük, hogy a gyűjtemény egy adott elem mindenképpen előfordul
        /// </summary>
        /// <param name="Collection">Vizsgált gyűjtemény</param>
        /// <param name="P">Tulajdonság függvény, amely minden T típusú érték esetén igaz vagy hamis értéket ad vissza</param>
        /// <returns>Az első P tulajdonságú tömbelem indexe</returns>
        public static int KivalasztasTetel<T>(IEnumerable<T> Collection, Func<T, bool> P)
        {
            int i = 0;

            foreach (var item in Collection)
            {
                if (P(item))
                {
                    return i;
                }
                i++;
            }

            throw new InvalidOperationException("Nincs adott tulajdonságú elem a gyűjteményben");
        }

        /// <summary>
        /// Egy gyűjteményben van-e valamilyen tulajdonságú elem, és ha van, akkor hol található az első ilyen.
        /// </summary>
        /// <param name="Collection">Vizsgált gyűjtemény</param>
        /// <param name="P">Az első P tulajdonságú tömbelem indexe</param>
        /// <returns>True + index: ha van adott tulajdonságú elem. Index (null) amennyiben nincs ilyen elem</returns>
        public static (bool, int?) LinearisKeresesTetel<T>(IEnumerable<T> Collection, Func<T, bool> P)
        {
            int index = 0;
            foreach (T item in Collection)
            {
                if (P(item))
                {
                    return (true, index);
                }
                index++;
            }
            return (false, null);
        }

        /// <summary>
        /// Egy gyűjteményben van-e valamilyen tulajdonságú elem, és ha van, akkor hol található az első ilyen.
        /// </summary>
        /// <param name="Collection">Vizsgált gyűjtemény</param>
        /// <param name="P">Az első P tulajdonságú tömbelem indexe</param>
        /// <param name="Index">Hányadik elemtől vizsgáljuk</param>
        /// <returns><c>True</c>: ha van adott tulajdonságú elem. Index (null) amennyiben nincs ilyen elem</returns>

        public static (bool, int?) LinearisKeresesTetel<T>(IEnumerable<T> Collection, Func<T, bool> P, int FromIndex)
        {
            int i = FromIndex;
            while (i < Collection.Count() && !P(Collection.ElementAt(i)))
            {
                i++;
            }
            if(i<Collection.Count())
            {
                return (true, i);
            }

            return (false, null);
        }

        /// <summary>
        /// Egy gyűjteményben szeretnénk adott tulajdonságú elemek számát meghatározni
        /// </summary>
        /// <param name="Collection">Feldolgozandó tömb</param>
        /// <param name="P">Keresési feltétel</param>
        /// <returns>P tulajdonságú elemek darabszáma</returns>
        public static int MegszamlalasTetel<T>(IEnumerable<T> Collection, Func<T, bool> P)
        {
            int darabSzam = 0;

            foreach (T item in Collection)
            {
                if (P(item))
                {
                    darabSzam++;
                }
            }
            return darabSzam;
        }

        /// <summary>
        /// Azt keressük, hogy egy növekvő módon rendezett tömbben benne van-e a keresett érték, és ha benne van, akkor melyik helyen. A lineáris kereséssel szemben a logaritmikus keresés csak rendezett tömbök esetén használható
        /// </summary>
        /// <param name="Collection">Növekvo módon rendezett tömb</param>
        /// <param name="ertek">A keresett érték</param>
        /// <returns>(bool, int) (létezik az adott elem, melyik indexen található)</returns>
        public static (bool, int?) LogaritmikusKeresesIterativanTetel<T>(IEnumerable<T> Collection, T ertek) where T : IComparable<T>
        {
            int bal = 0;
            int jobb = Collection.Count() - 1;
            int center = (bal + jobb) / 2;
            T centerValue = Collection.ElementAt(center);

            while (bal <= jobb && centerValue.CompareTo(ertek) != 0)
            {
                if (centerValue.CompareTo(ertek) > 0)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
                centerValue = Collection.ElementAt(center);
            }

            return (bal <= jobb, bal <= jobb ? center : null);
        }
    }
}
