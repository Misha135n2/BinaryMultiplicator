using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod3xIII : MultiplicationMethodIII
    {
        private MultiplicationMethod3xIII() : base(3) {}
        public static MultiplicationMethod3xIII Singleton { get; } = new MultiplicationMethod3xIII();
    }
}