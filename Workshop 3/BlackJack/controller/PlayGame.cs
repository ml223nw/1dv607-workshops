using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model;

namespace BlackJack.model
{
    class PlayGame : model.CardObserver
    {
        private view.IView m_view;

        public void CardRedrawn(Card a_card)
        {
            m_view.MakeSuperExitingPause();
            m_view.DisplayCard(a_card);
        }

        public bool Play(model.Game a_game, view.IView a_view)
        {
            m_view = a_view;

            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            view.MenuChoice input = a_view.GetInput();

            if (input == view.MenuChoice.Play)
            {
                a_game.NewGame();
            }
            else if (input == view.MenuChoice.Hit)
            {
                a_game.Hit();
            }
            else if (input == view.MenuChoice.Stand)
            {
                a_game.Stand();
            }

            return input != view.MenuChoice.Quit;
        }
    }
}
