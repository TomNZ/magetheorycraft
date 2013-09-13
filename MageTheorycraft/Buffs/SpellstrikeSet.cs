using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class SpellstrikeSet : Buff
    {
        // The following numbers are generally "agreed upon"
        // numbers for this set, but may be slightly inaccurate
        protected const double _procChance = 0.05;

        // Bonus damage increase
        protected const int _bonusDamage = 92;

        internal SpellstrikeSet()
            :
            base("Spellstrike Set Bonus", 10)
        {
        }

        internal override bool ProcSpellCast(State state, SpellParameter spellParameter)
        {
            if (Chance.RandomChance(_procChance))
            {
                return true;
            }

            return false;
        }

        internal override int ApplyBonusDamage(State state, int bonusDamage, SpellParameter spellParameter)
        {
            return base.ApplyBonusDamage(state, bonusDamage, spellParameter) + _bonusDamage;
        }
    }
}
