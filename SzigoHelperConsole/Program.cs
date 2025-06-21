using System;
using System.Collections.Generic;
using System.Linq;
using SzigoHelperConsole.Assests;
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

        public static Numbers[] numbers =
        {
            new Numbers()
            {
               Number = 50
            },

            new Numbers()
            {
               Number = 24
            },

            new Numbers()
            {
               Number = 64
            },

            new Numbers()
            {
               Number = 12
            },

            new Numbers()
            {
               Number = 31
            },

            new Numbers()
            {
               Number = 71
            },

            new Numbers()
            {
               Number = 58
            },
        };
        public static int[] VeletlenTomb;

        static void Main(string[] args)
        {
            //TODO: nem lett mindenre tesztelve
            //Minta2();
            Rekurzio.Hanoi(3, "A", "C", "B");

            Console.ReadKey();
        }

        /// <summary>
        /// Egy tömböt feltölt véletlenszerű számokkal
        /// </summary>
        /// <param name="tomb">Feltöltendő tömb</param>
        /// <param name="darabSzam">Véletlenszerű számok darabszáma</param>
        /// <param name="alsoHatar">Legkisebb véletlen szám</param>
        /// <param name="felsoHatar">Legnagyobb véletlen szám</param>
        /// <param name="ismetlodes"><c>True</c> amennyiben engedélyezett a számok ismétlődése</param>
        static void TombFeltoltRandom(ref int[] tomb, int darabSzam = 10, int alsoHatar = 1, int felsoHatar = 20, bool ismetlodes = true)
        {
            tomb = new int[darabSzam];
            int randomNum = 0;
            for (int i = 0; i < darabSzam; i++)
            {
                randomNum = RandomNumber(alsoHatar, felsoHatar);
                if (!ismetlodes)
                {
                    while (tomb.Contains(randomNum))
                    {
                        randomNum = RandomNumber(alsoHatar, felsoHatar);
                    }
                    tomb[i] = randomNum;
                    continue;
                }
                tomb[i] = randomNum;
            }
        }

        /// <summary>
        /// Tömb kiíratása
        /// </summary>
        /// <param name="tomb">Tömb, amit ki szeretnénk íratni</param>
        /// <param name="soronkent"><c>True</c> amennyiben soronként szeretnénk kiíratni</param>
        /// <param name="sorNum">Soronként hány elem legyen</param>
        /// <param name="separator">Két elem közötti elválasztókarakter</param>
        static void TombKiir(ref int[] tomb, bool soronkent = false, int sorNum = 0, string separator = ", ")
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                if (soronkent)
                {
                    if (sorNum != 0 && i % sorNum == 0)
                    {
                        Console.Write(tomb[i] + separator);
                    }
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine(tomb[i]);
            }
        }

        static int RandomNumber(int alsoHatar, int felsoHatar)
        {
            Random rand = new Random();
            return rand.Next(alsoHatar, felsoHatar + 1);
        }

        static void MintaEgyszeruProgTetelek()
        {
            TombFeltoltRandom(ref VeletlenTomb);

            EgyszeruProgTetelek.EldontesTetel(students.ToArray(), x => x.Neptun == "");
            EgyszeruProgTetelek.EldontesTetel(numbers, x => x.Number % 2 == 0);
            EgyszeruProgTetelek.EldontesTetel(VeletlenTomb, x => x % 3 == 0);

            EgyszeruProgTetelek.KivalasztasTetel(numbers, x => x.Number == 58);

            EgyszeruProgTetelek.LinearisKeresesTetel(students.ToArray(), x => x.Neptun == "OE8NIK");

            EgyszeruProgTetelek.MegszamlalasTetel(students.ToArray(), x => x.Age > 20);

            EgyszeruProgTetelek.MaximumKivalasztas(students.ToArray());
        }

        //        /// <summary>
        //        /// Minta lambdára, Turple-re, Hanoi-ra
        //        /// </summary>
        //        static void Minta1()
        //        {
        //            int[] tombA = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //            //páros számok a tömb elejére
        //            OsszetettProgTetelek.SzetvalogatasHelybenCsereNelkul(ref tombA, lambda => tombA[lambda] % 2 == 0);

        //            Rekurzio.Hanoi(4, "A", "C", "B");
        //        }

        /// <summary>
        /// Minta visszalépéses keresésre (alapeset)
        /// </summary>
        static void Minta2()
        {
            string[][] tombBackTrack =
{
                        new string[]{"Miklós", "Klaudia"},
                        new string[]{"Zsolt", "Miklós"},
                        new string[]{"András"},
                        new string[]{"András", "Pál", "Péter"},
                        new string[]{"András", "Géza"},
                        new string[]{"Géza", "Miklós"}
                    };

            bool ok = false;
            string[] kimenet = new string[tombBackTrack.Length];
            Optimalizalas.VisszaLepesesKereses<string>(0, tombBackTrack, kimenet, ref ok);
            ;
        }

        //        /// <summary>
        //        /// Minta egyszerű láncolt listára
        //        /// </summary>
        //        static void Minta3()
        //        {
        //            EgyszeruLancoltLista<Student> lancoltLista = new EgyszeruLancoltLista<Student>();

        //            foreach (var item in students)
        //            {
        //                lancoltLista.BeszurasUtolsoElemMoge(item);
        //            }


        //            var a = lancoltLista.Kereses(lambad => lambad.Name == "Koaxk Ábel");
        //            Console.WriteLine("\nKeresés eredménye: " + "\n" + a);


        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("\n\nTörlés előtt: ");
        //            Console.ResetColor();
        //            lancoltLista.Bejaras();


        //            lancoltLista.Torles(students[new Random().Next(1, 6 + 1)]);


        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("\n\nTörlés után: ");
        //            Console.ResetColor();
        //            lancoltLista.Bejaras();
        //        }

        //        /// <summary>
        //        /// Minta rendezett láncolt listára
        //        /// </summary>
        //        static void Minta4()
        //        {
        //            RendezettLancoltListak<Student> lancoltLista = new RendezettLancoltListak<Student>();

        //            for (int i = 0; i < students.Count; i++)
        //            {
        //                lancoltLista.BeszurasRovidebbValtozat(students[i].Name, students[i]);
        //            }

        //            var a = lancoltLista.Kereses("Koaxk Ábel");

        //            Console.WriteLine(a);
        //        }

        //        /// <summary>
        //        /// Minta bináris kereső fák
        //        /// </summary>
        //        static void Minta5()
        //        {

        //            BinarisFa<Student> binarisFa = new BinarisFa<Student>();

        //            foreach (var item in students)
        //            {
        //                binarisFa.Beszuras(item.Name, item);
        //            }

        //            binarisFa.PreOrderBejaras();

        //            binarisFa.Torles("Cserepes Virág"); //van szülője + jobb -és bal gyereke is

        //            binarisFa.PreOrderBejaras();


        //        }

        //        /// <summary>
        //        /// Bináris fa számokkal
        //        /// </summary>
        //        static void Minta6()
        //        {
        //            //A könyv (Algoritmusok, adatszerkezetek II.) 119.oldala alapján
        //            //változtatáshoz elég a listában új elemeket létrehoznod (sorrend nem számít)

        //            BinarisFa<Numbers> binarisFa = new BinarisFa<Numbers>();

        //            foreach (var item in numbers)
        //            {
        //                binarisFa.Beszuras(item.Number.ToString(), item);
        //            }

        //            binarisFa.PreOrderBejaras();
        //            ;
        //        }

        //        /// <summary>
        //        /// Gráfok
        //        /// </summary>
        //        static void Minta7()
        //        {
        //            Graf<int> graf = new GrafSzomszedsagiLista<int>();
        //            Graf<int> grafDijkstra = new GrafSzomszedsagiLista<int>();

        //            for (int i = 0; i < 7; i++)
        //            {
        //                graf.UjCsucs(i + 1);
        //                grafDijkstra.UjCsucs(i + 1);
        //            }


        //            //bejárásoknál nem mindegy, hogy milyen sorrendben vesszük fel az éleket (vagy valamit elírtam)
        //            #region 184 oldal ábra /Mélységi & szélességi bejárás
        //            graf.UjEl(1, 2);
        //            graf.UjEl(1, 4);
        //            graf.UjEl(1, 5);

        //            graf.UjEl(2, 3);

        //            graf.UjEl(3, 4);
        //            graf.UjEl(3, 6);

        //            graf.UjEl(4, 6);

        //            graf.UjEl(6, 7);
        //            #endregion

        //            #region 196 oldal ábrája /Dijkstra/
        //            grafDijkstra.UjEl(1, 2, 1);
        //            grafDijkstra.UjEl(1, 4, 2);
        //            grafDijkstra.UjEl(1, 5, 4);

        //            grafDijkstra.UjEl(2, 3, 9);
        //            grafDijkstra.UjEl(2, 4, 2);

        //            grafDijkstra.UjEl(3, 4, 5);
        //            grafDijkstra.UjEl(3, 6, 1);

        //            grafDijkstra.UjEl(4, 6, 3);

        //            grafDijkstra.UjEl(6, 7, 3);
        //            #endregion

        //            Console.WriteLine("Szélességi bejárás eredménye: ");
        //            graf.SzelessegiBejaras(2);

        //            Console.WriteLine("\nMélységi bejárás eredménye: ");
        //            graf.MelysegiBejaras(2);

        //            var (lista, osszSuly) = graf.Dijkstra(2, 6);

        //            Console.WriteLine("\nDijkstra sorrendben: ");
        //            foreach (var item in lista)
        //            {
        //                Console.WriteLine(item);
        //            }

        //            Console.WriteLine($"Összesúly: {osszSuly}");
        //            ;
        //        }
    }
}
