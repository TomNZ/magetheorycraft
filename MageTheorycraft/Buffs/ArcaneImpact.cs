using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class ArcaneImpact : Buff
    {
        private double _critBoost = 0;

        internal ArcaneImpact(int numPoints)
            :
            base("Arcane Impact", BuffType.Passive)
        {
            _critBoost = 0.02 * Math.Min(numPoints, 3);
        }

        internal override double ApplySpellCrit(State state, double spellCrit, SpellParameter spellParameter)
        {
            if (spellParameter.Spell.Name == "Arcane Explosion" || spellParameter.Spell.Name == "Arcane Blast")
            {
                return spellCrit + _critBoost;
            }

            return base.ApplySpellCrit(state, spellCrit, spellParameter);
        }
    }
}
