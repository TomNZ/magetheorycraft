using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class PiercingIce : Buff
    {
        private double _damageMultiplier = 1;

        internal PiercingIce(int numPoints)
            :
            base("Piercing Ice", BuffType.Passive)
        {
            _damageMultiplier = 1 + 0.02 * Math.Min(numPoints, 3);
        }

        internal override Damage ApplyDamage(State state, Damage damage)
        {
            damage.Value *= _damageMultiplier;
            return damage;
        }
    }
}
