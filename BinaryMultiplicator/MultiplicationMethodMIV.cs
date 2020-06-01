using System;

namespace BinaryMultiplicator
{
    public sealed class MultiplicationMethodMIV : IMultiplicationMethod
    {
        private MultiplicationMethodMIV() {}
        public static MultiplicationMethodMIV Singleton { get; } = new MultiplicationMethodMIV();
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
                

            if (a[0] == '1')
            {
                Console.WriteLine("----------------------");
                spp = Binary.Add(spp, Binary.InvertSign(b));
                Console.WriteLine($"c|a:{a}|b:{b}|spp:{spp}|correction -b;");
            }

            Console.WriteLine("----------------------");

            bool bFill1 = b[0] == '1';

            for (int i = 0; i < a.Length; i++)
            {
                bool add = a[0] == '1';
                b = Binary.MoveBitwiseRight(b, bFill1);
                    
                if (add)
                    spp = Binary.Add(spp, b);

                string s = add ? "+b;" : "";
                string e = "move a, b;";
                if (i == (a.Length - 1))
                {
                    Console.WriteLine("----------------------");
                    e += "result;";
                }
                Console.WriteLine($"{i + 1}|a:{a}|b:{b}|spp:{spp}|{s}{e}");
                a = Binary.MoveBitwiseLeft(a, false);
            }
        }
    }
}