using elephantocracy.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging.Effects;
using System.Text;

namespace elephantocracy.Models.Effects
{
    public class FreezingEffect : Effect
    {
        private int _previousSpeed;

        public FreezingEffect(int x, int y, float duration) : base(x, y, duration) { }

        public override void ApplyTo(IEntityStats target)
        {
            _previousSpeed = target.Speed;
            target.Speed = 0;
        }

        public override void RemoveFrom(IEntityStats target)
        {
            target.Speed = _previousSpeed;
        }
    }
}
