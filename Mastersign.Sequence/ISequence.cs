using System;
using System.Collections.Generic;

namespace Mastersign.Sequence
{
    public interface ISequence<T> : IEnumerable<T>
    {
        int Count();

        void ForEach(Action<T> action);

        void ForEach(IndexedAction<T> action);

        ISequence<T> Skip(int n);

        ISequence<T> Take(int n);

        ISequence<T> Filter(Predicate<T> pred);

        ISequence<T> Filter(IndexedPredicate<T> pred);

        ISequence<TResult> Map<TResult>(Converter<T, TResult> transform);

        ISequence<TResult> Map<TResult>(IndexedConverter<T, TResult> transform);

        T Reduce(Combinator<T> comb);

        T Reduce(Combinator<T> comb, T initialValue);

        T First(Predicate<T> pred);

        T FirstOrDefault(Predicate<T> pred);

        bool All(Predicate<T> pred);

        bool Any(Predicate<T> pred);

        ISequence<TResult> Cast<TResult>();

        ISequence<TResult> OfType<TResult>();

        ISequence<T> Realize();

        T[] ToArray();

        List<T> ToList();

        Dictionary<TKey, T> ToDictionary<TKey>(Converter<T, TKey> keySelector);

        Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            Converter<T, TKey> keySelector, Converter<T, TValue> valueSelector);
    }
}
