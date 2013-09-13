using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class WandSpec : Buff
    {
        protected double _damageFactor = 0;

        internal WandSpec(int numPoints)
            :
            base("Wand Specialisation", BuffType.Passive)
        {
            _damageFactor = 1 + 0.13 * Math.Min(numPoints, 2);
        }

        internal override Damage ApplyDamage(State state, Damage damage)
        {
            if (damage.SpellParameter.Spell.Name == "Wand")
            {
                damage.Value *= _damageFactor;
                return damage;
            }

            return base.ApplyDamage(state, damage);
        }
    }
}
