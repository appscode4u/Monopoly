using System;

namespace GraPlanszowa_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Run();

            //simulation of x moves for all players
            int simulationX = 100;
            for (int i = 0; i < simulationX; i++)
            {
                foreach (Player p in game.players)
                {
                    if (p.JailTurns == 0) { game.trowCubforMove(p); }
                    else {p.JailTurns--;}
                }
            }

            Console.WriteLine($"Player 1: {game.players[0].Name} obtain: {game.players[0].Wallet} USD, stoped at position: {game.players[0].GamePosition}");
            Console.WriteLine($"Player 2: {game.players[1].Name} obtain: {game.players[1].Wallet} USD, stoped at position: {game.players[1].GamePosition}");

            string winner = game.players[0].Wallet == game.players[1].Wallet ? "Remis" : game.players[0].Wallet > game.players[1].Wallet ? game.players[0].Name : game.players[1].Name;
            Console.WriteLine($"After {simulationX} turns the winner is: {winner}");

            Console.WriteLine();
        }
    }
}
