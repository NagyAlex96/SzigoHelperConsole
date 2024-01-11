using System;

namespace SzigoHelperConsole.BinarisFak
{
    public class BinarisFa<TTartalom, TKulcs>
        where TKulcs : IComparable
        where TTartalom : class, IComparable
    {
        TreeItem<TTartalom, TKulcs> root;

        public void PreOrderBejaras()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PreOrder bejárás: ");
            Console.ResetColor();
            PreOrderSeged(this.root);
        }
        private void PreOrderSeged(TreeItem<TTartalom, TKulcs> p)
        {
            if (p != null)
            {
                Console.WriteLine(p.Tartalom.ToString()); //feldolgoz
                PreOrderSeged(p.Left);
                PreOrderSeged(p.Right);
            }
        }

        public void InOrderBejaras()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("InOrder bejárás: ");
            Console.ResetColor();
            InOrderSeged(this.root);
        }
        private void InOrderSeged(TreeItem<TTartalom, TKulcs> p)
        {
            if (p != null)
            {
                InOrderSeged(p.Left);
                Console.WriteLine(p.Tartalom.ToString()); //feldolgoz
                InOrderSeged(p.Right);
            }
        }

        public void PostOrderBejaras()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PostOrder bejárás: ");
            Console.ResetColor();
            PostOrderSeged(this.root);
        }
        private void PostOrderSeged(TreeItem<TTartalom, TKulcs> p)
        {
            if (p != null)
            {
                PostOrderSeged(p.Left);
                PostOrderSeged(p.Right);
                Console.WriteLine(p.Tartalom.ToString()); //feldolgoz
            }
        }

        public TTartalom Kereses(TKulcs kulcs)
        {
            return KeresesSeged(ref this.root, kulcs);
        }
        private TTartalom KeresesSeged(ref TreeItem<TTartalom, TKulcs> p, TKulcs kulcs)
        {
            if (p != null)
            {
                if (p.Kulcs.CompareTo(kulcs) > 0)
                {
                    KeresesSeged(ref p.Left, kulcs);
                }
                else
                {
                    if (p.Kulcs.CompareTo(kulcs) < 0)
                    {
                        KeresesSeged(ref p.Right, kulcs);
                    }
                    else
                    {
                        return p.Tartalom;
                    }
                }
            }
            else
            {
                throw new Exception("Nincs ilyen kulcs");
            }

            return null;
        }

        public void Beszuras(TKulcs kulcs, TTartalom ertek)
        {
            BeszurasSeged(ref this.root, kulcs, ertek);
        }
        private void BeszurasSeged(ref TreeItem<TTartalom,TKulcs> p, TKulcs kulcs, TTartalom ertek)
        {
            if (p == null)
            {
                p = new TreeItem<TTartalom,TKulcs>();
                p.Kulcs = kulcs;
                p.Tartalom = ertek;
                p.Left = null;
                p.Right = null;
            }
            else
            {
                if (p.Kulcs.CompareTo(kulcs)>0)
                {
                    BeszurasSeged(ref p.Left, kulcs, ertek);
                }
                else
                {
                    if (p.Kulcs.CompareTo(kulcs) < 0)
                    {

                        BeszurasSeged(ref p.Right, kulcs, ertek);
                    }
                    else
                    {
                        throw new Exception("Van már ilyen kulcs");
                    }
                }
            }

        }

        public void Torles(TKulcs kulcs)
        {
            TorlesSeged(ref this.root, kulcs);
        }
        private void TorlesSeged(ref TreeItem<TTartalom, TKulcs> p, TKulcs kulcs)
        {
            if (p != null)
            {
                if (p.Kulcs.CompareTo(kulcs) > 0)
                {
                    TorlesSeged(ref p.Left, kulcs);
                }
                else
                {
                    if (p.Left == null)
                    {
                        var q = p;
                        p = p.Right;
                        //felszabadít
                    }
                    else
                    {
                        if (p.Right == null)
                        {
                            var q = p;
                            p = p.Left;
                            //felszabadít
                        }
                        else
                        {
                            TorlesKetGyerek(p, ref p.Left);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Nincs ilyen kulcs");
            }
        }
        private void TorlesKetGyerek(TreeItem<TTartalom, TKulcs> e, ref TreeItem<TTartalom, TKulcs> r)
        {
            if (r.Right != null)
            {
                TorlesKetGyerek(e, ref r.Right);
            }
            else
            {
                e.Tartalom = r.Tartalom;
                e.Kulcs = r.Kulcs;
                var q = r;
                r = r.Left;
                //felszabadit
            }
        }
    }
}
