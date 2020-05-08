using System;

namespace BinaryMultiplicator
{
    public sealed class MultiplicationMethodAIII : IMultiplicationMethod
    {
        private MultiplicationMethodAIII() {}
        public static MultiplicationMethodAIII Singleton { get; } = new MultiplicationMethodAIII();

        public void Calculate(string a, string b)
        {
            string bsrc = b;
            
            {
                string buf = "";
                char flr = b[0];
                for (int i = 0; i < b.Length; i++)
                    buf += flr;
                b = $"{buf}{b}";
            }
            string nb = Binary.InvertSign(b);
                
            string spp = "";
            {
                for (int i = 0; i < b.Length; i++)
                    spp += '0';
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"0|a:{a}|b:{bsrc}|spp:{spp}|input");
            Console.WriteLine("----------------------");

            for (int i = 0; i < a.Length; i++)
            {
                bool higher = a[0] == '1';
                bool lesser = a[1] == '1';

                string op = "";

                spp = Binary.MoveBitwiseLeft(spp, false);

                // 01
                if (!higher && lesser)
                {
                    spp = Binary.BitwiseAdd(spp, b);
                    op = "+b;";
                }
                // 10
                if (higher && !lesser)
                {
                    spp = Binary.BitwiseAdd(spp, nb);
                    op = "-b;";
                }

                string cycle = i == a.Length - 1 ? "result;" : "move a, b;";
                    
                Console.WriteLine($"{i + 1}|a:{a}|b:{bsrc}|spp:{spp}|{op}{cycle}");
                a = Binary.MoveBitwiseLeft(a, false);
            }
        }
    }
}