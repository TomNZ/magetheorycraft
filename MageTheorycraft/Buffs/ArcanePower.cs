using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class ArcanePower : Buff
    {
        protected const double _cooldownTime = 360.0;
        protected const double _damageMultiplier = 1.3;
        protected const double _manaCostMultiplier = 1.3;

        protected bool _buffActive = false;
        protected double _lastGainTime = 0;

        internal bool Available(double currentTime)
        {
            if (_buffActive)
                return false;

            if (_lastGainTime == -1)
                return true;
            else
                return currentTime >= (_lastGainTime + _cooldownTime);
        }

        internal ArcanePower()
            :
            base("Arcane Power", 15)
        {
        }

        internal override void Gain(State state)
        {
            base.Gain(state);
            _lastGainTime = state.CurrentTime;
        }

        internal override Damage ApplyDamage(State state, Damage damage)
        {
            damage.Value *= _damageMultiplier;
            return base.ApplyDamage(state, damage);
        }

        internal override int ApplyManaCost(State state, int manaCost, Spell spell)
        {
            return (int)((double)base.ApplyManaCost(state, manaCost, spell) * _manaCostMultiplier);
        }
    }
}
