// Title: Merge Sorted Array
// Description: Data Structure Problem 88 (Easy) - Take 2 sorted arrays and merge them.
// Category: Array Sort
// Tags: c#, array, sort, O(n)

namespace ChallengeLibrary.LeetCode
{
    public class MergeSortedArray88
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int ind = m + n - 1, i = m - 1, j = n - 1;

            while (i >= 0 && j >= 0)
            {
                if (nums1[i] >= nums2[j])
                {
                    nums1[ind--] = nums1[i--];
                }
                else
                {
                    nums1[ind--] = nums2[j--];
                }
            }

            while (i >= 0) nums1[ind--] = nums1[i--];
            while (j >= 0) nums1[ind--] = nums2[j--];
        }
    }
}
