using System;

namespace Mastersign.Sequence
{
    public delegate bool Predicate<T>(T value);

    public delegate T Combinator<T>(T a, T b);

    public delegate void IteratedAction<T>(T value, int i);
}
