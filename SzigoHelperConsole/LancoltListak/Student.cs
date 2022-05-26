using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole.LancoltListak
{
    //Tetszőleges class lehet, ami megvalósítja a IComparable-t, és a ToString-et override-olja
    public class Student : IComparable
    {
        public string Neptun { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"\nNév: {Name}\nNeptunkód: {Neptun}\nÉletkora: {Age}";
        }

        public int CompareTo(object obj)
        {
            return Name.CompareTo((obj as Student).Neptun);
        }

        //saját magunk is kitalálhatunk egy logikát
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Neptun.GetHashCode();
        }

        //listából való törlésnél fontos
        public override bool Equals(object obj)
        {
            return GetHashCode() == (obj as Student).GetHashCode();
        }
    }
}
