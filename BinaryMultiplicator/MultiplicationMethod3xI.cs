﻿using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod3xI : IMultiplicationMethod
    {
        private MultiplicationMethod3xI() {}
        public static MultiplicationMethod3xI Singleton { get; } = new MultiplicationMethod3xI();

        public void Calculate(string a, string b)
        {
            if (a.Length % 2 != 0)
            {
                Console.WriteLine("The alignment must be multiple of 3.");
                return;
            }

            string bsrc = b;
            string asrc = a;
            a = $"000{a}0";

            b = $"000{b}";
            string nb = Binary.InvertSign(b);
            string b2 = Binary.MoveBitwiseLeft(b, false);
            string b4 = Binary.MoveBitwiseLeft(b2, false);
            string b3 = Binary.Add(b2, b);
            {
                for (int i = 0; i < bsrc.Length; i++)
                {
                    b += "0";
                    nb += "0";
                    b2 += "0";
                    b3 += "0";
                    b4 += "0";
                }
            }

            string spp = "";
            {
                for (int i = 0; i < b.Length; i++)
                    spp += '0';
            }

            bool p = false;

            Console.WriteLine("----------------------");
            Console.WriteLine($"0|a:{a.Substring(0, 3)}.{a.Substring(3, asrc.Length - 1)}.{a.Substring(a.Length - 1, 1)}|b:{bsrc}|spp:{spp.Substring(0, 3)}.{spp.Substring(3, bsrc.Length)}.{spp.Substring(3 + bsrc.Length, bsrc.Length)}|input");
            Console.WriteLine("----------------------");
            
            for (int i = 0; i < a.Length - 1; i += 3)
            {
                string digit = a.Substring(a.Length - 4, 4);

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
                    
                Console.WriteLine($"{i / 3 + 1}|a:{a.Substring(0, 3)}.{a.Substring(3, asrc.Length - 1)}.{a.Substring(a.Length - 1, 1)}|b:{bsrc}|spp:{spp.Substring(0, 3)}.{spp.Substring(3, bsrc.Length)}.{spp.Substring(3 + bsrc.Length, bsrc.Length)}|{op}{cycle}");
                
                a = Binary.MoveBitwiseRight(Binary.MoveBitwiseRight(Binary.MoveBitwiseRight(a, false), false), false);
                spp = Binary.MoveBitwiseRight(Binary.MoveBitwiseRight(Binary.MoveBitwiseRight(spp, spp[0] == '1'), spp[0] == '1'), spp[0] == '1');
            }

        }
    }
}