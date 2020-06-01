using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod2xIV : IMultiplicationMethod
    {
        private MultiplicationMethod2xIV() {}
        public static MultiplicationMethod2xIV Singleton { get; } = new MultiplicationMethod2xIV();

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
            {
                for (int i = 0; i < bsrc.Length; i++)
                    b += "0";
            }

            string spp = "";
            {
                for (int i = 0; i < b.Length; i++)
                    spp += '0';
            }
            
            Console.WriteLine("----------------------");
            Console.WriteLine($"0|a:{a.Substring(0, 2)}.{a.Substring(2, asrc.Length)}|b:{b.Substring(0, 2)}.{b.Substring(2, bsrc.Length)}.{b.Substring(2 + bsrc.Length, bsrc.Length)}|spp:{spp.Substring(0, 2)}.{spp.Substring(2, bsrc.Length)}.{spp.Substring(2 + bsrc.Length, bsrc.Length)}|input");
            Console.WriteLine("----------------------");
            
            for (int i = 0; i < a.Length - 1; i += 2)
            {
                string digit = a.Substring(0, 2);
                bool p = a[2] == '1';

                string nb = Binary.InvertSign(b);
                string b2 = Binary.MoveBitwiseLeft(b, false);
                string nb2 = Binary.InvertSign(b2);

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
                    
                Console.WriteLine($"{i / 2 + 1}|a:{a.Substring(0, 2)}.{a.Substring(2, asrc.Length)}|b:{b.Substring(0, 2)}.{b.Substring(2, bsrc.Length)}.{b.Substring(2 + bsrc.Length, bsrc.Length)}|spp:{spp.Substring(0, 2)}.{spp.Substring(2, bsrc.Length)}.{spp.Substring(2 + bsrc.Length, bsrc.Length)}|{op}{cycle}");
                
                a = Binary.MoveBitwiseLeft(Binary.MoveBitwiseLeft(a, false), false);
                b = Binary.MoveBitwiseRight(Binary.MoveBitwiseRight(b, b[0] == '1'), b[0] == '1');
            }

        }
    }
}