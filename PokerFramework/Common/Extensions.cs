using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerFramework.Common
{
    public static class Empty<T>
    {
        public static T[] Array = new T[0];
    }

    public static class EnumerableExtension
    {
        public static T[] EnumerableToArray<T>(this IEnumerable<T> enumerable)
        {
            return EnumerableToArrayInternal(enumerable, -1);
        }

        public static T[] EnumerableToArray<T>(this IEnumerable<T> enumerable, int count)
        {
            if (count < 0)
            {
                throw new ArgumentException(
                    string.Format(
                        "Cannot copy the enumerable {0} to array. The argument 'count' has to be a non-negative integer. The specified value is {1}.",
                        enumerable.GetType().FullName,
                        count));
            }

            return EnumerableToArrayInternal(enumerable, count);
        }

        private static T[] EnumerableToArrayInternal<T>(IEnumerable<T> enumerable, int count)
        {
            if (count == 0)
            {
                return Empty<T>.Array;
            }

            var enumerableLength = -1;
            var array = enumerable as T[];
            if (!ReferenceEquals(null, array))
            {
                enumerableLength = array.Length;
                if (count < 0 || enumerableLength == count)
                {
                    if (enumerableLength == 0)
                    {
                        return Empty<T>.Array;
                    }

                    return (T[])array.Clone();
                }

                if (enumerableLength > count)
                {
                    var result = new T[count];
                    Array.Copy(array, result, count);
                    return result;
                }
            }
            else
            {
                var collection = enumerable as ICollection<T>;
                if (!ReferenceEquals(null, collection))
                {
                    enumerableLength = collection.Count;
                    if (count < 0 || enumerableLength == count)
                    {
                        var result = new T[enumerableLength];
                        if (enumerableLength > 0)
                        {
                            collection.CopyTo(result, 0);
                        }

                        return result;
                    }
                }
                else
                {
                    var readOnlyCollection = enumerable as IReadOnlyCollection<T>;
                    if (!ReferenceEquals(null, readOnlyCollection))
                    {
                        enumerableLength = readOnlyCollection.Count;
                        if (enumerableLength == 0)
                        {
                            return Empty<T>.Array;
                        }
                    }
                }
            }

            if (enumerableLength < 0 && count < 0)
            {
                return enumerable.ToArray();
            }

            if (enumerableLength < 0 || count <= enumerableLength)
            {
                var result = new T[count >= 0 ? count : enumerableLength];
                var index = 0;
                foreach (var item in enumerable)
                {
                    result[index++] = item;
                    if (index >= result.Length)
                    {
                        return result;
                    }
                }

                if (enumerableLength >= 0)
                {
                    throw new ArgumentException(
                        string.Format(
                            "Cannot copy the enumerable {0} to array. The enumerator has provided just {1} items instead of {2}.",
                            enumerable.GetType().FullName,
                            index,
                            enumerableLength));
                }

                enumerableLength = index;
            }

            throw new ArgumentException(
                string.Format(
                    "Cannot copy the enumerable {0} to array. The specified argument 'count' is {1}, it is great than the actuall collection size {2}.",
                    enumerable.GetType().FullName,
                    count,
                    enumerableLength));
        }
    }
}