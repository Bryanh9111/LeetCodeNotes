using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.原地修改数组
{
    public partial class Solution
    {
        //快慢指针
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int slow = 0, fast = 0;
            while(fast < nums.Length)
            {
                if(nums[fast] != nums[slow])
                {
                    slow++;
                    nums[slow] = nums[fast];
                }
                fast++;
            }
            return slow + 1;
        }
    }
}
