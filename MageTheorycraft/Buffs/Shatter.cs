using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class Shatter : Buff
    {
        private double _critBoost = 0;

        internal Shatter(int numPoints)
            :
            base("Shatter", BuffType.Passive)
        {
            _critBoost = 0.1 * Math.Min(numPoints, 5);
        }

        internal override double ApplySpellCrit(State state, double spellCrit, SpellParameter spellParameter)
        {
            if (state.ActiveBuffs.Contains(state.GetBuff("Frozen Target")))
                return base.ApplySpellCrit(state, spellCrit, spellParameter) + _critBoost;

            return base.ApplySpellCrit(state, spellCrit, spellParameter);
        }
    }
}
