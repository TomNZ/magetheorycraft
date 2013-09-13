using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class FirePower : Buff
    {
        protected double _damageMultiplier = 1;

        internal FirePower(int numPoints)
            :
            base("Fire Power", BuffType.Passive)
        {
            _damageMultiplier = 1 + 0.02 * Math.Min(numPoints, 5);
        }

        internal override Damage ApplyDamage(State state, Damage damage)
        {
            if (damage.SpellParameter.Spell.Type == MageTheorycraft.Spells.Spell.SpellType.Fire)
            {
                damage.Value *= _damageMultiplier;
            }

            return damage;
        }
    }
}
