using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class IcyVeins : Buff
    {
        protected int _hasteRating = (int)(20.0 * 15.8); // 20%

        private bool _buffActive = false;

        protected double _lastGainTime = 0;
        protected const double _cooldownTime = 180;

        internal bool Available(double currentTime)
        {
            if (_buffActive)
                return false;

            if (_lastGainTime == -1)
                return true;
            else
                return currentTime >= (_lastGainTime + _cooldownTime);
        }

        internal IcyVeins()
            :
            base("Icy Veins", 20)
        {
        }

        internal override int ApplyHasteRating(State state, int hasteRating, Spell spell)
        {
            // This code is only reached when the buff is active (procced)
            return base.ApplyHasteRating(state, hasteRating, spell) + _hasteRating;
        }

        internal override void Gain(State state)
        {
            base.Gain(state);
            _buffActive = true;
            _lastGainTime = state.CurrentTime;
        }

        internal override void Fade(State state)
        {
            base.Fade(state);
            _buffActive = false;
        }


    }
}
