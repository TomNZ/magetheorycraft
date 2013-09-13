using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class Combustion : Buff
    {
        private int _buffStacks = 0;
        private int _buffProcs = 0;
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

        internal Combustion()
            :
            base("Combustion", BuffType.ActiveAura)
        {
        }

        internal override double ApplySpellCrit(State state, double spellCrit, SpellParameter spellParameter)
        {
            if (spellParameter.Spell.Type == Spell.SpellType.Fire)
            {
                return base.ApplySpellCrit(state, spellCrit, spellParameter) + 0.1 * (double)_buffStacks;
            }
            else
            {
                return base.ApplySpellCrit(state, spellCrit, spellParameter);
            }
        }

        internal override void Gain(State state)
        {
            base.Gain(state);

            _buffStacks = 0;
            _buffProcs = 0;
            _buffActive = true;
        }

        internal override bool ProcSpellDamage(State state, Damage damage)
        {
            if (_buffActive)
            {
                if (damage.SpellParameter.Spell.Type == Spell.SpellType.Fire)
                {
                    if (damage.Type == Damage.DamageType.Crit)
                        _buffProcs++;

                    _buffStacks++;
                }
            }

            if (_buffProcs >= 3)
            {
                state.AddEvent(TimelineEvent.EventType.RemoveBuff, this, 0, this);
            }

            return false;
        }

        internal override void Fade(State state)
        {
            base.Fade(state);
            _buffActive = false;
            _buffStacks = 0;
            _buffProcs = 0;
            _lastFadeTime = state.CurrentTime;
        }
    }
}
