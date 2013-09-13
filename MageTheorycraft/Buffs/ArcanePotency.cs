using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class ArcanePotency : Buff
    {
        private double _critBoost = 0;

        internal ArcanePotency(int numPoints)
            :
            base("Arcane Potency", BuffType.Passive)
        {
            _critBoost = 0.1 * Math.Min(numPoints, 3);
        }

        internal override double ApplySpellCrit(State state, double spellCrit, SpellParameter spellParameter)
        {
            // Currently this is the only real way to work out
            // whether this cast was a Clearcast...... not ideal
            // but "good enough"
            Clearcasting clearcast = (Clearcasting)state.GetBuff("ClearCast");

            if (clearcast == null)
                return base.ApplySpellCrit(state, spellCrit, spellParameter);

            if (clearcast.LastSpell.Equals(spellParameter.Spell) && spellParameter.ManaCost == 0)
            {
                return base.ApplySpellCrit(state, spellCrit, spellParameter) + _critBoost;
            }

            return base.ApplySpellCrit(state, spellCrit, spellParameter);
        }
    }
}
