using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PokerFramework.Common
{
    public abstract class Value<TValue>
        where TValue : Value<TValue>
    {
        protected static ParserDelegate Parser = DefaultParser;

        private static readonly Comparer<TValue> IdsComparer =
            Comparer<TValue>.Create(
                (value1, value2) => string.Compare(value1._id, value2._id, StringComparison.Ordinal));

        private static readonly List<TValue> ValuesOrderedById = new List<TValue>();

        private static readonly List<TValue> ValuesOrderedByIndex = new List<TValue>();

        private readonly string _id;

        private readonly int _index;

        // ReSharper disable once StaticFieldInGenericType
        private static bool _isImmutable;

        static Value()
        {
            Dictionary = new ValuesDictionary(ValuesOrderedByIndex);
            RuntimeHelpers.RunClassConstructor(typeof(TValue).TypeHandle);
        }

        protected Value(string id)
        {
            var thisValue = this as TValue;
            if (ReferenceEquals(null, thisValue))
            {
                throw new InvalidOperationException(
                    string.Format(
                        "The type {0} has to be derived from the type {1}.",
                        GetType().FullName,
                        typeof(TValue).FullName));
            }

            if (_isImmutable)
            {
                throw new InvalidOperationException(
                    string.Format("The type {0} is locked for adding new values.", typeof(TValue).FullName));
            }

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException(
                    string.Format(
                        "Id of a value of the type {0} has to be a non-empty string.",
                        typeof(TValue).FullName));
            }

            _id = id;
            var idPosition = ValuesOrderedById.BinarySearch(thisValue, IdsComparer);
            if (idPosition >= 0)
            {
                throw new ArgumentException(
                    string.Format("The value of the type {0} with id '{1}' has already exist.", typeof(TValue), _id));
            }

            ValuesOrderedById.Insert(~idPosition, thisValue);

            _index = ValuesOrderedByIndex.Count;
            ValuesOrderedByIndex.Add(thisValue);
        }

        protected delegate TValue ParserDelegate(string buffer, ref int position);

        public static ReadOnlyList<TValue> Dictionary { get; private set; }

        protected static int Capacity
        {
            get
            {
                return ValuesOrderedByIndex.Capacity;
            }

            set
            {
                ValuesOrderedByIndex.Capacity = value;
                ValuesOrderedById.Capacity = value;
            }
        }

        public static TValue Parse(string buffer)
        {
            var position = 0;
            var value = TryParse(buffer, ref position);
            if (!ReferenceEquals(null, value) && position == buffer.Length)
            {
                return value;
            }

            var errorReason = (position >= buffer.Length)
                ? "Unexpected end of the buffer has been reached"
                : string.Format("Invalid character at the position {0}", position + 1);

            throw new InvalidOperationException(
                string.Format(
                    "Cannot parse a value of the type {0} from the string '{1}'. {2}.",
                    typeof(TValue).FullName,
                    buffer,
                    errorReason));
        }

        public static TValue TryParse(string buffer, ref int position)
        {
            if (position >= buffer.Length || ValuesOrderedById.Count == 0)
            {
                return null;
            }

            return Parser(buffer, ref position);
        }

        public static explicit operator string(Value<TValue> value)
        {
            return value._id;
        }

        public static explicit operator int(Value<TValue> value)
        {
            return value._index;
        }

        public override string ToString()
        {
            return _id;
        }

        public void Write(StringBuilder buffer)
        {
            buffer.Append(_id);
        }

        protected static TValue DefaultParser(string buffer, ref int position)
        {
            TValue result = null;
            var low = 0;
            var high = ValuesOrderedById.Count - 1;
            var vPos = 0;
            var rPos = position;
            var b = buffer[rPos];

            do
            {
                var middle = (low >> 1) + ((high + 1) >> 1);
                var cmp = ValuesOrderedById[middle]._id[vPos] - b;
                if (cmp > 0)
                {
                    high = middle - 1;
                }
                else if (cmp < 0)
                {
                    low = middle + 1;
                }
                else
                {
                    var middle2 = middle;
                    while (low < middle2)
                    {
                        var lookup = (low >> 1) + (middle2 >> 1);
                        if (ValuesOrderedById[lookup]._id[vPos] == b)
                        {
                            middle2 = lookup;
                        }
                        else
                        {
                            low = lookup + 1;
                        }
                    }

                    while (middle < high)
                    {
                        var lookup = (middle >> 1) + (high >> 1) + 1;
                        if (ValuesOrderedById[lookup]._id[vPos] == b)
                        {
                            middle = lookup;
                        }
                        else
                        {
                            high = lookup - 1;
                        }
                    }

                    var candidate = ValuesOrderedById[low];
                    if (++vPos >= candidate._id.Length)
                    {
                        result = candidate;
                        low++;
                    }

                    if (++rPos >= buffer.Length)
                    {
                        break;
                    }

                    b = buffer[rPos];
                }
            }
            while (low <= high);

            if (ReferenceEquals(null, result))
            {
                position = rPos;
            }
            else
            {
                position += result._id.Length;
            }

            return result;
        }

        protected static void Fix()
        {
            if (!_isImmutable)
            {
                ValuesOrderedByIndex.Capacity = ValuesOrderedByIndex.Count;
                ValuesOrderedById.Capacity = ValuesOrderedById.Count;
                _isImmutable = true;
            }
        }

        protected static bool TryParseDelimiter(string buffer, ref int position, string delimiter)
        {
            for (var dPos = 0; dPos < delimiter.Length; position++, dPos++)
            {
                if (position >= buffer.Length || delimiter[dPos] != buffer[position])
                {
                    return false;
                }
            }

            return true;
        }

        private class ValuesDictionary : ReadOnlyList<TValue>
        {
            public ValuesDictionary(IList<TValue> baseList)
                : base(false, baseList, 0, null)
            {
            }

            public override bool IsImmutable
            {
                get
                {
                    return _isImmutable;
                }
            }

            public override bool Contains(TValue item)
            {
                return true;
            }

            public override int IndexOf(TValue item)
            {
                return item._index;
            }
        }
    }
}