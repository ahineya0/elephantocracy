using elephantocracy.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Models
{
    public class EnemyData
    {
        public int Hp { get; set; }
        public int Speed { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public EnemyData() { }

        public EnemyData(Enemy enemy)
        {
            Hp = enemy.Hp;
            Speed = enemy.Speed;
            X = enemy.X;
            Y = enemy.Y;
            Direction = enemy.Direction;
        }

        public Enemy ToEnemy()
        {
            return new Enemy(Hp, Speed, X, Y, Direction);
        }
    }
}
