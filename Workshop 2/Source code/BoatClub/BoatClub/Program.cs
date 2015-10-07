using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub
{
    class Program
    {
        static void Main(string[] args)
        {
            BoatClub.Controller.Controller controller = new BoatClub.Controller.Controller();
            controller.Run();
        }
    }
}
