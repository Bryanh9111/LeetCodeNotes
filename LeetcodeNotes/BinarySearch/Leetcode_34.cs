using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.BinarySearch
{
    public partial class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;
            int[] res = new int[2] { -1, -1 };
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    right = mid;
                else if (nums[mid] > target)
                    right = mid;
                else if (nums[mid] < target)
                    left = mid + 1;
            }
            if (!(left >= nums.Length || nums[left] != target))
                res[0] = left;

            left = 0;
            right = nums.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid;
                else if (nums[mid] < target)
                    left = mid + 1;
            }
            if (!(left <= 0 || nums[left - 1] != target))
                res[1] = left - 1;

            return res;
        }
    }
}
