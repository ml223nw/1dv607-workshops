using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Program
    {
        static void Main(string[] args)
        {
            model.Game g = new model.Game();
            view.IView v = new view.SimpleView(); // new view.SwedishView();
            model.PlayGame c = new model.PlayGame();
            g.ObserveCards(c);

            while (c.Play(g, v)) ;
        }
    }
}