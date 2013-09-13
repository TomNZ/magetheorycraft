using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class ElementalPrecision : Buff
    {
        protected double _hitFactor = 0;

        internal ElementalPrecision(int numPoints)
            :
            base("Elemental Precision", BuffType.Passive)
        {
            _hitFactor = 0.01 * Math.Min(numPoints, 3);
        }

        internal override double ApplySpellHit(State state, double spellHit, Spell spell)
        {
            if (spell.Type == Spell.SpellType.Fire || spell.Type == Spell.SpellType.Frost)
                return spellHit + _hitFactor;

            return base.ApplySpellHit(state, spellHit, spell);
        }
    }
}
