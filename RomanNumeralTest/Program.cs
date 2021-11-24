using NUnit.Framework;

namespace RomanNumeralTest
{
    [TestFixture]
    public class RomanNumeralTest
    {
        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(14, "XIV")]
        [TestCase(9, "IX")]
        public void TestRomanNumeral(int expected, string romanNumeral) =>
         Assert.AreEqual(expected, RomanNumeral.Parse(romanNumeral));
    }

    public class RomanNumeral
    {
        private static  Dictionary<char, int> map =
        new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public static int Parse(string romanNumeral)
        {
            var result = 0;

            for (int i = 0; i < romanNumeral.Length; i ++)
            {
                if (i + 1 < romanNumeral.Length
                    && IsSubtractive(romanNumeral[i], romanNumeral[i + 1]))
                {
                    result -= map[romanNumeral[i]];
                }
                else
                {
                    result += map[romanNumeral[i]];
                }
            }

            return result;
        }

        private static bool IsSubtractive(char c1, char c2) => map[c1] < map[c2];
    }
}