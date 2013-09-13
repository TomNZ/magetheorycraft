using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class PlayingWithFire : Buff
    {
        protected double _damageMultiplier = 1;

        internal PlayingWithFire(int numPoints)
            :
            base("Fire Power", BuffType.Passive)
        {
            _damageMultiplier = 1 + 0.01 * Math.Min(numPoints, 3);
        }

        internal override Damage ApplyDamage(State state, Damage damage)
        {
            damage.Value *= _damageMultiplier;

            return damage;
        }
    }
}
