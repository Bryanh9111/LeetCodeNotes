using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.Collections
{
    public interface IQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// Add item to queue
        /// </summary>
        /// <param name="item"></param>
        void Enqueue(T item);
        /// <summary>
        /// Add item to queue
        /// </summary>
        /// <param name="item"></param>
        void EnqueueRange(IEnumerable<T> items);
        /// <summary>
        /// Remove top item from queue
        /// </summary>
        /// <returns></returns>
        T Dequeue();
        /// <summary>
        /// Check if queue is empty
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Get item on the top of the queue, without removing it from the queue
        /// </summary>
        /// <returns></returns>
        T Peek();

        /// <summary>
        /// Check if the queue contains specified item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Contains(T item);
    }
}
