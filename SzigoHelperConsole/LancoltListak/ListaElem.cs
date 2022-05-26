using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigoHelperConsole.LancoltListak
{
    public class ListaElem<T> where T : class, IComparable
    {
        public T Tartalom { get; set; }
        public T Kulcs { get; set; }
        public ListaElem<T> Kovetkezo { get; set; }
    }
}
