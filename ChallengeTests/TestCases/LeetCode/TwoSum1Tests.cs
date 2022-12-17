using ChallengeLibrary.LeetCode;

namespace ChallengeTests.TestCases.LeetCode
{
    public class TwoSum1Tests
    {
        public static Results2<int[], int, int[]> Parse(string[] lines)
        {
            var index = 0;
            var items = Utilities.GetIntArray(lines, ref index);
            var target = Int32.Parse(lines[index++]);
            var expected = Utilities.GetIntArray(lines, ref index);

            return new Results2<int[], int, int[]>(items, target, expected);
        }

        [Theory]
        [TestData("leet1")]
        public void Test(string[] input)
        {
            var data = Parse(input);
            var test = new TwoSum1();
            var actual = test.TwoSum(data.Items, data.Params);
            Assert.Equal(2, actual.Length);
            Assert.Contains(data.Expected[0], actual);
            Assert.Contains(data.Expected[1], actual);
        }
    }
}
