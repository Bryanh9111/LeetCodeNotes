using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNotes.Collections
{
    /// <summary>
    /// Simple key value based Min Heap priority queue.
    /// Uses SortedDictionary and its BST behind the scene. Unlike SortedDictionary it Allow duplicate values.
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <typeparam name="TPriority"></typeparam>
    public class PriorityQueue<TItem, TPriority> : IQueueDoubleEnded<TItem>, IEnumerable<TItem>
    {
        public PriorityQueue(Func<TItem, TPriority> getPriority, IEnumerable<TItem> items = null, IComparer<TPriority> comparer = null)
        {
            this.getPriority = getPriority;
            var tupleComparer = comparer != null ? new TupleComparer<TPriority>(comparer) : null;
            binaryTree = new SortedDictionary<Tuple<TPriority>, Queue<TItem>>(tupleComparer);
            AddRange(items);
        }

        /// <summary>
        /// Add multiple items to the queue
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<TItem> items)
        {
            foreach (var item in items ?? Enumerable.Empty<TItem>())
                Enqueue(item);
        }

        Func<TItem, TPriority> getPriority;

        /// <summary>
        /// Dictionary prohibit using Null as key, that's why we have to create Tuple
        /// </summary>
        SortedDictionary<Tuple<TPriority>, Queue<TItem>> binaryTree;
        public IEnumerable<TItem> GetItems()
        {
            foreach (var kvp in binaryTree)
                foreach (var item in kvp.Value)
                    yield return item;
        }

        public bool IsEmpty
        {
            get
            {
                return binaryTree.Count == 0;
            }
        }

        public TItem Dequeue()
        {
            var firstKvp = binaryTree.First();
            var res = firstKvp.Value.Dequeue();
            if (firstKvp.Value.Count == 0)
                if (!binaryTree.Remove(firstKvp.Key))
                {
                    //throw new InvalidOperationException();
                }
            return res;
        }

        Tuple<TPriority> T(TPriority priority)
        {
            //TODO: pooling to save memory
            return Tuple.Create(priority);
        }


        public void Enqueue(TItem item)
        {
            Queue<TItem> queue = null;
            var key = T(getPriority(item));
            if (!binaryTree.TryGetValue(key, out queue))
                binaryTree[key] = queue = new Queue<TItem>();
            queue.Enqueue(item);
        }

        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            return this.GetItems().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetItems().GetEnumerator();
        }

        public TItem DequeueLast()
        {
            var kvp = binaryTree.Last();
            var res = kvp.Value.Dequeue();
            if (kvp.Value.Count == 0)
                binaryTree.Remove(kvp.Key);
            return res;
        }

        public TItem Peek()
        {
            var firstKvp = binaryTree.First();
            var res = firstKvp.Value.Peek();
            return res;
        }

        public TItem PeekLast()
        {
            var kvp = binaryTree.Last();
            var res = kvp.Value.Peek();
            return res;
        }

        public bool Contains(TItem item)
        {
            var itemPriority = T(getPriority(item));
            Queue<TItem> items = null;
            if (!binaryTree.TryGetValue(itemPriority, out items))
                return false;
            return items.Contains(item);
        }

        public void EnqueueRange(IEnumerable<TItem> items)
        {
            foreach (var item in items)
            {
                Enqueue(item);
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
