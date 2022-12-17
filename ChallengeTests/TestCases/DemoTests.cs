using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTests.TestCases
{
    public class DemoTests
    {
        public static Results<int[], int> Parse(string[] lines)
        {
            var index = 0;
            var items = Utilities.GetIntArray(lines, ref index);
            var expected = Int32.Parse(lines[index]);

            return new Results<int[], int>(items, expected);
        }

        [Theory]
        [TestData("DemoTest")]
        public void Test(string[] input)
        {
            var data = Parse(input);
            var test = new DemoTest();
            var actual = test.CalculateSum(data.Items);
            Assert.Equal(data.Expected, actual);
        }
    }
}
