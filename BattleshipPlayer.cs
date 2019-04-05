using System;
namespace FinalBattleship
{
    public interface BattleshipPlayer
    {
        void placeShip();
        void fireAt(BattleshipPlayer opponent);
        int getTotalLivesLeft();
    }
}
