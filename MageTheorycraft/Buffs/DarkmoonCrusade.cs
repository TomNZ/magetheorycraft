using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class DarkmoonCrusade : Buff
    {
        // Parameters
        private const int _bonusDamagePerStack = 8;
        private const int _maxStackSize = 10;

        private int _stackSize = 0;

        internal DarkmoonCrusade()
            :
            base("Darkmoon Card: Crusade", 10.0)
        {
        }

        internal override bool ProcSpellDamage(State state, Damage damage)
        {
            return true;
        }

        internal override int ApplyBonusDamage(State state, int bonusDamage, SpellParameter spellParameter)
        {
            return base.ApplyBonusDamage(state, bonusDamage, spellParameter) + _bonusDamagePerStack * _stackSize;
        }

        internal override void Gain(State state)
        {
            base.Gain(state);

            if (_stackSize < _maxStackSize)
                _stackSize++;
        }

        internal override void Fade(State state)
        {
            _stackSize = 0;
        }
    }
}
