using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class EmpoweredFrostbolt : Buff
    {
        private double _damageMultiplier = 0;
        private double _critBoost = 0;

        internal EmpoweredFrostbolt(int numPoints)
            :
            base("Empowered Frostbolt", BuffType.Passive)
        {
            _damageMultiplier = 0.02 * Math.Min(numPoints, 5);
            _critBoost = 0.01 * Math.Min(numPoints, 5);
        }

        internal override int ApplyBonusDamage(State state, int bonusDamage, SpellParameter spellParameter)
        {
            if (spellParameter.Spell.Name == "Frostbolt")
                return base.ApplyBonusDamage(state, bonusDamage, spellParameter) + (int)((double)state.PlayerStats.SpellDamage * _damageMultiplier);

            return base.ApplyBonusDamage(state, bonusDamage, spellParameter);
        }

        internal override double ApplySpellCrit(State state, double spellCrit, SpellParameter spellParameter)
        {
            if (spellParameter.Spell.Name == "Frostbolt")
                return base.ApplySpellCrit(state, spellCrit, spellParameter) + _critBoost;
            
            return base.ApplySpellCrit(state, spellCrit, spellParameter);
        }
    }
}
