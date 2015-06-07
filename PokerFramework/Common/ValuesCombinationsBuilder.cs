using System;

namespace PokerFramework.Common
{
    public sealed class ValuesCombinationsBuilder<TValue> : ValuesSequencesBuilder<TValue, TValue>
        where TValue : Value<TValue>
    {
        public ValuesCombinationsBuilder(bool withRepetitions)
        {
            WithRepetitions = withRepetitions;
        }

        public bool WithRepetitions { get; private set; }

        protected override int CalculateSequencesCount(int highValueDictionarySize)
        {
            var modifier = WithRepetitions ? 1 : -1;

            if ((highValueDictionarySize & 1) == 0)
            {
                return (highValueDictionarySize >> 1) * (highValueDictionarySize + modifier);
            }

            return ((highValueDictionarySize + modifier) >> 1) * highValueDictionarySize;
        }

        protected override bool? CanBuildSequence(int value1Index, int value2Index)
        {
            if (WithRepetitions)
            {
                value2Index++;
            }

            return value1Index <= value2Index ? null : (bool?)true;
        }

        protected override void ValidateAndFixSequence(ref int value1Index, ref int value2Index)
        {
            if (value1Index < value2Index)
            {
                var highIndex = value2Index;
                value2Index = value1Index;
                value1Index = highIndex;
            }

            if (WithRepetitions)
            {
                return;
            }

            if (value1Index == value2Index)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        "A combination of two non-repeated values of the type {0} cannot contain the same value {{{1}}} twice.",
                        typeof(TValue).FullName,
                        Value<TValue>.Dictionary[value1Index]));
            }
        }
    }
}