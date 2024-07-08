using System.Runtime.CompilerServices;

namespace UltimateOrb.Runtime.InteropServices {

    public static partial class DictionariesMarshal {

        class DictionaryDummy<TKey, TValue> where TKey : notnull {

            internal struct Entry {
                public uint hashCode;
                public int next;
                public TKey key;
                public TValue value;
            }
        }

        class Dictionary0Dummy<TKey, TValue> where TKey : notnull {
            internal int[]? _buckets;
            internal DictionaryDummy<TKey, TValue>.Entry[]? _entries;
            internal int _count;
            internal int _freeList;
            internal int _freeCount;
            internal int _version;
            internal IEqualityComparer<TKey>? _comparer;
            internal object? _keys;
            internal object? _values;
        }

        class Dictionary64Dummy<TKey, TValue> where TKey : notnull {
            internal int[]? _buckets;
            internal DictionaryDummy<TKey, TValue>.Entry[]? _entries;
            internal ulong _fastModMultiplier;
            internal int _count;
            internal int _freeList;
            internal int _freeCount;
            internal int _version;
            internal IEqualityComparer<TKey>? _comparer;
            internal object? _keys;
            internal object? _values;
        }

        // TODO: 
        // [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_entries")]
        private static ref DictionaryDummy<TKey, TValue>.Entry[]? GetEntries<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : notnull {
            if (8 == IntPtr.Size) {
                return ref Unsafe.As<Dictionary0Dummy<TKey, TValue>>(dictionary)._entries;
            } else {
                return ref Unsafe.As<Dictionary64Dummy<TKey, TValue>>(dictionary)._entries;
            }
        }

        [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_count")]
        private extern static ref int GetCount<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : notnull;

        public delegate void RefAction<T>(ref T arg);

        public static void ForEachValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, RefAction<TValue> action) where TKey : notnull {
            var entries = GetEntries(dictionary)!;
            var count = GetCount(dictionary);
            for (int i = 0; i < count; i++) {
                if (entries![i].next >= -1) {
                    action(ref entries[i].value);
                }
            }
        }
    }
}
