using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.括号
{
    class Leetcode_921
    {
        /// <summary>
        /// 书里写的
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinAddToMakeValid(string s)
        {
            int res = 0; //插入次数
            int need = 0; //右括号的需求量
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == '(')
                {
                    need++;
                }
                if(s[i] == ')')
                {
                    need--;
                    if (need == -1)
                    {
                        need = 0;
                        res++;//需要一个左括号
                    }   
                }
            }
            return res + need;
        }
        /// <summary>
        /// 自己写的
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinAddToMakeValid_other(string s)
        {
            int open = 0, close = 0;
            foreach(var c in s)
            {
                if (Char.Equals('(', c))
                    open++;
                else if (Char.Equals(')', c) && open > 0)
                    open--;
                else if (Char.Equals(')', c) && open == 0)
                    close++;
            }
            return open + close;
        }
    }
}
