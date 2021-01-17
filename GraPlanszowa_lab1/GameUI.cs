using GraPlanszowa_lab1.Helpers;
using GraPlanszowa_lab1.Models;
using System;
using System.Collections.Generic;

namespace GraPlanszowa_lab1
{
    class GameUI
    {
        private int startMoney;
        protected Game game;
        public MovesHistory GameHistory;
        private List<HistoryDetail> PlayerHistory;

        public GameUI()
        {
            game = new Game();

            GameHistory = new MovesHistory();
        }

        public void GameInit() => InitializeGameLogicFlow();

        internal void DisplayGameHistoryForEachPlayer()
        {
            Console.WriteLine($"\nHistory of moves (player count: {GameHistory.History.Count}):\n");

            foreach (var key in GameHistory.History.Keys)
            {
                Console.WriteLine($"Player: {key}");
                PlayerHistory = GameHistory.History[key];

                int i = 0;
                foreach (var ph in PlayerHistory)
                {
                    Console.WriteLine($"   Move {i}: game position: {ph.MoveIntoPosition}, wallet value: {ph.Wallet}");

                    i++;
                }
            }
        }

        private void InitializeGameLogicFlow()
        {

            //initialize amount of starting money
            if (!StartAmountOfMoney()) { ExitGame(1); }

            //initialize number of players
            if (!SetPlayers()) { ExitGame(2); }

        }

        private void ExitGame(int err)
        {
            string message = "";

            switch(err){
                case 1: message = "Starting amount of money must be an Integer value"; break;
                case 2: message = "Exit Game because of wrong game settings"; break;
                case 3: message = "Propable number of turns were defined incorrectly"; break;
            }

            Console.WriteLine(message);
            Environment.Exit(0); //close program
        }

        private bool StartAmountOfMoney()
        {
            Console.WriteLine("Type amount of starting money for players: ");
            if (Int32.TryParse(Console.ReadLine(), out int startMoney))
            {
                this.startMoney = startMoney;
                return true;
            }
            return false;
        }

        private bool SetPlayers()
        {

            Console.WriteLine("Number of players (1-4)?: ");
            int i = int.Parse(Console.ReadLine());

            if (i > 0 && i <= 4)
            {

                //************************* JUST FOR TESTST, uncomment this block to enable automated user create
                SetPlayersWithoutConsoleForTest(i);
                return true;
                //*****************************************
            

                for (int k = 0; k < i; k++)
                {
                    Console.Clear();
                    Console.WriteLine("Type name of {0} player",k+1);
                    string name = Console.ReadLine();
                    Console.WriteLine("Type age of {0} player", k + 1);
                    if (!Int32.TryParse(Console.ReadLine(), out int age))
                    {
                        return false;
                    }
                    Console.WriteLine("Is player {0} a human (y/n)", k + 1);
                    char humanChar = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    bool human;
                    if (humanChar == 'y' || humanChar == 'Y')
                    {
                        human = true;
                    }
                    else if(humanChar == 'n' || humanChar == 'N'){
                        human = false;
                    }
                    else
                    {
                        return false;
                    }

                    game.AddPlayer(new Player(name, age, human, this.startMoney));

                    PlayerHistory = new List<HistoryDetail>();
                    PlayerHistory.Add(new HistoryDetail { MoveIntoPosition = 0, Wallet = this.startMoney });
                    GameHistory.History.Add(name, PlayerHistory);

                }
                return true;
            }
            return false; //something goes wrong; return false to stop program
        }

        private void SetPlayersWithoutConsoleForTest(int playersCount)
        {
            for (int i = 0; i < playersCount; i++)
            {   
                bool human = GameHelper.GetRandomHumanity();
                int age = GameHelper.GetRandomAge();
                string name = GameHelper.GetRandomName(human);
                
                //disable the same name for players; prevent for the same key in dictionary
                while (GameHistory.History.ContainsKey(name)){
                    name = GameHelper.GetRandomName(human);
                }
            
                game.AddPlayer(new Player(name, age, human, this.startMoney));

                PlayerHistory = new List<HistoryDetail>();
                PlayerHistory.Add(new HistoryDetail { MoveIntoPosition = 0, Wallet = this.startMoney });
                GameHistory.History.Add(name, PlayerHistory);

            }
        }

        internal void GetScore()
        {
            Console.WriteLine("\n");
            int i = 0;
            foreach (Player p in game.players)
            {
                Console.WriteLine($"Player {i+1}: {game.players[i].Name} " +
                    $"obtain: {game.players[i].Wallet} USD, " +
                    $"stoped at position: {game.players[i].GamePosition}, " +
                    $"is human? {game.players[i].IsHuman}, " +
                    $"bought {game.GetBoughtCitiesCount(p)} cities");
                i++;
            }
        }

        internal void SimulationGame()
        {
            Console.WriteLine("Type number of total simulations:");
            if (!Int32.TryParse(Console.ReadLine(), out int turns))
            {
                ExitGame(3); //exit if an error occurred
            }

            //starting a game
            game.StartGame();

            Console.WriteLine($"Starting simulation for: {turns} turns");
            for (int i = 0; i < turns; i++)
            {
                int k = 1;
                foreach (Player p in game.players)
                {
                    if (p.JailTurns == 0) { game.TrowCubforMove(p); }
                    else { p.JailTurns--; }
                    Console.WriteLine($"Player: {p.Name} moved to gap: {p.GamePosition}, gap description: {game.GetPositionName(p.GamePosition)} wallet: {p.Wallet}");

                    //support for collect history
                        PlayerHistory = GameHistory.History[p.Name];
                        PlayerHistory.Add(new HistoryDetail { MoveIntoPosition = p.GamePosition, Wallet = p.Wallet });
                    //

                    k++;
                    System.Threading.Thread.Sleep(250);
                }
            }
        }

        public void ListOwnedCitiesDetails()
        {
            Console.WriteLine();
            foreach (var item in game.gameMatrix)
            {
                if (item.OWNER != null) { 
                    Console.WriteLine($"City: {item.NAME} owner: {item.OWNER.Name} number of houses: {item.MULTIPLIER}");}
            }
        }
    }
}
