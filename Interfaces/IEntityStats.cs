using elephantocracy.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Interfaces
{
    public interface IEntityStats
    {
        public int Hp { get; set; }

        public int Speed { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Direction Direction { get; set; }
    }
}
