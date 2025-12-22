using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Interfaces
{
    public interface IEffect
    {
        void ApplyTo(IEntityStats target);
        void RemoveFrom(IEntityStats target);
    }
}
