using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod2xII : IMultiplicationMethod
    {
        private MultiplicationMethod2xII() {}
        public static MultiplicationMethod2xII Singleton { get; } = new MultiplicationMethod2xII();

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

            {
                string buf = "";
                for (int i = 0; i < bsrc.Length + 2; i++)
                    buf += "0";
                b = $"{buf}{b}";
            }

            string spp = "";
            {
                for (int i = 0; i < b.Length; i++)
                    spp += '0';
            }

            bool p = false;

            Console.WriteLine("----------------------");
            Console.WriteLine($"0|a:{a.Substring(0, 2)}.{a.Substring(2, asrc.Length)}|.|b:{b.Substring(0, 2)}.{b.Substring(2, bsrc.Length)}.{b.Substring(2 + bsrc.Length, bsrc.Length)}|spp:{spp.Substring(0, 2)}.{spp.Substring(2, bsrc.Length)}.{spp.Substring(2 + bsrc.Length, bsrc.Length)}|input");
            Console.WriteLine("----------------------");
            
            for (int i = 0; i < a.Length - 1; i += 2)
            {
                string digit = a.Substring(a.Length - 2, 2);

                bool pp = p;
                string op = "";

                string nb = Binary.InvertSign(b);
                string b2 = Binary.MoveBitwiseLeft(b, false);

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
                string cycle = eoc ? "result;" : "move a, b;";
                    
                Console.WriteLine($"{i / 2 + 1}|a:{a.Substring(0, 2)}.{a.Substring(2, asrc.Length)}|{(pp ? "1" : "0")}|b:{b.Substring(0, 2)}.{b.Substring(2, bsrc.Length)}.{b.Substring(2 + bsrc.Length, bsrc.Length)}|spp:{spp.Substring(0, 2)}.{spp.Substring(2, bsrc.Length)}.{spp.Substring(2 + bsrc.Length, bsrc.Length)}|{op}{cycle}");
                
                a = Binary.MoveBitwiseRight(Binary.MoveBitwiseRight(a, false), false);
                b = Binary.MoveBitwiseLeft(Binary.MoveBitwiseLeft(b, false), false);
            }

        }
    }
}