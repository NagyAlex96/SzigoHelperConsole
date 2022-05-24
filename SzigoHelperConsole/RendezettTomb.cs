using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole
{
    public class RendezettTomb
    {
        /// <summary>
        /// Egy tömbben van-e valamilyen tulajdonságú elem, és ha van, akkor hol található az első ilyen. Az algoritmus akkor is véget ér, ha az aktuálisan vizsgált tömbelem nagyobb a keresett értéknél. Ilyenkor már biztos nem fogjuk a keresett értéket megtalálni a tömbben.
        /// </summary>
        /// <param name="inputArray">Növekvő módon rendezett tömb</param>
        /// <param name="ertek">Keresett érték</param>
        /// <returns>(bool, int) (létezik az adott elem, melyik indexen található)</returns>
        public static (bool, int?) LinearisKeresesTetel(int[] inputArray, int ertek)
        {
            int i = 0;
            while (i < inputArray.Length && inputArray[i] < ertek)
            {
                i++;
            }

            bool van = (i < inputArray.Length && inputArray[i] == ertek);

            if (van)
            {
                int index = i;
                return (van, index);
            }
            else
            {
                return (van, null);
            }

        }

        /// <summary>
        /// Azt keressük, hogy egy növekvő módon rendezett tömbben benne van-e a keresett érték, és ha benne van, akkor melyik helyen. A lineáris kereséssel szemben a logaritmikus keresés csak rendezett tömbök esetén használható
        /// </summary>
        /// <param name="inputArray">Növekvo módon rendezett tömb</param>
        /// <param name="bal">Az aktuálisan vizsgált résztömb első elemének indexe</param>
        /// <param name="jobb">Az aktuálisan vizsgált résztömb utolsó elemének indexe</param>
        /// <param name="ertek">A keresett érték</param>
        /// <returns>Melyik indexen található a keresett elem. NULL: nincs ilyen elem</returns>
        public static int? LogaritmikusKeresesRekurzivanTetel(int[] inputArray, int bal, int jobb, int ertek)
        {
            if (bal > jobb)
            {
                return null;
            }
            else
            {
                int center = (bal + jobb) / 2;
                if (inputArray[center] == ertek)
                {
                    return center;
                }
                else
                {
                    if (inputArray[center] > ertek)
                    {
                        return LogaritmikusKeresesRekurzivanTetel(inputArray, bal, center - 1, ertek);
                    }
                    else
                    {
                        return LogaritmikusKeresesRekurzivanTetel(inputArray, center + 1, jobb, ertek);
                    }
                }

            }

        }

        /// <summary>
        /// Azt keressük, hogy egy növekvő módon rendezett tömbben benne van-e a keresett érték, és ha benne van, akkor melyik helyen. A lineáris kereséssel szemben a logaritmikus keresés csak rendezett tömbök esetén használható
        /// </summary>
        /// <param name="inputArray">Növekvo módon rendezett tömb</param>
        /// <param name="ertek">A keresett érték</param>
        /// <returns>(bool, int) (létezik az adott elem, melyik indexen található)</returns>
        public static (bool, int?) LogaritmikusKeresesIterativanTetel(int[] inputArray, int ertek)
        {
            int bal = 0, jobb = inputArray.Length;
            int center = (bal + jobb) / 2;

            while (bal < jobb && inputArray[center] != ertek)
            {
                if (inputArray[center] > ertek)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
            }

            bool van = (bal < jobb);

            if (van)
            {
                int index = center;
                return (van, index);
            }
            else
            {
                return (van, null);
            }
        }

        /// <summary>
        /// Arról ad információt, hogy a vizsgált tömbben megtalálható-e egy konkrét érték
        /// </summary>
        /// <param name="inputArray">Növekvő módon rendezett tömb</param>
        /// <param name="ertek">A keresett érték</param>
        /// <returns>True: amennyiben megtalálható a tömbben a keresett elem</returns>
        public static bool EldontesTetel(int[] inputArray, int ertek)
        {
            int bal = 0;
            int jobb = inputArray.Length;
            int center = (bal + jobb) / 2;

            while (bal < jobb && inputArray[center] != ertek)
            {
                if (inputArray[center] > ertek)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
            }

            bool van = bal < jobb;
            return van;
        }

        /// <summary>
        /// Arról ad információt, hogy a vizsgált tömbben megtalálható-e egy konkrét érték
        /// </summary>
        /// <param name="inputArray">Növekvő módon rendezett tömb</param>
        /// <param name="alsoHatar">Ennél az értéknél nem kisebb elemet keresünk a tömbben</param>
        /// <param name="felsoHatar">Ennél az értéknél nem nagyobb elemet keresünk a tömbben</param>
        /// <returns>True: amennyiben megtalálható a tömbben a keresett elem</returns>
        public static bool ModositottEldontesTetel(int[] inputArray, int alsoHatar, int felsoHatar)
        {
            int bal = 0, jobb = inputArray.Length;

            int center = (bal + jobb) / 2;

            while (bal < jobb && !(alsoHatar <= inputArray[center] && inputArray[center] <= felsoHatar))
            {
                if (inputArray[center] > felsoHatar)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
            }

            bool van = bal < jobb;

            return van;
        }

        /// <summary>
        /// A rendezett tömbben van-e olyan elem, mely a keresett értékkel megegyezik
        /// </summary>
        /// <param name="inputArray">Növekvő módon rendezett tömb</param>
        /// <param name="ertek">A keresett érték</param>
        /// <returns>A keresett érték tömbben elfoglalt helyének indexe</returns>
        public static int KivalasztasTetel(int[] inputArray, int ertek)
        {
            int bal = 0;
            int jobb = inputArray.Length;

            int center = (bal + jobb) / 2;

            while (inputArray[center] != ertek)
            {
                if (inputArray[center] > ertek)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
            }

            return center;
        }

        /// <summary>
        /// Azokat a elemeket keressük, amik egy konkrét értékkel megegyeznek
        /// </summary>
        /// <param name="inputArray">Növekvő módon rendezett tömb</param>
        /// <param name="ertek">A keresett érték</param>
        /// <returns>(bool, int, int) (van, bal, jobb)</returns>
        public static (bool, int?, int?) KivalogatasTetel(int[] inputArray, int ertek)
        {
            int bal = 0;
            int jobb = inputArray.Length;
            int center = (bal + jobb) / 2;

            while (bal < jobb && inputArray[center] != ertek)
            {
                if (inputArray[center] > ertek)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
            }

            bool van = (bal < jobb);

            if (van)
            {
                bal = center;

                while (bal > 0 && inputArray[bal - 1] == ertek)
                {
                    bal--;
                }
                jobb = center;

                while (jobb < inputArray.Length && inputArray[jobb + 1] == ertek)
                {
                    jobb++;
                }

                return (van, bal, jobb);
            }
            else
            {
                return (van, null, null);
            }
        }

        /// <summary>
        /// Azokat a elemeket keressük, amik egy konkrét értékkel megegyeznek
        /// </summary>
        /// <param name="inputArray">Növekvő módon rendezett tömb</param>
        /// <param name="alsoHatar">Ennél az értéknél nem kisebb elem</param>
        /// <param name="felsoHatar">Ennél az értéknél nem nagyobb elem</param>
        /// <returns>(bool, int, int) (van, bal, jobb)</returns>
        public static (bool, int?, int?) ModositottKivalogatasTetel(int[] inputArray, int alsoHatar, int felsoHatar)
        {
            int bal = 0;
            int jobb = inputArray.Length;

            int center = (bal + jobb) / 2;

            while (bal < jobb && !(alsoHatar <= inputArray[center] && inputArray[center] <= felsoHatar))
            {
                if (inputArray[center] > felsoHatar)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
            }

            bool van = bal < jobb;

            if (van)
            {
                bal = center;

                while (bal > 0 && inputArray[bal - 1] >= alsoHatar)
                {
                    bal--;
                }

                jobb = center;

                while (jobb < inputArray.Length - 1 && inputArray[jobb + 1] <= felsoHatar)
                {
                    jobb++;
                }

                return (bal < jobb, bal, jobb);
            }
            else
            {
                return (bal < jobb, null, null);
            }

        }

        /// <summary>
        /// Azt szeretnénk meghatározni, hogy egy konkrét érték hányszor fordul elő a rendezett tömbben.
        /// </summary>
        /// <param name="inputArray">Növekvő módon rendezett tömb</param>
        /// <param name="ertek">A keresett érték</param>
        /// <returns>Az értékkel egyező elemek száma a tömbben</returns>
        public static int MegszamlalasTetel(int[] inputArray, int ertek)
        {
            int bal = 0;
            int jobb = inputArray.Length;
            int center = (bal + jobb) / 2;

            while (bal < jobb && inputArray[center] != ertek)
            {
                if (inputArray[center] > ertek)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
            }

            bool van = (bal < jobb);

            if (van)
            {
                bal = center;

                while (bal > 0 && inputArray[bal - 1] == ertek)
                {
                    bal--;
                }
                jobb = center;

                while (jobb < inputArray.Length - 1 && inputArray[jobb + 1] == ertek)
                {
                    jobb++;
                }

                return jobb - bal + 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Egy tömbről azt szeretnénk eldönteni, hogy halmaz-e (rendezett, nincs ismétlődés)
        /// </summary>
        /// <param name="inputArray">Vizsgált tömb (legalább 2 elemet tartalmaz)</param>
        /// <returns></returns>
        public static bool HalmazTulajdonsagVizsgalata(int[] inputArray)
        {
            int i = 1;

            while (i < inputArray.Length && inputArray[i - 1] != inputArray[i])
            {
                i++;
            }

            bool van = (i >= inputArray.Length);
            return van;
        }

        /// <summary>
        /// Kiszűri a rendezett tömbből az ismétlődő elemeket
        /// </summary>
        /// <param name="inputArray">Rendezett tömb</param>
        /// <returns>(int[], int) (Halmaz, mely a bemeneti tömb elemeit tartalmazza ismétlődés nélkül; A kimeneti halmazban tárolt elemek száma) (</returns>
        public static (int[], int) HalmazLetrehozasa(int[] inputArray)
        {
            int db = 0;
            int[] a = new int[inputArray.Length];
            a[db] = inputArray[0];

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] != a[db])
                {
                    db++;
                    a[db] = inputArray[i];
                }
            }
            return (a, db);
        }

        /// <summary>
        /// Valami benne van-e egy halmazban vagy sem.
        /// </summary>
        /// <param name="halmaz">Bemeneti halmaz</param>
        /// <param name="ertek">A keresett érték</param>
        /// <returns></returns>
        public static bool TartalmazasVizsgalat(int[] halmaz, int ertek)
        {
            int bal = 0, jobb = halmaz.Length;
            int center = (bal + jobb) / 2;

            while (bal < jobb && halmaz[center] != ertek)
            {
                if (halmaz[center] > ertek)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
            }
            bool van = (bal < jobb);

            return van;
        }

        /// <summary>
        /// Egy halmaz minden egyes eleme benne van-e egy másik halmazban.
        /// </summary>
        /// <param name="halmaz1">Egyik halmaz</param>
        /// <param name="halmaz2">Másik halmaz</param>
        /// <returns>True: amennyiben A részhalmaza B-nek</returns>
        public static bool ReszhalmazVizsgalat(int[] halmaz1, int[] halmaz2)
        {
            int i = 0, j = 0;

            while (i < halmaz1.Length && j < halmaz2.Length && halmaz1[i] >= halmaz2[j])
            {
                if (halmaz1[i] == halmaz2[j])
                {
                    i++;
                }
                j++;
                ;
            }
            return i >= halmaz1.Length;
        }

        /// <summary>
        /// A halmazok uniója teljes mértékben megfelel a Módosított Összefuttatás tétellel
        /// </summary>
        /// <param name="halmaz1">Egyik halmaz</param>
        /// <param name="halmaz2">Másik halmaz</param>
        /// <returns>Kimeneti halmaz, melynek minden egyes eleme vagy az egyik vagy a másik halmaznak eleme</returns>
        public static (int[], int) HalmazokUnioja(int[] halmaz1, int[] halmaz2)
        {
            int kimenetiMeret = halmaz1.Length + halmaz2.Length;
            int[] kimenetiHalmaz = new int[kimenetiMeret];

            Array.Resize<int>(ref halmaz1, halmaz1.Length + 1);
            Array.Resize<int>(ref halmaz2, halmaz2.Length + 1); //ez a két sor csak azért szükséges, hogy a végtelen-t el tudjuk tárolnis
            //listával nyilván egyszerűbb

            halmaz1[halmaz1.Length - 1] = int.MaxValue;
            halmaz2[halmaz2.Length - 1] = int.MaxValue;

            int i = 0;
            int j = 0;
            int darab = 0;

            while (i < halmaz1.Length - 1 || j < halmaz2.Length - 1)
            {
                if (halmaz1[i] < halmaz2[j])
                {
                    kimenetiHalmaz[darab] = halmaz1[i];
                    i++;
                }
                else if (halmaz1[i] > halmaz2[j])
                {
                    kimenetiHalmaz[darab] = halmaz2[j];
                    j++;
                }
                else
                {
                    kimenetiHalmaz[darab] = halmaz1[i];
                    i++;
                    j++;
                }
                darab++;
            }
            return (kimenetiHalmaz, darab);

        }

        /// <summary>
        /// Két halmaz metszetében a halmazok közös elemei lesznek benne
        /// </summary>
        /// <param name="halmaz1">Egyik halmaz</param>
        /// <param name="halmaz2">Másik halmaz</param>
        /// <returns>(int[], int) (Kimeneti halmaz, amely minden egyes eleme az Egyik illetve a Másik halmaz eleme; A halamaz releváns elemeinek száma)</returns>
        public static (int[], int) HalmazokMetszete(int[] halmaz1, int[] halmaz2)
        {
            int length = (halmaz1.Length > halmaz2.Length ? halmaz2.Length : halmaz1.Length); //kisebbik halmaz méretével egyező legyen a kimeneti tömb mérete

            int[] yKimenetiHalmaz = new int[length];
            int i = 0;
            int j = 0;
            int darab = 0;

            while (i < halmaz1.Length && j < halmaz2.Length)
            {
                if (halmaz1[i] < halmaz2[j])
                {
                    i++;
                }
                else if (halmaz1[i] > halmaz2[j])
                {
                    j++;
                }
                else
                {
                    yKimenetiHalmaz[darab] = halmaz1[i];
                    i++;
                    j++;
                    darab++;
                }
            }
            return (yKimenetiHalmaz, darab);
        }

        /// <summary>
        /// Azon elemek kiszervezése, amelyek az első halmaznak elemei, de a másodiknak nem
        /// </summary>
        /// <param name="halmaz1">Egyik halmaz</param>
        /// <param name="halmaz2">Másik halmaz</param>
        /// <returns>(int[], int) (Kimeneti halmaz, amely minden egyes eleme csak az első halmazban található meg; A halamaz releváns elemeinek száma)</returns>
        public static (int[], int) HalmazokKulobsege(int[] halmaz1, int[] halmaz2)
        {
            int[] yKimenetiHalmaz = new int[halmaz1.Length];
            int i = 0;
            int j = 0;
            int darab = 0;

            while (i < halmaz1.Length && j < halmaz2.Length)
            {
                if (halmaz1[i] < halmaz2[j]) //első halmaz elemeti válogassuk ki
                {
                    yKimenetiHalmaz[darab] = halmaz1[i];
                    darab++;
                    i++;
                }
                else if (halmaz1[i] > halmaz2[j])
                {
                    j++;
                }
                else
                {
                    i++;
                    j++;
                }
            }

            while (i < halmaz1.Length)
            {
                yKimenetiHalmaz[darab] = halmaz1[i];
                i++;
                darab++;
            }

            return (yKimenetiHalmaz, darab);
        }

        /// <summary>
        /// Azon elemek kigyűjtése, amelyek a két halmazból pontosan az egyikben vannak benne. 
        /// </summary>
        /// <param name="halmaz1">Egyik halamaz</param>
        /// <param name="halmaz2">Másik halmaz</param>
        /// <returns>(int[], int) (Kimeneti halmaz, melynek minden egyes eleme a egyik és a másik halmazok közül pontosan az egyiknek eleme; A halamaz releváns elemeinek száma)</returns>
        public static (int[], int) HalmazokSzemetrikusDifferencialja(int[] halmaz1, int[] halmaz2)
        {
            int length = halmaz1.Length + halmaz2.Length;
            int[] yKimenetiHalmaz = new int[length];
            int i = 0, j = 0, darab = -1;

            while (i < halmaz1.Length && j < halmaz2.Length)
            {
                if (halmaz1[i] < halmaz2[j])
                {
                    darab++;
                    yKimenetiHalmaz[darab] = halmaz1[i];
                    i++;
                }
                else if (halmaz1[i] > halmaz2[j])
                {
                    darab++;
                    yKimenetiHalmaz[darab] = halmaz1[i];
                    j++;
                }
                else
                {
                    i++;
                    j++;
                }
            }

            while (i < halmaz1.Length)
            {
                yKimenetiHalmaz[darab] = halmaz1[i];
                darab++;
                i++;
            }

            while (j < halmaz2.Length)
            {
                yKimenetiHalmaz[darab] = halmaz2[j];
                darab++;
                j++;
            }

            return (yKimenetiHalmaz, darab);
        }
    }
}
