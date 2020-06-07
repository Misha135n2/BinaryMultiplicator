using System;
using System.Collections.Generic;

namespace BinaryMultiplicator
{
    public class MultiplicationMethodI : IMultiplicationMethod
    {
        public readonly int Word;

        private readonly Table _table;

        public MultiplicationMethodI(int word)
        {
            Word = word;
            _table = new Table(word);
        }

        public void Calculate(string a, string b)
        {
            a = Binary.AlignFor(a, Word);
            b = Binary.AlignFor(b, Word);

            //int align = (int) Math.Pow(2, Word - 1); // max koef
            //int extend = (int) Math.Pow(2, Word - 1); //(_table.Max - 1) + ((_table.Max - 1) % Word);

            int extend = _table.N - 1;
            {
                int d = extend % Word;
                extend = d > 0 ? extend + (Word - extend) : extend;
            }

            string asrc = a;
            a = $"{a}0";

            string bsrc = b;
            {
                string postfix = "";
                foreach (var ch in bsrc)
                    postfix += '0';
                
                string prefix = "";
                char flr = b[0];
                //for (int i = 0; i < align; i++)
                for (int i = 0; i < extend; i++)
                    prefix += flr;

                b = $"{prefix}{b}{postfix}";
            }

            BinaryWord aa = new BinaryWord(a);
            BinaryWord bb = new BinaryWord(b);
            Dictionary<string, BinaryWord> bDics = _table.Generate(bb);
            
            BinaryWord spp = new BinaryWord(bb.Value.Length);

            string aPattern = "";
            for (int i = 0; i < asrc.Length; i++)
                aPattern += '*';
            aPattern += ".*";

            string bPattern = "";

            //for (int i = 0; i < align; i++)
            //    bPattern += '*';
            //if (align > 0) 
            //    bPattern += '.';

            if (extend > 0)
            {
                for (int i = 0; i < extend; i++)
                    bPattern += '*';
                bPattern += '.';
            }

            for (int i = 0; i < bsrc.Length; i++)
                bPattern += '*';
            bPattern += '.';
            for (int i = 0; i < bsrc.Length; i++)
                bPattern += '*';
            
            Console.WriteLine("----------------------");
            Console.WriteLine($"0|a:{Binary.Pattern(aa.Value, aPattern)}|b:{Binary.Pattern(bb.Value, bPattern)}|spp:{Binary.Pattern(spp.Value, bPattern)}|input");
            Console.WriteLine("----------------------");

            for (int i = 0; i < (aa.Value.Length - 1) / Word; i++)
            {
                string key = aa.Value.Substring(aa.Value.Length - (Word + 1), (Word + 1));
                
                spp = spp.Add(bDics[key]);
                string op;
                {
                    int m = _table.Contibution[key];
                    op = m == 0 ? "" : $"{m}b; ";
                }

                Console.WriteLine($"{i + 1}|a:{Binary.Pattern(aa.Value, aPattern)}|b:{Binary.Pattern(bb.Value, bPattern)}|spp:{Binary.Pattern(spp.Value, bPattern)}|{op}move a, spp;");

                aa.MoveRight(Word, false);
                spp.MoveRight(Word);
            }

            Console.WriteLine($"r|a:{Binary.Pattern(aa.Value, aPattern)}|b:{Binary.Pattern(bb.Value, bPattern)}|spp:{Binary.Pattern(spp.Value, bPattern)}|result;");
        }
    }
}