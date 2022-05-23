using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole
{
    public class Rendezesek
    {
        public static void EgyszeruCseresRendezesTetel(ref int[] tomb)
        {
            for (int i = 0; i < tomb.Length - 1; i++)
            {
                for (int j = i + 1; j < tomb.Length; j++)
                {
                    if (tomb[i] > tomb[j]) //relációs jel megfordítása esetén, csökkenő sorrend
                    {
                        var temp = tomb[i];
                        tomb[i] = tomb[j];
                        tomb[j] = temp;
                    }
                }
            }
        }

        public static void MinimumKivalasztasosRendezesTelelt(ref int[] tomb)
        {
            int db = 0;
            for (int i = 0; i < tomb.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < tomb.Length; j++)
                {
                    db++;
                    if (tomb[min] > tomb[j])
                    {
                        min = j;
                    }
                }
                var temp = tomb[i];
                tomb[i] = tomb[min];
                tomb[min] = temp;
            }
            Console.WriteLine($"Összehasonlítások száma: {db}");
        }

        public static void BuborekRendezesTetel(ref int[] tomb)
        {
            int db = 0;
            for (int i = tomb.Length; i > 1; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    db++;
                    if (tomb[j] > tomb[j + 1])
                    {
                        var temp = tomb[j];
                        tomb[j] = tomb[j + 1];
                        tomb[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine($"Összehasonlítások száma: {db}");

        }

        public static void JavitottBuborekRendezesTetel(ref int[] tomb)
        {
            int i = tomb.Length;
            int db = 0;
            while (i >= 1)
            {
                int index = 0;
                for (int j = 0; j < i - 1; j++)
                {
                    db++;
                    if (tomb[j] > tomb[j + 1])
                    {
                        var temp = tomb[j];
                        tomb[j] = tomb[j + 1];
                        tomb[j + 1] = temp;
                        index = j + 1;
                    }
                }
                i = index;
            }
            Console.WriteLine($"Összehasonlítások száma: {db}");
        }

        public static void BeillesztésesRendezésTetel(ref int[] tomb)
        {
            int db = 0;
            for (int i = 1; i < tomb.Length; i++)
            {
                int j = i - 1;
                db++;
                while (j >= 0 && (tomb[j] > tomb[j + 1]))
                {
                    var temp = tomb[j];
                    tomb[j] = tomb[j + 1];
                    tomb[j + 1] = temp;
                    j--;
                }
            }
            Console.WriteLine($"Összehasonlítások száma: {db}");

        }

        public static void JavitottBeillesztésesRendezesTetel(ref int[] tomb)
        {
            int db = 0;
            for (int i = 1; i < tomb.Length; i++)
            {
                int j = i - 1;
                int seged = tomb[i];

                db++;
                while (j >= 0 && tomb[j] > seged)
                {
                    tomb[j + 1] = tomb[j];
                    j--;
                }
                tomb[j + 1] = seged;
            }
            Console.WriteLine($"Összehasonlítások száma: {db}");

        }

    }
}
