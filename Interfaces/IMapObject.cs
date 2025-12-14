using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Interfaces
{
    public interface IMapObject
    {
        int X { get; }
        int Y { get; }

        // для эффектов и тд
        bool CanBePickedUp { get; }
    }
}
