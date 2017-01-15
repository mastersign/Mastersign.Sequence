using System;

namespace Mastersign.Sequence
{
    public delegate bool Predicate<T>(T value);

    public delegate bool IndexedPredicate<T>(T value, int i);

    public delegate TResult IndexedConverter<TSource, TResult>(TSource v, int i);

    public delegate T Combinator<T>(T a, T b);

    public delegate void IndexedAction<T>(T value, int i);
}
