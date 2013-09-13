using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class FrostChanneling : Buff
    {
        private double _manaCostPercent = 1;

        internal FrostChanneling(int numPoints)
            :
            base("Frost Channeling", BuffType.Passive)
        {
            _manaCostPercent = 1 - 0.05 * Math.Min(numPoints, 3);
        }

        internal override int ApplyManaCost(State state, int manaCost, MageTheorycraft.Spells.Spell spell)
        {
            if (spell.Type == MageTheorycraft.Spells.Spell.SpellType.Frost)
                return (int)((double)manaCost * _manaCostPercent);

            return base.ApplyManaCost(state, manaCost, spell);
        }
    }
}
