using System;
using System.Collections.Generic;

namespace SzigoHelperConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Mintak();


            
            Console.ReadKey();
        }

        /// <summary>
        /// Egy tömböt feltölt véletlenszerű számokkal
        /// </summary>
        /// <param name="tomb">Feltöltendő tömb</param>
        /// <param name="darabSzam">Véletlenszerű számok darabszáma</param>
        /// <param name="alsoHatar">Legkisebb véletlen szám</param>
        /// <param name="felsoHatar">Legnagyobb véletlen szám</param>
        static void TombFeltoltRandom(ref int[] tomb, int darabSzam, int alsoHatar, int felsoHatar)
        {
            tomb = new int[darabSzam];
            Random rand = new Random();
            for (int i = 0; i < darabSzam; i++)
            {
                tomb[i] = rand.Next(alsoHatar, felsoHatar + 1);
            }
        }

        static void Mintak()
        {
            int[] tombA = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //páros számok a tömb elejére
            OsszetettProgTetelek.SzetvalogatasHelybenCsereNelkul(ref tombA, lambda => tombA[lambda] % 2 == 0);


            string[][] tombBackTrack =
            {
                new string[]{"Miklós", "Klaudia"},
                new string[]{"Miklós", "András"},
                new string[]{"András", "Zsolt"},
                new string[]{"Géza", "Zsolt", "Palika"},
                new string[]{"Géza", "András"},
                new string[]{"Miklós", "Géza"}
            };

            bool ok = false;
            string[] kimenet = new string[tombBackTrack.Length];
            Optimalizalas.VisszaLepesesKereses<string>(0, tombBackTrack, kimenet, ref ok);
        }
    }
}
