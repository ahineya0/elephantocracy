using elephantocracy.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Structures
{
    public struct FireResult
    {
        private int x, y;
        private Direction direction;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set {  y = value; }
        }
        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }


        public FireResult(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }


    }
}
