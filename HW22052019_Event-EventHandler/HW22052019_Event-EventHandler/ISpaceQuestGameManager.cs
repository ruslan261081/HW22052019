using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW22052019_Event_EventHandler
{
    interface ISpaceQuestGameManager
    {
        event EventHandler<PointsEventsArgs> GoodSpaceShipHpChanged;
        event EventHandler<LocationEventsArgs> GoodSpaceShipLocationChanged;
        event EventHandler<LocationEventsArgs> GoodSpaceShipDestroyed;
        event EventHandler<BadShipsExplodedEventsArgs> BadShipExploded;
        event EventHandler<LevelEventsArgs> LevelUpReached;

        void NewGame();
        void MoveSpaceShip(int newX, int newY);
        void GoodShipSpaceGetDamage(int damage);
        void EnemyShipDestroyed(int numberOfBadShipsDestroyed);
        void GoodSpaceShipGotExtraHp(int extraHp);
    }
}
