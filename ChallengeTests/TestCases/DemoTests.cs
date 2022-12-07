using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTests.TestCases
{
    public class DemoTests
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

        public Results Parse(string[] lines)
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
        [TestData("DemoTest1,DemoTest2")]
        public void Test2(string[] input)
        {
            var data = Parse(input);
            var test = new DemoTest();
            var actual = test.CalculateSum(data.Items);
            Assert.Equal(data.Expected, actual);
        }
    }
}
