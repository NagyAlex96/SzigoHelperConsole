using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole
{
    public class Rekurzio
    {
        /// <summary>
        /// N darab pozitív egész szám szorzata
        /// </summary>
        /// <param name="N">Természetes szám, melynek a faktoriálisát meg kívánjuk határozni</param>
        /// <returns>N! értéke</returns>
        public static int FaktorialisIterativan(int N)
        {
            int ertek = 1;

            for (int i = 2; i <= N; i++)
            {
                ertek *= i;
            }

            return ertek;
        }

        /// <summary>
        /// N darab pozitív egész szám szorzata
        /// </summary>
        /// <param name="N">Természetes szám, amelynek faktoriálisát meg szeretnék határozni</param>
        /// <returns>N! értéke</returns>
        public static int FaktorialisRekurzivTetel(int N)
        {
            if (N == 0)
            {
                return 1;
            }
            else
            {
                return N * FaktorialisRekurzivTetel(N - 1);
            }
        }

        /// <summary>
        /// Fibonacci szám meghatározása
        /// </summary>
        /// <param name="N">Nemnegatív egész, mely megadja, hogy hányadik Fibonacci számot akarjuk meghatározni</param>
        /// <returns>N-edik Fibonacci szám értéke</returns>
        public static int FibonacciIterativan(int N)
        {
            int aktualis = 1;
            int elozo = 1;

            for (int i = 1; i < N - 1; i++)
            {
                int atmeneti = aktualis + elozo;
                elozo = aktualis;
                aktualis = atmeneti;
            }
            return aktualis;
        }

        /// <summary>
        /// Fibonacci szám meghatározása
        /// </summary>
        /// <param name="N">Nemnegatív egész, mely megadja, hogy hányadik Fibonacci számot akarjuk meghatározni</param>
        /// <returns>N-edik Fibonacci szám értéke</returns>
        public static int FibonacciRekurzivTetel(int N)
        {
            if (N <= 2)
            {
                return 1;
            }
            else
            {
                return FibonacciRekurzivTetel(N - 2) + FibonacciRekurzivTetel(N - 1);
            }
        }

        /// <summary>
        /// Valós szám, pozitív egész kitevős hatványának meghatározása
        /// </summary>
        /// <param name="a">Pozitív valós szám. Hatványalap</param>
        /// <param name="N">Pozitív valós szám. Hatványkitevő</param>
        /// <returns>A^n értéke</returns>
        public static int HatvanyozasIterativan(int a, int N)
        {
            int ertek = a;

            for (int i = 1; i < N; i++)
            {
                ertek *= a;
            }
            return ertek;
        }

        /// <summary>
        /// Valós szám, pozitív egész kitevős hatványának meghatározása
        /// </summary>
        /// <param name="a">Pozitív valós szám. Hatványalap</param>
        /// <param name="N">Pozitív valós szám. Hatványkitevő</param>
        /// <returns>A^n értéke</returns>
        public static int HatvanyozasRekurzivTetel(int a, int N)
        {
            if (N == 1)
            {
                return a;
            }
            else
            {
                return a * HatvanyozasRekurzivTetel(a, N - 1);
            }
        }

        /// <summary>
        /// Valós szám, pozitív egész kitevős hatványának meghatározása
        /// </summary>
        /// <param name="a">Pozitív valós szám. Hatványalap</param>
        /// <param name="N">Pozitív valós szám. Hatványkitevő</param>
        /// <returns>A^n értéke</returns>
        public static Int64 HatvanyFelezoRekurzivTetel(int a, int N)
        {
            if (N == 1)
            {
                return a;
            }
            else
            {
                if (N % 2 == 0)
                {
                    Int64 seged = HatvanyFelezoRekurzivTetel(a, N / 2);
                    return seged * seged;
                }
                else
                {
                    Int64 seged = HatvanyFelezoRekurzivTetel(a, (N - 1) / 2);
                    return a * seged * seged;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="N">A mozgatandó korongok száma</param>
        /// <param name="forras">Az a rúd, amelyről mozgatni akarunk</param>
        /// <param name="cel">Az a rúd, amelyre mozgatni akarunk</param>
        /// <param name="seged">Az a rúd, amelyet segítségül használhatunk a mozgatáshoz</param>
        public static void Hanoi(int N, string forras, string cel, string seged)
        {
            if(N == 1)
            {
                Console.WriteLine($"Mozgassuk: {N} számú korongot {forras}(ról/ről), {cel}(ra/re)");
                //pszeudóban Mozgat van, Nálam kiíratás (átláthatóbb és a lényegen nem változtat)
            }
            else
            {
                Hanoi(N - 1, forras, seged, cel);
                Console.WriteLine($"Mozgassuk: {N} számú korongot {forras}(ról/ről), {cel}(ra/re)");
                //pszeudóban Mozgat van, Nálam kiíratás (átláthatóbb és a lényegen nem változtat)
                Hanoi(N-1, seged, cel, forras);
            }
        }

        /// <summary>
        /// Tömb összes eleme között elvégez egy megadott műveletet (összeadás jelenleg)
        /// </summary>
        /// <param name="inputArray">Feldolgozandó tömb</param>
        /// <param name="jobb">Tömb első elemétől a jobb indexű eleméig tartó résztömböt dolgozza fel</param>
        /// <returns></returns>
        public static int SorozatSzamitasRekurzivTetel(int[] inputArray, int jobb)
        {
            if (jobb == -1)
            {
                return 0;
            }
            else
            {
                return SorozatSzamitasRekurzivTetel(inputArray, jobb - 1) + inputArray[jobb];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputArray">A feldolgozandó tömb</param>
        /// <param name="bal">A bemeneti tömbnek a bal indexű elemétől az utolsó eleméig tartó résztömböt dolgozza fel</param>
        /// <param name="P">Logikai értéket visszaadó tulajdonságfüggvény</param>
        /// <returns></returns>
        public static int? LinearisKeresesRekurzivTetel(int[] inputArray, int bal, Func<int, bool> P)
        {
            if (bal >= inputArray.Length)
            {
                return null;
            }
            else
            {
                if (P(bal))
                {
                    return bal;
                }
                else
                {
                    return LinearisKeresesRekurzivTetel(inputArray, bal + 1, P);
                }
            }
        }

        /// <summary>
        /// Megszámolja a tömbben a P tulajdonságú elemek darabszámát
        /// </summary>
        /// <param name="inputArray">A feldolgozandó tömb</param>
        /// <param name="jobb">A tömbnek az első elemétől a jobb indexű eleméig tartó résztömböt dolgozza fel</param>
        /// <param name="P">Logikai értéket visszaadó tulajdonság függvény</param>
        /// <returns>P tulajdonságú elemek darabszáma</returns>
        public static int MegszamlalasRekurzivTetel(int[] inputArray, int jobb, Func<int, bool> P)
        {
            if (jobb == -1)
            {
                return 0;
            }
            else
            {
                if (P(jobb))
                {
                    return 1 + MegszamlalasRekurzivTetel(inputArray, jobb - 1, P);
                }
                else
                {
                    return MegszamlalasRekurzivTetel(inputArray, jobb - 1, P);
                }
            }
        }

        /// <summary>
        /// Egy tömb elemei közül megadja a maximális értékű elem indexét
        /// </summary>
        /// <param name="inputArray">A feldolgozandó tömb</param>
        /// <param name="jobb">A tömbnek az első elemétől a jobb indexű eleméig tartó résztömböt dolgozza fel</param>
        /// <returns>Maximális értékű elem indexe</returns>
        public static int MaximumKivalasztasRekurzivTetel(int[] inputArray, int jobb)
        {
            if (jobb == 0)
            {
                return 0;
            }
            else
            {
                int max = MaximumKivalasztasRekurzivTetel(inputArray, jobb - 1);
                if (inputArray[jobb] > inputArray[max])
                {
                    return jobb;
                }
                else
                {
                    return max;
                }
            }
        }
    }
}
