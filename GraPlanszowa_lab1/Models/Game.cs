using GraPlanszowa_lab1.Dictionaries;
using GraPlanszowa_lab1.Helpers;
using GraPlanszowa_lab1.Models;
using System.Collections.Generic;

namespace GraPlanszowa_lab1
{
    class Game
    {
        private int GapsCount;

        public List<Gap> gameMatrix;
        public List<Player> players = new List<Player>();

        public Game() { }

        public void Run()
        {
            //setPlayers();
            //startNewGame();
        }
        
        public void addPlayer(Player p)
        {
            players.Add(p);
        }

        public void StartGame()
        {
            startNewGame();
        }

        /*private void setPlayers()
        {
            players.Add(new Player("Maciek", 37, true, 2000));
            players.Add(new Player("RoboBoy", 135, false, 2000));
        }*/

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
                    //check player possition is already owned
                    Player owner = isOwned(curPlayer);
                    
                    if (owner!=null) //there is an owner
                    {
                        /*TODO:
                            check if owner is the same that curPlayer

                            yes
                                - check if player have enough money to buy next house
                                - check if player want to buy this house
                            no
                                - check how many player have to pay the other player
                        */
                    }
                    else //currently no owner at possition
                    {
                        //check if player have enouth money
                        if (checkIfPlayerHaveMoneyForCity(curPlayer))
                        {
                            //check if player want to buy city
                            if (GameHelper.CheckIfPlayerWantToBuyCity())
                            {
                                //invoke buy city logic
                                PlayerBuyCity(curPlayer);

                                //check if player have enouth money to buy house and if there is a space for new house
                                if (checkIfPlayerHaveMoneyForHouse(curPlayer)&&checkIfHouseCouldBeBuy(curPlayer))
                                {
                                    //check if player want to buy a house
                                    if (GameHelper.CheckIfPlayerWantToBuyHouse())
                                    {
                                        //invoke buy house logic
                                        PlayerBuyAhouse(curPlayer);
                                    }
                                }
                            }
                        }
                    }
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
            int aTraw = Cube.getInstance(6).Lotery(); //retrieve random number 1-6 from singleton pattern implemented in class Cube
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

        public string GetPositionName(int i)
        {
            return i > -1 && i <= gameMatrix.Count ? gameMatrix[i].NAME : "";
        }

        public Player isOwned(Player p)
        {
            if (gameMatrix[p.GamePosition].OWNER!=null)
            {
                return gameMatrix[p.GamePosition].OWNER;
            }
            return null;
        }

        private bool checkIfPlayerHaveMoneyForCity(Player p)
        {
            if (p.Wallet >= gameMatrix[p.GamePosition].CITYCOST) { return true; }
            return false;
        }

        private bool checkIfPlayerHaveMoneyForHouse(Player p)
        {
            if (p.Wallet >= gameMatrix[p.GamePosition].HOUSECOST) { return true; }
            return false;
        }

        private void PlayerBuyCity(Player p)
        {
            gameMatrix[p.GamePosition].OWNER = p; //handler for the owner
            p.Wallet -= (long)gameMatrix[p.GamePosition].CITYCOST; //decrase amount of money
        }

        private bool checkIfHouseCouldBeBuy(Player p)
        {
            if (gameMatrix[p.GamePosition].MULTIPLIER <= Settings.MaxNumberOfHouses) { return true; }
            return false;
        }

        private void PlayerBuyAhouse(Player p)
        {
            gameMatrix[p.GamePosition].MULTIPLIER += 1; //incrase number of bought houses in current city
            p.Wallet -= gameMatrix[p.GamePosition].HOUSECOST; //decrease player's amount of money
        }

    }
}
