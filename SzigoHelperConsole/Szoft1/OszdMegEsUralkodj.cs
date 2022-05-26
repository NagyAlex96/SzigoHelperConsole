using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole
{
    public class OszdMegEsUralkodj
    {
        /// <summary>
        /// Egy tömb legnagyobb elemének helyét adja vissza
        /// </summary>
        /// <param name="inputArray">Bemeneti tömb</param>
        /// <param name="bal">Az aktuálisan vizsgált résztömb első elemének indexe</param>
        /// <param name="jobb">Az aktuálisan vizsgált résztömb utolsó elemének indexe</param>
        /// <returns>Legnagyobb elem indexe</returns>
        public static int MaximumFelezoKereses(int[] inputArray, int bal, int jobb)
        {
            if (bal == jobb)
            {
                return bal;
            }
            else
            {
                int center = (bal + jobb) / 2;
                int balmax = MaximumFelezoKereses(inputArray, bal, center);
                int jobbmax = MaximumFelezoKereses(inputArray, center + 1, jobb);

                if (inputArray[balmax] > inputArray[jobbmax])
                {
                    return balmax;
                }
                else
                {
                    return jobbmax;
                }
            }
        }

        /// <summary>
        /// A rendezendő tömbünket úgy rendezzük, hogy szétvágjuk két(közel) egyenlő részre, majd az egyes részeket rendezzük
        /// </summary>
        /// <param name="inputArray">Rendezendő tömb, mely az algoritmus végére rendezetté válik</param>
        /// <param name="bal">A tömb éppen rendezés alatt lévő részének alsó indexe</param>
        /// <param name="jobb">A tömb éppen rendezés alatt lévő részének felső indexe</param>
        public static void OsszefesuloRendezes(ref int[] inputArray, int bal, int jobb)
        {
            if (bal < jobb)
            {
                int center = (bal + jobb) / 2;
                OsszefesuloRendezes(ref inputArray, bal, center);
                OsszefesuloRendezes(ref inputArray, center + 1, jobb);
                Osszefesul(ref inputArray, bal, center, jobb);
            }
        }

        /// <summary>
        /// Összefésülő rendezéshez tartozó, segéd eljárás
        /// </summary>
        /// <param name="inputArray">Rendezendő tömb. A tömb bal és center közötti része, valamint center + 1 és jobb közötti része az algoritmus elején rendezett. Az algoritmus végére a tömb bal és jobb közötti része válik rendezetté.</param>
        /// <param name="bal">A tömb összefésülendő résztömbjének kezdő indexe</param>
        /// <param name="center">Index, amely megadja, hogy a két rendezett résztömbnek hol van a határa</param>
        /// <param name="jobb">A tömb összefésülendő résztömbjének záró indexe</param>
        static void Osszefesul(ref int[] inputArray, int bal, int center, int jobb)
        {
            int y1Lenght = center - bal + 1;
            int y2Lenght = jobb - center;
            int[] y1 = new int[y1Lenght + 1];

            for (int i = 0; i < y1Lenght; i++)
            {
                y1[i] = inputArray[bal + i];
            }

            int[] y2 = new int[y2Lenght + 1];

            for (int j = 0; j < y2Lenght; j++)
            {
                y2[j] = inputArray[center + j + 1];
            }

            y1[y1Lenght] = int.MaxValue;
            y2[y2Lenght] = int.MaxValue;
            int x = 0, y = 0;

            for (int k = bal; k <= jobb; k++)
            {
                if (y1[x] < y2[y])
                {
                    inputArray[k] = y1[x];
                    x++;
                }
                else
                {
                    inputArray[k] = y2[y];
                    y++;
                }
            }

        }

        /// <summary>
        /// Rendező algoritmus, de itt nem tudjuk előre, hogy a rendezendő tömböt milyen méretű résztömbökre osztjuk fel.Tehát ebben az esetben nem lesz igaz, hogy a tömböt mindig felezzük. A gyorsrendezés legfontosabb lépése, hogy a tömb elemeit egy támpont elem segítségével szétválogatja. A támpont például az eredeti tömb első eleme lehet. A tömb elemeinek szétválogatása pedig úgy történik, hogy a kiválasztott támpont elem olyan helyre kerül a tömbben, hogy előtte csak nála nem nagyobb, mögötte pedig csak nála nagyobb elemek vannak.
        /// </summary>
        /// <param name="inputArray">Rendezendő tömb, mely az algoritmus végére rendezetté válik</param>
        /// <param name="bal">A tömb éppen rendezés alatt lévő részének alsó indexe</param>
        /// <param name="jobb">A tömb éppen rendezés alatt lévő részének felső indexe</param>
        public static void GyorsRendezes(ref int[] inputArray, int bal, int jobb)
        {
            int index = SzetValogat(ref inputArray, bal, jobb);

            if (index > bal + 1)
            {
                GyorsRendezes(ref inputArray, bal, index - 1);
            }

            if (index < jobb - 1)
            {
                GyorsRendezes(ref inputArray, index + 1, jobb);
            }
            ;
        }

        /// <summary>
        /// Gyorsrendezéshez/K-adik legkisebb elemhez tartozó segéd eljárás
        /// </summary>
        /// <param name="inputArray">A rendezés alatt lévő tömb</param>
        /// <param name="bal">Kezdetben az bemeneti tömb éppen vizsgált résztömbjének alsó indexe, majd a bejárást segítő változó</param>
        /// <param name="jobb">Kezdetben az bemeneti tömb éppen vizsgált résztömbjének felső indexe, majd a bejárást segítő változó</param>
        /// <returns>Az eltárolt segédváltozó helye a függvény végén. Az idx-nél kisebb indexű elemek mind kisebbek vagy egyenlők a segéd-del, míg az idx-nél nagyobb indexű elemek mind nagyobbak a segéd-nél</returns>
        static int SzetValogat(ref int[] inputArray, int bal, int jobb)
        {
            int seged = inputArray[bal];

            while (bal < jobb)
            {
                while (bal < jobb && inputArray[jobb] > seged)
                {
                    jobb--;
                }
                if (bal < jobb)
                {
                    inputArray[bal] = inputArray[jobb];
                    bal++;
                    while (bal < jobb && inputArray[bal] < seged)
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
            int index = bal;
            inputArray[index] = seged;
            return index;
        }

        /// <summary>
        /// Egy tömbben megkeresi a K-adik legkisebb elemet
        /// </summary>
        /// <param name="inputArray">Tömb, melybol a k-adik legkisebb elem értékét akarjuk kiválasztani</param>
        /// <param name="bal">Az tömb aktuálisan vizsgált részének alsó indexe</param>
        /// <param name="jobb">Az tömb aktuálisan vizsgált részének felső indexe</param>
        /// <param name="k">A k-adik legkisebb elemet akarjuk kiválasztani a bemeneti tömbből</param>
        /// <returns>K-adik legkisebb elem értéke</returns>
        public static int KadikLegkisebbElem(int[] inputArray, int bal, int jobb, int k)
        {
            if (bal == jobb)
            {
                return inputArray[bal];
            }
            else
            {
                int index = SzetValogat(ref inputArray, bal, jobb);
                if (k == index - bal + 1)
                {
                    return inputArray[index];
                }
                else if (k < index - bal + 1)
                {
                    return KadikLegkisebbElem(inputArray, bal, index - 1, k);
                }
                else
                {
                    return KadikLegkisebbElem(inputArray, index + 1, jobb, k - (index - bal + 1));
                }
            }
        }
    }
}
