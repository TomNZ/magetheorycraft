using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class ArcaneInstability : Buff
    {
        private double _damageFactor = 1;
        private double _critBoost = 0;

        internal ArcaneInstability(int numPoints)
            :
            base("Arcane Instability", BuffType.Passive)
        {
            _damageFactor = 1 + 0.1 * Math.Min(numPoints, 3);
            _critBoost = 0.1 * Math.Min(numPoints, 3);
        }

        internal override Damage ApplyDamage(State state, Damage damage)
        {
            damage.Value *= _damageFactor;
            return damage;
        }

        internal override double ApplySpellCrit(State state, double spellCrit, SpellParameter spellParameter)
        {
            return base.ApplySpellCrit(state, spellCrit, spellParameter) + _critBoost;
        }
    }
}
