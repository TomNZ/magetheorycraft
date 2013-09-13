using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class Ignite : Buff
    {
        private double _coefficient = 0;

        private double _igniteDamage = 0;
        private TimelineEvent _tickEvent = null;

        internal Ignite(int points)
            :
            base("Ignite", 4)
        {
            _coefficient = Math.Min(points, 5) * 0.08;
        }

        internal override void Gain(State state)
        {
            base.Gain(state);

            // Add a halfway tick
            if (_tickEvent == null || _tickEvent.Triggered)
            {
                _tickEvent = new TimelineEvent(TimelineEvent.EventType.BuffTick, this, state.CurrentTime + _duration / 2, this);
                state.Timeline.Events.Add(_tickEvent);
            }
            else
            {
                _tickEvent.TriggerTime = state.CurrentTime + _duration / 2;
            }
        }

        internal override void Fade(State state)
        {
            state.Damages.Add(new Damage(_igniteDamage, state.CurrentTime, "Ignite", Damage.DamageType.Tick));
            state.AddLog(LogEvent.EventType.Message, this, "Your Ignite ticks for " + (int)_igniteDamage + "");
            _igniteDamage = 0;
        }

        internal override bool ProcSpellDamage(State state, Damage damage)
        {
            if (damage.Type == Damage.DamageType.Crit && damage.SpellParameter.Spell.Type == Spell.SpellType.Fire)
            {
                _igniteDamage += damage.Value * _coefficient;
                return true;
            }

            return false;
        }

        internal override void Tick(State state)
        {
            _igniteDamage /= 2;

            state.Damages.Add(new Damage(_igniteDamage, state.CurrentTime, "Ignite", Damage.DamageType.Tick));
            state.AddLog(LogEvent.EventType.Message, this, "Your Ignite ticks for " + (int)_igniteDamage + "");
        }
    }
}
