using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.括号
{
    class Leetcode_1541
    {
        public int MinInsertions(string s)
        {
            int res = 0;
            int need = 0;//右括号需求量

            for(int i = 0; i <  s.Length; i++)
            {
                //一个左括号对应两个右括号
                //当遇到左括号时，若对右括号的需求量为奇数，需要插⼊ 1 个右括号
                if (s[i] == '(')
                {
                    need += 2;
                    if(need % 2 == 1)
                    {
                        res++;// 插⼊⼀个右括号
                        need--;// 对右括号的需求减⼀
                    }
                }
                   

                if(s[i] == ')')
                {
                    need--;
                    if(need == -1)// 说明右括号太多了
                    {
                        res++;// 需要插⼊⼀个左括号
                        need = 1;// 同时，对右括号的需求变为 1
                    }
                }
            }
            return res + need;
        }
    }
}
