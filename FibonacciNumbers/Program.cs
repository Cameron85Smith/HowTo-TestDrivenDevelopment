using NUnit.Framework;

// Triangulation is when you drive the implementation by writing tests.
// This means that we generalize the implementation after we have at
// least two test cases.
namespace FibonacciNumber
{

    [TestFixture]
    public class FibonacciNumber
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void TestFibonacciNumbers(int expected, int index) => Assert.AreEqual(expected, GetFibonacci(index));

        private int GetFibonacci(int index) => index switch
        {
            0 => 0,
            1 => 1,
            _ => GetFibonacci(index - 1) + GetFibonacci(index - 2)
        };
    }
}