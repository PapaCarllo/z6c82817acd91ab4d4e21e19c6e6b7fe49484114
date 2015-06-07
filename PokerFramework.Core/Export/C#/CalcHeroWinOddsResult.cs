#if __LINE__
enum class
#else
namespace PokerFramework.Core
{
	public enum
#endif
	// ReSharper disable once EnumUnderlyingTypeIsInt
	CalcHeroWinOddsResult : int
	{
		WrongDeal = 0,

		WrongHeroPocket = -1,

		WrongHeroWinOdds = -2,

		WrongBoard = -3,

		WrongMuck = -4,

		WrongOpponentsCount = -5,

		WrongOpponentPockets = -6,

		WrongOpponentPocket0 = WrongOpponentPockets - 1,

		WrongOpponentPocket1 = WrongOpponentPockets - 2,

		WrongOpponentPocket2 = WrongOpponentPockets - 3,

		WrongOpponentPocket3 = WrongOpponentPockets - 4,

		WrongOpponentPocket4 = WrongOpponentPockets - 5,

		WrongOpponentPocket5 = WrongOpponentPockets - 6,

		WrongOpponentPocket6 = WrongOpponentPockets - 7,

		WrongOpponentPocket7 = WrongOpponentPockets - 8,

		WrongOpponentPocket8 = WrongOpponentPockets - 9,
	};
#if __LINE__
Enum(CalcHeroWinOddsResult)
#else
}
#endif
