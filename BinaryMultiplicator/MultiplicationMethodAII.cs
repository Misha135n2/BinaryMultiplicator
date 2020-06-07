using System;

namespace BinaryMultiplicator
{
    public sealed class MultiplicationMethodAII : MultiplicationMethodII
    {
        private MultiplicationMethodAII() : base(1) {}
        public static MultiplicationMethodAII Singleton { get; } = new MultiplicationMethodAII();
    }
}