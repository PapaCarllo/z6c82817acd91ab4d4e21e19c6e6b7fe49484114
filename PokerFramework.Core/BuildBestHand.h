#pragma once

#include "Export/C++/Api.h"

__forceinline Hand BuildBestHandInternal(CardSet cardSet)
{
    return Hand::Invalid;
    /*
    _workingCardSet = cardSet;

    var cardRank = MaxCardRank;

    var straight_Flush = 0;

    var clubsCount = 0;
    var diamondsCount = 0;
    var heartsCount = 0;
    var spadesCount = 0;

    var cClub = _clubs & 1;
    var cDiamond = _diamonds & 1;
    var cHeart = _hearts & 1;
    var cSpade = _spades & 1;
    var cCards = cClub + cDiamond + cHeart + cSpade;

    if (cCards > 0)
    {
    if (cClub > 0)
    {
    _clubs |= 0x2000;
    }

    if (cDiamond > 0)
    {
    _diamonds |= 0x2000;
    }

    if (cHeart > 0)
    {
    _hearts |= 0x2000;
    }

    if (cSpade > 0)
    {
    _spades |= 0x2000;
    }
    }
    else
    {
    while (cCards == 0)
    {
    if (--cardRank < 0)
    {
    throw new Exception();
    }

    _workingCardSet >>= 1;
    cClub = _clubs & 1;
    cDiamond = _diamonds & 1;
    cHeart = _hearts & 1;
    cSpade = _spades & 1;
    cCards = cClub + cDiamond + cHeart + cSpade;
    }
    }

    var mutableHandRank = MutableHandRanks.HighCard;
    while (true)
    {
    if (cCards > 0)
    {
    if (cCards > 1)
    {
    if (cCards == 2)
    {
    if (mutableHandRank < MutableHandRanks.OnePair)
    {
    mutableHandRank = MutableHandRanks.OnePair;
    }
    else if (mutableHandRank == MutableHandRanks.OnePair)
    {
    mutableHandRank = MutableHandRanks.TwoPair;
    }
    else if (mutableHandRank == MutableHandRanks.ThreeOfAKind)
    {
    mutableHandRank = MutableHandRanks.FullHouse;
    }
    }
    else if (cCards == 3)
    {
    if (mutableHandRank < MutableHandRanks.OnePair)
    {
    mutableHandRank = MutableHandRanks.ThreeOfAKind;
    }
    else if (mutableHandRank == MutableHandRanks.OnePair
    || mutableHandRank == MutableHandRanks.TwoPair
    || mutableHandRank == MutableHandRanks.ThreeOfAKind)
    {
    mutableHandRank = MutableHandRanks.FullHouse;
    }
    }
    else
    {
    mutableHandRank = MutableHandRanks.FourOfAKind;
    }
    }

    var needToCheckStraights = cardRank >= 3;

    if (straight_Flush < 2 && mutableHandRank < MutableHandRanks.FullHouse)
    {
    if (cClub > 0 && ++clubsCount == 5)
    {
    straight_Flush = 2;
    cardSet = cardSet & (ulong)CardSet.Clubs;
    }
    else if (cDiamond > 0 && ++diamondsCount == 5)
    {
    straight_Flush = 2;
    cardSet = cardSet & (ulong)CardSet.Diamonds;
    }
    else if (cHeart > 0 && ++heartsCount == 5)
    {
    straight_Flush = 2;
    cardSet = cardSet & (ulong)CardSet.Hearts;
    }
    else if (cSpade > 0 && ++spadesCount == 5)
    {
    straight_Flush = 2;
    cardSet = cardSet & (ulong)CardSet.Spades;
    }
    else if (needToCheckStraights && straight_Flush < 1)
    {
    if (((_clubs | _diamonds | _hearts | _spades) & FiveInARow) == FiveInARow)
    {
    straight_Flush = 1;
    }
    else
    {
    needToCheckStraights = false;
    }
    }
    }

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
    }

    if (--cardRank < 0)
    {
    break;
    }

    _workingCardSet >>= 1;
    cClub = _clubs & 1;
    cDiamond = _diamonds & 1;
    cHeart = _hearts & 1;
    cSpade = _spades & 1;
    cCards = cClub + cDiamond + cHeart + cSpade;
    }

    if (mutableHandRank < MutableHandRanks.FullHouse)
    {
    if (straight_Flush == 1)
    {
    Straights++;
    //_rank = HandRank.Straights[CardRank.Dictionary[straightHighCardRank]];
    return;
    }

    _workingCardSet = cardSet;

    if (straight_Flush == 2)
    {
    Flushes++;
    //_rank = HandRank.Flushes[CardRank.Dictionary[flushHighCardRank]];
    return;
    }

    if (mutableHandRank == MutableHandRanks.HighCard)
    {
    HighCards++;
    // _rank = HandRank.HighCards[CardRank.Dictionary[mutableCard1Rank]];
    return;
    }

    if (mutableHandRank == MutableHandRanks.OnePair)
    {
    OnePairs++;
    // _rank = HandRank.OnePairs[CardRank.Dictionary[mutableCard1Rank]];
    return;
    }

    if (mutableHandRank == MutableHandRanks.TwoPair)
    {
    TwoPairs++;
    //_rank =
    //    HandRank.TwoPairs[
    //        CardRank.Dictionary[mutableCard1Rank],
    //        CardRank.Dictionary[mutableCard2Rank]];
    return;
    }

    ThreeOfAKinds++;
    //_rank = HandRank.ThreeOfAKinds[CardRank.Dictionary[mutableCard1Rank]];
    return;
    }

    if (mutableHandRank == MutableHandRanks.FullHouse)
    {
    FullHouses++;
    //_rank =
    //    HandRank.FullHouses[
    //        CardRank.Dictionary[mutableCard1Rank],
    //        CardRank.Dictionary[mutableCard2Rank]];
    return;
    }

    _workingCardSet = cardSet;
    FourOfAKinds++;
    // _rank = HandRank.FourOfAKinds[CardRank.Dictionary[mutableCard1Rank]];
    }
    */
}