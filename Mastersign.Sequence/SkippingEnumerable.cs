using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mastersign.Sequence
{
    internal class SkippingEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> source;
        private readonly int offset;

        public SkippingEnumerable(IEnumerable<T> values, int offset)
        {
            if (values == null) throw new ArgumentNullException("values");
            source = values;
            this.offset = offset;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var enumerator = source.GetEnumerator();
            for (int i = 0; i < offset; i++)
            {
                if (!enumerator.MoveNext()) break;
            }
            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
