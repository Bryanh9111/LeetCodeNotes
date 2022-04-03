using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.数组去重
{
    class Leetcode_1081
    {
        public string SmallestSubsequence(string s)
        {
            // 存放去重的结果
            Stack<char> st = new Stack<char>();
            // 布尔数组初始值为 false，记录栈中是否存在某个字符
            // 输入字符均为 ASCII 字符，所以大小 256 够用了
            bool[] inStack = new bool[256];

            // 维护一个计数器记录字符串中字符的数量
            // 因为输入为 ASCII 字符，大小 256 够用了
            int[] count = new int[256];
            for (int i = 0; i < s.Length; i++)
                count[s[i]]++;

            foreach (var c in s)
            {
                count[c]--;// 每遍历过一个字符，都将对应的计数减一

                // 如果字符 c 存在栈中，直接跳过
                if (inStack[c])
                    continue;

                // 插入之前，和之前的元素比较一下大小
                // 如果字典序比前面的小，pop 前面的元素
                while (st.Count > 0 && st.Peek() > c)
                {
                    // 若之后不存在栈顶元素了，则停止 pop
                    if (count[st.Peek()] == 0)
                        break;

                    inStack[st.Pop()] = false;// 弹出栈顶元素，并把该元素标记为不在栈中
                }

                // 若不存在，则插入栈顶并标记为存在
                st.Push(c);
                inStack[c] = true;
            }
            char[] arr = new char[st.Count];
            for (int i = st.Count - 1; i >= 0; i--)
                arr[i] = st.Pop();

            return new string(arr);
        }
    }
}
