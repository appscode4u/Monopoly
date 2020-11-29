using System;
using System.Collections.Generic;

namespace GraPlanszowa_lab1
{
    class Game
    {
        Random rnd = new Random();
        private int GapsCount;

        public List<Gap> gameMatrix;
        public List<Player> players = new List<Player>();

        public Game() { }

        public void Run()
        {
            setPlayers();
            startNewGame();
        }

        private void setPlayers()
        {
            players.Add(new Player("Maciek", 37, true, 2000));
            players.Add(new Player("RoboBoy", 135, false, 2000));
        }

        private void startNewGame()
        {
            gameMatrix = new Matrix().newMatrix();
            GapsCount = gameMatrix.Count;
        }


        private void checkGap(Player curPlayer)
        {
            //check type of stopped place of the player
            switch (gameMatrix[curPlayer.GamePosition].TYPE)
            {
                case 0:
                    //start position nothing to do
                    break; 
                case 1:
                    //City position; check if is someones if yes check if player self if yes increse multimpli at position, if no pay panilty to other player
                    break;  
                case 2:
                    //drawing a fortune card
                    break;
                case 3:
                    //parking position, free of charge place, nothing to do
                    break;
                case 4:
                    //panelty possition, player should pay money to the bank
                    break;
                case 5:
                    //player go to jail for two turns
                    curPlayer.JailTurns = 2;
                    break;
            }

        }

        public void trowCubforMove(Player curPlayer)
        {  
            //calculate possition
            int aTraw = rnd.Next(6) + 1;
            int move = curPlayer.GamePosition + aTraw;
            if (move >= GapsCount)
            {
                curPlayer.Wallet += 400; //retreive bonus becase player cross the start
                curPlayer.GamePosition = move % GapsCount; //calculate new position
            }
            else { curPlayer.GamePosition = move; }

            checkGap(curPlayer);
        }

        public int getGapsCount()
        {
            return GapsCount;
        }

    }
}
