using System;
using System.Collections.Generic;

namespace Mastersign.Sequence
{
    public static class SequenceLib
    {
        public static int Count<T>(IEnumerable<T> values)
        {
            var enumerator = values.GetEnumerator();
            var result = 0;
            while (enumerator.MoveNext())
            {
                result++;
            }
            return result;
        }

        public static void ForEach<T>(IEnumerable<T> values, Action<T> action)
        {
            foreach (T v in values)
            {
                action(v);
            }
        }

        public static void ForEach<T>(IEnumerable<T> values, IteratedAction<T> action)
        {
            var i = 0;
            foreach (T v in values)
            {
                action(v, i);
                i++;
            }
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> values, Predicate<T> pred)
        {
            foreach (T v in values)
            {
                if (pred(v))
                {
                    yield return v;
                }
            }
        }

        public static IEnumerable<TResult> Map<TSource, TResult>(
            IEnumerable<TSource> values, Converter<TSource, TResult> transform)
        {
            foreach (TSource v in values)
            {
                yield return transform(v);
            }
        }

        public static T Reduce<T>(IEnumerable<T> values, Combinator<T> comb)
        {
            var enumerator = values.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new ArgumentOutOfRangeException();
            }
            T v = enumerator.Current;
            while (enumerator.MoveNext())
            {
                v = comb(v, enumerator.Current);
            }
            return v;
        }

        public static T Reduce<T>(IEnumerable<T> values, Combinator<T> comb, T initialValue)
        {
            T v = initialValue;
            foreach (T v2 in values)
            {
                v = comb(v, v2);
            }
            return v;
        }

        public static T First<T>(IEnumerable<T> values, Predicate<T> pred)
        {
            foreach (T v in values)
            {
                if (pred(v))
                {
                    return v;
                }
            }
            throw new ArgumentOutOfRangeException("values", "The predicate never matched.");
        }

        public static T FirstOrDefault<T>(IEnumerable<T> values, Predicate<T> pred)
        {
            foreach (T v in values)
            {
                if (pred(v))
                {
                    return v;
                }
            }
            return default(T);
        }

        public static bool All<T>(IEnumerable<T> values, Predicate<T> pred)
        {
            foreach (T v in values)
            {
                if (!pred(v)) return false;
            }
            return true;
        }

        public static bool Any<T>(IEnumerable<T> values, Predicate<T> pred)
        {
            foreach (T v in values)
            {
                if (pred(v)) return true;
            }
            return false;
        }

        public static IEnumerable<TResult> Cast<TSource, TResult>(IEnumerable<TSource> values)
        {
            foreach (object v in values)
            {
                yield return (TResult)v;
            }
        }

        public static IEnumerable<TResult> OfType<TSource, TResult>(IEnumerable<TSource> values)
        {
            foreach (object v in values)
            {
                if (v is TResult)
                {
                    yield return (TResult)v;
                }
            }
        }

        public static Dictionary<TKey, T> ToDictionary<T, TKey>(IEnumerable<T> values,
            Converter<T, TKey> keySelector)
        {
            var dict = new Dictionary<TKey, T>();
            foreach (T v in values)
            {
                dict[keySelector(v)] = v;
            }
            return dict;
        }

        public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(IEnumerable<T> values,
            Converter<T, TKey> keySelector, Converter<T, TValue> valueSelector)
        {
            var dict = new Dictionary<TKey, TValue>();
            foreach (T v in values)
            {
                dict[keySelector(v)] = valueSelector(v);
            }
            return dict;
        }
    }
}
