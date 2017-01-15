using System;
using System.Collections.Generic;

namespace Mastersign.Sequence
{
    internal class CollectionSequence<T> : EnumerableSequence<T>
    {
        private readonly ICollection<T> source;

        public CollectionSequence(ICollection<T> values)
            : base(values)
        {
            if (values == null) throw new ArgumentNullException("values");
            source = values;
        }

        public override int Count()
        {
            return source.Count;
        }

        public override T[] ToArray()
        {
            var result = new T[source.Count];
            source.CopyTo(result, 0);
            return result;
        }

        public override ISequence<T> Realize()
        {
            return this;
        }
    }
}
