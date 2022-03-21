﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.BinarySearch
{
    public partial class Solution
    {
        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1; //[left, right]

            while(left <= right) //[2,2]需要搜索, [3,2]停止
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    right = mid - 1;
                else if (nums[mid] < target)
                    left = mid + 1;
            }
            return -1;
        }

        public int Search2(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length; //[left, right)
            while (left < right) //[2,2) 停止搜索漏掉了2没搜索
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    right = mid; //[left, mid)  
                else if (nums[mid] < target)
                    left = mid + 1; //[mid + 1, right)
            }
            if (left >= nums.Length || nums[left] != target)
                return -1;
            return left;
        }

        //找到符合条件的最左元素index
        public int Search_left(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)//[left, right]
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    right = mid - 1;
                else if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid - 1;
            }
            //退出while时left == right + 1越界
            if (left >= nums.Length || nums[left] != target)
                return -1;
            return left;
        }
        public int Search_left2(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            int left = 0;
            int right = nums.Length;

            while (left < right)//[left, right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    right = mid;
                else if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid;
            }
            if (left >= nums.Length || nums[left] != target)
                return -1;
            return left;
        }

        //找到符合条件的最右元素index
        public int Search_right(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    left = mid + 1;
                else if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid - 1;
            }
            //当target比所有元素都小，right会被减到-1
            if (right < 0 || nums[right] != target)
                return -1;
            return right; 
        }
        public int Search_right2(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            int left = 0, right = nums.Length;
            
            while(left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    left = mid + 1;
                else if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid;
            }
            if (left == 0 || nums[left - 1] != target)
                return -1;
            return left - 1; //当while结束时nums[left]肯定不是target，而nums[left - 1]可能是target
        }
    }
}