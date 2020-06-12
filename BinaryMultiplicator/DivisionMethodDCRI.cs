using System;

namespace BinaryMultiplicator
{
    public class DivisionMethodDCRI : IDivisionMethod
    {
        public static readonly DivisionMethodDCRI Singleton = new DivisionMethodDCRI();
        private DivisionMethodDCRI() {}

        public void Divide(string l, string d)
        {
            int n = l.Length;
            

            while (d.Length < n)
                d = $"0{d}";
            d = $"0{d}";

            string dPattern = "*,";
            for (int i = 0; i < n; i++)
                dPattern += '*';

            for (int i = 0; i < n + 1; i++)
                l = $"0{l}";

            string lPattern = "*,";
            for (int i = 0; i < n; i++)
                lPattern += '*';
            lPattern += ' ';
            for (int i = 0; i < n; i++)
                lPattern += '*';

            BinaryWord qq = new BinaryWord(n);
            BinaryWord ll = new BinaryWord(l);
            BinaryWord dd;
            BinaryWord ndd;
            {
                string db = d;
                string ndb = Binary.InvertSign(db);
                while (db.Length < l.Length)
                {
                    db += '0';
                    ndb += '0';
                }
                dd = new BinaryWord(db);
                ndd = new BinaryWord(ndb);
            }
            

            Console.WriteLine("----------------------");
            Console.WriteLine($"0|q:{qq.Value}|l:{ll.Pattern(lPattern)}|d:{Binary.Pattern(d, dPattern)}|input");
            Console.WriteLine("----------------------");

            for (int i = 0; i < n; i++)
            {
                qq.MoveLeft(1, false);
                ll.MoveLeft(1, false);
                
                string op = $"l{i + 1} >= 0;";
                ll = ll.Add(ndd);
                char qd = '1';
                if (ll.Value[0] == '1')
                {
                    ll = ll.Add(dd);
                    op = $"l{i + 1} < 0 => restore;";
                    qd = '0';
                }
                qq.Value = qq.Value.Substring(0, qq.Value.Length - 1) + qd;

                Console.WriteLine($"{i + 1}|q:{qq.Value}|l:{ll.Pattern(lPattern)}|d:{dd.Pattern(dPattern)}|move q, l; {op}");
            }
        }
    }
}
