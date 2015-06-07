using System;

namespace PokerFramework.Common
{
    public sealed class ValuesPermutationsBuilder<TValue> : ValuesSequencesBuilder<TValue, TValue>
        where TValue : Value<TValue>
    {
        private readonly int _lowValueDictionarySize;

        public ValuesPermutationsBuilder(bool withRepetitions)
        {
            _lowValueDictionarySize = Value<TValue>.Dictionary.Count - (withRepetitions ? 0 : 1);
            WithRepetitions = withRepetitions;
        }

        public bool WithRepetitions { get; private set; }

        protected override int CalculateSequencesCount(int highValueDictionarySize)
        {
            return highValueDictionarySize * _lowValueDictionarySize;
        }

        protected override bool? CanBuildSequence(int value1Index, int value2Index)
        {
            return WithRepetitions || value1Index != value2Index;
        }

        protected override void ValidateAndFixSequence(ref int value1Index, ref int value2Index)
        {
            if (WithRepetitions)
            {
                return;
            }

            if (value1Index == value2Index)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        "A permutation of two non-repeated values of the type {0} cannot contain the same value {{{1}}} twice.",
                        typeof(TValue).FullName,
                        Value<TValue>.Dictionary[value1Index]));
            }

            if (value1Index < value2Index)
            {
                value2Index--;
            }
        }
    }
}