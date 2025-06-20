using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole
{
    public class Rendezesek
    {
        public static void EgyszeruCseresRendezesTetel<T>(ref T[] tomb) where T : IComparable
        {
            for (int i = 0; i < tomb.Length - 1; i++)
            {
                for (int j = i + 1; j < tomb.Length; j++)
                {
                    if (tomb[i].CompareTo(tomb[j]) > 0) //relációs jel megfordítása esetén, csökkenő sorrend
                    {
                        T temp = tomb[i];
                        tomb[i] = tomb[j];
                        tomb[j] = temp;
                    }
                }
            }
        }

        public static void MinimumKivalasztasosRendezesTelelt<T>(ref T[] tomb) where T : IComparable
        {
            for (int i = 0; i < tomb.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < tomb.Length; j++)
                {
                    if (tomb[min].CompareTo(tomb[j]) > 0)
                    {
                        min = j;
                    }
                }
                T temp = tomb[i];
                tomb[i] = tomb[min];
                tomb[min] = temp;
            }
        }

        public static void BuborekRendezesTetel<T>(ref T[] tomb) where T : IComparable
        {
            for (int i = tomb.Length; i > 1; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (tomb[j].CompareTo(tomb[j + 1]) > 0)
                    {
                        T temp = tomb[j];
                        tomb[j] = tomb[j + 1];
                        tomb[j + 1] = temp;
                    }
                }
            }
        }

        public static void JavitottBuborekRendezesTetel<T>(ref T[] tomb) where T : IComparable
        {
            int i = tomb.Length;
            while (i >= 1)
            {
                int index = 0;
                for (int j = 0; j < i - 1; j++)
                {
                    if (tomb[j].CompareTo(tomb[j + 1]) > 0)
                    {
                        T temp = tomb[j];
                        tomb[j] = tomb[j + 1];
                        tomb[j + 1] = temp;
                        index = j + 1;
                    }
                }
                i = index;
            }
        }

        public static void BeillesztésesRendezésTetel<T>(ref T[] tomb) where T : IComparable
        {
            for (int i = 1; i < tomb.Length; i++)
            {
                int j = i - 1;
                while (j >= 0 && (tomb[j].CompareTo(tomb[j + 1]) > 0))
                {
                    T temp = tomb[j];
                    tomb[j] = tomb[j + 1];
                    tomb[j + 1] = temp;
                    j--;
                }
            }
        }

        public static void JavitottBeillesztésesRendezesTetel<T>(ref T[] tomb) where T : IComparable
        {
            for (int i = 1; i < tomb.Length; i++)
            {
                int j = i - 1;
                T seged = tomb[i];

                while (j >= 0 && tomb[j].CompareTo(seged) > 0)
                {
                    tomb[j + 1] = tomb[j];
                    j--;
                }
                tomb[j + 1] = seged;
            }
        }

    }
}
