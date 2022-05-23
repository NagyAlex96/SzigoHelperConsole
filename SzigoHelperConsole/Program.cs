using System;

namespace SzigoHelperConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Segítség a Turple-höz és a lambdához
            int[] tomb = { 1, 2, 3, 4, 9, 8, 7, 6, 5, 10 };

            bool van = false;
            int? index = null;

            (van, index) = EgyszeruProgTetelek.LinearisKeresesTetel(tomb, labda => tomb[labda] % 9 == 0); //fontos az igaz állítás, mivel a feltétel !P(x[i]) 
            Console.WriteLine($"Van ilyen elem: {van}\nKeresett eleme indexe: {index}");

            #endregion


            int[] tombA = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] tombB = { 1, 2, 8, 9, 10, 11, 12 };





            ;

            Console.ReadKey();
        }
    }
}
