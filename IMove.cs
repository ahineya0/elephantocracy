using System;
using System.Collections.Generic;
using System.Text;
using DirectionForm;

namespace IMoveForm
{
    public interface IMove
    {
        void Move(Direction dir);
        void Rotate(Direction dir);
    }
}
