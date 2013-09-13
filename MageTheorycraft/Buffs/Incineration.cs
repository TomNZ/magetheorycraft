using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class Incineration : Buff
    {
        protected double _critAddition = 0;

        internal Incineration(int numPoints)
            :
            base("Incineration", BuffType.Passive)
        {
            _critAddition = 0.02 * Math.Min(numPoints, 2);
        }

        internal override double ApplySpellCrit(State state, double spellCrit, SpellParameter spellParameter)
        {
            if (spellParameter.Spell.Name == "Scorch" || spellParameter.Spell.Name == "Fire Blast")
            {
                return base.ApplySpellCrit(state, spellCrit, spellParameter) + _critAddition;
            }
            return base.ApplySpellCrit(state, spellCrit, spellParameter);
        }
    }
}
