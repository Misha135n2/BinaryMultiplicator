using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod3xI : MultiplicationMethodI
    {
        private MultiplicationMethod3xI() : base(3) {}
        public static MultiplicationMethod3xI Singleton { get; } = new MultiplicationMethod3xI();
    }
}