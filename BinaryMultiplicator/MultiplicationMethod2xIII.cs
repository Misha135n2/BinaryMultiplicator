using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod2xIII : IMultiplicationMethod
    {
        private MultiplicationMethod2xIII() {}
        public static MultiplicationMethod2xIII Singleton { get; } = new MultiplicationMethod2xIII();

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

            b = $"{b}";

            {
                string buf = "00";
                for (int i = 0; i < bsrc.Length; i++)
                    buf += "0";
                b = $"{buf}{b}";
            }

            string nb = Binary.InvertSign(b);
            string b2 = Binary.MoveBitwiseLeft(b, false);
            string nb2 = Binary.InvertSign(b2);

            string spp = "";
            {
                for (int i = 0; i < b.Length; i++)
                    spp += '0';
            }
            
            Console.WriteLine("----------------------");
            Console.WriteLine($"0|a:{a.Substring(0, 2)}.{a.Substring(2, asrc.Length)}|b:{bsrc}|spp:{spp.Substring(0, 2)}.{spp.Substring(2, bsrc.Length)}.{spp.Substring(2 + bsrc.Length, bsrc.Length)}|input");
            Console.WriteLine("----------------------");
            
            for (int i = 0; i < a.Length - 1; i += 2)
            {
                string digit = a.Substring(0, 2);
                bool p = a[2] == '1';

                string op = "";
                switch (digit)
                {
                    case ("00"):
                    {
                        if (p)
                        {
                            spp = Binary.Add(spp, b);
                            op = "+b; ";
                        }
                        break;
                    }

                    case ("01"):
                    {
                        op = $"{(p ? "+2b" : "+b")}; ";
                        spp = Binary.Add(spp, p ? b2 : b);
                        break;
                    }

                    case ("10"):
                    {
                        op = $"{(p ? "-b" : "-2b")}; ";
                        spp = Binary.Add(spp, p ? nb : nb2);
                        break;
                    }

                    case ("11"):
                    {
                        if (!p)
                        {
                            op = "-b; ";
                            spp = Binary.Add(spp, nb);
                        }
                        break;
                    }
                }

                bool eoc = i == a.Length - 2;
                string cycle = eoc ? "result;" : "move a, spp;";
                    
                Console.WriteLine($"{i / 2 + 1}|a:{a.Substring(0, 2)}.{a.Substring(2, asrc.Length)}|b:{bsrc}|spp:{spp.Substring(0, 2)}.{spp.Substring(2, bsrc.Length)}.{spp.Substring(2 + bsrc.Length, bsrc.Length)}|{op}{cycle}");
                
                a = Binary.MoveBitwiseLeft(Binary.MoveBitwiseLeft(a, false), false);
                spp = Binary.MoveBitwiseLeft(Binary.MoveBitwiseLeft(spp, false), false);
            }

        }
    }
}