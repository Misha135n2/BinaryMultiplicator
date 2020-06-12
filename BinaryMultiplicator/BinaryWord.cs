namespace BinaryMultiplicator
{
    public class BinaryWord
    {
        private string _two;
        private string _one;
        private string _value;
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                _one = Binary.Invert(_value);
                _two = Binary.InvertSign(_value);
            }
        }

        public BinaryWord(string value = "0")
        {
            Value = value;
        }

        public BinaryWord(int len)
        {
            _value = "";
            for (int i = 0; i < len; i++)
                _value += '0';
            Value = _value;
        }

        public BinaryWord Add(BinaryWord augend) => new BinaryWord(Binary.Add(_value, augend._value));
        public BinaryWord Subtract(BinaryWord subtrahend) => new BinaryWord(Binary.Add(_value, subtrahend._two));
        public BinaryWord Minus => new BinaryWord(Binary.InvertSign(_value));

        public void MoveLeft(int n = 1, bool isTwo = true)
        {
            for (int i = 0; i < n; i++)
                _value = Binary.MoveBitwiseLeft(_value, false);
            Value = _value;
        }
        public void MoveRight(int n = 1, bool isTwo = true)
        {
            for (int i = 0; i < n; i++)
                _value = Binary.MoveBitwiseRight(_value, isTwo && (_value[0] == '1'));
            Value = _value;
        }
        public void Align(int n)
        {
            Value = Binary.AlignFor(_value, n);
        }

        public string Pattern(string pattern, char placeholder = '*') => Binary.Pattern(_value, pattern, placeholder);

    }
}