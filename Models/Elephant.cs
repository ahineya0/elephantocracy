using System;
using System.Collections.Generic;
using System.Text;
using elephantocracy.Enums;
using elephantocracy.Interfaces;

namespace elephantocracy.Models
{
    public class Elephant : IMove, IAttack, IMapObject, IRotate
    {
        private int hp, speed, x, y;
        //private string skin;
        private Direction direction;

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

        public bool CanBePickedUp => false;

        public void Move(Direction dir)
        {
            if (direction == Direction.Up)
            {
                Y += speed;
                Rotate(dir);
            }
            else if (direction == Direction.Down)
            {
                Y -= speed;
                Rotate(dir);
            }
            else if (direction == Direction.Left)
            {
                X -= speed;
                Rotate(dir);
            }
            else if (direction == Direction.Right)
            {
                X += speed;
                Rotate(dir);
            }
        }

        public void Rotate(Direction dir)
        {
            direction = dir;
        }

        public FireResult? Fire()
        {
            return new FireResult(X, Y, Direction);
        }

    }
}
