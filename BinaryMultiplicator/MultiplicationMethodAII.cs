using System;

namespace BinaryMultiplicator
{
    public sealed class MultiplicationMethodAII : IMultiplicationMethod
    {
        private MultiplicationMethodAII() {}
        public static MultiplicationMethodAII Singleton { get; } = new MultiplicationMethodAII();

        public void Calculate(string a, string b)
        {
            a += '0';
            {
                string buf = "";
                char flr = b[0];
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
            Console.WriteLine($"0|a:{a.Substring(0, a.Length - 1)}.{a.Substring(a.Length - 1, 1)}|b:{b}|spp:{spp}|input");
            Console.WriteLine("----------------------");

            for (int i = 0; i < a.Length - 1; i++)
            {
                bool higher = a[a.Length - 2] == '1';
                bool lesser = a[a.Length - 1] == '1';

                string op = "";

                // 01
                if (!higher && lesser)
                {
                    spp = Binary.BitwiseAdd(spp, b);
                    op = "+b;";
                }
                // 10
                if (higher && !lesser)
                {
                    spp = Binary.BitwiseAdd(spp, Binary.InvertSign(b));
                    op = "-b;";
                }
                
                string cycle = i == a.Length - 2 ? "result;" : "move a, b;";
                    
                b = Binary.MoveBitwiseLeft(b, false);
                Console.WriteLine($"{i + 1}|a:{a.Substring(0, a.Length - 1)}.{a.Substring(a.Length - 1, 1)}|b:{b}|spp:{spp}|{op}{cycle}");
                a = Binary.MoveBitwiseRight(a, false);
            }
        }
    }
}