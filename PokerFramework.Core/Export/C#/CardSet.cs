#if __LINE__
enum class
#else
namespace PokerFramework.Core
{
    // ReSharper disable InconsistentNaming

	[System.Flags]
	public enum
#endif
    CardSet : ulong
    {
        Empty = 0,

        FullDeck = 0x1FFF1FFF1FFF1FFF,

        Reserved = ~FullDeck,

        Clubs = 0x0000000000001FFF,

        Diamonds = 0x000000001FFF0000,

        Hearts = 0x00001FFF00000000,

        Spades = 0x1FFF000000000000,

        Deuces = 0x0001000100010001,

        Threes = 0x0002000200020002,

        Fours = 0x0004000400040004,

        Fives = 0x0008000800080008,

        Sixes = 0x0010001000100010,

        Sevens = 0x0020002000200020,

        Eights = 0x0040004000400040,

        Nines = 0x0080008000800080,

        Tens = 0x0100010001000100,

        Jacks = 0x0200020002000200,

        Queens = 0x0400040004000400,

        Kings = 0x0800080008000800,

        Aces = 0x1000100010001000,

        _2c = Deuces & Clubs,

        _3c = Threes & Clubs,

        _4c = Fours & Clubs,

        _5c = Fives & Clubs,

        _6c = Sixes & Clubs,

        _7c = Sevens & Clubs,

        _8c = Eights & Clubs,

        _9c = Nines & Clubs,

        _Tc = Tens & Clubs,

        _Jc = Jacks & Clubs,

        _Qc = Queens & Clubs,

        _Kc = Kings & Clubs,

        _Ac = Aces & Clubs,

        _2d = Deuces & Diamonds,

        _3d = Threes & Diamonds,

        _4d = Fours & Diamonds,

        _5d = Fives & Diamonds,

        _6d = Sixes & Diamonds,

        _7d = Sevens & Diamonds,

        _8d = Eights & Diamonds,

        _9d = Nines & Diamonds,

        _Td = Tens & Diamonds,

        _Jd = Jacks & Diamonds,

        _Qd = Queens & Diamonds,

        _Kd = Kings & Diamonds,

        _Ad = Aces & Diamonds,

        _2h = Deuces & Hearts,

        _3h = Threes & Hearts,

        _4h = Fours & Hearts,

        _5h = Fives & Hearts,

        _6h = Sixes & Hearts,

        _7h = Sevens & Hearts,

        _8h = Eights & Hearts,

        _9h = Nines & Hearts,

        _Th = Tens & Hearts,

        _Jh = Jacks & Hearts,

        _Qh = Queens & Hearts,

        _Kh = Kings & Hearts,

        _Ah = Aces & Hearts,

        _2s = Deuces & Spades,

        _3s = Threes & Spades,

        _4s = Fours & Spades,

        _5s = Fives & Spades,

        _6s = Sixes & Spades,

        _7s = Sevens & Spades,

        _8s = Eights & Spades,

        _9s = Nines & Spades,

        _Ts = Tens & Spades,

        _Js = Jacks & Spades,

        _Qs = Queens & Spades,

        _Ks = Kings & Spades,

        _As = Aces & Spades,
    };
#if __LINE__
EnumFlags(CardSet)
#else
}

// ReSharper restore InconsistentNaming
#endif
