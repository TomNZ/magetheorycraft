using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class PresenceOfMind : Buff
    {
        private bool _buffActive = false;
        internal bool BuffActive
        {
            get { return _buffActive; }
        }

        private double _lastFadeTime = -1;
        protected const double _cooldownTime = 180;

        internal bool Available(double currentTime)
        {
            if (_buffActive)
                return false;

            if (_lastFadeTime == -1)
                return true;
            else
                return currentTime >= (_lastFadeTime + _cooldownTime);
        }

        internal PresenceOfMind()
            :
            base("Presence of Mind", BuffType.ActiveAura)
        {
        }

        internal override double ApplyCastTime(State state, double castTime, Spell spell)
        {
            // If activated reduce the cast time on the next cast to 0
            // and remove the buff
            if (spell.Type != Spell.SpellType.Physical)
            {
                state.AddEvent(TimelineEvent.EventType.RemoveBuff, this, 0, this);
                return 0;
            }
            else
            {
                return base.ApplyCastTime(state, castTime, spell);
            }
        }

        internal override void Gain(State state)
        {
            base.Gain(state);

            _buffActive = true;
        }

        internal override void Fade(State state)
        {
            base.Fade(state);

            _buffActive = false;
            _lastFadeTime = state.CurrentTime;
        }
    }
}
