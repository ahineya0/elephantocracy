using elephantocracy.Enums;
using elephantocracy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Models
{
    public class RandomAIController : IInputSource
    {
        private Random _random = new Random();

        public Direction? MoveDirection 
        { 
            get => (Direction)_random.Next(0, 3);
        }

        public bool FirePressed
        {
            get => _random.Next(0, 100) < 5;
        }

    }
}
