using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod2xI : IMultiplicationMethod
    {
        private MultiplicationMethod2xI() {}
        public static MultiplicationMethod2xI Singleton { get; } = new MultiplicationMethod2xI();

        public void Calculate(string a, string b)
        {
            if (a.Length % 2 != 0)
            {
                Console.WriteLine("The alignment must be multiple of 2.");
                return;
            }

            string bsrc = b;
            string asrc = a;
            a = $"00{a}";

            b = $"00{b}";
            string nb = Binary.InvertSign(b);
            string b2 = Binary.MoveBitwiseLeft(b, false);
            {
                for (int i = 0; i < bsrc.Length; i++)
                {
                    b += "0";
                    nb += "0";
                    b2 += "0";
                }
            }

            string spp = "";
            {
                for (int i = 0; i < b.Length; i++)
                    spp += '0';
            }

            bool p = false;

            Console.WriteLine("----------------------");
            Console.WriteLine($"0|a:{a.Substring(0, 2)}.{a.Substring(2, asrc.Length)}|.|b:{bsrc}|spp:{spp.Substring(0, 2)}.{spp.Substring(2, bsrc.Length)}.{spp.Substring(2 + bsrc.Length, bsrc.Length)}|input");
            Console.WriteLine("----------------------");
            
            for (int i = 0; i < a.Length - 1; i += 2)
            {
                string digit = a.Substring(a.Length - 2, 2);

                bool pp = p;
                string op = "";
                switch (digit)
                {
                    case ("00"):
                    {
                        if (p)
                        {
                            spp = Binary.Add(spp, b);
                            op = "+b; p:0; ";
                        }
                        p = false;
                        break;
                    }

                    case ("01"):
                    {
                        op = $"{(p ? "+2b" : "+b")}; p:0; ";
                        spp = Binary.Add(spp, p ? b2 : b);
                        p = false;
                        break;
                    }

                    case ("10"):
                    {
                        op = $"{(p ? "-b" : "+2b")}; p:{(p ? "1" : "0")}; ";
                        spp = Binary.Add(spp, p ? nb : b2);
                        break;
                    }

                    case ("11"):
                    {
                        if (!p)
                        {
                            op = "-b; p:1; ";
                            spp = Binary.Add(spp, nb);
                        }
                        p = true;
                        break;
                    }
                }

                bool eoc = i == a.Length - 2;
                string cycle = eoc ? "result;" : "move a, spp;";
                    
                Console.WriteLine($"{i / 2 + 1}|a:{a.Substring(0, 2)}.{a.Substring(2, asrc.Length)}|{(pp ? "1" : "0")}|b:{bsrc}|spp:{spp.Substring(0, 2)}.{spp.Substring(2, bsrc.Length)}.{spp.Substring(2 + bsrc.Length, bsrc.Length)}|{op}{cycle}");
                
                a = Binary.MoveBitwiseRight(Binary.MoveBitwiseRight(a, false), false);
                spp = Binary.MoveBitwiseRight(Binary.MoveBitwiseRight(spp, spp[0] == '1'), spp[0] == '1');
            }

        }
    }
}