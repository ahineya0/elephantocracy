using DirectionForm;
using IMoveForm;
using MapForm;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace BubbleForm
{
    public class Bubble : IMapObject, IMove
    {
        private int size, speed, x, y;
        private Direction direction;

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

        public bool IsAlive { get; private set; }

        public Bubble(int startX, int startY, Direction direction, int speed = 1, int size = 1)
        {
            X = startX;
            Y = startY;
            Direction = direction;

            this.speed = speed;
            this.size = size;

            IsAlive = true;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(X, Y, size, size);
        }

        public bool CanBePickedUp => false;

        public void Move(Direction dir)
        {
            Direction = Direction;
            MoveInternal();
        }

        public void Rotate(Direction dir) { }

        private void MoveInternal()
        {
            if (!IsAlive) return;

            switch (Direction)
            {
                case Direction.Up:
                    Y += speed;
                    break;
                case Direction.Down:
                    Y -= speed;
                    break;
                case Direction.Left:
                    X -= speed;
                    break;
                case Direction.Right:
                    X += speed;
                    break;
            }
        }

        public void Destroy()
        {
            IsAlive = false;
        }
    }
}
