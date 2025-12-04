using System;
using System.Collections.Generic;
using System.Text;
using IMoveForm;
using DirectionForm;
using IAttackForm;
using FireResultForm;

namespace ElephantoCracy
{
    public class Elephant : IMove, IAttack
    {
        private int hp, speed, cordX, cordY;
        private string skin;
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

        public int CordX
        {
            get { return cordX; }
            set { cordX = value; }
        }

        public int CordY
        {
            get { return cordY; }
            set { cordY = value; }
        }

        public string Skin
        {
            get { return skin; }
            set { skin = value; }
        }

        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }


        public void Move(Direction dir)
        {
            if (direction == Direction.Up)
            {
                cordY += speed;
                Rotate(dir);
            }
            else if (direction == Direction.Down)
            {
                cordY -= speed;
                Rotate(dir);
            }
            else if (direction == Direction.Left)
            {
                cordX -= speed;
                Rotate(dir);
            }
            else if (direction == Direction.Right)
            {
                cordX += speed;
                Rotate(dir);
            }
        }

        public void Rotate(Direction dir)
        {
            direction = dir;
        }

        public FireResult? Fire()
        {
            return new FireResult(CordX, CordY, Direction);
        }

    }
}
