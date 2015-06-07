#if __LINE__
enum class
#else
namespace PokerFramework.Core
{
    // ReSharper disable InconsistentNaming

	[System.Flags]
	public enum
#endif
    Hand : uint
    {
        Invalid = 0,

        TwoPair = 0x20000000,

        ThreeOfAKind = 0x40000000,

        Straight = 0x60000000,

        Flush = 0x80000000,

        FullHouse = 0xA0000000,

        FourOfAKind = 0xC0000000,

        StraightFlush = 0xE0000000,

        RoyalFlush = 0xF0000000,

        HighCard_2 = 1,

        HighCard_3 = HighCard_2 << 1,

        HighCard_4 = HighCard_3 << 1,

        HighCard_5 = HighCard_4 << 1,

        HighCard_6 = HighCard_5 << 1,

        HighCard_7 = HighCard_6 << 1,

        HighCard_8 = HighCard_7 << 1,

        HighCard_9 = HighCard_8 << 1,

        HighCard_T = HighCard_9 << 1,

        HighCard_J = HighCard_T << 1,

        HighCard_Q = HighCard_J << 1,

        HighCard_K = HighCard_Q << 1,

        HighCard_A = HighCard_K << 1,

        OnePair_2 = HighCard_2 << 16,

        OnePair_3 = HighCard_3 << 16,

        OnePair_4 = HighCard_4 << 16,

        OnePair_5 = HighCard_5 << 16,

        OnePair_6 = HighCard_6 << 16,

        OnePair_7 = HighCard_7 << 16,

        OnePair_8 = HighCard_8 << 16,

        OnePair_9 = HighCard_9 << 16,

        OnePair_T = HighCard_T << 16,

        OnePair_J = HighCard_J << 16,

        OnePair_Q = HighCard_Q << 16,

        OnePair_K = HighCard_K << 16,

        OnePair_A = HighCard_A << 16,

        TwoPair_32 = TwoPair | OnePair_3 | OnePair_2,

        TwoPair_42 = TwoPair | OnePair_4 | OnePair_2,

        TwoPair_43 = TwoPair | OnePair_4 | OnePair_3,

        TwoPair_52 = TwoPair | OnePair_5 | OnePair_2,

        TwoPair_53 = TwoPair | OnePair_5 | OnePair_3,

        TwoPair_54 = TwoPair | OnePair_5 | OnePair_4,

        TwoPair_62 = TwoPair | OnePair_6 | OnePair_2,

        TwoPair_63 = TwoPair | OnePair_6 | OnePair_3,

        TwoPair_64 = TwoPair | OnePair_6 | OnePair_4,

        TwoPair_65 = TwoPair | OnePair_6 | OnePair_5,

        TwoPair_72 = TwoPair | OnePair_7 | OnePair_2,

        TwoPair_73 = TwoPair | OnePair_7 | OnePair_3,

        TwoPair_74 = TwoPair | OnePair_7 | OnePair_4,

        TwoPair_75 = TwoPair | OnePair_7 | OnePair_5,

        TwoPair_76 = TwoPair | OnePair_7 | OnePair_6,

        TwoPair_82 = TwoPair | OnePair_8 | OnePair_2,

        TwoPair_83 = TwoPair | OnePair_8 | OnePair_3,

        TwoPair_84 = TwoPair | OnePair_8 | OnePair_4,

        TwoPair_85 = TwoPair | OnePair_8 | OnePair_5,

        TwoPair_86 = TwoPair | OnePair_8 | OnePair_6,

        TwoPair_87 = TwoPair | OnePair_8 | OnePair_7,

        TwoPair_92 = TwoPair | OnePair_9 | OnePair_2,

        TwoPair_93 = TwoPair | OnePair_9 | OnePair_3,

        TwoPair_94 = TwoPair | OnePair_9 | OnePair_4,

        TwoPair_95 = TwoPair | OnePair_9 | OnePair_5,

        TwoPair_96 = TwoPair | OnePair_9 | OnePair_6,

        TwoPair_97 = TwoPair | OnePair_9 | OnePair_7,

        TwoPair_98 = TwoPair | OnePair_9 | OnePair_8,

        TwoPair_T2 = TwoPair | OnePair_T | OnePair_2,

        TwoPair_T3 = TwoPair | OnePair_T | OnePair_3,

        TwoPair_T4 = TwoPair | OnePair_T | OnePair_4,

        TwoPair_T5 = TwoPair | OnePair_T | OnePair_5,

        TwoPair_T6 = TwoPair | OnePair_T | OnePair_6,

        TwoPair_T7 = TwoPair | OnePair_T | OnePair_7,

        TwoPair_T8 = TwoPair | OnePair_T | OnePair_8,

        TwoPair_T9 = TwoPair | OnePair_T | OnePair_9,

        TwoPair_J2 = TwoPair | OnePair_J | OnePair_2,

        TwoPair_J3 = TwoPair | OnePair_J | OnePair_3,

        TwoPair_J4 = TwoPair | OnePair_J | OnePair_4,

        TwoPair_J5 = TwoPair | OnePair_J | OnePair_5,

        TwoPair_J6 = TwoPair | OnePair_J | OnePair_6,

        TwoPair_J7 = TwoPair | OnePair_J | OnePair_7,

        TwoPair_J8 = TwoPair | OnePair_J | OnePair_8,

        TwoPair_J9 = TwoPair | OnePair_J | OnePair_9,

        TwoPair_JT = TwoPair | OnePair_J | OnePair_T,

        TwoPair_Q2 = TwoPair | OnePair_Q | OnePair_2,

        TwoPair_Q3 = TwoPair | OnePair_Q | OnePair_3,

        TwoPair_Q4 = TwoPair | OnePair_Q | OnePair_4,

        TwoPair_Q5 = TwoPair | OnePair_Q | OnePair_5,

        TwoPair_Q6 = TwoPair | OnePair_Q | OnePair_6,

        TwoPair_Q7 = TwoPair | OnePair_Q | OnePair_7,

        TwoPair_Q8 = TwoPair | OnePair_Q | OnePair_8,

        TwoPair_Q9 = TwoPair | OnePair_Q | OnePair_9,

        TwoPair_QT = TwoPair | OnePair_Q | OnePair_T,

        TwoPair_QJ = TwoPair | OnePair_Q | OnePair_J,

        TwoPair_K2 = TwoPair | OnePair_K | OnePair_2,

        TwoPair_K3 = TwoPair | OnePair_K | OnePair_3,

        TwoPair_K4 = TwoPair | OnePair_K | OnePair_4,

        TwoPair_K5 = TwoPair | OnePair_K | OnePair_5,

        TwoPair_K6 = TwoPair | OnePair_K | OnePair_6,

        TwoPair_K7 = TwoPair | OnePair_K | OnePair_7,

        TwoPair_K8 = TwoPair | OnePair_K | OnePair_8,

        TwoPair_K9 = TwoPair | OnePair_K | OnePair_9,

        TwoPair_KT = TwoPair | OnePair_K | OnePair_T,

        TwoPair_KJ = TwoPair | OnePair_K | OnePair_J,

        TwoPair_KQ = TwoPair | OnePair_K | OnePair_Q,

        TwoPair_A2 = TwoPair | OnePair_A | OnePair_2,

        TwoPair_A3 = TwoPair | OnePair_A | OnePair_3,

        TwoPair_A4 = TwoPair | OnePair_A | OnePair_4,

        TwoPair_A5 = TwoPair | OnePair_A | OnePair_5,

        TwoPair_A6 = TwoPair | OnePair_A | OnePair_6,

        TwoPair_A7 = TwoPair | OnePair_A | OnePair_7,

        TwoPair_A8 = TwoPair | OnePair_A | OnePair_8,

        TwoPair_A9 = TwoPair | OnePair_A | OnePair_9,

        TwoPair_AT = TwoPair | OnePair_A | OnePair_T,

        TwoPair_AJ = TwoPair | OnePair_A | OnePair_J,

        TwoPair_AQ = TwoPair | OnePair_A | OnePair_Q,

        TwoPair_AK = TwoPair | OnePair_A | OnePair_K,

        ThreeOfAKind_2 = ThreeOfAKind | OnePair_2,

        ThreeOfAKind_3 = ThreeOfAKind | OnePair_3,

        ThreeOfAKind_4 = ThreeOfAKind | OnePair_4,

        ThreeOfAKind_5 = ThreeOfAKind | OnePair_5,

        ThreeOfAKind_6 = ThreeOfAKind | OnePair_6,

        ThreeOfAKind_7 = ThreeOfAKind | OnePair_7,

        ThreeOfAKind_8 = ThreeOfAKind | OnePair_8,

        ThreeOfAKind_9 = ThreeOfAKind | OnePair_9,

        ThreeOfAKind_T = ThreeOfAKind | OnePair_T,

        ThreeOfAKind_J = ThreeOfAKind | OnePair_J,

        ThreeOfAKind_Q = ThreeOfAKind | OnePair_Q,

        ThreeOfAKind_K = ThreeOfAKind | OnePair_K,

        ThreeOfAKind_A = ThreeOfAKind | OnePair_A,

        Straight_5 = Straight | OnePair_5,

        Straight_6 = Straight | OnePair_6,

        Straight_7 = Straight | OnePair_7,

        Straight_8 = Straight | OnePair_8,

        Straight_9 = Straight | OnePair_9,

        Straight_T = Straight | OnePair_T,

        Straight_J = Straight | OnePair_J,

        Straight_Q = Straight | OnePair_Q,

        Straight_K = Straight | OnePair_K,

        Straight_A = Straight | OnePair_A,

        Flush_7 = Flush | OnePair_7,

        Flush_8 = Flush | OnePair_8,

        Flush_9 = Flush | OnePair_9,

        Flush_T = Flush | OnePair_T,

        Flush_J = Flush | OnePair_J,

        Flush_Q = Flush | OnePair_Q,

        Flush_K = Flush | OnePair_K,

        Flush_A = Flush | OnePair_A,

        FullHouse_23 = FullHouse | OnePair_2 | HighCard_3,

        FullHouse_24 = FullHouse | OnePair_2 | HighCard_4,

        FullHouse_25 = FullHouse | OnePair_2 | HighCard_5,

        FullHouse_26 = FullHouse | OnePair_2 | HighCard_6,

        FullHouse_27 = FullHouse | OnePair_2 | HighCard_7,

        FullHouse_28 = FullHouse | OnePair_2 | HighCard_8,

        FullHouse_29 = FullHouse | OnePair_2 | HighCard_9,

        FullHouse_2T = FullHouse | OnePair_2 | HighCard_T,

        FullHouse_2J = FullHouse | OnePair_2 | HighCard_J,

        FullHouse_2Q = FullHouse | OnePair_2 | HighCard_Q,

        FullHouse_2K = FullHouse | OnePair_2 | HighCard_K,

        FullHouse_2A = FullHouse | OnePair_2 | HighCard_A,

        FullHouse_32 = FullHouse | OnePair_3 | HighCard_2,

        FullHouse_34 = FullHouse | OnePair_3 | HighCard_4,

        FullHouse_35 = FullHouse | OnePair_3 | HighCard_5,

        FullHouse_36 = FullHouse | OnePair_3 | HighCard_6,

        FullHouse_37 = FullHouse | OnePair_3 | HighCard_7,

        FullHouse_38 = FullHouse | OnePair_3 | HighCard_8,

        FullHouse_39 = FullHouse | OnePair_3 | HighCard_9,

        FullHouse_3T = FullHouse | OnePair_3 | HighCard_T,

        FullHouse_3J = FullHouse | OnePair_3 | HighCard_J,

        FullHouse_3Q = FullHouse | OnePair_3 | HighCard_Q,

        FullHouse_3K = FullHouse | OnePair_3 | HighCard_K,

        FullHouse_3A = FullHouse | OnePair_3 | HighCard_A,

        FullHouse_42 = FullHouse | OnePair_4 | HighCard_2,

        FullHouse_43 = FullHouse | OnePair_4 | HighCard_3,

        FullHouse_45 = FullHouse | OnePair_4 | HighCard_5,

        FullHouse_46 = FullHouse | OnePair_4 | HighCard_6,

        FullHouse_47 = FullHouse | OnePair_4 | HighCard_7,

        FullHouse_48 = FullHouse | OnePair_4 | HighCard_8,

        FullHouse_49 = FullHouse | OnePair_4 | HighCard_9,

        FullHouse_4T = FullHouse | OnePair_4 | HighCard_T,

        FullHouse_4J = FullHouse | OnePair_4 | HighCard_J,

        FullHouse_4Q = FullHouse | OnePair_4 | HighCard_Q,

        FullHouse_4K = FullHouse | OnePair_4 | HighCard_K,

        FullHouse_4A = FullHouse | OnePair_4 | HighCard_A,

        FullHouse_52 = FullHouse | OnePair_5 | HighCard_2,

        FullHouse_53 = FullHouse | OnePair_5 | HighCard_3,

        FullHouse_54 = FullHouse | OnePair_5 | HighCard_4,

        FullHouse_56 = FullHouse | OnePair_5 | HighCard_6,

        FullHouse_57 = FullHouse | OnePair_5 | HighCard_7,

        FullHouse_58 = FullHouse | OnePair_5 | HighCard_8,

        FullHouse_59 = FullHouse | OnePair_5 | HighCard_9,

        FullHouse_5T = FullHouse | OnePair_5 | HighCard_T,

        FullHouse_5J = FullHouse | OnePair_5 | HighCard_J,

        FullHouse_5Q = FullHouse | OnePair_5 | HighCard_Q,

        FullHouse_5K = FullHouse | OnePair_5 | HighCard_K,

        FullHouse_5A = FullHouse | OnePair_5 | HighCard_A,

        FullHouse_62 = FullHouse | OnePair_6 | HighCard_2,

        FullHouse_63 = FullHouse | OnePair_6 | HighCard_3,

        FullHouse_64 = FullHouse | OnePair_6 | HighCard_4,

        FullHouse_65 = FullHouse | OnePair_6 | HighCard_5,

        FullHouse_67 = FullHouse | OnePair_6 | HighCard_7,

        FullHouse_68 = FullHouse | OnePair_6 | HighCard_8,

        FullHouse_69 = FullHouse | OnePair_6 | HighCard_9,

        FullHouse_6T = FullHouse | OnePair_6 | HighCard_T,

        FullHouse_6J = FullHouse | OnePair_6 | HighCard_J,

        FullHouse_6Q = FullHouse | OnePair_6 | HighCard_Q,

        FullHouse_6K = FullHouse | OnePair_6 | HighCard_K,

        FullHouse_6A = FullHouse | OnePair_6 | HighCard_A,

        FullHouse_72 = FullHouse | OnePair_7 | HighCard_2,

        FullHouse_73 = FullHouse | OnePair_7 | HighCard_3,

        FullHouse_74 = FullHouse | OnePair_7 | HighCard_4,

        FullHouse_75 = FullHouse | OnePair_7 | HighCard_5,

        FullHouse_76 = FullHouse | OnePair_7 | HighCard_6,

        FullHouse_78 = FullHouse | OnePair_7 | HighCard_8,

        FullHouse_79 = FullHouse | OnePair_7 | HighCard_9,

        FullHouse_7T = FullHouse | OnePair_7 | HighCard_T,

        FullHouse_7J = FullHouse | OnePair_7 | HighCard_J,

        FullHouse_7Q = FullHouse | OnePair_7 | HighCard_Q,

        FullHouse_7K = FullHouse | OnePair_7 | HighCard_K,

        FullHouse_7A = FullHouse | OnePair_7 | HighCard_A,

        FullHouse_82 = FullHouse | OnePair_8 | HighCard_2,

        FullHouse_83 = FullHouse | OnePair_8 | HighCard_3,

        FullHouse_84 = FullHouse | OnePair_8 | HighCard_4,

        FullHouse_85 = FullHouse | OnePair_8 | HighCard_5,

        FullHouse_86 = FullHouse | OnePair_8 | HighCard_6,

        FullHouse_87 = FullHouse | OnePair_8 | HighCard_7,

        FullHouse_89 = FullHouse | OnePair_8 | HighCard_9,

        FullHouse_8T = FullHouse | OnePair_8 | HighCard_T,

        FullHouse_8J = FullHouse | OnePair_8 | HighCard_J,

        FullHouse_8Q = FullHouse | OnePair_8 | HighCard_Q,

        FullHouse_8K = FullHouse | OnePair_8 | HighCard_K,

        FullHouse_8A = FullHouse | OnePair_8 | HighCard_A,

        FullHouse_92 = FullHouse | OnePair_9 | HighCard_2,

        FullHouse_93 = FullHouse | OnePair_9 | HighCard_3,

        FullHouse_94 = FullHouse | OnePair_9 | HighCard_4,

        FullHouse_95 = FullHouse | OnePair_9 | HighCard_5,

        FullHouse_96 = FullHouse | OnePair_9 | HighCard_6,

        FullHouse_97 = FullHouse | OnePair_9 | HighCard_7,

        FullHouse_98 = FullHouse | OnePair_9 | HighCard_8,

        FullHouse_9T = FullHouse | OnePair_9 | HighCard_T,

        FullHouse_9J = FullHouse | OnePair_9 | HighCard_J,

        FullHouse_9Q = FullHouse | OnePair_9 | HighCard_Q,

        FullHouse_9K = FullHouse | OnePair_9 | HighCard_K,

        FullHouse_9A = FullHouse | OnePair_9 | HighCard_A,

        FullHouse_T2 = FullHouse | OnePair_T | HighCard_2,

        FullHouse_T3 = FullHouse | OnePair_T | HighCard_3,

        FullHouse_T4 = FullHouse | OnePair_T | HighCard_4,

        FullHouse_T5 = FullHouse | OnePair_T | HighCard_5,

        FullHouse_T6 = FullHouse | OnePair_T | HighCard_6,

        FullHouse_T7 = FullHouse | OnePair_T | HighCard_7,

        FullHouse_T8 = FullHouse | OnePair_T | HighCard_8,

        FullHouse_T9 = FullHouse | OnePair_T | HighCard_9,

        FullHouse_TJ = FullHouse | OnePair_T | HighCard_J,

        FullHouse_TQ = FullHouse | OnePair_T | HighCard_Q,

        FullHouse_TK = FullHouse | OnePair_T | HighCard_K,

        FullHouse_TA = FullHouse | OnePair_T | HighCard_A,

        FullHouse_J2 = FullHouse | OnePair_J | HighCard_2,

        FullHouse_J3 = FullHouse | OnePair_J | HighCard_3,

        FullHouse_J4 = FullHouse | OnePair_J | HighCard_4,

        FullHouse_J5 = FullHouse | OnePair_J | HighCard_5,

        FullHouse_J6 = FullHouse | OnePair_J | HighCard_6,

        FullHouse_J7 = FullHouse | OnePair_J | HighCard_7,

        FullHouse_J8 = FullHouse | OnePair_J | HighCard_8,

        FullHouse_J9 = FullHouse | OnePair_J | HighCard_9,

        FullHouse_JT = FullHouse | OnePair_J | HighCard_T,

        FullHouse_JQ = FullHouse | OnePair_J | HighCard_Q,

        FullHouse_JK = FullHouse | OnePair_J | HighCard_K,

        FullHouse_JA = FullHouse | OnePair_J | HighCard_A,

        FullHouse_Q2 = FullHouse | OnePair_Q | HighCard_2,

        FullHouse_Q3 = FullHouse | OnePair_Q | HighCard_3,

        FullHouse_Q4 = FullHouse | OnePair_Q | HighCard_4,

        FullHouse_Q5 = FullHouse | OnePair_Q | HighCard_5,

        FullHouse_Q6 = FullHouse | OnePair_Q | HighCard_6,

        FullHouse_Q7 = FullHouse | OnePair_Q | HighCard_7,

        FullHouse_Q8 = FullHouse | OnePair_Q | HighCard_8,

        FullHouse_Q9 = FullHouse | OnePair_Q | HighCard_9,

        FullHouse_QT = FullHouse | OnePair_Q | HighCard_T,

        FullHouse_QJ = FullHouse | OnePair_Q | HighCard_J,

        FullHouse_QK = FullHouse | OnePair_Q | HighCard_K,

        FullHouse_QA = FullHouse | OnePair_Q | HighCard_A,

        FullHouse_K2 = FullHouse | OnePair_K | HighCard_2,

        FullHouse_K3 = FullHouse | OnePair_K | HighCard_3,

        FullHouse_K4 = FullHouse | OnePair_K | HighCard_4,

        FullHouse_K5 = FullHouse | OnePair_K | HighCard_5,

        FullHouse_K6 = FullHouse | OnePair_K | HighCard_6,

        FullHouse_K7 = FullHouse | OnePair_K | HighCard_7,

        FullHouse_K8 = FullHouse | OnePair_K | HighCard_8,

        FullHouse_K9 = FullHouse | OnePair_K | HighCard_9,

        FullHouse_KT = FullHouse | OnePair_K | HighCard_T,

        FullHouse_KJ = FullHouse | OnePair_K | HighCard_J,

        FullHouse_KQ = FullHouse | OnePair_K | HighCard_Q,

        FullHouse_KA = FullHouse | OnePair_K | HighCard_A,

        FullHouse_A2 = FullHouse | OnePair_A | HighCard_2,

        FullHouse_A3 = FullHouse | OnePair_A | HighCard_3,

        FullHouse_A4 = FullHouse | OnePair_A | HighCard_4,

        FullHouse_A5 = FullHouse | OnePair_A | HighCard_5,

        FullHouse_A6 = FullHouse | OnePair_A | HighCard_6,

        FullHouse_A7 = FullHouse | OnePair_A | HighCard_7,

        FullHouse_A8 = FullHouse | OnePair_A | HighCard_8,

        FullHouse_A9 = FullHouse | OnePair_A | HighCard_9,

        FullHouse_AT = FullHouse | OnePair_A | HighCard_T,

        FullHouse_AJ = FullHouse | OnePair_A | HighCard_J,

        FullHouse_AQ = FullHouse | OnePair_A | HighCard_Q,

        FullHouse_AK = FullHouse | OnePair_A | HighCard_K,

        FourOfAKind_2 = FourOfAKind | OnePair_2,

        FourOfAKind_3 = FourOfAKind | OnePair_3,

        FourOfAKind_4 = FourOfAKind | OnePair_4,

        FourOfAKind_5 = FourOfAKind | OnePair_5,

        FourOfAKind_6 = FourOfAKind | OnePair_6,

        FourOfAKind_7 = FourOfAKind | OnePair_7,

        FourOfAKind_8 = FourOfAKind | OnePair_8,

        FourOfAKind_9 = FourOfAKind | OnePair_9,

        FourOfAKind_T = FourOfAKind | OnePair_T,

        FourOfAKind_J = FourOfAKind | OnePair_J,

        FourOfAKind_Q = FourOfAKind | OnePair_Q,

        FourOfAKind_K = FourOfAKind | OnePair_K,

        FourOfAKind_A = FourOfAKind | OnePair_A,

        StraightFlush_5 = StraightFlush | OnePair_5,

        StraightFlush_6 = StraightFlush | OnePair_6,

        StraightFlush_7 = StraightFlush | OnePair_7,

        StraightFlush_8 = StraightFlush | OnePair_8,

        StraightFlush_9 = StraightFlush | OnePair_9,

        StraightFlush_T = StraightFlush | OnePair_T,

        StraightFlush_J = StraightFlush | OnePair_J,

        StraightFlush_Q = StraightFlush | OnePair_Q,

        StraightFlush_K = StraightFlush | OnePair_K,
    };
#if __LINE__
EnumFlags(Hand)
#else
}

// ReSharper restore InconsistentNaming
#endif
