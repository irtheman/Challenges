// Title: The Demo Test
// Category: Testing
// Tags: testing,c#

namespace ChallengeLibrary
{
    public class DemoTest
    {
        public int CalculateSum(int[] input)
        {
            if (input == null) return 0;
            return input.Sum();
        }
    }
}