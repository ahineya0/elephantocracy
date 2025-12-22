using System;
using elephantocracy.Interfaces;
using elephantocracy.Enums;

namespace elephantocracy.Models
{
    public abstract class Effect : IMapObject, IEffect
    {
        public bool CanBePickedUp => true;
        public int X { get; private set; }
        public int Y { get; private set; }
        public float Duration { get; private set; }
        public float ElapsedTime { get; private set; }
        public Effect(int x, int y, float duration)
        {
            X = x;
            Y = y;
            Duration = duration;
            ElapsedTime = 0;
        }

        public void Update(float deltaTime)
        {
            ElapsedTime += deltaTime;
        }
        public bool IsInactive => ElapsedTime > Duration;
        public abstract void ApplyTo(IEntityStats target);
        public abstract void RemoveFrom(IEntityStats target);
    }
}