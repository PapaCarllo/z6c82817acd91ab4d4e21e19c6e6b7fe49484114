using System;

namespace PokerFramework.Common
{
    public sealed class ValuesWrappersBuilder<TValue> : ValuesBuilder
        where TValue : Value<TValue>
    {
        private readonly int _fromValueIndex;

        private readonly int _tillValueIndex;

        public ValuesWrappersBuilder()
        {
            Value<TValue>.Dictionary.ThrowIfIsNotImmutable();

            _fromValueIndex = 0;
            _tillValueIndex = Value<TValue>.Dictionary.Count - 1;
        }

        public ValuesWrappersBuilder(TValue fromValue)
            : this()
        {
            _fromValueIndex = (int)(Value<TValue>)fromValue;
        }

        public ValuesWrappersBuilder(TValue fromValue, TValue tillValue)
            : this(fromValue)
        {
            _tillValueIndex = (int)(Value<TValue>)tillValue;

            if (_fromValueIndex > _tillValueIndex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Index of the 'fromValue' parameter has to be less or equal than index of the 'tillValue'"));
            }
        }

        public ReadOnlyList<TWrapper, TValue> Build<TWrapper>(Func<TValue, TWrapper> wrapperBuilder)
            where TWrapper : Value<TWrapper>
        {
            var baseDictionary = Value<TWrapper>.Dictionary;
            var offset = Build(baseDictionary, () => BuildResultDictionaryValues(v => wrapperBuilder(v)));
            return new ReadOnlyList<TWrapper, TValue>(false, baseDictionary, offset, Count, GetWrapperIndex);
        }

        protected override int CalculateCount()
        {
            return _tillValueIndex - _fromValueIndex + 1;
        }

        private int BuildResultDictionaryValues(Action<TValue> wrapperBuilder)
        {
            for (var index = _fromValueIndex; index <= _tillValueIndex; index++)
            {
                wrapperBuilder(Value<TValue>.Dictionary[index]);
            }

            return Count;
        }

        private int GetWrapperIndex(TValue value)
        {
            var valueIndex = (int)(Value<TValue>)value;

            if (valueIndex < _fromValueIndex || valueIndex > _tillValueIndex)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        "A specified value {{{0}}} of the type {1} is not included into allowed values range.",
                        value,
                        typeof(TValue).FullName));
            }

            return valueIndex - _fromValueIndex;
        }
    }
}