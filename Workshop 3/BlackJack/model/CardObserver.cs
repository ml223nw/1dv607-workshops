﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface CardObserver
    {
        void CardRedrawn(Card a_card);
    }
}
