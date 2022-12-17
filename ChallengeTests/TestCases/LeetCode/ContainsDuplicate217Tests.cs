using ChallengeLibrary.LeetCode;

namespace ChallengeTests.TestCases.LeetCode
{
    public class ContainsDuplicate217Tests
    {
        public static Results<int[], bool> Parse(string[] lines)
        {
            var index = 0;
            var items = Utilities.GetIntArray(lines, ref index);
            var expected = Boolean.Parse(lines[index]);

            return new Results<int[], bool>(items, expected);
        }

        [Theory]
        [TestData("leet217")]
        public void Test(string[] input)
        {
            var data = Parse(input);
            var test = new ContainsDuplicate217();
            var actual = test.ContainsDuplicate(data.Items);
            Assert.Equal(data.Expected, actual);
        }
    }
}
