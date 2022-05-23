using System;

namespace SzigoHelperConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] tomb = { 1, 2, 3, 4, 9, 8, 7, 6, 5 };

            bool van = false;
            int? index = null;
            (van, index) = EgyszeruProgTetelek.LinearisKeresesTetel(tomb, x => tomb[x] % 7 != 0);

            Console.WriteLine($"Van ilyen elem: {van}\n Keresett eleme indexe: {index}");









            Console.ReadKey();
        }
    }
}
