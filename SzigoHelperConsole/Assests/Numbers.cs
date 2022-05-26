using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole.Assests
{
    public class Numbers : IComparable
    {
        public int Number { get; set; }

        public override string ToString()
        {
            return $"Numbers class: {this.Number}";
        }

        public int CompareTo(object obj)
        {
            return Number.CompareTo((obj as Numbers).Number);
        }
    }
}
