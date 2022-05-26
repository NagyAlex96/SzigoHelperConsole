using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole.BinarisFak
{
    public class TreeItem<T> where T : class, IComparable
    {
        public string Kulcs { get; set; }

        public T Tartalom;

        public TreeItem<T> Left;

        public TreeItem<T> Right;

        public override string ToString()
        {
            return $"{this.Tartalom}";
        }
    }
}
