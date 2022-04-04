using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.原地修改数组
{
    public class Leetcode_27
    {
        public int RemoveElement(int[] nums, int val)
        {
            int fast = 0; int slow = 0;
            while(fast < nums.Length)
            {
                if(nums[fast] != val)
                {
                    nums[slow++] = nums[fast];
                }
                fast++;
            }
            return slow;
        }
    }
}
