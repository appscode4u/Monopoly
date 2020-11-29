using System;
using System.Collections.Generic;
using System.Text;

namespace GraPlanszowa_lab1
{

    class Matrix
    {
        private List<Gap> gameMatrix;
        public Matrix() {}

        private void prepareMatrix()
        {
            List<Gap> tmpMatrix = new List<Gap>();
            tmpMatrix.Add(new Gap(0, null, Model.gapType.Start.ToString("d"), "Start",null,0,false));
            tmpMatrix.Add(new Gap(1, null, Model.gapType.City.ToString("d"), "Athens",100,50,true));
            tmpMatrix.Add(new Gap(2, null, Model.gapType.City.ToString("d"), "Neapol",200,55, true));
            tmpMatrix.Add(new Gap(3, null, Model.gapType.Fortune.ToString("d"), "? Fortune ?", null,0, false));
            tmpMatrix.Add(new Gap(4, null, Model.gapType.City.ToString("d"), "Warsaw",300,60, true));
            tmpMatrix.Add(new Gap(5, null, Model.gapType.City.ToString("d"), "Katowice",400,65, true));
            tmpMatrix.Add(new Gap(6, null, Model.gapType.Fortune.ToString("d"), "? Fortune ?", null,0, false));
            tmpMatrix.Add(new Gap(7, null, Model.gapType.Penelty.ToString("d"), "You have to Pay!!!", null,-300, false));
            tmpMatrix.Add(new Gap(8, null, Model.gapType.Parking.ToString("d"), "Place free of charge", null,0, false));
            tmpMatrix.Add(new Gap(9, null, Model.gapType.Jail.ToString("d"), "You are arrested", null,0, false));
            tmpMatrix.Add(new Gap(10, null, Model.gapType.City.ToString("d"), "Wien",500,70, true));
            tmpMatrix.Add(new Gap(11, null, Model.gapType.City.ToString("d"), "London",600,75, true));
            
            gameMatrix = tmpMatrix;
        }

        public List<Gap> newMatrix()
        {
            prepareMatrix();
            return gameMatrix;
        }
    }

    class Gap
    {
        public int POS { get; }
        public int? OWNER { get; set; }
        public int TYPE { get; }
        public string NAME { get; }
        public int? VALUE { get; }
        public int REWARD { get; }
        public int MULTIPLIER { get; set; } = 0;
        public bool COULDBEBUY{get;}

        public Gap(int pos, int? owner, string type, string name, int? value, int reward,bool couldBeBuy)
        {
            POS = pos;
            OWNER = owner;
            TYPE = Int32.Parse(type);
            NAME = name;
            REWARD = reward;
            COULDBEBUY = couldBeBuy;
        }
    }
}
