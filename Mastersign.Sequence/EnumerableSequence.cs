using System;
using System.Collections.Generic;

namespace Mastersign.Sequence
{
    internal class EnumerableSequence<T> : ISequence<T>
    {
        private readonly IEnumerable<T> source;

        public EnumerableSequence(IEnumerable<T> values)
        {
            if (values == null) throw new ArgumentNullException("values");
            source = values;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return source.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return source.GetEnumerator();
        }

        public virtual int Count()
        {
            return SequenceLib.Count(source);
        }

        public virtual void ForEach(Action<T> action)
        {
            SequenceLib.ForEach(source, action);
        }

        public virtual void ForEach(IteratedAction<T> action)
        {
            SequenceLib.ForEach(source, action);
        }

        public ISequence<T> Filter(Predicate<T> pred)
        {
            return new EnumerableSequence<T>(SequenceLib.Filter(source, pred));
        }

        public ISequence<TResult> Map<TResult>(Converter<T, TResult> transform)
        {
            return new EnumerableSequence<TResult>(SequenceLib.Map(source, transform));
        }

        public T Reduce(Combinator<T> comb)
        {
            return SequenceLib.Reduce(source, comb);
        }

        public T Reduce(Combinator<T> comb, T initialValue)
        {
            return SequenceLib.Reduce(source, comb, initialValue);
        }

        public T First(Predicate<T> pred)
        {
            return SequenceLib.First(source, pred);
        }

        public T FirstOrDefault(Predicate<T> pred)
        {
            return SequenceLib.FirstOrDefault(source, pred);
        }

        public bool All(Predicate<T> pred)
        {
            return SequenceLib.All(source, pred);
        }

        public bool Any(Predicate<T> pred)
        {
            return SequenceLib.Any(source, pred);
        }

        public ISequence<TResult> Cast<TResult>()
        {
            return new EnumerableSequence<TResult>(SequenceLib.Cast<T, TResult>(source));
        }

        public ISequence<TResult> OfType<TResult>()
        {
            return new EnumerableSequence<TResult>(SequenceLib.OfType<T, TResult>(source));
        }

        public virtual T[] ToArray()
        {
            return new List<T>(source).ToArray();
        }

        public List<T> ToList()
        {
            return new List<T>(source);
        }

        public Dictionary<TKey, T> ToDictionary<TKey>(Converter<T, TKey> keySelector)
        {
            return SequenceLib.ToDictionary<T, TKey>(source, keySelector);
        }

        public Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            Converter<T, TKey> keySelector, Converter<T, TValue> valueSelector)
        {
            return SequenceLib.ToDictionary<T, TKey, TValue>(source, keySelector, valueSelector);
        }

        public virtual ISequence<T> Realize()
        {
            return new CollectionSequence<T>(new List<T>(source));
        }
    }
}
