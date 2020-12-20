using GraPlanszowa_lab1.Dictionaries;
using GraPlanszowa_lab1.Helpers;
using GraPlanszowa_lab1.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraPlanszowa_lab1
{
    class Game
    {
        private int GapsCount;

        public List<Gap> gameMatrix;
        public List<Player> players = new List<Player>();

        public Game() { }
        
        public void AddPlayer(Player p)
        {
            players.Add(p);
        }

        public void StartGame()
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            gameMatrix = new Matrix().newMatrix();
            GapsCount = gameMatrix.Count;
        }


        private void CheckGap(Player curPlayer)
        {
            //check type of stopped place of the player
            switch (gameMatrix[curPlayer.GamePosition].TYPE)
            {
                case 0:
                    //start position nothing to do
                    break; 
                case 1: 
                    //check player possition is already owned
                    Player owner = IsOwned(curPlayer);
                    
                    if (owner!=null) //there is an owner
                    {
                        //check if owner is the same that curPlayer
                        if(owner == curPlayer)
                        {
                            //check if player have enouth money to buy house and if there is a space for new house
                            if (CheckIfPlayerHaveMoneyForHouse(curPlayer) && CheckIfHouseCouldBeBuy(curPlayer))
                            {
                                //check if player want to buy a house
                                if (GameHelper.CheckIfPlayerWantToBuyHouse())
                                {
                                    //invoke buy house logic
                                    PlayerBuyAhouse(curPlayer);
                                }
                            }
                        }
                        else
                        {
                            SubAddMoneyPlayerStayAtOwnedGap(owner, curPlayer);
                        }
                    }
                    else //currently no owner at possition
                    {
                        //check if player have enouth money
                        if (CheckIfPlayerHaveMoneyForCity(curPlayer))
                        {
                            //check if player want to buy city
                            if (GameHelper.CheckIfPlayerWantToBuyCity())
                            {
                                //invoke buy city logic
                                PlayerBuyCity(curPlayer);

                                //check if player have enouth money to buy house and if there is a space for new house
                                if (CheckIfPlayerHaveMoneyForHouse(curPlayer)&&CheckIfHouseCouldBeBuy(curPlayer))
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

        private void SubAddMoneyPlayerStayAtOwnedGap(Player owner, Player curPlayer)
        {
            owner.Wallet += gameMatrix[curPlayer.GamePosition].REWARD * gameMatrix[curPlayer.GamePosition].MULTIPLIER;
            curPlayer.Wallet -= gameMatrix[curPlayer.GamePosition].REWARD * gameMatrix[curPlayer.GamePosition].MULTIPLIER;
        }

        public void TrowCubforMove(Player curPlayer)
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

            CheckGap(curPlayer);
        }

        public int GetGapsCount()
        {
            return GapsCount;
        }

        public string GetPositionName(int i)
        {
            return i > -1 && i <= gameMatrix.Count ? gameMatrix[i].NAME : "";
        }

        public Player IsOwned(Player p)
        {
            if (gameMatrix[p.GamePosition].OWNER!=null)
            {
                return gameMatrix[p.GamePosition].OWNER;
            }
            return null;
        }

        private bool CheckIfPlayerHaveMoneyForCity(Player p)
        {
            if (p.Wallet >= gameMatrix[p.GamePosition].CITYCOST) { return true; }
            return false;
        }

        private bool CheckIfPlayerHaveMoneyForHouse(Player p)
        {
            if (p.Wallet >= gameMatrix[p.GamePosition].HOUSECOST) { return true; }
            return false;
        }

        private void PlayerBuyCity(Player p)
        {
            gameMatrix[p.GamePosition].OWNER = p; //handler for the owner
            p.Wallet -= (long)gameMatrix[p.GamePosition].CITYCOST; //decrase amount of money
        }

        private bool CheckIfHouseCouldBeBuy(Player p)
        {
            if (gameMatrix[p.GamePosition].MULTIPLIER <= Settings.MaxNumberOfHouses) { return true; }
            return false;
        }

        private void PlayerBuyAhouse(Player p)
        {
            gameMatrix[p.GamePosition].MULTIPLIER += 1; //incrase number of bought houses in current city
            p.Wallet -= gameMatrix[p.GamePosition].HOUSECOST; //decrease player's amount of money
        }


        public int GetBoughtCitiesCount(Player p)
        {
            return gameMatrix.Where(own => own.OWNER == p).Count(); ;
        }
    }
}
