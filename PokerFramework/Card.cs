using PokerFramework.Common;
using PokerFramework.Core;

namespace PokerFramework
{
    public sealed class Card : Value<Card>
    {
        public readonly CardRank Rank;

        public readonly CardSuit Suit;

        private readonly CardSet _cardSet;

        static Card()
        {
            Parser = CardParser;

            var cardsBuilder = new ValuesSequencesBuilder<CardRank, CardSuit>();
            Capacity = cardsBuilder.Count;
            Dictionary = cardsBuilder.Build((rank, suit) => new Card(rank, suit));

            Fix();
        }

        private Card(CardRank rank, CardSuit suit)
            : base((string)rank + (string)suit)
        {
            _cardSet |= rank;
            _cardSet &= suit;

            Rank = rank;
            Suit = suit;
        }

        public static new ReadOnlyList<Card, CardRank, CardSuit> Dictionary { get; private set; }

        public static implicit operator CardSet(Card card)
        {
            return card._cardSet;
        }

        public static implicit operator Card(string str)
        {
            return Parse(str);
        }

        private static Card CardParser(string buffer, ref int position)
        {
            var rank = CardRank.TryParse(buffer, ref position);
            if (ReferenceEquals(null, rank))
            {
                return null;
            }

            var suit = CardSuit.TryParse(buffer, ref position);
            if (ReferenceEquals(null, suit))
            {
                return null;
            }

            return Dictionary[rank, suit];
        }
    }
}