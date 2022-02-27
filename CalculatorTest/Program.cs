using NUnit.Framework;

namespace CalculatorTest
{
    [TestFixture]
    public class CalculatorTest
    {
        // 1) - Develop the Unit Test
        // 3) Refactor the logic.
        [Test]
        public void AddNumbers_ValidValues_ReturnsCorrectResult()
        {
            var addition = new Calculator();
            int result = addition.AddNumbers(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        // 1) Develop the Unit Test
        // 3) Refactor the logic.
        [Test]
        public void SubtractNumbers_ValidValues_ReturnsCorrectResults()
        {
            var subtraction = new Calculator();
            int result  = subtraction.SubtractNumbers(5,3);
            
            Assert.That(result, Is.EqualTo(2));
        }
    }
}