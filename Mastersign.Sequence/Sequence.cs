using System;
using System.Collections.Generic;

namespace Mastersign.Sequence
{
    public static class Sequence
    {
        public static ISequence<T> Seq<T>(ICollection<T> values)
        {
            return new CollectionSequence<T>(values);
        }

        public static ISequence<T> Seq<T>(IEnumerable<T> values)
        {
            return new EnumerableSequence<T>(values);
        }
    }
}
