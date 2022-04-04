using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.常数时间删除查找元素
{
    public class Solution
    {
        private int sz;
        private Dictionary<int, int> mapping;
        private Random rand;
        public Solution(int n, int[] blacklist)
        {
            rand = new Random();
            mapping = new Dictionary<int, int>();
            sz = n - blacklist.Length;// 最终数组中的元素个数

            foreach (var b in blacklist)// 先将所有⿊名单数字加⼊ map
                mapping.Add(b, 6666);  // 这⾥赋值多少都可以
                                     // ⽬的仅仅是把键存进哈希表
                                      // ⽅便快速判断数字是否在⿊名单内

            int last = n - 1;// 最后⼀个元素的索引
            foreach (var b in blacklist)
            {
                if (b >= sz)// 如果 b 已经在区间 [sz, N)
                    continue;      // 可以直接忽略

                while (mapping.ContainsKey(last))
                    last--;// 跳过所有⿊名单中的数字

                mapping[b] = last--;// 将⿊名单中的索引换到最后去
            }
                
        }

        public int Pick()
        {
            int index = rand.Next(0, sz) % sz;// 随机选取⼀个索引
            if (mapping.ContainsKey(index))
                return mapping[index];// 这个索引命中了⿊名单，
                                      // 需要被映射到其他位置
            return index;// 若没命中⿊名单，则直接返回
        }
    }
}
