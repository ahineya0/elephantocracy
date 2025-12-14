using System;
using elephantocracy.Interfaces;

namespace elephantocracy.Models
{
    public class EffectModel : IMapObject
    {
        public bool CanBePickedUp => true;
        public Effect EffectType { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public float Duration { get; private set; }
        public float ElapsedTime { get; private set; }
        publci Effect(Effect effectType, int x, int y, float duration)
        {
            EffectType = effectType;
            X = x;
            Y = y;
            Duration = duration;
            ElapsedTime = 0;
        }

        public void Update(float deltaTime)
        {
            ElapsedTime += deltaTime;
        }
        public bool IsInactive => elapsedTime > Duration;
        public void AppleTo(IEffectTarget target)
        {
            switch (EffectType)
            {
                case EffectType.Freeze:
                    target.ApplyFreeze();  
                    break;
                case EffectType.SpeedBoost:
                    target.ApplySpeedBoost();  
                    break;
                case EffectType.Life:
                    target.AddLife();  
                    break;
                default:
                    break;
            }
        }
    }
}