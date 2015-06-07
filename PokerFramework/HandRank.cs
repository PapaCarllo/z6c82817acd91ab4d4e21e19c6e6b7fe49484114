using PokerFramework.Common;

namespace PokerFramework
{
    public class HandRank : Value<HandRank>
    {
        public static readonly ReadOnlyList<HandRank, CardRank> Flushes;

        public static readonly ReadOnlyList<HandRank, CardRank> FourOfAKinds;

        public static readonly ReadOnlyList<HandRank, CardRank, CardRank> FullHouses;

        public static readonly ReadOnlyList<HandRank, CardRank> HighCards;

        public static readonly ReadOnlyList<HandRank, CardRank> OnePairs;

        public static readonly HandRank RoyalFlush;

        public static readonly ReadOnlyList<HandRank, CardRank> StraightFlushes;

        public static readonly ReadOnlyList<HandRank, CardRank> Straights;

        public static readonly ReadOnlyList<HandRank, CardRank> ThreeOfAKinds;

        public static readonly ReadOnlyList<HandRank, CardRank, CardRank> TwoPairs;

        static HandRank()
        {
            var bHighCards = new ValuesWrappersBuilder<CardRank>();
            var bOnePairs = new ValuesWrappersBuilder<CardRank>();
            var bTwoPairs = new ValuesCombinationsBuilder<CardRank>(false);
            var bThreeOfAKinds = new ValuesWrappersBuilder<CardRank>();
            var bStraights = new ValuesWrappersBuilder<CardRank>(CardRank.Five);
            var bFlushes = new ValuesWrappersBuilder<CardRank>(CardRank.Seven);
            var bFullHouses = new ValuesPermutationsBuilder<CardRank>(false);
            var bFourOfAKinds = new ValuesWrappersBuilder<CardRank>();
            var bStraightFlushes = new ValuesWrappersBuilder<CardRank>(CardRank.Five, CardRank.King);

            Capacity = bHighCards.Count + bOnePairs.Count + bTwoPairs.Count + bThreeOfAKinds.Count + bStraights.Count
                       + bFlushes.Count + bFullHouses.Count + bFourOfAKinds.Count + bStraightFlushes.Count + 1;

            HighCards = bHighCards.Build<HandRank>(cr => new HighCardRank(cr));
            OnePairs = bOnePairs.Build<HandRank>(cr => new OnePairRank(cr));
            TwoPairs = bTwoPairs.Build<HandRank>((h, l) => new TwoPairRank(h, l));
            ThreeOfAKinds = bThreeOfAKinds.Build<HandRank>(cr => new ThreeOfAKindRank(cr));
            Straights = bStraights.Build<HandRank>(cr => new StraightRank(cr));
            Flushes = bFlushes.Build<HandRank>(cr => new FlushRank(cr));
            FullHouses = bFullHouses.Build<HandRank>((t, d) => new FullHouseRank(t, d));
            FourOfAKinds = bFourOfAKinds.Build<HandRank>(cr => new FourOfAKindRank(cr));
            StraightFlushes = bStraightFlushes.Build<HandRank>(cr => new StraightFlushRank(cr));
            RoyalFlush = new RoyalFlushRank();

            Fix();
        }

        private HandRank(string id)
            : base(id)
        {
        }

        private class FlushRank : HandRank
        {
            public FlushRank(CardRank highCardRank)
                : base(string.Format("a flush, {0} high", highCardRank.Name))
            {
            }
        }

        private class FourOfAKindRank : HandRank
        {
            public FourOfAKindRank(CardRank cardsRank)
                : base(string.Format("four of a kind, {0}", cardsRank.PluralName))
            {
            }
        }

        private class FullHouseRank : HandRank
        {
            public FullHouseRank(CardRank tripleCardRank, CardRank dupleCardRank)
                : base(
                    string.Format("a full house, {0} full of {1}", tripleCardRank.PluralName, dupleCardRank.PluralName))
            {
            }
        }

        private class HighCardRank : HandRank
        {
            public HighCardRank(CardRank cardRank)
                : base(string.Format("high card {0}", cardRank.Name))
            {
            }
        }

        private class OnePairRank : HandRank
        {
            public OnePairRank(CardRank cardsRank)
                : base(string.Format("a pair of {0}", cardsRank.PluralName))
            {
            }
        }

        private class RoyalFlushRank : HandRank
        {
            public RoyalFlushRank()
                : base("a Royal Flush")
            {
            }
        }

        private class StraightFlushRank : HandRank
        {
            public StraightFlushRank(CardRank highCardRank)
                : base(
                    string.Format(
                        "a straight flush, {0} to {1}",
                        StraightRank.GetLowCard(highCardRank).Name,
                        highCardRank.Name))
            {
            }
        }

        private class StraightRank : HandRank
        {
            public StraightRank(CardRank highCardRank)
                : base(string.Format("a straight, {0} to {1}", GetLowCard(highCardRank).Name, highCardRank.Name))
            {
            }

            public static CardRank GetLowCard(CardRank highCard)
            {
                return highCard == CardRank.Five ? CardRank.Ace : CardRank.Dictionary[(int)highCard - 4];
            }
        }

        private class ThreeOfAKindRank : HandRank
        {
            public ThreeOfAKindRank(CardRank cardsRank)
                : base(string.Format("three of a kind, {0}", cardsRank.PluralName))
            {
            }
        }

        private class TwoPairRank : HandRank
        {
            public TwoPairRank(CardRank highCardRank, CardRank lowCardRank)
                : base(string.Format("two pair, {0} and {1}", highCardRank.PluralName, lowCardRank.PluralName))
            {
            }
        }
    }
}