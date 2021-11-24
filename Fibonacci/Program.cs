using NUnit.Framework;

namespace Fibonacci
{
    [TestFixture]
    public class Fibonacci
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void TestFibonacci(int expected, int index) => Assert.AreEqual(expected, FibonacciNumber(index));

        private int FibonacciNumber(int index) => index switch
        {
            0 => 0,
            1 => 1,
            _ => FibonacciNumber(index - 1) + FibonacciNumber(index - 2)
        };
    }
}