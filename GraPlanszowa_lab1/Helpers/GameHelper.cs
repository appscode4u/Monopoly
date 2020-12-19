﻿using System;

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

        public static int GetBoughtCities(Player p)
        {
            if (p.OwnedCities == null)
            {
                return 0;
            }
            else
            {
                return p.OwnedCities.Count;
            }
        }
    }
}