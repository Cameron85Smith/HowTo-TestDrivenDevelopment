using NUnit.Framework;

namespace FibonacciTest
{
    [TestFixture]
    public class FibonacciTest
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void TestFibonacci(int expected, int index) => Assert.AreEqual(expected, Fibonacci(index));

        private int Fibonacci(int index) => index switch
        {
            0 => 0,
            1 => 1,
            _ => Fibonacci(index - 1) + Fibonacci(index - 2)
        };
    }
}