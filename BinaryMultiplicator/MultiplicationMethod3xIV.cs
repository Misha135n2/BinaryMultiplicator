using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod3xIV : IMultiplicationMethod
    {
        private MultiplicationMethod3xIV() {}
        public static MultiplicationMethod3xIV Singleton { get; } = new MultiplicationMethod3xIV();

    public void Calculate(string a, string b)
        {
            if (a.Length % 3 != 0)
            {
                Console.WriteLine("The alignment must be multiple of 3.");
                return;
            }

            string bsrc = b;
            string asrc = a;
            a = $"000{a}";

            b = $"000{b}";
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
            Console.WriteLine($"0|a:{a.Substring(0, 3)}.{a.Substring(3, asrc.Length)}|b:{b.Substring(0, 3)}.{b.Substring(3, bsrc.Length)}.{b.Substring(3 + bsrc.Length, bsrc.Length)}|spp:{spp.Substring(0, 3)}.{spp.Substring(3, bsrc.Length)}.{spp.Substring(3 + bsrc.Length, bsrc.Length)}|input");
            Console.WriteLine("----------------------");
            
            for (int i = 0; i < a.Length - 1; i += 3)
            {
                string digit = a.Substring(0, 4);

                string nb = Binary.InvertSign(b);
                string b2 = Binary.MoveBitwiseLeft(b, false);
                string b4 = Binary.MoveBitwiseLeft(b2, false);
                string b3 = Binary.Add(b2, b);

                string op = "";
                switch (digit)
                {
                    case ("0010"):
                    {
                        op = "+b; ";
                        spp = Binary.Add(spp, b);
                        break;
                    }
                    case ("0100"):
                    {
                        op = "+2b; ";
                        spp = Binary.Add(spp, b2);
                        break;
                    }
                    case ("0110"):
                    {
                        op = "+3b; ";
                        spp = Binary.Add(spp, b3);
                        break;
                    }
                    case ("1000"):
                    {
                        op = "-4b; ";
                        spp = Binary.Add(spp, Binary.InvertSign(b4));
                        break;
                    }
                    case ("1010"):
                    {
                        op = "-3b; ";
                        spp = Binary.Add(spp, Binary.InvertSign(b3));
                        break;
                    }
                    case ("1100"):
                    {
                        op = "-2b; ";
                        spp = Binary.Add(spp, Binary.InvertSign(b2));
                        break;
                    }
                    case ("1110"):
                    {
                        op = "-b; ";
                        spp = Binary.Add(spp, nb);
                        break;
                    }

                    case ("0001"):
                    {
                        op = "+b; ";
                        spp = Binary.Add(spp, b);
                        break;
                    }
                    case ("0011"):
                    {
                        op = "+2b; ";
                        spp = Binary.Add(spp, b2);
                        break;
                    }
                    case ("0101"):
                    {
                        op = "+3b; ";
                        spp = Binary.Add(spp, b3);
                        break;
                    }
                    case ("0111"):
                    {
                        op = "+4b; ";
                        spp = Binary.Add(spp, b4);
                        break;
                    }
                    case ("1001"):
                    {
                        op = "-3b; ";
                        spp = Binary.Add(spp, Binary.InvertSign(b3));
                        break;
                    }
                    case ("1011"):
                    {
                        op = "-2b; ";
                        spp = Binary.Add(spp, Binary.InvertSign(b2));
                        break;
                    }
                    case ("1101"):
                    {
                        op = "-b; ";
                        spp = Binary.Add(spp, nb);
                        break;
                    }
                    default: break;
                }

                bool eoc = i == a.Length - 3;
                string cycle = eoc ? "result;" : "move a, spp;";
                    
                Console.WriteLine($"{i / 3 + 1}|a:{a.Substring(0, 3)}.{a.Substring(3, asrc.Length)}|b:{b.Substring(0, 3)}.{b.Substring(3, bsrc.Length)}.{b.Substring(3 + bsrc.Length, bsrc.Length)}|spp:{spp.Substring(0, 3)}.{spp.Substring(3, bsrc.Length)}.{spp.Substring(3 + bsrc.Length, bsrc.Length)}|{op}{cycle}");
                
                a = Binary.MoveBitwiseLeft(Binary.MoveBitwiseLeft(Binary.MoveBitwiseLeft(a, false), false), false);
                b =  Binary.MoveBitwiseRight(Binary.MoveBitwiseRight(Binary.MoveBitwiseRight(b, b[0] == '1'), b[0] == '1'), b[0] == '1');
            }

        }
    }
}