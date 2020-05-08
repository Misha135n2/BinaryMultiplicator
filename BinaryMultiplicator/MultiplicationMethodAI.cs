using System;

namespace BinaryMultiplicator
{
    public sealed class MultiplicationMethodAI : IMultiplicationMethod
    {
        private MultiplicationMethodAI() {}
        public static MultiplicationMethodAI Singleton { get; } = new MultiplicationMethodAI();
        public void Calculate(string a, string b)
        {
            string bsrc = b;
            a += '0';
            string nb = Binary.InvertSign(b);
            {
                string buf = "";
                for (int i = 0; i < b.Length - 1; i++)
                    buf += '0';
                b = $"{b[0]}{b}{buf}";
                nb = $"{nb[0]}{nb}{buf}";
            }
                

            string spp = "";
            {
                for (int i = 0; i < b.Length; i++)
                    spp += '0';
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"0|a:{a.Substring(0, a.Length - 1)}.{a.Substring(a.Length - 1, 1)}|b:{bsrc}|spp:{spp}|input");
            Console.WriteLine("----------------------");

            for (int i = 0; i < a.Length - 1; i++)
            {
                bool higher = a[a.Length - 2] == '1';
                bool lesser = a[a.Length - 1] == '1';

                string op = "";

                spp = Binary.MoveBitwiseRight(spp, spp[0] == '1');

                // 01
                if (!higher && lesser)
                {
                    spp = Binary.BitwiseAdd(spp, b);
                    op = "+b/2;";
                }
                // 10
                if (higher && !lesser)
                {
                    spp = Binary.BitwiseAdd(spp, nb);
                    op = "-b/2;";
                }

                string cycle = i == a.Length - 2 ? "result;" : "move a, spp;";
                    
                Console.WriteLine($"{i + 1}|a:{a.Substring(0, a.Length - 1)}.{a.Substring(a.Length - 1, 1)}|b:{bsrc}|spp:{spp}|{op}{cycle}");
                a = Binary.MoveBitwiseRight(a, false);
            }
        }
    }
}