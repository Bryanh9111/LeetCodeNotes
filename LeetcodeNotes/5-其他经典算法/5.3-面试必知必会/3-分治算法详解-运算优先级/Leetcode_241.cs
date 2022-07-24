using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._3_面试必知必会._3_分治算法详解_运算优先级
{
    internal class Leetcode_241
    {
        IDictionary<string, IList<int>> memo = new Dictionary<string, IList<int>>();
        public IList<int> DiffWaysToCompute(string expression)
        {
            if (memo.ContainsKey(expression))
                return memo[expression];

            IList<int> res = new List<int>();
            for(int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                // 扫描算式 expression 中的运算符
                if (c == '-' || c == '*' || c == '+')
                {
                    /****** 分 ******/
                    // 以运算符为中⼼，分割成两个字符串，分别递归计算
                    IList<int> left = DiffWaysToCompute(expression.Substring(0, i));
                    IList<int> right = DiffWaysToCompute(expression.Substring(i + 1));
                    /****** 治 ******/
                    // 通过⼦问题的结果，合成原问题的结果
                    foreach(int a in left)
                        foreach(int b in right)
                        {
                            if (c == '+')
                                res.Add(a + b);
                            else if (c == '-')
                                res.Add(a - b);
                            else if (c == '*')
                                res.Add(a * b);
                        }
                }
            }
            // base case
            // 如果 res 为空，说明算式是⼀个数字，没有运算符
            if (res.Count == 0)
                res.Add(Int32.Parse(expression));
            memo.Add(expression, res);
            return res;
        }
    }
}
