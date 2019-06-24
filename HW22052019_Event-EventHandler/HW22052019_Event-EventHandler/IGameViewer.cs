using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW22052019_Event_EventHandler
{
    interface IGameViewer
    {
        void GoodSpaceShipHpChangedEventHandler(object sender, PointsEventsArgs e);
        void GoodSpaceShipLocationChangedEventHandler(object sender, LocationEventsArgs e);
        void GoodSpaceShipDestroyedEventHandler(object sender, LocationEventsArgs e);
        void BadShipExplodedEventHandler(object sender, BadShipsExplodedEventsArgs e);
        void LevelUpReachedEventHandler(object sender, LevelEventsArgs e);
       
    }
}
