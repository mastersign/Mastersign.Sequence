Mastersign.Sequence
===================

> A CLR 2.0 compatible alternative to LINQ

This small library aims to be an alternative to LINQ in C# programs,
which target the Common Language Runtime version 2.0.

## Example
With `static` `using` statement &ndash;
requires a compiler for C# 6 or higher:

```csharp
using static Mastersign.Sequence.Sequence;
...

var myData = new [] {1, 2, 3, 4};
var transformed = Seq(myData).Map(v => v * 2).ToArray();
```

Without the `static` `using` statement:

```csharp
using Mastersign.Sequence;
...

var myData = new [] {1, 2, 3, 4};
var transformed = Sequence.Seq(myData).Map(v => v * 2).ToArray();
```

## Limitations
This library does not provide an interface like `IQueryable<T>`
to interact with data sources not in memory.

This library is not compatible with the syntax sugar of LINQ,
because it can not use extension methods, which are only available
in the Microsoft .NET Framework 3.0 and higher.

## License
MIT
