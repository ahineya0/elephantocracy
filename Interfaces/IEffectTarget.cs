using System;
using elephantocracy.Models;
using elephantocracy.Enums;

namespace elephantocracy.Interfaces
{
    public interface IEffectTarget
    {
        void ApplyFreeze();
        void ApplySpeedBoost();
        void AddLife();
    }
}
