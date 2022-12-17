// Title: Two Sum
// Description: Data Structure Problem 1 (Easy) - Given an array of integers and a target, return indices of the two numbers such that they add up to target.
// Category: Array Search
// Tags: c#, array, O(n)

namespace ChallengeLibrary.LeetCode
{
    public class TwoSum1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] ret = new int[2];
            Dictionary<int, int> d = new Dictionary<int, int>();
            int len = nums.Length, req = 0, j = 0;

            for (int i = 0; i < len; i++)
            {
                req = target - nums[i];
                if (d.TryGetValue(req, out j))
                {
                    ret[0] = i;
                    ret[1] = j;
                    break;
                }
                else
                {
                    d[nums[i]] = i;
                }
            }

            return ret;
        }
    }
}
