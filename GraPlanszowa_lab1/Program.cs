using GraPlanszowa_lab1.Helpers;
using System;

namespace GraPlanszowa_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            GameUI UI = new GameUI(); //initialize UI object

            UI.GameInit();           //initialize game basic settings
            UI.SimulationGame();     //start simulation
            UI.getScore();           //display game scores

            Console.WriteLine();
            UI.ListOwnedCitiesDetails(); //display cities, theirs owners and number of houses
        }
    }
}
