using elephantocracy.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Models
{
    public class ElephantData
    {
        public int Hp { get; set; }
        public int Speed { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public ElephantData() { }

        public ElephantData(Elephant elephant)
        {
            Hp = elephant.Hp;
            Speed = elephant.Speed;
            X = elephant.X;
            Y = elephant.Y;
            Direction = elephant.Direction;
        }

        public Elephant ToElephant()
        {
            return new Elephant(Hp, Speed, X, Y, Direction);
        }
    }
}
