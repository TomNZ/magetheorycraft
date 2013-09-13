using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class SpellPower : Buff
    {
        double _critMultiplierBoost = 0;

        internal SpellPower(int numPoints)
            :
            base("Spell Power", BuffType.Passive)
        {
            _critMultiplierBoost = 0.25 * Math.Min(numPoints, 2);
        }

        internal override double ApplyCritMultiplier(State state, double critMultiplier, SpellParameter spellParameter)
        {
            return base.ApplyCritMultiplier(state, critMultiplier, spellParameter) + _critMultiplierBoost;
        }
    }
}
