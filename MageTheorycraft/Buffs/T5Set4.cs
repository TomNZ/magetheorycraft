using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class T5Set4 : Buff
    {
        private const int _bonusDamage = 70;

        internal T5Set4()
            :
            base("T5 Set (4)", 6.0)
        {
        }

        internal override bool ProcSpellDamage(State state, Damage damage)
        {
            if (damage.Type == Damage.DamageType.Crit)
                return true;

            return false;
        }

        internal override int ApplyBonusDamage(State state, int bonusDamage, SpellParameter spellParameter)
        {
            return base.ApplyBonusDamage(state, bonusDamage, spellParameter) + _bonusDamage;
        }
    }
}
