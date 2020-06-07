using System;

namespace BinaryMultiplicator
{
    public class MultiplicationMethod2xI : MultiplicationMethodI
    {
        private MultiplicationMethod2xI() : base(2) {}
        public static MultiplicationMethod2xI Singleton { get; } = new MultiplicationMethod2xI();
    }
}