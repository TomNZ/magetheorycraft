using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft;
using MageTheorycraft.Buffs;

namespace MageTheorycraft.Spells
{
    class Evocation : Spell
    {
        private int _numTicks = 4;  // Number of regen ticks throughout the duration
        private int _currentTick = 0;
        private double _percentageRegen = 0.6;   // Total percentage of mana to regen (ie. 60% as of patch 2.3)

        internal Evocation()
            :
            base("Evocation", SpellType.Unknown, 8, (8 * 60.0))
        {
        }

        internal override void StartCast(State state, SpellParameter spellParameter)
        {
            base.StartCast(state, spellParameter);

            _currentTick = 0;
            state.AddEvent(TimelineEvent.EventType.SpellcastEffect, this, _castTime / _numTicks, spellParameter);
        }

        internal override void SpellcastEffect(State state, SpellParameter spellParameter)
        {
            // Regen mana
            int regenAmount = (int)(((double)state.PlayerStats.PlayerTotalMana * _percentageRegen) / (double)_numTicks);
            state.PlayerStats.PlayerCurrentMana += regenAmount;
            state.AddLog(LogEvent.EventType.PowerGain, _name, regenAmount);

            _currentTick++;

            if (_currentTick < _numTicks - 1)
            {
                state.AddEvent(TimelineEvent.EventType.SpellcastEffect, this, _castTime / _numTicks, spellParameter);
            }
        }

        internal override void StopCast(State state, SpellParameter spellParameter)
        {
            // Regen mana
            int regenAmount = (int)(((double)state.PlayerStats.PlayerTotalMana * _percentageRegen) / (double)_numTicks);
            state.PlayerStats.PlayerCurrentMana += regenAmount;
            state.AddLog(LogEvent.EventType.PowerGain, _name, regenAmount);
        }
    }
}
