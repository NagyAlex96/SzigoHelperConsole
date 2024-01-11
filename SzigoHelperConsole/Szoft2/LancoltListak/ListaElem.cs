using System;
using System.Collections.Generic;

namespace SzigoHelperConsole.LancoltListak
{
    public class ListaElem<TTartalom, TKulcs> 
        where TKulcs : IComparable 
        where TTartalom : class, IComparable, IEqualityComparer<TTartalom>
    {
        public TTartalom Tartalom { get; set; }

        public TKulcs Kulcs { get; set; }

        public ListaElem<TTartalom, TKulcs> Kovetkezo { get; set; }
    }
}
