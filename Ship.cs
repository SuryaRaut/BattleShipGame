using System;
namespace FinalBattleship
{
    public class Ship
    {
        private string name;
        private int size;
        private int lives;

        public Ship(string name, int size)
        {
            this.name = name;
            this.size = size;
            this.lives = size;
        }

        public void hit()
        {
            if(lives > 0)
            {
                Console.WriteLine(name + "was hit");
                lives--;
            }
            else
            {
                Console.WriteLine(name + "was sunk");
            }
        }
        public Result getState()
        {
            if(lives== 0)
            {
                return Result.DESTROYED;
            }
            else if(lives < size)
            {
                return Result.DESTROYED;
            }
            else
            {
                return Result.NO_HIT;
            }
        }
        public string getName()
        {
            return name;
        }
        public int getSize()
        {
            return size;
        }
    }
}
