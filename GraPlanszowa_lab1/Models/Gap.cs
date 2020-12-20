using System;
using System.Collections.Generic;
using System.Text;

namespace GraPlanszowa_lab1.Models
{
    class Gap
    {
        public int POS { get; }
        public Player OWNER { get; set; }
        public int TYPE { get; }
        public string NAME { get; }
        public int? CITYCOST { get; }
        public int HOUSECOST { get; set; }
        public int REWARD { get; }
        public int MULTIPLIER { get; set; } = 0;
        public bool COULDBEBUY { get; }

        public Gap(int pos, Player owner, string type, string name, int? cityCost, int reward, bool couldBeBuy, int houseCost=0)
        {
            POS = pos;
            OWNER = owner;
            TYPE = Int32.Parse(type);
            NAME = name;
            REWARD = reward;
            COULDBEBUY = couldBeBuy;
            HOUSECOST = houseCost;
            CITYCOST = cityCost;
        }
    }
}
