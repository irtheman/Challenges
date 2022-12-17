// Title: Maximum Subarray
// Description: Data Structure Problem 53 (Medium) - normal and divide-and-conquer solutions
// Category: Array Search
// Tags: c#, array, O(n), O(log(n))

namespace ChallengeLibrary.LeetCode
{
	public record struct Val(int l, int m, int r, int s);

    public class MaximumSubArray53
    {
        public int MaxSubArray1(int[] nums)
        {
			var max = nums[0];
			var sum = nums[0];

			for (int i = 1; i < nums.Length; i++)
			{
				if (sum > 0)
				{
					sum += nums[i];
				}
				else
				{
					sum = nums[i];
				}

				if (sum > max)
				{
					max = sum;
				}
			}

			return max;
        }

        public int MaxSubArray2(int[] nums)
        {
			var v = Helper(nums, 0, nums.Length - 1);
			return v.m;
        }

		private Val Helper(int[] nums, int left, int right)
		{
			if (left == right) return new Val(nums[left], nums[left], nums[left], nums[left]);
			var mid = left + (right - left) / 2;
            var v1 = Helper(nums, left, mid);
			var v2 = Helper(nums,mid + 1, right);
			return new Val(
					Math.Max(v1.l, v1.s + v2.l),
					Math.Max(v1.r + v2.l, Math.Max(v1.m, v2.m)),
					Math.Max(v2.r, v1.r + v2.s),
					v1.s + v2.s
				   );
		}
    }
}
