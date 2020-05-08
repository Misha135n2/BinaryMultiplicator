using System;

namespace BinaryMultiplicator
{
    public sealed class MultiplicationMethodMI : IMultiplicationMethod
    {
        private MultiplicationMethodMI() {}
        public static MultiplicationMethodMI Singleton { get; } = new MultiplicationMethodMI();
        public void Calculate(string a, string b)
        {
            string bsrc = b;
            {
                string buf = "";
                for (int i = 0; i < b.Length; i++)
                    buf += '0';
                char flr = b[0] == '0' ? '0' : '1';
                b = $"{flr}{b}{buf}";
            }

            string spp = "";
            {
                for (int i = 0; i < b.Length; i++)
                    spp += '0';
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"0|a:{a}|b:{bsrc}|spp:{spp[0]}.{spp.Substring(1, spp.Length - 1)}|input");
            Console.WriteLine("----------------------");

            bool needCorrection = a[0] == '1';
            bool sppFill1 = b[0] == '1';

            for (int i = 0; i < a.Length; i++)
            {
                bool add = a[a.Length - 1] == '1';
                    
                if (add)
                    spp = Binary.BitwiseAdd(spp, b);

                spp = Binary.MoveBitwiseRight(spp, sppFill1);

                string s = add ? "+b/2;" : "";
                bool isEnd = i == (a.Length - 1);
                string e = "move a, spp;";
                if (isEnd && !needCorrection)
                    e += "result;";

                Console.WriteLine($"{i + 1}|a:{a}|b:{bsrc}|spp:{spp[0]}.{spp.Substring(1, spp.Length - 1)}|{s}{e}");
                if (isEnd)
                {
                    if (needCorrection)
                    {
                        Console.WriteLine("----------------------");
                        spp = Binary.BitwiseAdd(spp, Binary.InvertSign(b));
                        Console.WriteLine($"c|a:{a}|b:{bsrc}|spp:{spp[0]}.{spp.Substring(1, spp.Length - 1)}|correction -b/2;result;");
                    }
                }
                a = Binary.MoveBitwiseRight(a, false);
            }
        }
    }
}