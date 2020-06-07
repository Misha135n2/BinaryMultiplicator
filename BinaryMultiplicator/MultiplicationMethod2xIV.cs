using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod2xIV : MultiplicationMethodIV
    {
        private MultiplicationMethod2xIV() : base(2) {}
        public static MultiplicationMethod2xIV Singleton { get; } = new MultiplicationMethod2xIV();
    }
}