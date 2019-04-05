using System;
namespace FinalBattleship
{
    public struct Point
    {
        private string v;

        public Point(string v) : this()
        {
            this.v = v;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int getX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }
    }
    public class Player1 : BattleshipPlayer
    {
        public int totalLivesLeft = 17;
        public int id;
        public Board board;


        public Player1(int id)
        {
            this.id = id;
            board = new Board();

        }
        public int getId()
        {
            return id;
        }
        public Board GetBoard()
        {
            return board;
        }

        public void fireAt(BattleshipPlayer opponent)
        {
            Console.WriteLine("Enter coordinate for fire");
            bool IsPointValid = false;
            while (!IsPointValid)
            {
                try
                {
                    Point point = new Point(Console.ReadLine());
                    int x = point.getX() - 1;
                    int y = point.getY() - 1;
                    Result result = ((Player1)opponent).GetBoard().GetField(x, y).shootAt();
                    if (result == Result.HIT || result == Result.DESTROYED)
                    {
                        totalLivesLeft--;
                    }
                    IsPointValid = true;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }
            }

        }

        public int getTotalLivesLeft()
        {
            return totalLivesLeft;
            throw new NotImplementedException();
        }

        public void placeShip()
        {
            Console.WriteLine("id: {0}place your ship", id);

            board.placeShipOnBoard();

        }
    }
}
