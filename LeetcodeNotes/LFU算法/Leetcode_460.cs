using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.LFU算法
{
    public class LFUCache
    {
        Dictionary<int, int> keyToVal;// key 到 val 的映射
        Dictionary<int, int> keyToFreq;// key 到 freq 的映射
        Dictionary<int, LinkedHashSet<int>> freqToKeys;// freq 到 key 列表的映射
        int minFreq;// 记录最⼩的频次
        int cap;// 记录 LFU 缓存的最⼤容量
        public LFUCache(int capacity)
        {
            keyToVal = new Dictionary<int, int>();
            keyToFreq = new Dictionary<int, int>();
            freqToKeys = new Dictionary<int, LinkedHashSet<int>>();
            minFreq = 0;
            cap = capacity;
        }
        private void IncreaseFreq(int key)
        {
            int freq = keyToFreq[key];
            keyToFreq[key] = freq + 1;
            freqToKeys[freq].Remove(key);
            if (freqToKeys.ContainsKey(freq + 1))
                freqToKeys[freq + 1].Add(key);
            else
            {
                freqToKeys.Add(freq + 1, new LinkedHashSet<int>());
                freqToKeys[freq + 1].Add(key);
            }
            // 如果 freq 对应的列表空了，移除这个 freq
            if (freqToKeys[freq].Size() == 0)
            {
                freqToKeys.Remove(freq);
                if (freq == minFreq)// 如果这个 freq 恰好是 minFreq，更新 minFreq
                    minFreq++;
            }
        }
        private void RemoveMinFreqKey()
        {
            LinkedHashSet<int> keyLst = freqToKeys[minFreq];// freq 最小的 key 列表
            int deletedKey = keyLst.RemoveFirst();// 其中最先被插入的那个 key 就是该被淘汰的 key
            if (keyLst.Size() == 0)
                freqToKeys.Remove(minFreq);
            keyToVal.Remove(deletedKey);
            keyToFreq.Remove(deletedKey);
        }

        public int Get(int key)
        {
            if (!keyToVal.ContainsKey(key))
                return -1;

            IncreaseFreq(key);
            return keyToVal[key];
        }

        public void Put(int key, int value)
        {
            if (cap <= 0)
                return;

            /* 若 key 已存在，修改对应的 val 即可 */
            if (keyToVal.ContainsKey(key))
            {
                keyToVal[key] = value;
                // key 对应的 freq 加一
                IncreaseFreq(key);
                return;
            }
            /* key 不存在，需要插入 */
            /* 容量已满的话需要淘汰一个 freq 最小的 key */
            if (cap <= keyToVal.Count)
                RemoveMinFreqKey();

            keyToVal.Add(key, value);
            keyToFreq.Add(key, 1);
            if (freqToKeys.ContainsKey(1))
                freqToKeys[1].Add(key);
            else
            {
                freqToKeys.Add(1, new LinkedHashSet<int>());
                freqToKeys[1].Add(key);
            }
            minFreq = 1; // 插入新 key 后最小的 freq 肯定是 1
        }
    }
    /// <summary>
    /// 自己写的:)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedHashSet<T>
    {
        private HashSet<int> st;
        private LinkedList<int> llst;

        public LinkedHashSet()
        {
            st = new HashSet<int>();
            llst = new LinkedList<int>();
        }
        public void Add(int n)
        {
            if (st.Add(n))
                llst.AddLast(n);
        }
        public void Remove(int n)
        {
            if (st.Remove(n))
                llst.Remove(n);
        }
        public int RemoveFirst()
        {
            var n = llst.First.Value;
            Remove(n);
            return n;
        }
        public int Size()
        {
            return llst.Count;
        }
    }
}
