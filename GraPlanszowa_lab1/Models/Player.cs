using GraPlanszowa_lab1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraPlanszowa_lab1
{
    class Player : Person
    {
        public bool IsHuman { get; set; }
        public long Wallet { get; set; }

        public int GamePosition { get; set; }

        public int JailTurns { get; set; } = 0;


        public Player(string name,int age, bool isHuman,int startAmounOfMoney)
        {
            Name = name;
            Age = age;
            IsHuman = isHuman;
            Wallet = startAmounOfMoney;
            GamePosition = 0;
        }
    }
}
