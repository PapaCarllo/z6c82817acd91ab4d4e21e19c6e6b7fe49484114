//using System;
//using System.Runtime.InteropServices;

//namespace PokerFramework
//{
//    [StructLayout(LayoutKind.Explicit)]
//    public struct Hand
//    {
//        public static int HighCards;

//        public static int OnePairs;

//        public static int TwoPairs;

//        public static int ThreeOfAKinds;

//        public static int Straights;

//        public static int Flushes;

//        public static int FullHouses;

//        public static int FourOfAKinds;

//        public static int StraightFlushes;

//        private enum MutableHandRanks
//        {
//            HighCard,

//            OnePair,

//            TwoPair,

//            ThreeOfAKind,

//            FullHouse,

//            FourOfAKind
//        }

//        private const int MaxCardRank = 12;

//        private const ushort DupAce = 0x2000;

//        private const ushort FiveInARow = 0x001F;

//        [FieldOffset(8)]
//        public HandRank _rank;

//        [FieldOffset(0)]
//        private ulong _workingCardSet;

//        [FieldOffset(0)]
//        private ushort _clubs;

//        [FieldOffset(2)]
//        private ushort _diamonds;

//        [FieldOffset(4)]
//        private ushort _hearts;

//        [FieldOffset(6)]
//        private ushort _spades;

//        public void InitHand(ulong cardSet)
//        {
//            _workingCardSet = cardSet;

//            var cardRank = MaxCardRank;
//            var straight_Flush = 0;

//            int clubsCount;
//            int diamondsCount;
//            int heartsCount;
//            int spadesCount;

//            var cClub = _clubs & 1;
//            var cDiamond = _diamonds & 1;
//            var cHeart = _hearts & 1;
//            var cSpade = _spades & 1;
//            var cCards = cClub + cDiamond + cHeart + cSpade;
            
//            if (cClub > 0)
//            {
//                clubsCount = 1;
//                _clubs |= DupAce;
//                cClub = 0;
//            }
//            else
//            {
//                clubsCount = 0;
//            }

//            if (cDiamond > 0)
//            {
//                diamondsCount = 1;
//                _diamonds |= DupAce;
//                cDiamond = 0;
//            }
//            else
//            {
//                diamondsCount = 0;
//            }

//            if (cHeart > 0)
//            {
//                heartsCount = 1;
//                _hearts |= DupAce;
//                cHeart = 0;
//            }
//            else
//            {
//                heartsCount = 0;
//            }

//            if (cSpade > 0)
//            {
//                spadesCount = 1;
//                _spades |= DupAce;
//                cSpade = 0;
//            }
//            else
//            {
//                spadesCount = 0;
//            }
            
//            do
//            {
//                if (cCards > 0)
//                {
//                    var mutableHandRank = MutableHandRanks.HighCard;

//                    do
//                    {
//                        var needToCheckStraights = cardRank >= 3;

//                        do
//                        {
//                            if (cCards == 1)
//                            {
//                                if (mutableHandRank >= MutableHandRanks.FullHouse)
//                                {
//                                    break;
//                                }
//                            }
//                            else if (cCards == 2)
//                            {
//                                if (mutableHandRank < MutableHandRanks.OnePair)
//                                {
//                                    mutableHandRank = MutableHandRanks.OnePair;
//                                }
//                                else if (mutableHandRank == MutableHandRanks.OnePair)
//                                {
//                                    mutableHandRank = MutableHandRanks.TwoPair;
//                                }
//                                else if (mutableHandRank == MutableHandRanks.ThreeOfAKind)
//                                {
//                                    mutableHandRank = MutableHandRanks.FullHouse;
//                                    break;
//                                }
//                                else
//                                {
//                                    break;
//                                }
//                            }
//                            else if (cCards == 3)
//                            {
//                                if (mutableHandRank < MutableHandRanks.OnePair)
//                                {
//                                    mutableHandRank = MutableHandRanks.ThreeOfAKind;
//                                }
//                                else if (mutableHandRank == MutableHandRanks.OnePair
//                                         || mutableHandRank == MutableHandRanks.TwoPair
//                                         || mutableHandRank == MutableHandRanks.ThreeOfAKind)
//                                {
//                                    mutableHandRank = MutableHandRanks.FullHouse;
//                                    break;
//                                }
//                                else
//                                {
//                                    break;
//                                }
//                            }
//                            else
//                            {
//                                if (mutableHandRank < MutableHandRanks.FourOfAKind)
//                                {
//                                    mutableHandRank = MutableHandRanks.FourOfAKind;
//                                }

//                                break;
//                            }

//                            while (straight_Flush < 2)
//                            {
//                                if (cClub > 0)
//                                {
//                                    if (++clubsCount == 5)
//                                    {
//                                        straight_Flush = 2;
//                                        cardSet = cardSet & (ulong)CardSet.Clubs;
//                                        break;
//                                    }
//                                }

//                                if (cDiamond > 0)
//                                {
//                                    if (++diamondsCount == 5)
//                                    {
//                                        straight_Flush = 2;
//                                        cardSet = cardSet & (ulong)CardSet.Diamonds;
//                                        break;
//                                    }
//                                }

//                                if (cHeart > 0)
//                                {
//                                    if (++heartsCount == 5)
//                                    {
//                                        straight_Flush = 2;
//                                        cardSet = cardSet & (ulong)CardSet.Hearts;
//                                        break;
//                                    }
//                                }

//                                if (cSpade > 0)
//                                {
//                                    if (++spadesCount == 5)
//                                    {
//                                        straight_Flush = 2;
//                                        cardSet = cardSet & (ulong)CardSet.Spades;
//                                        break;
//                                    }
//                                }

//                                if (needToCheckStraights && straight_Flush < 1)
//                                {
//                                    if (((_clubs | _diamonds | _hearts | _spades) & FiveInARow) == FiveInARow)
//                                    {
//                                        straight_Flush = 1;
//                                    }
//                                    else
//                                    {
//                                        needToCheckStraights = false;
//                                    }
//                                }

//                                break;
//                            }
//                        }
//                        while (false);

//                        if (needToCheckStraights)
//                        {
//                            if ((_clubs & FiveInARow) == FiveInARow || (_diamonds & FiveInARow) == FiveInARow
//                                || (_hearts & FiveInARow) == FiveInARow || (_spades & FiveInARow) == FiveInARow)
//                            {
//                                StraightFlushes++;
//                                //_rank = cardRank == 12 ? HandRank.RoyalFlush : HandRank.StraightFlushes[CardRank.Dictionary[cardRank]];
//                                return;
//                            }
//                        }

//                        do
//                        {
//                            if (cardRank == 0)
//                            {
//                                if (mutableHandRank < MutableHandRanks.FullHouse)
//                                {
//                                    if (straight_Flush == 1)
//                                    {
//                                        Straights++;
//                                        //_rank = HandRank.Straights[CardRank.Dictionary[straightHighCardRank]];
//                                        return;
//                                    }

//                                    _workingCardSet = cardSet;

//                                    if (straight_Flush == 2)
//                                    {
//                                        Flushes++;
//                                        //_rank = HandRank.Flushes[CardRank.Dictionary[flushHighCardRank]];
//                                        return;
//                                    }

//                                    switch (mutableHandRank)
//                                    {
//                                        case MutableHandRanks.HighCard:
//                                            HighCards++;
//                                           // _rank = HandRank.HighCards[CardRank.Dictionary[mutableCard1Rank]];
//                                            return;
//                                        case MutableHandRanks.OnePair:
//                                            OnePairs++;
//                                           // _rank = HandRank.OnePairs[CardRank.Dictionary[mutableCard1Rank]];
//                                            return;
//                                        case MutableHandRanks.TwoPair:
//                                            TwoPairs++;
//                                            //_rank =
//                                            //    HandRank.TwoPairs[
//                                            //        CardRank.Dictionary[mutableCard1Rank],
//                                            //        CardRank.Dictionary[mutableCard2Rank]];
//                                            return;
//                                        default:
//                                            ThreeOfAKinds++;
//                                            //_rank = HandRank.ThreeOfAKinds[CardRank.Dictionary[mutableCard1Rank]];
//                                            return;
//                                    }
//                                }

//                                if (mutableHandRank == MutableHandRanks.FullHouse)
//                                {
//                                    FullHouses++;
//                                    //_rank =
//                                    //    HandRank.FullHouses[
//                                    //        CardRank.Dictionary[mutableCard1Rank],
//                                    //        CardRank.Dictionary[mutableCard2Rank]];
//                                    return;
//                                }

//                                _workingCardSet = cardSet;
//                                FourOfAKinds++;
//                                // _rank = HandRank.FourOfAKinds[CardRank.Dictionary[mutableCard1Rank]];
//                                return;
//                            }

//                            cardRank--;
//                            _workingCardSet = (_workingCardSet >> 1);
//                            cClub = _clubs & 1;
//                            cDiamond = _diamonds & 1;
//                            cHeart = _hearts & 1;
//                            cSpade = _spades & 1;
//                            cCards = cClub + cDiamond + cHeart + cSpade;
//                        }
//                        while (cCards == 0);
//                    }
//                    while (true);
//                }

//                if (cardRank == 0)
//                {
//                    throw new Exception();
//                }

//                cardRank--;
//                _workingCardSet = (_workingCardSet >> 1);
//                cClub = _clubs & 1;
//                cDiamond = _diamonds & 1;
//                cHeart = _hearts & 1;
//                cSpade = _spades & 1;
//                cCards = cClub + cDiamond + cHeart + cSpade;
//            }
//            while (true);
//        }
//    }
//}