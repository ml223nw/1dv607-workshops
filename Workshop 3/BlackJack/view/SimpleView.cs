using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model;

namespace BlackJack.view
{
    class SimpleView : IView
    {
        public const char PLAY = 'p';
        public const char HIT = 'h';
        public const char STAND = 's';
        public const char QUIT = 'q';

        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hello Black Jack World");
            System.Console.WriteLine("Type '{0}' to Play, '{1}' to Hit, '{2}' to Stand or '{3}' to Quit\n", PLAY, HIT, STAND, QUIT);
        }

        public MenuChoice GetInput()
        {
            switch (System.Console.In.Read())
            {
                case PLAY:
                    return MenuChoice.Play;
                case HIT:
                    return MenuChoice.Hit;
                case STAND:
                    return MenuChoice.Stand;
                case QUIT:
                    return MenuChoice.Quit;
                default:
                    return MenuChoice.None;
            }

        }

        public void DisplayCard(model.Card a_card)
        {
            System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Player", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Dealer", a_hand, a_score);
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Score: {0}", a_score);
            System.Console.WriteLine("");
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Dealer Won!");
            }
            else
            {
                System.Console.WriteLine("You Won!");
            }

        }

        public void MakeSuperExitingPause()
        {
            System.Console.WriteLine("The dealer is dealing...");
            System.Threading.Thread.Sleep(800);
        }

    }

}