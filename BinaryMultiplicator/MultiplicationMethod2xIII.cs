using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod2xIII : MultiplicationMethodIII
    {
        private MultiplicationMethod2xIII() : base(2) {}
        public static MultiplicationMethod2xIII Singleton { get; } = new MultiplicationMethod2xIII();
    }
}