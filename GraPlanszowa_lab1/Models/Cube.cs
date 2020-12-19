using System;
using System.Collections.Generic;
using System.Text;

namespace GraPlanszowa_lab1
{
    class Cube
    {
        private int maxSize;
        private Random rand;
        private static Cube instance;

        public Cube(int size)
        {
            this.maxSize = size;
            this.rand = new Random();
        }

        public static Cube getInstance(int size)
        {
            if(Cube.instance == null)
            {
                Cube.instance = new Cube(size);
            }

            return Cube.instance;
        }

        public int Lotery()
        {
            return rand.Next(this.maxSize)+1;
        }
    }
}
