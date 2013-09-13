using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Buffs;
using MageTheorycraft.Spells;
using MageTheorycraft.Players;

namespace MageTheorycraft
{
    public class TimelineEvent
    {
        public enum EventType
        {
            TriggerPlayerCast,
            SpellcastStart,
            SpellcastFinish,
            SpellcastEffect,
            TriggerAllBuffs,
            AddBuff,
            RemoveBuff,
            PowerGain,
            FightFinished,
            BuffTick
        }

        private EventType _type;
        public EventType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private object _sender;
        public object Sender
        {
            get { return _sender; }
        }

        private object _parameters;
        public object Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        private double _triggerTime;
        public double TriggerTime
        {
            get { return _triggerTime; }
            set { _triggerTime = value; }
        }

        private bool _triggered;
        public bool Triggered
        {
            get { return _triggered; }
        }

        public TimelineEvent()
        {
        }

        public TimelineEvent(EventType type, object sender, double triggerTime, object parameters)
        {
            _type = type;
            _sender = sender;
            _triggerTime = triggerTime;
            _parameters = parameters;
        }

        public void Trigger(State state)
        {
            switch (_type)
            {
                case EventType.SpellcastStart:
                    {
                        SpellParameter spellParameter = (SpellParameter)_parameters;
                        if (state.PlayerStats.PlayerCurrentMana > spellParameter.ManaCost)
                        {
                            spellParameter.Spell.StartCast(state, spellParameter);
                            state.AddLog(LogEvent.EventType.SpellcastStart, _sender, _parameters);
                        }
                    } break;
                case EventType.SpellcastFinish:
                    {
                        SpellParameter spellParameter = (SpellParameter)_parameters;
                        spellParameter.CalculateBonusDamage(state);
                        if (state.PlayerStats.PlayerCurrentMana > spellParameter.ManaCost)
                        {
                            spellParameter.Spell.StopCast(state, spellParameter);
                            state.PlayerStats.PlayerCurrentMana -= spellParameter.ManaCost;
                            state.SuccessfulCast(spellParameter);
                            state.AddLog(LogEvent.EventType.SpellcastFinish, _sender, _parameters);
                        }
                    } break;
                case EventType.SpellcastEffect:
                    {
                        SpellParameter spellParameter = (SpellParameter)_parameters;
                        spellParameter.Spell.SpellcastEffect(state, spellParameter);
                        state.AddLog(LogEvent.EventType.SpellcastEffect, _sender, _parameters);
                    } break;
                case EventType.PowerGain:
                    {
                        state.PlayerStats.PlayerCurrentMana += (int)_parameters;
                        state.AddLog(LogEvent.EventType.PowerGain, _sender, _parameters);
                    } break;
                case EventType.AddBuff:
                    {
                        state.AddBuff((string)_parameters);
                        state.AddLog(LogEvent.EventType.AddBuff, _sender, _parameters);
                    } break;
                case EventType.RemoveBuff:
                    {
                        Buff b = (Buff)_parameters;
                        b.Fade(state);
                        state.ActiveBuffs.Remove(b);
                        state.AddLog(LogEvent.EventType.RemoveBuff, _sender, _parameters);
                    } break;
                case EventType.BuffTick:
                    {
                        Buff b = (Buff)_parameters;
                        b.Tick(state);
                        state.AddLog(LogEvent.EventType.BuffTick, _sender, _parameters);
                    } break;
                case EventType.TriggerPlayerCast:
                    {
                        FirePlayer p = (FirePlayer)_parameters;
                        p.NextSpellCast(state);
                    }break;
            }

            _triggered = true;
        }
    }
}
