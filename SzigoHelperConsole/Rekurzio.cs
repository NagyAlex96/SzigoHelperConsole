using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole
{
    public class Rekurzio
    {
        public static Int64 FaktorialisRekurzivTetel(Int64 egesz)
        {
            if (egesz == 0)
            {
                return 1;
            }
            else
            {
                return egesz * FaktorialisRekurzivTetel(egesz - 1);
            }
        }

        public static Int64 FibonacciRekurzivTetel(Int64 egesz)
        {
            if (egesz <= 2)
            {
                return 1;
            }
            else
            {
                return FibonacciRekurzivTetel(egesz - 2) + FibonacciRekurzivTetel(egesz - 1);
            }
        }

        public static Int64 HatvanyozasRekurzivTetel(Int64 egesz, Int64 hatvanyKitevo)
        {
            if (hatvanyKitevo == 1)
            {
                return egesz;
            }
            else
            {
                return egesz * HatvanyozasRekurzivTetel(egesz, hatvanyKitevo - 1);
            }
        }

        public static Int64 HatvanyFelezoRekurzivTetel(Int64 egesz, Int64 hatvanyKitevo)
        {
            if (hatvanyKitevo == 1)
            {
                return egesz;
            }
            else
            {
                if (hatvanyKitevo % 2 == 0)
                {
                    Int64 seged = HatvanyFelezoRekurzivTetel(egesz, hatvanyKitevo / 2);
                    return seged * seged;
                }
                else
                {
                    Int64 seged = HatvanyFelezoRekurzivTetel(egesz, (hatvanyKitevo - 1) / 2);
                    return egesz * seged * seged;
                }
            }
        }

        public static int SorozatSzamitasRekurzivTetel(int[] bemenetiTomb, int jobb)
        {
            if (jobb == -1)
            {
                return 0;
            }
            else
            {
                return SorozatSzamitasRekurzivTetel(bemenetiTomb, jobb - 1) + bemenetiTomb[jobb];
            }
        }

        public static int LinearisKeresesRekurzivTetel(int[] bemenetiTomb, int bal)
        {
            if (bal >= bemenetiTomb.Length)
            {
                return 0;
            }
            else
            {
                if (bemenetiTomb[bal] % 2 == 0)
                {
                    return bal;
                }
                else
                {
                    return LinearisKeresesRekurzivTetel(bemenetiTomb, bal + 1);
                }
            }
        }

        public static int MegszamlalasRekurzivTetel(int[] bemenetiTomb, int jobb)
        {
            if (jobb == -1)
            {
                return 0;
            }
            else
            {
                if (bemenetiTomb[jobb] % 2 == 0)
                {
                    return 1 + MegszamlalasRekurzivTetel(bemenetiTomb, jobb - 1);
                }
                else
                {
                    return MegszamlalasRekurzivTetel(bemenetiTomb, jobb - 1);
                }
            }
        }

        public static int MaximumKivalasztasRekurzivTetel(int[] bemenetiTomb, int jobb)
        {
            if (jobb == 0)
            {
                return 1;
            }
            else
            {
                int max = MaximumKivalasztasRekurzivTetel(bemenetiTomb, jobb - 1);
                if (bemenetiTomb[jobb] > max)
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
