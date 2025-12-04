using System;
using System.Collections.Generic;
using System.Text;

namespace MapForm
{
    public interface IMapObject
    {
        int X { get; }
        int Y { get; }

        // для эффектов и тд
        bool CanBePickedUp { get; }
    }
}
