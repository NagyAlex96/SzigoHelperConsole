using System;
using System.Collections.Generic;
using SzigoHelperConsole.BinarisFak;
using SzigoHelperConsole.LancoltListak;

namespace SzigoHelperConsole
{
    public class Program
    {
        public static List<Student> students = new List<Student>()
        {
            new Student()
                {
                    Name = "Trab Antal",
                    Age = 23,
                    Neptun = "OE3NIK"
                },

            new Student()
                {
                    Name = "Cserepes Virág",
                    Age = 18,
                    Neptun = "OE8NIK"
                },

            new Student()
                {
                    Name = "Major Anna",
                    Age = 22,
                    Neptun = "OE2NIK"
                },

            new Student()
                {
                    Name = "Kasza Blanka",
                    Age = 19,
                    Neptun = "OE9NIK"
                },

            new Student()
                {
                    Name = "Koaxk Ábel",
                    Age = 24,
                    Neptun = "OE4NIK"
                },

            new Student()
                {
                    Name = "Cicz Imre",
                    Age = 20,
                    Neptun = "OE0NIK"
                }

        };

        static void Main(string[] args)
        {
            //Minta1();
            //Minta2();
            //Minta3();
            //Minta4();
            Minta5();

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

        /// <summary>
        /// Minta lambdára, Turple-re, Hanoi-ra
        /// </summary>
        static void Minta1()
        {
            int[] tombA = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //páros számok a tömb elejére
            OsszetettProgTetelek.SzetvalogatasHelybenCsereNelkul(ref tombA, lambda => tombA[lambda] % 2 == 0);

            Rekurzio.Hanoi(4, "A", "C", "B");
        }

        /// <summary>
        /// Minta visszalépéses keresésre (alapeset)
        /// </summary>
        static void Minta2()
        {
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

        /// <summary>
        /// Minta egyszerű láncolt listára
        /// </summary>
        static void Minta3()
        {
            EgyszeruLancoltLista<Student> lancoltLista = new EgyszeruLancoltLista<Student>();

            foreach (var item in students)
            {
                lancoltLista.BeszurasUtolsoElemMoge(item);
            }


            var a = lancoltLista.Kereses(lambad => lambad.Name == "Koaxk Ábel");
            Console.WriteLine("\nKeresés eredménye: " + "\n" + a);


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nTörlés előtt: ");
            Console.ResetColor();
            lancoltLista.Bejaras();


            lancoltLista.Torles(students[new Random().Next(1, 6 + 1)]);


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nTörlés után: ");
            Console.ResetColor();
            lancoltLista.Bejaras();
        }

        /// <summary>
        /// Minta rendezett láncolt listára
        /// </summary>
        static void Minta4()
        {
            RendezettLancoltListak<Student> lancoltLista = new RendezettLancoltListak<Student>();

            for (int i = 0; i < students.Count; i++)
            {
                lancoltLista.BeszurasRovidebbValtozat(students[i].Name, students[i]);
            }

            var a = lancoltLista.Kereses("Koaxk Ábel");

            Console.WriteLine(a);
        }

        /// <summary>
        /// Minta bináris kereső fák
        /// </summary>
        static void Minta5()
        {

            BinarisFa<Student> binarisFa = new BinarisFa<Student>();

            foreach (var item in students)
            {
                binarisFa.Beszuras(item.Name, item);
            }

            binarisFa.PreOrderBejaras();

            binarisFa.Torles("Cserepes Virág"); //van szülője + jobb -és bal gyereke is

            binarisFa.PreOrderBejaras();

           
        }
    }
}
