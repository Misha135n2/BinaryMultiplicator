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
    }
}