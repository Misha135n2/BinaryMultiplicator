using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod3xII : MultiplicationMethodII
    {
        private MultiplicationMethod3xII() : base(3) {}
        public static MultiplicationMethod3xII Singleton { get; } = new MultiplicationMethod3xII();
    }
}