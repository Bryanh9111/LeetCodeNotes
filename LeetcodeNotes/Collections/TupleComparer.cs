using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.Collections
{
    /// <summary>
    /// Required to support adding Null as a Key to dictionaries (Nullable Priority to PriorityQueue)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TupleComparer<T> : IComparer<Tuple<T>>
    {
        public TupleComparer(IComparer<T> source)
        {
            this.Source = source ?? Comparer<T>.Default;
        }

        public IComparer<T> Source { get; private set; }

        public int Compare(Tuple<T> x, Tuple<T> y)
        {
            return Source.Compare(x.Item1, y.Item1);
        }
    }
}
