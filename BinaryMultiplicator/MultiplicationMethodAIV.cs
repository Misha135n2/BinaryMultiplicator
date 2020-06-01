using System;

namespace BinaryMultiplicator
{
    public sealed class MultiplicationMethodAIV : IMultiplicationMethod
    {
        private MultiplicationMethodAIV() {}
        public static MultiplicationMethodAIV Singleton { get; } = new MultiplicationMethodAIV();

        public void Calculate(string a, string b)
        {
            {
                string buf = "";
                for (int i = 0; i < b.Length; i++)
                    buf += '0';
                b = $"{b}{buf}";
            }

            string spp = "";
            {
                for (int i = 0; i < b.Length; i++)
                    spp += '0';
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"0|a:{a}|b:{b}|spp:{spp}|input");
            Console.WriteLine("----------------------");

            for (int i = 0; i < a.Length; i++)
            {
                bool higher = a[0] == '1';
                bool lesser = a[1] == '1';

                string op = "";

                b = Binary.MoveBitwiseRight(b, b[0] == '1');

                // 01
                if (!higher && lesser)
                {
                    spp = Binary.Add(spp, b);
                    op = "+b;";
                }
                // 10
                if (higher && !lesser)
                {
                    spp = Binary.Add(spp, Binary.InvertSign(b));
                    op = "-b;";
                }

                string cycle = i == a.Length - 1 ? "result;" : "move a, b;";
               
                Console.WriteLine($"{i + 1}|a:{a}|b:{b}|spp:{spp}|{op}{cycle}");
                a = Binary.MoveBitwiseLeft(a, false);
            }
        }
    }
}