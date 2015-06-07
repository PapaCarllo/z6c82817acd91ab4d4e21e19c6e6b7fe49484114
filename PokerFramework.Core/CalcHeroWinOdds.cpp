#include "BuildBestHand.h"

const CardSet FullDeck[] = {
	CardSet::_2c, CardSet::_3c, CardSet::_4c, CardSet::_5c, CardSet::_6c, CardSet::_7c, CardSet::_8c, CardSet::_9c, CardSet::_Tc, CardSet::_Jc, CardSet::_Qc, CardSet::_Kc, CardSet::_Ac,
	CardSet::_2d, CardSet::_3d, CardSet::_4d, CardSet::_5d, CardSet::_6d, CardSet::_7d, CardSet::_8d, CardSet::_9d, CardSet::_Td, CardSet::_Jd, CardSet::_Qd, CardSet::_Kd, CardSet::_Ad,
	CardSet::_2h, CardSet::_3h, CardSet::_4h, CardSet::_5h, CardSet::_6h, CardSet::_7h, CardSet::_8h, CardSet::_9h, CardSet::_Th, CardSet::_Jh, CardSet::_Qh, CardSet::_Kh, CardSet::_Ah,
	CardSet::_2s, CardSet::_3s, CardSet::_4s, CardSet::_5s, CardSet::_6s, CardSet::_7s, CardSet::_8s, CardSet::_9s, CardSet::_Ts, CardSet::_Js, CardSet::_Qs, CardSet::_Ks, CardSet::_As,
};

#define FullDeckSize	_countof(FullDeck)
#define FullPocketSize	2
#define FullBoardSize	5
#define FullTableSize	10

__forceinline int AcceptCardSet(CardSet cardSet, CardSet& accumulator)
{
	if (cardSet == CardSet::Empty) { return 0; }
	if ((cardSet & CardSet::Reserved) != CardSet::Empty) { return -1; }
    if ((cardSet & accumulator) != CardSet::Empty) { return -1; }

	accumulator |= cardSet;

	for (int cardSetSize = 1;; cardSetSize++)
    {		
		cardSet &= cardSet - CardSetFrom(1);
		if (cardSet == CardSet::Empty)
		{
			return cardSetSize;
		}
    }
}

PokerFrameworkExtern(CalcHeroWinOddsResult) CalcHeroWinOdds(CardSet heroPocket, CardSet board, CardSet muck, int opponentsCount, const CardSet * opponentPockets, unsigned int * heroWinOdds)
{
	if (opponentsCount < 1 || opponentsCount >(FullTableSize - 1)) { return CalcHeroWinOddsResult::WrongOpponentsCount; }

	if (heroWinOdds == nullptr) { return CalcHeroWinOddsResult::WrongHeroWinOdds; }

	if (opponentPockets == nullptr) { return CalcHeroWinOddsResult::WrongOpponentPockets; }

	CardSet knownCards = CardSet::Empty;
	if (AcceptCardSet(heroPocket, knownCards) != FullPocketSize) { return CalcHeroWinOddsResult::WrongHeroPocket; }

	int boardSize = AcceptCardSet(board, knownCards);
	if (boardSize < 0 || boardSize > FullBoardSize) { return CalcHeroWinOddsResult::WrongBoard; }

	int muckSize = AcceptCardSet(muck, knownCards);
	if (muckSize < 0) { return CalcHeroWinOddsResult::WrongMuck; }

	const CardSet * opponentPocketLast = opponentPockets;
	int cardsToCopy = FullDeckSize - FullPocketSize - boardSize - muckSize - (opponentsCount << 1);
	for (unsigned int * winOdds = heroWinOdds;; opponentPocketLast++, winOdds++)
	{
		if (AcceptCardSet(*opponentPocketLast, knownCards) != FullPocketSize) { return CalcHeroWinOddsResult(CalcHeroWinOddsResultValue(CalcHeroWinOddsResult::WrongOpponentPocket0) - (opponentPocketLast - opponentPockets)); }
		*winOdds = 0;
		if (--opponentsCount == 0) { break; }
	}

	int dealsDepth = FullBoardSize - boardSize - 1;
	if (cardsToCopy <= dealsDepth) { return CalcHeroWinOddsResult::WrongDeal; }

	CardSet deck[FullDeckSize];
	CardSet* deckEnd = deck;
	if (cardsToCopy > 0)
	{
		for (const CardSet * card = FullDeck;; card++)
		{
			if ((*card & knownCards) == CardSet::Empty)
			{
				*deckEnd++ = *card;
				if (--cardsToCopy == 0) { break; }
			}
		}
	}

	CardSet* cardStack[FullBoardSize];
	CardSet** cardStackHead = cardStack + dealsDepth;
	CardSet* currentCard = deckEnd;
	CardSet* firstCard = deck + dealsDepth;

	for (int dealsCount = 1;; dealsCount++)
	{
		while (cardStackHead >= cardStack)
		{
			*cardStackHead-- = currentCard;
			currentCard = firstCard--;
			board |= *currentCard;
		}

		Hand heroHand = BuildBestHandInternal(heroPocket | board);
		unsigned int * winOdds = heroWinOdds;
		for (const CardSet * opponentPocket = opponentPockets;; opponentPocket++, winOdds++)
		{
			if (heroHand > BuildBestHandInternal(*opponentPocket | board))
			{
				(*winOdds)++;
			}

			if (opponentPocket >= opponentPocketLast)
			{
				break;
			}
		}

		for (;;)
		{
			if (currentCard >= deckEnd)
			{
				return CalcHeroWinOddsResultFrom(dealsCount);
			}

			board ^= *currentCard++;
			if (currentCard < *(cardStackHead + 1))
			{
				board |= *currentCard;
				break;
			}

			cardStackHead++;
			firstCard++;
		}
	}
}
