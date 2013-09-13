using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Spells
{
    // Defines a structure for a spell
    public class Spell
    {
        public enum SpellType
        {
            Unknown,
            Fire,
            Arcane,
            Frost,
            Shadow,
            Holy,
            Nature,
            Physical
        }

        protected SpellType _type = SpellType.Unknown;
        public SpellType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        protected double _castTime = 0;
        public double CastTime
        {
            get { return _castTime; }
        }

        protected double _effectDelay = 0;
        public double EffectDelay
        {
            get { return _effectDelay; }
            set { _effectDelay = value; }
        }

        protected string _name;
        public string Name
        {
            get { return _name; }
        }

        protected int _manaCost = 0;
        public int ManaCost
        {
            get { return _manaCost; }
            set { _manaCost = value; }
        }

        protected int _minDamage = 0;
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }

        protected int _maxDamage = 0;
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }

        protected double _bonusDamageCoefficient = 1;
        public double BonusDamageCoefficient
        {
            get { return _bonusDamageCoefficient; }
            set { _bonusDamageCoefficient = value; }
        }

        protected double _cooldown = 0;
        public double Cooldown
        {
            get { return _cooldown; }
            set { _cooldown = value; }
        }

        protected double _cooldownStartedTime = -1;

        public Spell(string name)
        {
            _name = name;
        }

        public Spell(string name, SpellType type):
            this(name)
        {
            _type = type;
        }

        public Spell(string name, SpellType type, double castTime)
            :
            this(name, type)
        {
            _castTime = castTime;
        }

        public Spell(string name, SpellType type, double castTime, int manaCost)
            :
            this(name, type, castTime)
        {
            _manaCost = manaCost;
        }

        public Spell(string name, SpellType type, double castTime, int manaCost, int minDamage, int maxDamage, double bonusDamageCoefficient)
            :
            this(name, type, castTime, manaCost)
        {
            _minDamage = minDamage;
            _maxDamage = maxDamage;
            _bonusDamageCoefficient = bonusDamageCoefficient;
        }

        public Spell(string name, SpellType type, double castTime, int manaCost, double effectDelay)
            :
            this(name, type, castTime, manaCost)
        {
            _effectDelay = effectDelay;
        }

        public Spell(string name, SpellType type, double castTime, int manaCost, int minDamage, int maxDamage, double bonusDamageCoefficient, double effectDelay)
            :
            this(name, type, castTime, manaCost, minDamage, maxDamage, bonusDamageCoefficient)
        {
            _effectDelay = effectDelay;
        }

        public Spell(string name, SpellType type, double castTime, double cooldown)
            :
            this(name, type, castTime)
        {
            _cooldown = cooldown;
        }

        internal virtual void StartCast(State state, SpellParameter spellParameter)
        {
            state.AddEvent(TimelineEvent.EventType.SpellcastFinish, this, spellParameter.CastTime, spellParameter);
            if (_cooldown > 0)
                _cooldownStartedTime = state.CurrentTime;
        }

        internal virtual void StopCast(State state, SpellParameter spellParameter)
        {
            state.AddEvent(TimelineEvent.EventType.SpellcastEffect, this, this.EffectDelay, spellParameter);
        }

        internal virtual void SpellcastEffect(State state, SpellParameter spellParameter)
        {
            if (_minDamage > 0 && _maxDamage > 0)
            {
                state.AddDamage(spellParameter);
            }
        }

        internal virtual void SetDamage(Damage damage, int bonusDamage)
        {
            damage.Value = Chance.RandomDouble((double)_minDamage, (double)_maxDamage) + bonusDamage * _bonusDamageCoefficient;
        }

        internal virtual bool Available(State state)
        {
            if (_cooldownStartedTime == -1)
                return true;

            if (state.CurrentTime >= _cooldownStartedTime + _cooldown)
                return true;

            return false;
        }
    }
}
