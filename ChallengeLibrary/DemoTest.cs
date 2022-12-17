// Title: The Demo Test
// Description: This is a way of testing the challenge system unit testing.
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