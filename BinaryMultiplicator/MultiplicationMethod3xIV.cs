using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod3xIV : MultiplicationMethodIV
    {
        private MultiplicationMethod3xIV() : base(3) {}
        public static MultiplicationMethod3xIV Singleton { get; } = new MultiplicationMethod3xIV();
    }
}