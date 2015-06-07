using PokerFramework.Common;
using PokerFramework.Core;

namespace PokerFramework
{
    public sealed class CardRank : Value<CardRank>
    {
        public static readonly CardRank Ace;

        public static readonly CardRank Eight;

        public static readonly CardRank Five;

        public static readonly CardRank Four;

        public static readonly CardRank Jack;

        public static readonly CardRank King;

        public static readonly CardRank Nine;

        public static readonly CardRank Queen;

        public static readonly CardRank Seven;

        public static readonly CardRank Six;

        public static readonly CardRank Ten;

        public static readonly CardRank Three;

        public static readonly CardRank Two;

        public readonly string Name;

        public readonly string PluralName;

        private readonly CardSet _cardSet;

        static CardRank()
        {
            Parser = RankParser;

            Capacity = 13;
            Two = new CardRank(CardSet.Deuces, "2", "Two", "Deuces");
            Three = new CardRank(CardSet.Threes, "3", "Three", "Threes");
            Four = new CardRank(CardSet.Fours, "4", "Four", "Fours");
            Five = new CardRank(CardSet.Fives, "5", "Five", "Fives");
            Six = new CardRank(CardSet.Sixes, "6", "Six", "Sixes");
            Seven = new CardRank(CardSet.Sevens, "7", "Seven", "Sevens");
            Eight = new CardRank(CardSet.Eights, "8", "Eight", "Eights");
            Nine = new CardRank(CardSet.Nines, "9", "Nine", "Nines");
            Ten = new CardRank(CardSet.Tens, "T", "Ten", "Tens");
            Jack = new CardRank(CardSet.Jacks, "J", "Jack", "Jacks");
            Queen = new CardRank(CardSet.Queens, "Q", "Queen", "Queens");
            King = new CardRank(CardSet.Kings, "K", "King", "Kings");
            Ace = new CardRank(CardSet.Aces, "A", "Ace", "Aces");

            Fix();
        }

        private CardRank(CardSet cardSet, string id, string name, string pluralName)
            : base(id)
        {
            _cardSet = cardSet;

            Name = name;
            PluralName = pluralName;
        }

        public static implicit operator CardSet(CardRank rank)
        {
            return rank._cardSet;
        }

        private static CardRank RankParser(string buffer, ref int position)
        {
            var id = buffer[position++];

            switch (id)
            {
                case '2':
                    return Two;
                case '3':
                    return Three;
                case '4':
                    return Four;
                case '5':
                    return Five;
                case '6':
                    return Six;
                case '7':
                    return Seven;
                case '8':
                    return Eight;
                case '9':
                    return Nine;
            }

            switch (id)
            {
                case 'A':
                    return Ace;
                case 'J':
                    return Jack;
                case 'K':
                    return King;
                case 'Q':
                    return Queen;
                case 'T':
                    return Ten;
            }

            position--;
            return null;
        }
    }
}