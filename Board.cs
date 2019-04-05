using System;
using System.Collections.Generic;

namespace FinalBattleship
{
    public class Board
    {
        public static char WATER = '~';
        public static int BOARD_SIZE = 10;
        public static char[] BOARD_LETTERS = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        public static string HORIZONTAL = "H";
        public static string VERTICAL = "V";

        public NewGameField[][] board;
        //public List<Ship> ships { get; set; }
        public static Ship[] ships;

        static Board() {
            ships = new Ship[]
            {
            new Ship("Carrier", ShipSize.BATTLESHIP),
            new Ship("Battleship", ShipSize.BATTLESHIP),
            new Ship("Cruiser", ShipSize.CRUISER),
            new Ship("Submarine", ShipSize.SUBMARINE),
            new Ship("Destroyer", ShipSize.DESTROYER)
 };


        }

        public Board()
        {
            this.board = new NewGameField[BOARD_SIZE][];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    board[i][j] = new WaterField();
                }
            }
        }

        public void placeShipOnBoard()
        {
            if (ships != null)
            {
                foreach (Ship ship in ships)
                {
                    bool horizontal = askValidShipDirection();
                    Point startingPoint = askValidStartingPoint(ship, horizontal);
                    placeValidShip(ship, startingPoint, horizontal);

                    printBoard();
                }
            }


        }
        public NewGameField GetField(int x, int y)
        {
            if (!isInsideBoard(x, y))
            {
                throw new ArgumentOutOfRangeException("Outside board - try again: ");
                //Console.Write("Outside Board");
            }
            return board[y][x];
        }

        public void printBoard()
        {
            Console.WriteLine("\t");
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                Console.WriteLine(BOARD_LETTERS + "\t");
            }
            Console.WriteLine();

            for (int i = 0; i < BOARD_SIZE; i++)
            {
                Console.WriteLine((i + 1) + "\t");
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Console.Write(board[i][j].getIcon() + "\t");
                }
                Console.WriteLine();
            }

        }
        public bool askValidShipDirection()
        {
            Console.WriteLine("%nDo you want to place the ship horizontally (H) or vertically (V)?");


            string direction;
            do
            {
                direction = Console.ReadLine().Trim();

            } while (!HORIZONTAL.Equals(direction) && !VERTICAL.Equals(direction));
            return HORIZONTAL.Equals(direction);

        }

        public Point askValidStartingPoint(Ship ship, bool horizontal)
        {
            Point from;
            do
            {
                Console.WriteLine("name: {0} Enter position of %s (length  %d): ", ship.getName(), ship.getSize());
                from = new Point(Console.ReadLine());
            } while (!isValidStartingPoint(from, ship.getSize(), horizontal));
            return from;

        }

        public bool isValidStartingPoint(Point from, int length, bool horizontal)
        {
            int xDiff = 0;
            int yDiff = 0;
            if (horizontal)
            {
                xDiff = 1;
            }
            else
            {
                yDiff = 1;
            }

            int x = (int)from.getX() - 1;
            int y = (int)from.getY() - 1;
            if (!isInsideBoard(x, y) || (!isInsideBoard(x + length, y) && horizontal) ||(!isInsideBoard(x, y+ length) && !horizontal))
            {
                return false;
            }
            for(int i = 0; i<length; i++)
            {
                if(board[(int)from.getY() + i * xDiff -1][(int)from.getX() + i * yDiff-1].getIcon() != WATER)
                {
                    return false;
                }
            }
            return true;
        }

        public void placeValidShip(Ship ship, Point startingPoint, bool horizontal)
        {
            int xDiff = 0;
            int yDiff = 0;
            if (horizontal)
            {
                xDiff = 1;
            }
            else
            {
                yDiff = 1;
            }
            for(int i = 0; i<ship.getSize(); i++)
            {
                board[(int)startingPoint.getY() + i * yDiff - 1][(int)startingPoint.getX() + i * xDiff - 1]
                = new ShipField(ship);
            }

        }

        public bool isInsideBoard(int x , int y)
        {
            return x <= BOARD_SIZE && x >= 0
                && y <= BOARD_SIZE && y >= 0;
        }
    }
}
