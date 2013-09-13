using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class Fireball : Buff
    {
        // Note this is NOT the fireball spell,
        // it is a buff activated by the spell in
        // order to model the fireball DoT
        protected int _totalDamage = 84;
        internal int TotalDamage
        {
            get { return _totalDamage; }
        }

        protected const int _numTicks = 8;
        protected int _currentTick = 0;
        protected TimelineEvent _nextTick = null;

        internal Fireball()
            :
            base("Fireball", 8)
        {
        }

        internal override bool ProcSpellDamage(State state, Damage damage)
        {
            if (damage.SpellParameter.Spell.Name == "Fireball" && damage.Type != Damage.DamageType.Resist)
                return true;
            else
                return false;
        }

        internal override void Gain(State state)
        {
            base.Gain(state);

            _currentTick = 1;

            // Add the first tick
            if (_numTicks > 1)
            {
                if (_nextTick == null || _nextTick.Triggered)
                {
                    _nextTick = new TimelineEvent(TimelineEvent.EventType.BuffTick, this, state.CurrentTime + _duration / _numTicks, this);
                    state.Timeline.Events.Add(_nextTick);
                }
                else
                {
                    _nextTick.TriggerTime = state.CurrentTime + _duration / _numTicks;
                }
            }
        }

        internal override void Fade(State state)
        {
            state.Damages.Add(new Damage(GetTickDamage(), state.CurrentTime, "Fireball Tick", Damage.DamageType.Tick));
        }

        internal override void Tick(State state)
        {
            state.Damages.Add(new Damage(GetTickDamage(), state.CurrentTime, "Fireball Tick", Damage.DamageType.Tick));

            _currentTick += 1;

            if (_currentTick < _numTicks)
            {
                _nextTick = new TimelineEvent(TimelineEvent.EventType.BuffTick, this, state.CurrentTime + _duration / _numTicks, this);
                state.Timeline.Events.Add(_nextTick);
            }
        }

        private int GetTickDamage()
        {
            return (int)((double)_totalDamage / (double)_numTicks + 0.5);
        }
    }
}
