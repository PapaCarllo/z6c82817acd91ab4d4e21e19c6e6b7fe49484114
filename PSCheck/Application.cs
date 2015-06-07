using System;
using System.Diagnostics;

using PokerFramework;

namespace PSCheck
{
    public class Application : System.Windows.Application
    {
        [STAThread]
        public static void Main()
        {
            //var x = HandsConfrontation.Confrontations().ToArray();
            //var hand1 = Hand.Get("AsAd");

            //var hand2 = Hand.Get("KsKc");

            //var diff = hand1 - hand2;
            //var x = diff.Win;
            //var x = Combination.Collection;

            //Card.Collection[0].

            //var deal = new Deal("AsAd", "KsKd");
            //deal.Board = new Card[] { "Ac" };

            //hands[0] = "QdQs";

            //var x = Suit.Values;
            //Suit.Value c = Suit.Club;
            //Suit.Value v = (Suit.Value)0;
            //Suit.Value v2 = default(Suit.Value);

            //var board = new Board();
            //var hand1 = new Hand();
            //var hand2 = new Hand();
            //var push = new OddsCalculator(); //board, hand1, hand2);

            //var x = (Pocket)"Ac Ad";

            //var z = Card.Dictionary[CardRank.Five, CardSuit.Club];

            //foreach (var startingHand in Pocket.Dictionary)
            //{
            //    if (startingHand != (Pocket)(string)startingHand)
            //    {
            //    }
            //}

            //var c = Pocket.Dictionary.Select(h => h.ToString()).Distinct().ToArray();


            //var d = (Pocket)"As Qs";
            //var m = HandRank.HighCards[CardRank.Ace];
            //var u = HandsComparer.Deck;

            //var x = 0;
            //var r = 0L;
            //for (int i = 0; i < 32; i++)
            //{
            //    var hs = new HandsComparer();
            //    var sw = Stopwatch.StartNew();
            //    x = hs.lComparer();
            //    sw.Stop();
            //    r += sw.ElapsedMilliseconds;

            //    if (i == 0)
            //    {
            //        Debug.Assert(x == 2598960);
            //        Debug.Assert(Hand.HighCards == 1302540);
            //        Debug.Assert(Hand.OnePairs == 1098240);
            //        Debug.Assert(Hand.TwoPairs == 123552);
            //        Debug.Assert(Hand.ThreeOfAKinds == 54912);
            //        Debug.Assert(Hand.Straights == 10200);
            //        Debug.Assert(Hand.Flushes == 5108);
            //        Debug.Assert(Hand.FullHouses == 3744);
            //        Debug.Assert(Hand.FourOfAKinds == 624);
            //        Debug.Assert(Hand.StraightFlushes == 40);
            //    }
            //}
            //var res = (double)r / 32;

            var hs = new HandsComparer();

            var sw = Stopwatch.StartNew();
            var x = hs.TestCalcHeroWinOdds();
            sw.Stop();
            Debug.Assert(x == 2598960);
            var r = sw.ElapsedMilliseconds;
            Console.WriteLine(r);

            var application = new Application();
            application.InitializeComponent();
            application.Run();
        }

        public void InitializeComponent()
        {
            StartupUri = new System.Uri("MainWindow.xaml", System.UriKind.Relative);
        }

        /*
        public abstract class ShutdownsEnumerator
        {
            public Board Board { get; private set; }
            public Card[] CardsInOut { get; private set; }
            public Hand[] Hands { get; private set; }

            protected Combination[] TestCombinations;

            protected abstract void Accumulate();

            private void Calculate(Board board, Card[] cardsInOut, )
        }

        public class Board
        {
            public Flop Flop;
            public Card Turn;
            public Card River;
        }

        public class Flop
        {
            public Card Card1;
            public Card Card2;
            public Card Card3;
        }

        public class Combination
        {
            public Card Card1;
            public Card Card2;
            public Card Card3;
            public Card Card4;
            public Card Card5;
        }

        */
    }
}