using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class EmpoweredAM : Buff
    {
        protected double _damageMultiplier = 0;
        protected double _manaCostMultiplier = 1;

        internal EmpoweredAM(int numPoints)
            :
            base("Empowered Arcane Missiles", BuffType.Passive)
        {
            _damageMultiplier = 0.15 * Math.Min(numPoints, 3);
            _manaCostMultiplier = 1 + 0.02 * Math.Min(numPoints, 3);
        }

        internal override int ApplyBonusDamage(State state, int bonusDamage, SpellParameter spellParameter)
        {
            if (spellParameter.Spell.Name == "Arcane Missiles")
                return base.ApplyBonusDamage(state, bonusDamage, spellParameter) + (int)((double)state.PlayerStats.SpellDamage * _damageMultiplier);

            return base.ApplyBonusDamage(state, bonusDamage, spellParameter);
        }

        internal override int ApplyManaCost(State state, int manaCost, MageTheorycraft.Spells.Spell spell)
        {
            if (spell.Name == "Arcane Missiles")
                return (int)((double)base.ApplyManaCost(state, manaCost, spell) * _manaCostMultiplier);

            return base.ApplyManaCost(state, manaCost, spell);
        }
    }
}
