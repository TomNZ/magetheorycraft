using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class Pyromaniac : Buff
    {
        protected double _critAddition = 0;
        protected double _manaCostMultiplier = 1;

        internal Pyromaniac(int numPoints)
            :
            base("Pyromaniac", BuffType.Passive)
        {
            _critAddition = 0.01 * Math.Min(numPoints, 3);
            _manaCostMultiplier = 1 - 0.01 * Math.Min(numPoints, 3);
        }

        internal override double ApplySpellCrit(State state, double spellCrit, SpellParameter spellParameter)
        {
            if (spellParameter.Spell.Type == Spell.SpellType.Fire)
            {
                return base.ApplySpellCrit(state, spellCrit, spellParameter) + _critAddition;
            }
            return base.ApplySpellCrit(state, spellCrit, spellParameter);
        }

        internal override int ApplyManaCost(State state, int manaCost, Spell spell)
        {
            if (spell.Type == Spell.SpellType.Fire)
            {
                return (int)((double)base.ApplyManaCost(state, manaCost, spell) * _manaCostMultiplier);
            }
            return base.ApplyManaCost(state, manaCost, spell);
        }
    }
}
