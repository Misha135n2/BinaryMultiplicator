using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod2xII : MultiplicationMethodII
    {
        private MultiplicationMethod2xII() : base(2) {}
        public static MultiplicationMethod2xII Singleton { get; } = new MultiplicationMethod2xII();
    }
}