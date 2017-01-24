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

        private static IEnumerable<object> TypedEnumerable(System.Collections.IEnumerable values)
        {
            foreach (var value in values) yield return value;
        }

        public static ISequence<object> Seq(System.Collections.IEnumerable values)
        {
            return new EnumerableSequence<object>(TypedEnumerable(values));
        }

        public static ISequence<T> Seq<T>(System.Collections.IEnumerable values)
        {
            return new EnumerableSequence<object>(TypedEnumerable(values)).Cast<T>();
        }
    }
}
