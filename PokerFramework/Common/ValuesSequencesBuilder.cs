using System;

namespace PokerFramework.Common
{
    public class ValuesSequencesBuilder<TValue1, TValue2> : ValuesBuilder
        where TValue1 : Value<TValue1> where TValue2 : Value<TValue2>
    {
        public ValuesSequencesBuilder()
        {
            Value<TValue1>.Dictionary.ThrowIfIsNotImmutable();
            Value<TValue2>.Dictionary.ThrowIfIsNotImmutable();
        }

        public ReadOnlyList<TSequence, TValue1, TValue2> Build<TSequence>(
            Func<TValue1, TValue2, TSequence> sequenceBuilder) where TSequence : Value<TSequence>
        {
            var baseDictionary = Value<TSequence>.Dictionary;
            var offset = Build(baseDictionary, () => BuildResultDictionaryValues((v1, v2) => sequenceBuilder(v1, v2)));
            return new ReadOnlyList<TSequence, TValue1, TValue2>(false, baseDictionary, offset, Count, GetSequenceIndex);
        }

        protected override sealed int CalculateCount()
        {
            return CalculateSequencesCount(Value<TValue1>.Dictionary.Count);
        }

        protected virtual int CalculateSequencesCount(int highValueDictionarySize)
        {
            return highValueDictionarySize * Value<TValue2>.Dictionary.Count;
        }

        protected virtual bool? CanBuildSequence(int value1Index, int value2Index)
        {
            return true;
        }

        protected virtual void ValidateAndFixSequence(ref int value1Index, ref int value2Index)
        {
        }

        private int BuildResultDictionaryValues(Action<TValue1, TValue2> sequenceBuilder)
        {
            var builtSequencesCount = 0;
            var value1Index = 0;
            foreach (var value1 in Value<TValue1>.Dictionary)
            {
                var value2Index = 0;
                foreach (var value2 in Value<TValue2>.Dictionary)
                {
                    var canBuildSequence = CanBuildSequence(value1Index, value2Index);
                    if (!canBuildSequence.HasValue)
                    {
                        break;
                    }

                    if (canBuildSequence.Value)
                    {
                        sequenceBuilder(value1, value2);
                        builtSequencesCount++;
                    }

                    value2Index++;
                }

                value1Index++;
            }

            return builtSequencesCount;
        }

        private int GetSequenceIndex(TValue1 value1, TValue2 value2)
        {
            var value1Index = (int)(Value<TValue1>)value1;
            var value2Index = (int)(Value<TValue2>)value2;

            ValidateAndFixSequence(ref value1Index, ref value2Index);

            return CalculateSequencesCount(value1Index) + value2Index;
        }
    }
}