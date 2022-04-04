using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.原地修改数组
{
    public class Leetcode_283
    {
        public void MoveZeroes(int[] nums)
        {
            int slow = 0, fast = 0; int count = 0;
            while(fast < nums.Length)
            {
                if (nums[fast] != 0)
                    nums[slow++] = nums[fast];
                else count++;
                fast++;
            }
            //int length = nums.Length - 1;
            //while(count > 0)
            //{
            //    nums[length--] = 0;
            //    count--;
            //}
            for (int i = slow; i < nums.Length; i++)
                nums[i] = 0;
        }
    }
}
