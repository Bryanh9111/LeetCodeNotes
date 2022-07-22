using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._2_数学算法._1_如何高效寻找素数
{
    /// <summary>
    /// time limit exceeds
    /// </summary>
    internal class Leetcode_204
    {
        public int CountPrimes(int n)
        {
            if (n <= 0 || n == 1)
                return 0;

            int count = 0;
            for (int i = 2; i < n; i++)
            {
                if (IsPrime(i))
                    count++;
            }
            return count;
        }

        public bool IsPrime(int n)
        {
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }
    }

    internal class Leetcode_204_fast
    {
        public int CountPrimes(int n)
        {
            bool[] isPrime = new bool[n];
            // 将数组都初始化为 true
            for (int i = 0; i < n; i++)
                isPrime[i] = true;

            for (int i = 2; i < n; i++)
                if (isPrime[i])
                    // i 的倍数不可能是素数了
                    for (int j = 2 * i; j < n; j += i)
                        isPrime[j] = false;

            int count = 0;
            for (int i = 2; i < n; i++)
                if (isPrime[i])
                    count++;

            return count;
        }
    }

    internal class Leetcode_204_faster
    {
        public int CountPrimes(int n)
        {
            bool[] isPrime = new bool[n];
            for (int i = 0; i < n; i++)
                isPrime[i] = true;

            for (int i = 2; i * i < n; i++)
                if (isPrime[i])
                    // i 的倍数不可能是素数了
                    for (int j = i * i; j < n; j += i)
                        isPrime[j] = false;

            int count = 0;
            for (int i = 2; i < n; i++)
                if (isPrime[i])
                    count++;

            return count;
        }
    }
}
