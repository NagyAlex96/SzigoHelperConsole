using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole
{
    internal class EgyszeruProgTetelek
    {

        /// <summary>
        /// Egy tömb összes eleme között elvégez egy műveletet. Jelenleg összeadást
        /// </summary>
        /// <param name="inputArray">Bemeneti tömb</param>
        /// <returns>Összeadás eredménye</returns>
        static int SorozatSzamitasTetel(int[] inputArray)
        {
            int ertek = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                ertek += inputArray[i];
            }

            return ertek;
        }

        /// <summary>
        /// El akarjuk dönteni, hogy egy tömbben van-e legaláabb egy adott tulajdonságú elem
        /// </summary>
        /// <param name="inputArray">Vizsgált tömb</param>
        /// <param name="lambdaExpression">Lambda kifejezés</param>
        /// <returns>True: létezik adott tulajdonságú elem</returns>
        static bool EldontesTetel(int[] inputArray, Func<int, bool> lambdaExpression)
        {
            int i = 0;
            while (i < inputArray.Length && lambdaExpression(i))
            {
                i++;
            }

            bool letezik = i < inputArray.Length;

            return letezik;
        }

        /// <summary>
        /// Feltételezzük, hogy a tömbben egy adott elem mindenképpen előfordul
        /// </summary>
        /// <param name="lambdaExpression">lambda kifejezés</param>
        /// <returns>A keresett elem első előfordulási helye</returns>
        static int KivalasztasTetel(Func<int, bool> lambdaExpression)
        {
            int i = 0;
            while (lambdaExpression(i))
            {
                i++;
            }
            int index = i;

            return index;
        }

        /// <summary>
        /// Megnézi, hogy van-e adott tulajdonsággal rendelező elem a tömbben.
        /// </summary>
        /// <param name="bemenetiTomb">Keresett érték helye</param>
        /// <param name="lambdaExpression">Lambda kifejezés</param>
        /// <returns>True + index: ha van adott tulajdonságú elem. Index (null) amennyiben nincs ilyen elem</returns>
        static (bool, int?) LinearisKeresesTetel(int[] bemenetiTomb, Func<int, bool> lambdaExpression)
        {

            int i = 0;
            while (i < bemenetiTomb.Length && lambdaExpression(i))
            {
                i++;
            }

            bool letezik = i < bemenetiTomb.Length;
            if(letezik)
            {
                int index = i;
                return (letezik, i);
            }
            else
            {
                return (letezik, null);
            }
        }

        /// <summary>
        /// Egy tömbben szeretnénk adott tulajdonságú elemek számát meghatározni
        /// </summary>
        /// <param name="bemenetiTomb">Keresett elemek halmaza</param>
        /// <param name="lambdaExpression">Lambda kifejezés</param>
        /// <returns>Adott tulajdonságú elemek halmaza</returns>
        static int MegszamlalasTetel(int[] bemenetiTomb, Func<int, bool> lambdaExpression)
        {
            int darabSzam = 0;
            for (int j = 0; j < bemenetiTomb.Length; j++)
            {
                if (bemenetiTomb[j] % 2 == 0)
                {
                    darabSzam++;
                }
            }

            return darabSzam;
        }


        /// <summary>
        /// Adott egy tömb, amelyben az elemek összehasonlíthatók és megkeressük a legnagyobb elemet
        /// </summary>
        /// <param name="bemenetiTomb"></param>
        /// <returns></returns>
        static int MaximumKivalasztas(int[] bemenetiTomb)
        {
            int maxIndex = 0;

            for (int i = 1; i < bemenetiTomb.Length; i++)
            {
                if (bemenetiTomb[maxIndex] < bemenetiTomb[i]) // relációs jel megfordításával minimumkiválasztás érhető el
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }


    }

}
