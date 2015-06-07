using PokerFramework.Common;
using PokerFramework.Core;

namespace PokerFramework
{
    public sealed class Pocket : Value<Pocket>
    {
        public readonly Card HighCard;

        public readonly Card LowCard;

        private readonly CardSet _cardSet;

        static Pocket()
        {
            Parser = PocketParser;

            var pocketBuilder = new ValuesCombinationsBuilder<Card>(false);
            Capacity = pocketBuilder.Count;
            Dictionary = pocketBuilder.Build((h, l) => new Pocket(h, l));

            Fix();
        }

        private Pocket(Card highCard, Card lowCard)
            : base(highCard + " " + lowCard)
        {
            _cardSet |= highCard;
            _cardSet |= lowCard;

            HighCard = highCard;
            LowCard = lowCard;
        }

        public static new ReadOnlyList<Pocket, Card, Card> Dictionary { get; private set; }

        public static implicit operator CardSet(Pocket pocket)
        {
            return pocket._cardSet;
        }

        public static implicit operator Pocket(string str)
        {
            return Parse(str);
        }

        private static Pocket PocketParser(string buffer, ref int position)
        {
            var card1 = Card.TryParse(buffer, ref position);
            if (ReferenceEquals(null, card1))
            {
                return null;
            }

            if (!TryParseDelimiter(buffer, ref position, " "))
            {
                return null;
            }

            var card2 = Card.TryParse(buffer, ref position);
            if (ReferenceEquals(null, card2))
            {
                return null;
            }

            return Dictionary[card1, card2];
        }
    }
}