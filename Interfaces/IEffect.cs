using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Interfaces
{
    public interface IEffect
    {
        void ApplyTo(object target);
        void RemoveFrom(object target);
    }
}
