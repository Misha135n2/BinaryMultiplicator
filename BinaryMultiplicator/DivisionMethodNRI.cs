using System;

namespace BinaryMultiplicator
{
    public class DivisionMethodNRI : IDivisionMethod
    {
        public static readonly DivisionMethodNRI Singleton = new DivisionMethodNRI();
        private DivisionMethodNRI() {}

        public void Divide(string l, string d)
        {
            int n = l.Length;

            char ls = l[0];
            char ds = d[0];

            while (d.Length < n)
                d = $"{d[0]}{d}";
            d = $"{d[0]}{d}";

            string dPattern = "*,";
            for (int i = 0; i < n; i++)
                dPattern += '*';

            for (int i = 0; i < n + 1; i++)
                l = $"{l[0]}{l}";

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

            BinaryWord identity = new BinaryWord(Binary.GetOneFor(qq.Value.Length));
            BinaryWord zero = new BinaryWord(l.Length);

            Console.WriteLine("----------------------");
            Console.WriteLine($"0|q:{qq.Value}|l:{ll.Pattern(lPattern)}|d:{Binary.Pattern(d, dPattern)}|input");
            Console.WriteLine("----------------------");

            for (int i = 0; i < n; i++)
            {
                qq.MoveLeft();
                ll.MoveLeft();
                
                bool sameSigns = ll.Value[0] == dd.Value[0];

                ll = ll.Add(sameSigns ? ndd : dd);
                qq.Value = qq.Value.Substring(0, qq.Value.Length - 1) + (ll.Value[0] == '1' ? '1' : '0');
                string op = $"{(sameSigns ? "ss => [l -= d]" : "ds => [l += d]")}; l{i + 1} {(ll.Value[0] == '1' ? '<' : '>')} 0 =>  [q0 <= {ll.Value[0]}];";

                Console.WriteLine($"{i + 1}|q:{qq.Value}|l:{ll.Pattern(lPattern)}|d:{dd.Pattern(dPattern)}|move q, l; {op}");
            }

            string qop = "";
            string llop = "";

            char lls = ll.Value[0];
            if (ls == '0')
            {
                if (ds == '1')
                {
                    qq = qq.Add(identity);
                    qop = "q += 1; ";
                    if (lls == '1')
                    {
                        ll = ll.Add(ndd);
                        llop = "ll -= d; ";
                    }
                }
                else if (lls == '1')
                {
                    ll = ll.Add(dd);
                    llop = "ll += d; ";
                }
            }
            else
            {
                if (ds == '1')
                {
                    bool cll = Binary.Equality(ll.Value, zero.Value) || Binary.Equality(ll.Value, dd.Value);
                    if (cll)
                    {
                        qq = qq.Add(identity);
                        qop = "q += 1; ";
                        ll.Value = zero.Value;
                        llop = "ll = 0; ";
                    }
                    else if (ll.Value[0] != '1')
                    {
                        ll = ll.Add(dd);
                        llop = "ll += d; ";
                    }
                }
                else
                {
                    bool cll = Binary.Equality(ll.Value, zero.Value) || Binary.Equality(ll.Value, ndd.Value);
                    if (cll)
                    {
                        ll.Value = zero.Value;
                        llop = "ll = 0; ";
                    }
                    else
                    {
                        qq = qq.Add(identity);
                        qop = "q += 1; ";
                        if (ll.Value[0] != '1')
                        {
                            ll = ll.Add(ndd);
                            llop = "ll -= d; ";
                        }
                    }
                }
            }

            Console.WriteLine($"r|q:{qq.Value}|l:{ll.Pattern(lPattern)}|d:{dd.Pattern(dPattern)}|{qop}{llop}result;");
        }
    }
}