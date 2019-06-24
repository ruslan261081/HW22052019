using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW22052019_Event_EventHandler
{
    public class SpaceQuestGameManeqer : ISpaceQuestGameManager
    {
        private int _goodSpaceShipHitPoints;
        private int _shipXLocation;
        private int _shipYLocation;
        private int _currentLevel;
        private int _numberOfBadShips;
        public bool WaitForNewGame = false;

        public SpaceQuestGameManeqer(int goodSpaceShipHitPoints, int shipXLocation, int shipYLocation)
        {
            _goodSpaceShipHitPoints = goodSpaceShipHitPoints;
            _shipXLocation = shipXLocation;
            _shipYLocation = shipYLocation;
            _currentLevel = 1;
            _numberOfBadShips = _currentLevel * 10;
        }

        public event EventHandler<PointsEventsArgs> GoodSpaceShipHpChanged;
        public event EventHandler<LocationEventsArgs> GoodSpaceShipLocationChanged;
        public event EventHandler<LocationEventsArgs> GoodSpaceShipDestroyed;
        public event EventHandler<BadShipsExplodedEventsArgs> BadShipExploded;
        public event EventHandler<LevelEventsArgs> LevelUpReached;

        public void NewGame()
        {
            _shipXLocation = 0;
            _shipYLocation = 0;
            _currentLevel = 1;
            _goodSpaceShipHitPoints = 100;
            Console.WriteLine("\n\nNew Game Will Start In 3 Seconds...");
            WaitForNewGame = true;
            Thread.Sleep(3000);
            Console.Clear();
            WaitForNewGame = false;
        }
        public void MoveSpaceShip(int newX, int newY)
        {
            _shipXLocation = newX;
            _shipYLocation = newY;
        }
        private void OnGoodSpaceShipLocationChanged()
        {
            if(GoodSpaceShipLocationChanged != null)
            {
                GoodSpaceShipLocationChanged.Invoke(this, new LocationEventsArgs { X = _shipXLocation, Y = _shipYLocation });
            }
        }
        public void GoodShipsSpaceGetDamage(int damege)
        {
            _goodSpaceShipHitPoints -= damege;
            if(_goodSpaceShipHitPoints > 0)
            {
                Console.Write("Oyy, Your Ship Has Been Damaged...! ");
                OnGoodSpaceShipLocationChanged();
            }
            else
            {
                OnGoodSpaceShipDestroyed();
            }
        }
        private void OnGoodSpaceShipHpChanged()
        {
            if(GoodSpaceShipHpChanged != null)
            {
                GoodSpaceShipHpChanged.Invoke(this, new PointsEventsArgs { HpPoints = _goodSpaceShipHitPoints });
            }
        }
        private void OnGoodSpaceShipDestroyed()
        {
            if(GoodSpaceShipDestroyed != null)
            {
                GoodSpaceShipDestroyed.Invoke(this, new LocationEventsArgs { X = _shipXLocation, Y = _shipYLocation });
                NewGame();
            }

        }
        public void EnemyShipDestroyed(int numberOfBadShipDestroyed)
        {
            _numberOfBadShips -= numberOfBadShipDestroyed;
            if(numberOfBadShipDestroyed > 5)
            {
                GoodSpaceShipGotExtraHp(20);
            }
            if (_numberOfBadShips < 1)
            {
                _currentLevel++;
                OnLevelUpReached();
                if (_currentLevel > 2)
                {
                    Console.WriteLine("Congratulations! You Destroyed All The Bad Ships !!!");
                    NewGame();
                }
                _numberOfBadShips = _currentLevel * 10;
            }
            else
                OnBadShipExploded();
           
        }
        private void OnBadShipExploded()
        {
            if(BadShipExploded != null)
            {
                BadShipExploded.Invoke(this, new BadShipsExplodedEventsArgs { NumberOfBadShips = _numberOfBadShips });
            }
        }
        public void GoodSpaceShipGotExtraHp(int extraHp)
        {
            _goodSpaceShipHitPoints += extraHp;
            if(GoodSpaceShipHpChanged != null)
            {
                Console.Write("Wow Your Ship Got extra Hp ");
                GoodSpaceShipHpChanged.Invoke(this, new PointsEventsArgs { HpPoints = _goodSpaceShipHitPoints });
            }
        }
        private void OnLevelUpReached()
        {
            _goodSpaceShipHitPoints = 100;
            if(LevelUpReached != null)
            {
                LevelUpReached.Invoke(this, new LevelEventsArgs { CurrentLevel = _currentLevel });
            }
        }

        public void GoodShipSpaceGetDamage(int damage)
        {
            throw new NotImplementedException();
        }
    }

   
}
