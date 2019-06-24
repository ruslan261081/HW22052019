using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW22052019_Event_EventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            GameViewer game = new GameViewer();
            SpaceQuestGameManeqer spaceQuest = new SpaceQuestGameManeqer(100,20,30);
            Random random = new Random();
            System.Timers.Timer timer = new System.Timers.Timer(1000);

            spaceQuest.GoodSpaceShipHpChanged += game.GoodSpaseShipHpChangedEventHandler;
            spaceQuest.GoodSpaceShipLocationChanged += game.GoodSpaceShipLocationChangedEventHandler;
            spaceQuest.LevelUpReached += game.LevelUpReachedEventHandler;
            spaceQuest.BadShipExploded += game.BadShipExplodedEventHandler;
            spaceQuest.GoodSpaceShipDestroyed += game.GoodSpaceShipDestroyedEventHandler;

            timer.Elapsed += (sender, e) =>
            {
                int x = random.Next(1, 5);
                if (spaceQuest.WaitForNewGame == false)
                {
                    switch (x)
                    {
                        case 1:
                            spaceQuest.GoodShipsSpaceGetDamage(random.Next(3, 40));
                            break;
                        case 2:
                            spaceQuest.EnemyShipDestroyed(random.Next(1, 8));
                            break;
                        case 3:
                            spaceQuest.MoveSpaceShip(random.Next(1500), random.Next(1500));
                            break;
                        default: break;
                    }

                }

            };
            timer.Start();
            while (true)
            {

            }
        }
    }
}
