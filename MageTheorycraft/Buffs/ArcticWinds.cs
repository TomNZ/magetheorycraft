using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class ArcticWinds : Buff
    {
        public double _damageMultiplier = 1;

        internal ArcticWinds(int numPoints)
            :
            base("Arctic Winds", BuffType.Passive)
        {
            _damageMultiplier = 1 + 0.01 * Math.Min(numPoints, 5);
        }

        internal override Damage ApplyDamage(State state, Damage damage)
        {
            damage.Value *= _damageMultiplier;
            return damage;
        }
    }
}
