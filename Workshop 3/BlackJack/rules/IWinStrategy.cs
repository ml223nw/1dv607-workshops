using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    public interface IWinStrategy
    {
        bool IsDealerWinner(Player a_player, Dealer a_dealer, int maxScore);
    }
}