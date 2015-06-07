using PokerFramework.Common;
using PokerFramework.Core;

namespace PokerFramework
{
    public sealed class CardSuit : Value<CardSuit>
    {
        public static readonly CardSuit Club;

        public static readonly CardSuit Diamond;

        public static readonly CardSuit Heart;

        public static readonly CardSuit Spade;

        private readonly CardSet _cardSet;

        static CardSuit()
        {
            Parser = SuitParser;

            Capacity = 4;
            Club = new CardSuit(CardSet.Clubs, "c");
            Diamond = new CardSuit(CardSet.Diamonds, "d");
            Heart = new CardSuit(CardSet.Hearts, "h");
            Spade = new CardSuit(CardSet.Spades, "s");

            Fix();
        }

        private CardSuit(CardSet cardSet, string id)
            : base(id)
        {
            _cardSet = cardSet;
        }

        public static implicit operator CardSet(CardSuit suit)
        {
            return suit._cardSet;
        }

        private static CardSuit SuitParser(string buffer, ref int position)
        {
            switch (buffer[position++])
            {
                case 'c':
                    return Club;
                case 'd':
                    return Diamond;
                case 'h':
                    return Heart;
                case 's':
                    return Spade;
            }

            position--;
            return null;
        }
    }
}