using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class CriticalMass : Buff
    {
        protected double _critAddition = 1;

        internal CriticalMass(int numPoints)
            :
            base("Fire Power", BuffType.Passive)
        {
            _critAddition = 0.02 * Math.Min(numPoints, 3);
        }

        internal override double ApplySpellCrit(State state, double spellCrit, SpellParameter spellParameter)
        {
            return base.ApplySpellCrit(state, spellCrit, spellParameter) + _critAddition;
        }
    }
}
