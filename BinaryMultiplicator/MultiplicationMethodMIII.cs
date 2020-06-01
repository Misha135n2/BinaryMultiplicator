using System;

namespace BinaryMultiplicator
{
    public sealed class MultiplicationMethodMIII : IMultiplicationMethod
    {
        private MultiplicationMethodMIII() {}
        public static MultiplicationMethodMIII Singleton { get; } = new MultiplicationMethodMIII();
        public void Calculate(string a, string b)
        {
            string bsrc = b;
            {
                string buf = "";
                char flr = b[0] == '0' ? '0' : '1';
                for (int i = 0; i < b.Length; i++)
                    buf += flr;
                b = $"{buf}{b}";
            }

            string spp = "";
            {
                for (int i = 0; i < b.Length; i++)
                    spp += '0';
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"0|a:{a}|b:{bsrc}|spp:{spp}|input");

            if (a[0] == '1')
            {
                Console.WriteLine("----------------------");
                spp = Binary.Add(spp, Binary.InvertSign(b));
                Console.WriteLine($"c|a:{a}|b:{bsrc}|spp:{spp}|correction -b;");
            }

            Console.WriteLine("----------------------");

            //bool bFill1 = b[0] == '1';

            for (int i = 0; i < a.Length; i++)
            {
                bool add = a[0] == '1';

                spp = Binary.MoveBitwiseLeft(spp, false);

                if (add)
                    spp = Binary.Add(spp, b);

                string s = add ? "+b;" : "";
                string e = "move a, spp;";
                if (i == (a.Length - 1))
                {
                    Console.WriteLine("----------------------");
                    e = "result;";
                }
                Console.WriteLine($"{i + 1}|a:{a}|b:{bsrc}|spp:{spp}|{s}{e}");
                a = Binary.MoveBitwiseLeft(a, false);
            }
        }
    }
}