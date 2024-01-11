using System;

namespace SzigoHelperConsole.BinarisFak
{
    public class TreeItem<TTartalom, TKulcs>
        where TKulcs : IComparable
        where TTartalom : class, IComparable
    {
        public TKulcs Kulcs { get; set; }

        public TTartalom Tartalom;

        public TreeItem<TTartalom, TKulcs> Left;

        public TreeItem<TTartalom, TKulcs> Right;

        public override string ToString()
        {
            return $"{this.Tartalom}";
        }
    }
}
