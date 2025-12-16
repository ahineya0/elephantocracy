using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Interfaces
{
    public interface IGame
    {
        void Initialize();
        void Update(float deltaTime);
    }
}
