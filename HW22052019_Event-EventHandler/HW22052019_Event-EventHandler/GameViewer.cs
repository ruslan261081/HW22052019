using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW22052019_Event_EventHandler
{
    class GameViewer : IGameViewer
    {
       public void GoodSpaseShipHpChangedEventHandler(object sender, PointsEventsArgs e)
       {
            Console.WriteLine($"Now, Your Hp Is: {e.HpPoints}");
       }
       public void GoodSpaceShipLocationChangedEventHandler(object sender, LocationEventsArgs e)
       {
            Console.WriteLine($"Your Location Is Change To: {e.X}/{e.Y}.");
       }
       public void  GoodSpaceShipDestroyedEventHandler(object sender, LocationEventsArgs e)
       {
            Console.WriteLine($"\n\nThe Game Is Over! Your Ship Destroyed At: {e.X}/{e.Y} ):");
       }
       public void BadShipExplodedEventHandler(object sender, BadShipsExplodedEventsArgs e)
       {
            Console.WriteLine($"Boom!!! You Need To Explode More {e.NumberOfBadShips} Bad Ships.");
       }
       public void LevelUpReachedEventHandler(object sender, LevelEventsArgs e)
       {
            Console.WriteLine($"Excellent!!! You Reached {e.CurrentLevel} Level !!");

       }

        public void GoodSpaceShipHpChangedEventHandler(object sender, PointsEventsArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
