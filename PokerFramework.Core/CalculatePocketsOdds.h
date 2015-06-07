#include "BuildBestHand.h"

//__forceinline int _CalculatePocketsOdds(CardSet board, int cardsToDeal, const CardSet* firstDeckCard, const CardSet* lastDeckCard, const CardSet* firstPocket, const CardSet* lastPocket)
//{
//    Hand * hands = new Hand[lastPocket - firstPocket + 1];
//    const CardSet** cardStack = new const CardSet*[cardsToDeal];
//    const CardSet** cardStackHead = cardStack + (cardsToDeal - 1);
//    const CardSet* currentCard = lastDeckCard + 1;
//
//    firstDeckCard += cardsToDeal - 1;
//    
//    for (int dealsCount = 1;; dealsCount++)
//    {
//        while (cardStackHead >= cardStack)
//        {
//            *cardStackHead-- = currentCard;
//            currentCard = firstDeckCard--;
//            board |= *currentCard;
//        }
//
//        _BuildBestHand(board);
//
//        for (;;)
//        {
//            if (currentCard > lastDeckCard)
//            {
//                delete[] hands;
//                delete[] cardStack;
//                return dealsCount;
//            }
//
//            board ^= *currentCard++;
//            if (currentCard < *(cardStackHead + 1))
//            {
//                board |= *currentCard;
//                break;
//            }
//
//            cardStackHead++;
//            firstDeckCard++;
//        }
//    }
//}
