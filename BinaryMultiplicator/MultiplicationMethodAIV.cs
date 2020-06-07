using System;

namespace BinaryMultiplicator
{
    public sealed class MultiplicationMethodAIV : MultiplicationMethodIV
    {
        private MultiplicationMethodAIV() : base(1) {}
        public static MultiplicationMethodAIV Singleton { get; } = new MultiplicationMethodAIV();
    }
}