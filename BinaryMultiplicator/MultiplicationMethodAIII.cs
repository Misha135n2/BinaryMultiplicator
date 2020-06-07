using System;

namespace BinaryMultiplicator
{
    public sealed class MultiplicationMethodAIII : MultiplicationMethodIII
    {
        private MultiplicationMethodAIII() : base(1) {}
        public static MultiplicationMethodAIII Singleton { get; } = new MultiplicationMethodAIII();
    }
}