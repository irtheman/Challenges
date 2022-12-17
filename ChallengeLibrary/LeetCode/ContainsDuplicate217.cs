// Title: Contains Duplicate
// Description: Data Structure Problem 217 (Easy) - Normal solution
// Category: Array Search
// Tags: c#, array, O(n^2)

namespace ChallengeLibrary.LeetCode
{
    public class ContainsDuplicate217
    {
        public bool ContainsDuplicate(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                        return true;
                }
            }

            return false;
        }
    }
}
