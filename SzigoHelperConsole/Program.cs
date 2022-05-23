using System;

namespace SzigoHelperConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Segítség a Turple-höz és a lambdához
            //int[] tomb = { 1, 2, 3, 4, 9, 8, 7, 6, 5, 10 };

            //bool van = false;
            //int? index = null;

            //(van, index) = EgyszeruProgTetelek.LinearisKeresesTetel(tomb, labda => tomb[labda] % 9 == 0); //fontos az igaz állítás, mivel a feltétel !P(x[i]) 
            //Console.WriteLine($"Van ilyen elem: {van}\nKeresett eleme indexe: {index}");

            #endregion


            int[] tomb = { 1, 2, 3, 4, 9, 8, 7, 6, 5, 10 };

            var a = EgyszeruProgTetelek.MaximumKivalasztas(tomb);


            Console.WriteLine(a);



            Console.ReadKey();
        }
    }
}
