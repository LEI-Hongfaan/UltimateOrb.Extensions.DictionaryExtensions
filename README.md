# UltimateOrb.Extensions.DictionaryExtensions
UltimateOrb Core libraries.

Installation
====
Add the library to your project via NuGet:
```
dotnet add package UltimateOrb.Runtime.InteropServices.Collections
```

Usage
====
```CSharp
var dictionary = new Dictionary<string, int> {
    { "one", 1 },
    { "two", 2 },
    { "three", 3 },
};

DictionariesMarshal.ForEachValue(dictionary, (ref int value) => value *= 2);

Assert.Equal(2, dictionary["one"]);
Assert.Equal(4, dictionary["two"]);
Assert.Equal(6, dictionary["three"]);
```
Note: Changing a value should not affect the equality of its key.

Caution
====
This library relies on the internal structures of the `Dictionary` and other classes, which may change between different versions of .NET. Use it with caution.

License
====
This project is licensed under the MIT License.
