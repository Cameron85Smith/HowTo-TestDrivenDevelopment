using NUnit.Framework;

namespace FibonacciNumber
{
    [TestFixture]
    public class FibonacciNumber
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void TestFibonacciNumbers(int expected, int index) => Assert.AreEqual(expected, GetFibonacciNumber(index));

        private int GetFibonacciNumber(int index) => index switch
        {
            0 => 0,
            1 => 1,
            _ => GetFibonacciNumber(index - 1) + GetFibonacciNumber(index - 2)
        };
    }
}