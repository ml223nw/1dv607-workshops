using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(Player a_dealer)
        {
            int scoreDealer = a_dealer.CalcScore();

            if (scoreDealer == g_hitLimit)
            {
                foreach (Card c in a_dealer.GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && (scoreDealer - 11) == 6)
                    {
                        scoreDealer -= 10;
                    }
                }
                return scoreDealer < g_hitLimit;
            }
            else if (scoreDealer < g_hitLimit)
            {
                return true;
            }
            return false;
        }
    }
}