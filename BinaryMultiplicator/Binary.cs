﻿using System;

namespace BinaryMultiplicator
{
    public static class Binary
    {
        public static string GetOneFor(int n)
        {
            char[] arr = new char[n];
            for (int i = 0; i < n - 1; i++)
                arr[i] = '0';
            arr[n - 1] = '1';
            return new string(arr);
        }

         public static string GetMinusOneFor(int n)
        {
            char[] arr = new char[n];
            for (int i = 0; i < n; i++)
                arr[i] = '1';
            return new string(arr);
        }

        public static string Invert(string binary)
        {
            char[] ibinary = binary.ToCharArray();
            for (int i = 0; i < ibinary.Length; i++)
                ibinary[i] = ibinary[i] == '0' ? '1' : '0';
            return new string(ibinary);
        }

        public static string InvertSign(string binary)
        {
            string result;
            if (binary[0] == '0')
            {
                result = Invert(binary);
                result = Add(result, GetOneFor(binary.Length));
            }
            else
            {
                result = Add(binary, GetMinusOneFor(binary.Length));
                result = Invert(result);
            }

            return result;
        }

        public static string MoveBitwiseLeft(string binary, bool fill1)
        {
            string saved = binary.Substring(1, binary.Length - 1);
            char flr = fill1 ? '1' : '0';
            saved = $"{saved}{flr}";
            return saved;
        }

        public static string MoveBitwiseRight(string binary, bool fill1)
        {
            string saved = binary.Substring(0, binary.Length - 1);
            char flr = fill1 ? '1' : '0';
            saved = $"{flr}{saved}";
            return saved;
        }

        public static string Add(string a, string b)
        {
            char[] res = new char[a.Length];
            for (int i = 0; i < res.Length; i++)
                res[i] = '0';

            bool f = false;
            for (int i = res.Length - 1; i >= 0; i--)
            {
                bool bita = a[i] == '1';
                bool bitb = b[i] == '1';
                if (bita && bitb)
                {
                    if (f)
                        res[i] = '1';
                    else
                        res[i] = '0';
                    f = true;
                }
                else if (bita || bitb)
                {
                    if (f)
                    {
                        res[i] = '0';
                    }
                    else
                        res[i] = '1';
                }
                else
                {
                    if (f)
                    {
                        res[i] = '1';
                        f = false;
                    }
                }
            }

            return new string(res);
        }

        public static bool ValidateBinary(string str)
        {
            foreach (var ch in str)
            {
                if(!(ch == '0' || ch == '1'))
                    return false;
            }
            return true;
        }

        public static string Pattern(string binary, string pattern, char placeholder = '*')
        {
            char[] r = new char[pattern.Length];
            int n = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == placeholder)
                {
                    r[i] = binary[n];
                    n++;
                }
                else
                    r[i] = pattern[i];
            }
            return new string(r);
        }

        public static string AlignFor(string binary, int n, bool isTwo = true, bool extraExtend = false)
        {
            char flr = isTwo ? (binary[0]) : '0';
            int algn = binary.Length % n;
            algn = (algn == 0 && extraExtend) ? n : algn;
            for (int i = 0; i < algn; i++)
                binary = $"{flr}{binary}";
            return binary;
        }

        public static string Extend(string a, int n, bool isTwo = true)
        {
            if (a.Length < n)
            {
                char flr = isTwo ? a[0] : '0';
                while (a.Length < n)
                    a += flr;
                return a;
            }
            throw new InvalidOperationException();
        }

        public static bool Equality(string a, string b, bool isTwo = true)
        {
            if (a.Length != b.Length)
            {
                if (a.Length > b.Length)
                    b = Extend(b, a.Length);
                else
                    a = Extend(a, b.Length);
            }

            a = $"{(isTwo ? a[0] : '0')}{a}";
            b = $"{(isTwo ? b[0] : '0')}{b}";

            a = Binary.Add(a, InvertSign(b));

            return a == (new BinaryWord(a.Length).Value);
        }
        public static int ToInt(string binary, bool isTwo = true)
        {
            bool minus = (isTwo && binary[0] == '1');
            binary = minus ? InvertSign(binary) : binary;
            int r = 0;
            int pot = 1;
            for (int i = binary.Length - 1; i >= 0; i--)
            {
                r += binary[i] == '1' ? pot : 0;
                pot *= 2;
            }
            return minus ? -r : r;
        }
    }
}