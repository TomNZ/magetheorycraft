using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class MasterOfElements : Buff
    {
        protected double _refundFactor = 0;

        internal MasterOfElements(int numPoints)
            :
            base("Master of Elements", BuffType.Passive)
        {
            _refundFactor = 0.1 * Math.Min(numPoints, 3);
        }

        internal override bool ProcSpellDamage(State state, Damage damage)
        {
            if (damage.Type == Damage.DamageType.Crit && (damage.SpellParameter.Spell.Type == Spell.SpellType.Fire || damage.SpellParameter.Spell.Type == Spell.SpellType.Frost))
            {
                // Base mana cost, not true mana cost
                state.AddEvent(TimelineEvent.EventType.PowerGain, this.Name, 0, (int)((double)state.GetSpell(damage.SpellParameter.Spell.Name).ManaCost * _refundFactor));
            }

            return false;
        }

    }
}
