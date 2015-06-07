#include "BuildBestHand.h"

PokerFrameworkExtern(Hand) BuildBestHand(CardSet cardSet)
{
	return Hand::Flush_7;// BuildBestHandInternal(cardSet);
}