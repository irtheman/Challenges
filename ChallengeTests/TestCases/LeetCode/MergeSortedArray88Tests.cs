using ChallengeLibrary.LeetCode;

namespace ChallengeTests.TestCases.LeetCode
{
    public class Info88
    {
        public Info88(int[] array1, int[] array2, int m, int n, int[] expected)
        {
            Array1 = array1;
            Array2 = array2;
            M = m;
            N = n;
            Expected = expected;    
        }

        public int[] Array1 { get; }
        public int[] Array2 { get; }
        public int M { get; }
        public int N { get; }
        public int[] Expected { get; }
    }

    public class MergeSortedArray88Tests
    {
        public Info88 Parse(string[] lines)
        {
            var index = 0;

            var a1 = Utilities.GetIntArray(lines, ref index);
            var m = Int32.Parse(lines[index++]);

            var a2 = Utilities.GetIntArray(lines, ref index);
            var n = Int32.Parse(lines[index++]);

            var expected = Utilities.GetIntArray(lines, ref index);

            return new Info88(a1, a2, m, n, expected);
        }

        [Theory]
        [TestData("leet88")]
        public void Test(string[] input)
        {
            var data = Parse(input);
            var test = new MergeSortedArray88();
            test.Merge(data.Array1, data.M, data.Array2, data.N);
            Assert.Equal(data.Array1, data.Expected);
        }
    }
}
