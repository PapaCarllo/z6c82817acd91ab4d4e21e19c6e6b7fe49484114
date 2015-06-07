using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PokerFramework.Core
{
    static public class Api
    {
        [DllImport("PokerFramework.Core.dll", EntryPoint = "BuildBestHand")]
        private static extern CalcHeroWinOddsResult BuildBestHandInternal(CardSet cardSet);

        [DllImport("PokerFramework.Core.dll")]
        private static extern CalcHeroWinOddsResult CalcHeroWinOdds(CardSet heroPocket, CardSet board, CardSet muck, int opponentsCount, [In] CardSet[] opponentPockets, [In] uint[] heroWinOdds);

        public static uint CalcHeroWinOdds(CardSet heroPocket, CardSet board, CardSet muck, CardSet[] opponentPockets, uint[] heroWinOdds)
        {
            if (opponentPockets == null)
            {
                throw new InvalidEnumArgumentException(CalcHeroWinOddsResult.WrongOpponentPockets.ToString());
            }

            if (heroWinOdds == null || opponentPockets.Length > heroWinOdds.Length)
            {
                throw new InvalidEnumArgumentException(CalcHeroWinOddsResult.WrongHeroWinOdds.ToString());
            }

            var result = CalcHeroWinOdds(heroPocket, board, muck, opponentPockets.Length, opponentPockets, heroWinOdds);
            if (result <= 0)
            {
                throw new InvalidEnumArgumentException(result.ToString());
            }

            return (uint)result;
        }
    }
}

