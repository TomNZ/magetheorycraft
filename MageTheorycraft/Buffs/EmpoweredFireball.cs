using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class EmpoweredFireball : Buff
    {
        protected double _damageMultiplier = 0;

        internal EmpoweredFireball(int numPoints)
            :
            base("Empowered Fireball", BuffType.Passive)
        {
            _damageMultiplier = 0.03 * Math.Min(numPoints, 5);
        }

        internal override int ApplyBonusDamage(State state, int bonusDamage, SpellParameter spellParameter)
        {
            if (spellParameter.Spell.Name == "Fireball")
                return base.ApplyBonusDamage(state, bonusDamage, spellParameter) + (int)((double)state.PlayerStats.SpellDamage * _damageMultiplier);

            return base.ApplyBonusDamage(state, bonusDamage, spellParameter);
        }
    }
}
