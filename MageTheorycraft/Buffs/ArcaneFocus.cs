using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class ArcaneFocus : Buff
    {
        protected double _hitFactor = 0;

        internal ArcaneFocus(int numPoints)
            :
            base("Arcane Focus", BuffType.Passive)
        {
            _hitFactor = 0.02 * Math.Min(numPoints, 5);
        }

        internal override double ApplySpellHit(State state, double spellHit, Spell spell)
        {
            if (spell.Type == Spell.SpellType.Arcane)
                return spellHit + _hitFactor;

            return base.ApplySpellHit(state, spellHit, spell);
        }
    }
}
