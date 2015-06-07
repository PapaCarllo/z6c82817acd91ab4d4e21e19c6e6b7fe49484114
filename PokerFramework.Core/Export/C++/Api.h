#pragma once

#include "Base/Extern.h"
#include "Base/Enum.h"

#define public
#define uint unsigned int
#define ulong unsigned long long

#include "../C#/CardSet.cs"
#include "../C#/Hand.cs"
#include "../C#/CalcHeroWinOddsResult.cs"

#undef public
#undef uint
#undef ulong

PokerFrameworkExtern(Hand) BuildBestHand(CardSet cardSet);
PokerFrameworkExtern(CalcHeroWinOddsResult) CalcHeroWinOdds(CardSet heroPocket, CardSet board, CardSet muck, int opponentsCount, const CardSet * opponentPockets, unsigned int * heroWinOdds);
