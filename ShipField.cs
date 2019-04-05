using System;
namespace FinalBattleship
{
    public class ShipField : NewGameField
    {
        public Ship ship;

        public ShipField(Ship ship)
        {
            this.ship = ship;
        }

        public char getIcon()
        {
            char icon;
            Result shipState = ship.getState();
            switch (shipState)
            {
                case Result.HIT: icon = 'x';
                    break;
                case Result.DESTROYED: icon = 'x';
                    break;
                case Result.NO_HIT: icon = 'm';
                    break;
                default: icon = ' ';
                    break;


            }
            return icon;
        }

        public Result shootAt()
        {
            ship.hit();
            return ship.getState();
        }
    }
}
