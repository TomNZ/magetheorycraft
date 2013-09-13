using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class FrozenTarget : Buff
    {
        private double _freezeChanceOnChill = 0;

        internal FrozenTarget(int frostbitePoints)
            :
            base("Frozen Target", 5)
        {
            _freezeChanceOnChill = 0.05 * Math.Min(frostbitePoints, 5);
        }

        internal override bool ProcSpellDamage(State state, Damage damage)
        {
            if (damage.SpellParameter.Spell.Name == "Frostbolt")
            {
                if (Chance.RandomChance(_freezeChanceOnChill))
                    return true;
            }

            return false;
        }
    }
}
