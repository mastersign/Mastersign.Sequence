using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mastersign.Sequence
{
    internal class LimitingEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> source;
        private readonly int maxCount;

        public LimitingEnumerable(IEnumerable<T> values, int maxCount)
        {
            if (values == null) throw new ArgumentNullException("values");
            source = values;
            this.maxCount = maxCount;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var i = 0;
            foreach (var v in source)
            {
                if (i >= maxCount) break;
                yield return v;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
