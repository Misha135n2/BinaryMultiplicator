using System;

namespace BinaryMultiplicator
{
    public sealed class MultiplicationMethodMII : IMultiplicationMethod
    {
        private MultiplicationMethodMII() {}
        public static MultiplicationMethodMII Singleton { get; } = new MultiplicationMethodMII();
        public void Calculate(string a, string b)
        {
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
            Console.WriteLine($"0|a:{a}|b:{b}|spp:{spp}|input");
            Console.WriteLine("----------------------");

            bool needCorrection = a[0] == '1';

            for (int i = 0; i < a.Length; i++)
            {
                bool add = a[a.Length - 1] == '1';

                if (add)
                    spp = Binary.BitwiseAdd(spp, b);

                b = Binary.MoveBitwiseLeft(b, false);
                    

                string s = add ? "+b;" : "";
                bool isEnd = i == (a.Length - 1);
                string e = isEnd ? "" : "move a, b;";
                Console.WriteLine($"{i + 1}|a:{a}|b:{b}|spp:{spp}|{s}{e}");
                if (isEnd)
                {
                    if (needCorrection)
                    {
                        Console.WriteLine("----------------------");
                        spp = Binary.BitwiseAdd(spp, Binary.InvertSign(b));
                        Console.WriteLine($"c|a:{a}|b:{b}|spp:{spp}|correction -b;result;");
                    }
                    Console.WriteLine("----------------------");
                }
                a = Binary.MoveBitwiseRight(a, false);
            }
        }
    }
}