using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class DarkmoonWrath : Buff
    {
        // Parameters
        private const int _critRatingPerStack = 17;

        private int _stackSize = 0;

        internal DarkmoonWrath()
            :
            base("Darkmoon Card: Wrath", BuffType.Passive)
        {
        }

        internal override bool ProcSpellDamage(State state, Damage damage)
        {
            if (damage.Type == Damage.DamageType.Hit)
                _stackSize++;

            if (damage.Type == Damage.DamageType.Crit)
                _stackSize = 0;

            return base.ProcSpellDamage(state, damage);
        }

        internal override double ApplySpellCrit(State state, double spellCrit, SpellParameter spellParameter)
        {
            // Convert crit rating to percent
            return base.ApplySpellCrit(state, spellCrit, spellParameter) + (double)(_stackSize * _critRatingPerStack) / 2208;
        }
    }
}
