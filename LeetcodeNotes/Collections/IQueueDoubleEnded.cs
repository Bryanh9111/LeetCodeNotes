using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.Collections
{
    /// <summary>
    /// Double ended queue, allowing to dequeue from top and bottom of the queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueueDoubleEnded<T> : IQueue<T>
    {
        /// <summary>
        /// Dequeue from the bottom of the queue
        /// </summary>
        /// <returns></returns>
        T DequeueLast();

        /// <summary>
        /// Get the last item of the queue
        /// </summary>
        /// <returns></returns>
        T PeekLast();
    }
}
