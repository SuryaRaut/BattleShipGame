using System;
namespace FinalBattleship
{
    public class Game
    {
        public Player1[] players;
        public Game()
        {
            players = new Player1[]
            {
                new Player1(1),
                new Player1(2)
            };
        }
        public void start()
        {
            int i = 0;
            int j = 1;

            int len = players.Length;
            Player1 player = null;
            this.players[i].placeShip();
            this.players[j].placeShip();

            while(players[0].getTotalLivesLeft() > 0 && 
                  players[1].getTotalLivesLeft() > 0)
            {
                players[i++ % len].fireAt(players[j++ % len]);
                player = (players[0].getTotalLivesLeft()
                          < players[1].getTotalLivesLeft())
                          ? players[1] : players[0];
            }
            Console.WriteLine(player.getId() + "won");
        }
    }
}
