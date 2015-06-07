using System;
using System.Runtime.InteropServices;

namespace PokerFramework
{/*
    [StructLayout(LayoutKind.Explicit)]
    public struct Hand
    {
        public static int HighCards;

        public static int OnePairs;

        public static int TwoPairs;

        public static int ThreeOfAKinds;

        public static int Straights;

        public static int Flushes;

        public static int FullHouses;

        public static int FourOfAKinds;

        public static int StraightFlushes;

        private enum MutableHandRanks
        {
            HighCard,

            OnePair,

            TwoPair,

            ThreeOfAKind,

            FullHouse,

            FourOfAKind
        }

        private const int MaxCardRank = 12;

        private const ushort DupAce = 0x2000;

        private const ushort FiveInARow = 0x001F;

        private const ulong RollMask = 0x3FFF3FFF3FFF3FFF;

        [FieldOffset(8)]
        public HandRank _rank;

        [FieldOffset(0)]
        private ulong _workingCardSet;

        [FieldOffset(0)]
        private ushort _clubs;

        [FieldOffset(2)]
        private ushort _diamonds;

        [FieldOffset(4)]
        private ushort _hearts;

        [FieldOffset(6)]
        private ushort _spades;

        public void InitHand(ulong cardSet)
        {
            _workingCardSet = cardSet;

            var cardRank = MaxCardRank;

            int clubHighCardRank;
            int diamondHighCardRank;
            int heartHighCardRank;
            int spadeHighCardRank;

            int clubsCount;
            int diamondsCount;
            int heartsCount;
            int spadesCount;

            var cClub = _clubs & 1;
            var cDiamond = _diamonds & 1;
            var cHeart = _hearts & 1;
            var cSpade = _spades & 1;
            var cCards = cClub + cDiamond + cHeart + cSpade;

            if (cClub > 0)
            {
                clubsCount = 1;
                clubHighCardRank = cardRank;
                _clubs |= DupAce;
                cClub = 0;
            }
            else
            {
                clubsCount = 0;
                clubHighCardRank = -1;
            }

            if (cDiamond > 0)
            {
                diamondsCount = 1;
                diamondHighCardRank = cardRank;
                _diamonds |= DupAce;
                cDiamond = 0;
            }
            else
            {
                diamondsCount = 0;
                diamondHighCardRank = -1;
            }

            if (cHeart > 0)
            {
                heartsCount = 1;
                heartHighCardRank = cardRank;
                _hearts |= DupAce;
                cHeart = 0;
            }
            else
            {
                heartsCount = 0;
                heartHighCardRank = -1;
            }

            if (cSpade > 0)
            {
                spadesCount = 1;
                spadeHighCardRank = cardRank;
                _spades |= DupAce;
                cSpade = 0;
            }
            else
            {
                spadesCount = 0;
                spadeHighCardRank = -1;
            }

            do
            {
                if (cCards > 0)
                {
                    var mutableHandRank = MutableHandRanks.HighCard;
                    var mutableCard1Rank = cardRank;
                    var mutableCard2Rank = -1;
                    var straightHighCardRank = -1;
                    var flushHighCardRank = -1;

                    do
                    {
                        var needToCheckStraights = cardRank >= 3;

                        do
                        {
                            if (cCards == 1)
                            {
                                if (mutableHandRank >= MutableHandRanks.FullHouse)
                                {
                                    break;
                                }
                            }
                            else if (cCards == 2)
                            {
                                if (mutableHandRank < MutableHandRanks.OnePair)
                                {
                                    mutableCard1Rank = cardRank;
                                    mutableHandRank = MutableHandRanks.OnePair;
                                }
                                else if (mutableHandRank == MutableHandRanks.OnePair)
                                {
                                    mutableCard2Rank = cardRank;
                                    mutableHandRank = MutableHandRanks.TwoPair;
                                }
                                else if (mutableHandRank == MutableHandRanks.ThreeOfAKind)
                                {
                                    mutableCard2Rank = cardRank;
                                    mutableHandRank = MutableHandRanks.FullHouse;
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else if (cCards == 3)
                            {
                                if (mutableHandRank < MutableHandRanks.OnePair)
                                {
                                    mutableCard1Rank = cardRank;
                                    mutableHandRank = MutableHandRanks.ThreeOfAKind;
                                }
                                else if (mutableHandRank == MutableHandRanks.OnePair
                                         || mutableHandRank == MutableHandRanks.TwoPair)
                                {
                                    mutableCard2Rank = mutableCard1Rank;
                                    mutableCard1Rank = cardRank;
                                    mutableHandRank = MutableHandRanks.FullHouse;
                                    break;
                                }
                                else if (mutableHandRank == MutableHandRanks.ThreeOfAKind)
                                {
                                    mutableCard2Rank = cardRank;
                                    mutableHandRank = MutableHandRanks.FullHouse;
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (mutableHandRank < MutableHandRanks.FourOfAKind)
                                {
                                    mutableCard1Rank = cardRank;
                                    mutableHandRank = MutableHandRanks.FourOfAKind;
                                }

                                break;
                            }

                            while (flushHighCardRank < 0)
                            {
                                if (cClub > 0)
                                {
                                    if (clubsCount == 0)
                                    {
                                        clubsCount = 1;
                                        clubHighCardRank = cardRank;
                                    }
                                    else if (++clubsCount == 5)
                                    {
                                        flushHighCardRank = clubHighCardRank;
                                        cardSet = cardSet & (ulong)CardSet.Clubs;
                                        break;
                                    }
                                }

                                if (cDiamond > 0)
                                {
                                    if (diamondsCount == 0)
                                    {
                                        diamondsCount = 1;
                                        diamondHighCardRank = cardRank;
                                    }
                                    else if (++diamondsCount == 5)
                                    {
                                        flushHighCardRank = diamondHighCardRank;
                                        cardSet = cardSet & (ulong)CardSet.Diamonds;
                                        break;
                                    }
                                }

                                if (cHeart > 0)
                                {
                                    if (heartsCount == 0)
                                    {
                                        heartsCount = 1;
                                        heartHighCardRank = cardRank;
                                    }
                                    else if (++heartsCount == 5)
                                    {
                                        flushHighCardRank = heartHighCardRank;
                                        cardSet = cardSet & (ulong)CardSet.Hearts;
                                        break;
                                    }
                                }

                                if (cSpade > 0)
                                {
                                    if (spadesCount == 0)
                                    {
                                        spadesCount = 1;
                                        spadeHighCardRank = cardRank;
                                    }
                                    else if (++spadesCount == 5)
                                    {
                                        flushHighCardRank = spadeHighCardRank;
                                        cardSet = cardSet & (ulong)CardSet.Spades;
                                        break;
                                    }
                                }

                                if (needToCheckStraights && straightHighCardRank < 0)
                                {
                                    if (((_clubs | _diamonds | _hearts | _spades) & FiveInARow) == FiveInARow)
                                    {
                                        straightHighCardRank = cardRank;
                                    }
                                    else
                                    {
                                        needToCheckStraights = false;
                                    }
                                }

                                break;
                            }
                        }
                        while (false);

                        if (needToCheckStraights)
                        {
                            if ((_clubs & FiveInARow) == FiveInARow || (_diamonds & FiveInARow) == FiveInARow
                                || (_hearts & FiveInARow) == FiveInARow || (_spades & FiveInARow) == FiveInARow)
                            {
                                StraightFlushes++;
                                //_rank = cardRank == 12 ? HandRank.RoyalFlush : HandRank.StraightFlushes[CardRank.Dictionary[cardRank]];
                                return;
                            }
                        }

                        do
                        {
                            if (cardRank == 0)
                            {
                                if (mutableHandRank < MutableHandRanks.FullHouse)
                                {
                                    if (straightHighCardRank >= 0)
                                    {
                                        Straights++;
                                        //_rank = HandRank.Straights[CardRank.Dictionary[straightHighCardRank]];
                                        return;
                                    }

                                    _workingCardSet = cardSet;

                                    if (flushHighCardRank >= 0)
                                    {
                                        Flushes++;
                                        //_rank = HandRank.Flushes[CardRank.Dictionary[flushHighCardRank]];
                                        return;
                                    }

                                    switch (mutableHandRank)
                                    {
                                        case MutableHandRanks.HighCard:
                                            HighCards++;
                                           // _rank = HandRank.HighCards[CardRank.Dictionary[mutableCard1Rank]];
                                            return;
                                        case MutableHandRanks.OnePair:
                                            OnePairs++;
                                           // _rank = HandRank.OnePairs[CardRank.Dictionary[mutableCard1Rank]];
                                            return;
                                        case MutableHandRanks.TwoPair:
                                            TwoPairs++;
                                            //_rank =
                                            //    HandRank.TwoPairs[
                                            //        CardRank.Dictionary[mutableCard1Rank],
                                            //        CardRank.Dictionary[mutableCard2Rank]];
                                            return;
                                        case MutableHandRanks.ThreeOfAKind:
                                            ThreeOfAKinds++;
                                            //_rank = HandRank.ThreeOfAKinds[CardRank.Dictionary[mutableCard1Rank]];
                                            return;
                                    }
                                }
                                else
                                {
                                    if (mutableHandRank == MutableHandRanks.FullHouse)
                                    {
                                        FullHouses++;
                                        //_rank =
                                        //    HandRank.FullHouses[
                                        //        CardRank.Dictionary[mutableCard1Rank],
                                        //        CardRank.Dictionary[mutableCard2Rank]];
                                        return;
                                    }

                                    if (mutableHandRank == MutableHandRanks.FourOfAKind)
                                    {
                                        _workingCardSet = cardSet;
                                        FourOfAKinds++;
                                       // _rank = HandRank.FourOfAKinds[CardRank.Dictionary[mutableCard1Rank]];
                                        return;
                                    }
                                }

                                throw new Exception();
                            }

                            cardRank--;
                            _workingCardSet = (_workingCardSet >> 1) & RollMask;
                            cClub = _clubs & 1;
                            cDiamond = _diamonds & 1;
                            cHeart = _hearts & 1;
                            cSpade = _spades & 1;
                            cCards = cClub + cDiamond + cHeart + cSpade;
                        }
                        while (cCards == 0);
                    }
                    while (true);
                }

                if (cardRank == 0)
                {
                    return;
                }

                cardRank--;
                _workingCardSet = (_workingCardSet >> 1) & RollMask;
                cClub = _clubs & 1;
                cDiamond = _diamonds & 1;
                cHeart = _hearts & 1;
                cSpade = _spades & 1;
                cCards = cClub + cDiamond + cHeart + cSpade;
            }
            while (true);
        }
    }*/
}