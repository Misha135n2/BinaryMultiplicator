using System;

namespace BinaryMultiplicator
{
    public sealed class MultiplicationMethodAI : MultiplicationMethodI
    {
        private MultiplicationMethodAI() : base(1) {}
        public static MultiplicationMethodAI Singleton { get; } = new MultiplicationMethodAI();
    }
}