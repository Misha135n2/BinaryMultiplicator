using System;
using System.Collections.Generic;

namespace BinaryMultiplicator
{
    /// <summary>
    /// Koefficent table
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Maximal koefficent
        /// </summary>
        public int Max { get; } = 0;

        public readonly int N;
        public readonly Dictionary<string, int> Contibution = new Dictionary<string, int>();

        public Table(int n = 1)
        {
            N = n;

            List<string> list = new List<string>() { "0", "1" };
                
            while (n > 0)
            {
                List<string> l = new List<string>();
                foreach (var e in list)
                {
                    l.Add($"{e}0");
                    l.Add($"{e}1");
                }

                list = l;

                n--;
            }

            foreach (var e in list)
                Contibution.Add(e, GetContribution(e));
            //foreach (var kvp in Contibution)
            //    Max = kvp.Value > Max ? kvp.Value : Max;
            Max = (int) Math.Pow(2, n - 1);
            
            int GetContribution(string binary)
            {
                int r = 0;
                char f = binary[0] == '0' ? '1' : '0';
                int pot = 1;
                for (int i = binary.Length - 2; i >= 0; i--)
                {
                    r += (binary[i] == f) ? pot : 0;
                    pot *= 2;
                }

                r += binary[binary.Length - 1] == f ? 1 : 0;
                return f == '0' ? -r : r;
            }
        }

        //public Table(int n = 1)
        //{
        //    N = n;
        //    string key = "";

        //    // bordered
        //    // +\- 0
        //    for (int i = 0; i < n + 1; i++)
        //        key += '0';
        //    Contibution.Add(key, 0);
        //    key = key.Replace('0', '1');
        //    Contibution.Add(key, 0);
        //    // +\- N
        //    key = "0";
        //    for (int i = 0; i < n; i++)
        //        key += '1';
        //    Contibution.Add(key, N);
        //    key = "1";
        //    for (int i = 0; i < n; i++)
        //        key += '0';
        //    Contibution.Add(key, -N);

        //    // intermediate, +1 per 2
        //    GenerateIntermediate(n);

        //    void GenerateIntermediate(int step)
        //    {
        //        List<string> list = new List<string>() {"0", "1"};
        //        while (step > 0)
        //        {
        //            List<string> l = new List<string>();
        //            foreach (var e in list)
        //            {
        //                l.Add($"{e}0");
        //                l.Add($"{e}1");
        //            }

        //            list = l;
        //            step--;
        //        }

        //        foreach (var kvp in Contibution)
        //            list.Remove(kvp.Key);

        //        int m = 1;
        //        for (int i = 0; i < list.Count; i += 4)
        //        {
        //            Contibution.Add(list[i], m);
        //            Contibution.Add(list[i + 1], m);

        //            Contibution.Add(list[list.Count - (i + 2)], -m);
        //            Contibution.Add(list[list.Count - (i + 1)], -m);

        //            m++;
        //        }
        //    }
        //}

        public Dictionary<string, BinaryWord> Generate(BinaryWord b)
        {
            Dictionary<string, BinaryWord> bDict = new Dictionary<string, BinaryWord>();
            foreach (var kvp in Contibution)
            {
                BinaryWord bw = new BinaryWord(b.Value.Length);
                int m = Math.Abs(kvp.Value);
                if(m > 0)
                    for (int i = 0; i < m; i++)
                        bw = bw.Add(b);
                if (kvp.Value < 0)
                    bw = bw.Minus;
                bDict.Add(kvp.Key, bw);
            }

            return bDict;
        }
    }
}