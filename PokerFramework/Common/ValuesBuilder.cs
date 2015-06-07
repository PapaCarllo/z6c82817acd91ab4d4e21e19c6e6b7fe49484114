using System;

namespace PokerFramework.Common
{
    public abstract class ValuesBuilder
    {
        private int? _count;

        public int Count
        {
            get
            {
                return _count ?? (int)(_count = CalculateCount());
            }
        }

        protected int Build<T>(ReadOnlyList<T> baseDictionary, Func<int> buildValues)
        {
            baseDictionary.ThrowIfIsImmutable();

            var offset = baseDictionary.Count;
            var builtValuesCount = buildValues();
            if (builtValuesCount != Count)
            {
                throw new Exception(
                    string.Format(
                        "Internal error occured during building values of the type {0}. The total amount of the built values {1} is not equal to the declared amount {2}.",
                        typeof(T).FullName,
                        builtValuesCount,
                        Count));
            }

            builtValuesCount = baseDictionary.Count - offset;
            if (builtValuesCount != Count)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Building values of the type {0} is failed. The total amount of the actually built values {1} is not equal to the declared amount {2}.",
                        typeof(T).FullName,
                        builtValuesCount,
                        Count));
            }

            return offset;
        }

        protected abstract int CalculateCount();
    }
}