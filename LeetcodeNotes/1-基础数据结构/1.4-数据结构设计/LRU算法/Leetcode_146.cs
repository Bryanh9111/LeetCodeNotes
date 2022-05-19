using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.LRU算法
{
    public class LRUCache
    {
        // key -> Node(key, val)
        private Dictionary<int, Node> dic;
        // Node(k1, v1) <-> Node(k2, v2)...
        private DoubleList cache;
        private int cap;

        public LRUCache(int capacity)
        {
            dic = new Dictionary<int, Node>();
            cache = new DoubleList();
            cap = capacity;
        }

        //先不慌去实现 LRU 算法的 get 和 put ⽅法。由于我们要同时维护⼀个双链表 cache 和⼀个哈希表 map，很
        //容易漏掉⼀些操作，⽐如说删除某个 key 时，在 cache 中删除了对应的 Node，但是却忘记在 map 中删除
        //key。
        //解决这种问题的有效⽅法是：在这两种数据结构之上提供⼀层抽象 API。
        //说的有点⽞幻，实际上很简单，就是尽量让 LRU 的主⽅法 get 和 put 避免直接操作 map 和 cache 的细
        //节。
        /// <summary>
        /// 将某个 key 提升为最近使⽤的
        /// </summary>
        /// <param name="key"></param>
        private void MakeRecent(int key)
        {
            Node x = dic[key];
            cache.Remove(x);//先从链表中删除这个节点
            cache.AddLast(x);//重新插到队尾
        }
        /// <summary>
        ///  添加最近使⽤的元素
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        private void AddRecent(int key, int val)
        {
            Node x = new Node(key, val);
            cache.AddLast(x);// 链表尾部就是最近使⽤的元素
            dic.Add(key, x);// 别忘了在 map 中添加 key 的映射
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        private void UpdateToRencent(int key, int val)
        {
            dic[key].val = val;
            MakeRecent(key);
        }
        /// <summary>
        /// 删除某⼀个 key
        /// </summary>
        /// <param name="key"></param>
        private void DeleteKey(int key)
        {
            Node x = dic[key];
            cache.Remove(x);//从链表中删除
            dic.Remove(key);//从dic删除
        }
        /// <summary>
        /// 删除最久未使⽤的元素
        /// </summary>
        private void RemoveOldest()
        {
            Node x = cache.RemoveFirst();
            dic.Remove(x.key);
        }

        public int Get(int key)
        {
            if (!dic.ContainsKey(key))
                return -1;

            MakeRecent(key);
            return dic[key].val;
        }

        public void Put(int key, int value)
        {
            if (dic.ContainsKey(key))
            {
                UpdateToRencent(key, value);
                return;
            }

            while(cache.Size() >= cap)
                RemoveOldest();

            AddRecent(key, value);
        }
    }
    public class Node
    {
        public int key, val;
        public Node next, prev;
        public Node(int k, int v)
        {
            key = k;
            val = v;
        }
    }
    /// <summary>
    /// 双链表
    /// 注意我们实现的双链表 API 只能从尾部插⼊，也就是说靠尾部的数据是最近使⽤的，靠头部的数据是最久为
    /// 使⽤的。
    /// 到这⾥就能回答刚才「为什么必须要⽤双向链表」的问题了，因为我们需要删除操作。删除⼀个节点不光要
    /// 得到该节点本身的指针，也需要操作其前驱节点的指针，⽽双向链表才能⽀持直接查找前驱，保证操作的时
    /// 间复杂度 O(1)
    /// </summary>
    public class DoubleList
    {
        private Node head, tail;// 头尾虚节点
        private int size;// 链表元素数
        
        public DoubleList()
        {
            head = new Node(0, 0);
            tail = new Node(0, 0);
            head.next = tail;
            tail.prev = head;
            size = 0;
        }
        /// <summary>
        ///  在链表尾部添加节点 x，时间 O(1)
        /// </summary>
        /// <param name="x"></param>
        public void AddLast(Node x)
        {
            x.prev = tail.prev;
            x.next = tail;
            tail.prev.next = x;
            tail.prev = x;
            size++;
        }
        /// <summary>
        /// 删除链表中的 x 节点（x ⼀定存在）
        /// 由于是双链表且给的是⽬标 Node 节点，时间 O(1)
        /// </summary>
        /// <param name="x"></param>
        public void Remove(Node x)
        {
            x.prev.next = x.next;
            x.next.prev = x.prev;
            size--;
        }
        /// <summary>
        /// 删除链表中第⼀个节点，并返回该节点，时间 O(1)
        /// </summary>
        /// <returns></returns>
        public Node RemoveFirst()
        {
            if (head.next == tail)
                return null;
            Node first = head.next;
            Remove(first);
            return first;
        }
        /// <summary>
        /// 返回链表⻓度，时间 O(1)
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return size;
        }
    }
}
