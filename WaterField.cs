using System;
namespace FinalBattleship
{
    public class WaterField : NewGameField
    {
        private bool hasThisFieldHit = false;

        public char getIcon()
        {
            return hasThisFieldHit ? 'x' : '~';
            throw new NotImplementedException();
        }

        public Result shootAt()
        {
            hasThisFieldHit = true;
            return Result.NO_HIT;
            throw new NotImplementedException();
        }
    }
}
