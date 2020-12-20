using GraPlanszowa_lab1.Models;
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
            tmpMatrix.Add(new Gap(0, null, GapType.Start.ToString("d"), "Start",null,0,false));
            tmpMatrix.Add(new Gap(1, null, GapType.City.ToString("d"), "Athens",100,50,true,50));
            tmpMatrix.Add(new Gap(2, null, GapType.City.ToString("d"), "Neapol",200,55, true,55));
            tmpMatrix.Add(new Gap(3, null, GapType.Fortune.ToString("d"), "? Fortune ?", null,0, false));
            tmpMatrix.Add(new Gap(4, null, GapType.City.ToString("d"), "Warsaw",300,60, true,60));
            tmpMatrix.Add(new Gap(5, null, GapType.City.ToString("d"), "Katowice",400,65, true,65));
            tmpMatrix.Add(new Gap(6, null, GapType.Fortune.ToString("d"), "? Fortune ?", null,0, false));
            tmpMatrix.Add(new Gap(7, null, GapType.Penelty.ToString("d"), "You have to Pay!!!", null,-300, false));
            tmpMatrix.Add(new Gap(8, null, GapType.Parking.ToString("d"), "Place free of charge", null,0, false));
            tmpMatrix.Add(new Gap(9, null, GapType.Jail.ToString("d"), "You are arrested", null,0, false));
            tmpMatrix.Add(new Gap(10, null, GapType.City.ToString("d"), "Wien",500,70, true,70));
            tmpMatrix.Add(new Gap(11, null, GapType.City.ToString("d"), "London",600,75, true,75));
            tmpMatrix.Add(new Gap(12, null, GapType.Penelty.ToString("d"), "You have to Pay!!!", null, -300, false));
            tmpMatrix.Add(new Gap(13, null, GapType.Penelty.ToString("d"), "You have to Pay!!!", null, -300, false));
            tmpMatrix.Add(new Gap(14, null, GapType.Penelty.ToString("d"), "You have to Pay!!!", null, -300, false));
            tmpMatrix.Add(new Gap(15, null, GapType.Penelty.ToString("d"), "You have to Pay!!!", null, -300, false));
            tmpMatrix.Add(new Gap(16, null, GapType.Penelty.ToString("d"), "You have to Pay!!!", null, -300, false));

            gameMatrix = tmpMatrix;
        }

        public List<Gap> newMatrix()
        {
            prepareMatrix();
            return gameMatrix;
        }
    }
}
