using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    // Defines a structure for a buff class
    public abstract class Buff
    {
        public enum BuffType
        {
            Passive,
            Active,
            Aura,
            ActiveAura
        }

        protected BuffType _type = BuffType.Active;
        public BuffType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        protected string _name;
        public string Name
        {
            get { return _name; }
        }

        protected TimelineEvent _expiryEvent;
        public TimelineEvent ExpiryEvent
        {
            get { return _expiryEvent; }
            set { _expiryEvent = value; }
        }

        public double ExpireTime
        {
            get
            {
                if (_expiryEvent == null)
                    return 0;
                else
                    return _expiryEvent.TriggerTime;
            }
        }

        protected double _duration = 0;
        public double Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        // Constructors
        public Buff(string name)
        {
            _name = name;
        }

        public Buff(string name, BuffType type)
            :
            this(name)
        {
            _type = type;
        }

        public Buff(string name, double duration)
            :
            this(name)
        {
            _duration = duration;
        }

        public void RefreshBuff(State state)
        {
            if (_expiryEvent == null || _expiryEvent.Triggered)
            {
                _expiryEvent = new TimelineEvent(TimelineEvent.EventType.RemoveBuff, this, state.CurrentTime + _duration, this);
                state.Timeline.Events.Add(_expiryEvent);
            }
            else
            {
                _expiryEvent.TriggerTime = state.CurrentTime + _duration;
            }
        }

        // Overridable stuff
        internal virtual void Gain(State state)
        {
            if (_type == BuffType.Active)
            {
                RefreshBuff(state);
            }
        }

        internal virtual void Fade(State state)
        {
        }

        internal virtual int ApplyManaCost(State state, int manaCost, Spell spell)
        {
            return manaCost;
        }

        internal virtual int ApplyHasteRating(State state, int hasteRating, Spell spell)
        {
            return hasteRating;
        }

        internal virtual double ApplyCastTime(State state, double castTime, Spell spell)
        {
            return castTime;
        }

        internal virtual double ApplySpellHit(State state, double spellHit, Spell spell)
        {
            return spellHit;
        }

        internal virtual double ApplySpellCrit(State state, double spellCrit, SpellParameter spellParameter)
        {
            return spellCrit;
        }

        internal virtual double ApplyCritMultiplier(State state, double critMultiplier, SpellParameter spellParameter)
        {
            return critMultiplier;
        }

        internal virtual Damage ApplyDamage(State state, Damage damage)
        {
            return damage;
        }

        internal virtual int ApplyMP5Casting(State state, int mp5Casting)
        {
            return mp5Casting;
        }

        internal virtual int ApplyMP5NotCasting(State state, int mp5NotCasting)
        {
            return mp5NotCasting;
        }

        internal virtual int ApplyBonusDamage(State state, int bonusDamage, SpellParameter spellParameter)
        {
            return bonusDamage;
        }

        internal virtual bool ProcSpellCast(State state, SpellParameter spellParameter)
        {
            return false;
        }

        internal virtual bool ProcSpellDamage(State state, Damage damage)
        {
            return false;
        }

        internal virtual void Tick(State state)
        {
        }
    }
}
