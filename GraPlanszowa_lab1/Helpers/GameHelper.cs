using System;

namespace GraPlanszowa_lab1.Helpers
{
    static class GameHelper
    {
        public static string GetRandomName(bool human)
        {
            string[] imiona = { "Adam", "Magda", "Jan", "Karol", "Zbyszek", "Julia", "Kasia", "Zenek" };
            Random r = new Random();
            return human == true ? imiona[r.Next(imiona.Length)] : imiona[r.Next(imiona.Length)] + "AI";
        }

        public static bool GetRandomHumanity()
        {
            Random r = new Random();
            bool[] Human = { true, false };
            return Human[r.Next(2) % 2];
        }

        public static int GetRandomAge()
        {
            Random r = new Random();
            return r.Next(15,100);
        }

        public static bool CheckIfPlayerWantToBuyCity()
        {
            return true; //TODO lotery of joice
        }

        internal static bool CheckIfPlayerWantToBuyHouse()
        {
            return true; //TODO lotery of joice
        }
    }
}
