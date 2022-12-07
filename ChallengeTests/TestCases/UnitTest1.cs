using ChallengeTests;

namespace ChallengeTests.TestCases
{
    public class UnitTest1
    {
        public class Results
        {
            public Results(int[] items, int expected)
            {
                Items = items;
                Expected = expected;
            }

            public int[] Items { get; }
            public int Expected { get; }
        }

        public string Parse1(string[] lines)
        {
            return lines[0];
        }

        public Results Parse2(string[] lines)
        {
            var count = Int32.Parse(lines[0]);
            var items = new int[count];
            var expected = Int32.Parse(lines[count + 1]);

            for (int i = 1; i <= count; i++)
            {
                items[i - 1] = Int32.Parse(lines[i]);
            }

            return new Results(items, expected);
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