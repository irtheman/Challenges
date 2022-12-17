using ChallengeTests;

namespace ChallengeTests.TestCases
{
    public class UnitTest1
    {
        public static string Parse1(string[] lines)
        {
            return lines[0];
        }

        public static Results<int[], int> Parse2(string[] lines)
        {
            var index = 0;
            var items = Utilities.GetIntArray(lines, ref index);
            var expected = Int32.Parse(lines[index]);

            return new Results<int[], int>(items, expected);
        }

        [Theory]
        [TestData("Test1")]
        public void Test1(string[] data)
        {
            var s = Parse1(data);
            Assert.NotNull(s);
            Assert.Equal(@"1", s);
            Assert.Equal(1, Int32.Parse(s));
        }

        [Theory]
        [TestData("Test2")]
        public void Test2(string[] data)
        {
            var test = Parse2(data);
            var total = test.Items.Sum();
            Assert.Equal(test.Expected, total);
        }
    }
}