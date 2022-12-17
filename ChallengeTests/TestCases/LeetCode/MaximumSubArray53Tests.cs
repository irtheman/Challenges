using ChallengeLibrary.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTests.TestCases.LeetCode
{
    public class MaximumSubArray53Tests
    {
        public static Results<int[], int> Parse(string[] lines)
        {
            var index = 0;
            var items = Utilities.GetIntArray(lines, ref index);
            var expected = Int32.Parse(lines[index]);

            return new Results<int[], int>(items, expected);
        }

        [Theory]
        [TestData("leet53")]
        public void Test1(string[] input)
        {
            var data = Parse(input);
            var test = new MaximumSubArray53();
            var actual = test.MaxSubArray1(data.Items);
            Assert.Equal(data.Expected, actual);
        }

        [Theory]
        [TestData("leet53")]
        public void Test2(string[] input)
        {
            var data = Parse(input);
            var test = new MaximumSubArray53();
            var actual = test.MaxSubArray2(data.Items);
            Assert.Equal(data.Expected, actual);
        }
    }
}
