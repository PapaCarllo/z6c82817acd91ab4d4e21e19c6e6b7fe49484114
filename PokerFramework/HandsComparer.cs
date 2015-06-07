using PokerFramework.Core;

namespace PokerFramework
{
    public class HandsComparer
    {
        public static readonly ulong[] Deck;

        public uint TestCalcHeroWinOdds()
        {
            CardSet[] opponentPockets = { CardSet._As | CardSet._Ah };
            var heroWinOdds = new uint[opponentPockets.Length];
            heroWinOdds[0] = 10;
            return Api.CalcHeroWinOdds(CardSet._Ac | CardSet._Ad, CardSet.Empty, CardSet.Empty, opponentPockets, heroWinOdds);
        }

        static HandsComparer()
        {
            Deck = new ulong[Card.Dictionary.Count];
            foreach (var card in Card.Dictionary)
            {
                Deck[(int)card] = (ulong)(CardSet)card;
            }
        }

        private ulong _knownCards;

        private static int _x;

        private readonly int[] _loopCardIndices = { Deck.Length, 0, 0, 0, 0 };

        public int lComparer()
        {
            var maxDepth = 4;

            var depth = 0;
            var cardIndex = maxDepth;
            while (true)
            {
                var card = Deck[cardIndex];
                if (0 == (_knownCards & card))
                {
                    _knownCards |= card;
                    if (depth < maxDepth)
                    {
                        _loopCardIndices[++depth] = cardIndex;
                        cardIndex = maxDepth - depth;
                        continue;
                    }

                    _x++;
                    var h = new Hand();
                    h.InitHand(_knownCards);

                    _knownCards ^= card;
                }

                while (++cardIndex >= _loopCardIndices[depth])
                {
                    if (depth == 0)
                    {
                        return _x;
                    }

                    _knownCards ^= Deck[cardIndex];
                    depth--;
                }
            }
        }
    }

    /*
    public class HandsComparer : IComparer, IComparer<Pocket>
    {
        private struct Comparison
        {
            private CardSet _knownCards;

            private CardSet _boardCards;

            public void Cmp(int dealCardsCount, int deckSize)
            {
                if (dealCardsCount <= 0)
                {
                    _x++;
                    return;
                }

                dealCardsCount--;
                foreach (var card in Card.Dictionary)
                {
                    var cardIndex = (int)card;
                    if (cardIndex >= deckSize || 0 != (_knownCards & card))
                    {
                        break;
                    }

                    _knownCards |= card;
                    _boardCards |= card;

                    Cmp(dealCardsCount, cardIndex);

                    _knownCards ^= card;
                    _boardCards ^= card;
                }
            }
        }

        private static CardSet _boardCards;

        public static int lComparer(Pocket[] pocketCardses, params Card[] board)
        {
            foreach (var startingHand in pocketCardses)
            {
                _knownCards |= hand;
            }

            foreach (var card in board)
            {
                _boardCards |= card;
            }

            _knownCards |= _boardCards;

            Cmp(5 - board.Length, Card.Dictionary.Count);

            return _x;
        }

        public int Compare(Pocket x, Pocket y, Board board)
        {
        }

        private int CompareEnsuredDifferentInstances(Pocket x, Pocket y)
        {
        }


        public int Compare(Pocket x, Pocket y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            if (ReferenceEquals(null, x))
            {
                return -1;
            }

            if (ReferenceEquals(null, y))
            {
                return 1;
            }

            return CompareEnsuredDifferentInstances(x, y);
        }

        public int Compare(object x, object y)
        {
            if (ReferenceEquals(null, x))
            {
                if (ReferenceEquals(null, y))
                {
                    return 0;
                }

                if (y is Pocket)
                {
                    return -1;
                }

                return -Comparer.Default.Compare(y, null);
            }

            var hand1 = x as Pocket;
            var hand2 = y as Pocket;
            if (ReferenceEquals(null, hand1))
            {
                if (ReferenceEquals(null, hand2))
                {
                    return Comparer.Default.Compare(x, y);
                }

                return -1;
            }
            
            if (ReferenceEquals(null, hand2))
            {
                return 1;
            }

            return ReferenceEquals(hand1, hand2) ? 0 : CompareEnsuredDifferentInstances(hand1, hand2);
        }

        public static readonly HandsComparer Default = new HandsComparer();
    }*/
}