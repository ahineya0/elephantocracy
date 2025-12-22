using elephantocracy.Enums;
using elephantocracy.Interfaces;    
using System;
using System.Collections.Generic;
using System.Text;
using elephantocracy.Structures;    

namespace elephantocracy.Models
{
    public class Enemy : IMove, IAttack, IMapObject, IRotate, IEntityStats, ISerializableModel
    {
        public string GetFileName() => "enemy";

        private int hp, speed, x, y;
        private Direction direction;
        public IInputSource Brain { get; set; }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public Enemy(int hp, int speed, int x, int y, Direction direction)
        {
            Hp = hp;
            Speed = speed;
            X = x;
            Y  = y;
            Direction = direction;
            Brain = new RandomAIController();
        }

        public bool CanBePickedUp => false;

        public void Move(Direction dir)
        {
            Rotate(dir);
            switch (Direction)
            {
                case Direction.Up:
                    Y -= speed;
                    break;

                case Direction.Down:
                    Y += speed;
                    break;

                case Direction.Left:
                    X -= speed;
                    break;

                case Direction.Right:
                    X += speed;
                    break;
            }
        }


        public void Rotate(Direction dir)
        {
            Direction = dir;
        }

        public FireResult? Fire()
        {
            return new FireResult(X, Y, Direction);
        }

        public void TakeDamage(int damage)
        {
            if (damage >= 0 && Hp > 0)
                Hp -= damage;
        }

        public bool IsDead => Hp <= 0;

    }
}
