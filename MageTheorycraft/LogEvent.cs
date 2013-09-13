using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Buffs;
using MageTheorycraft.Spells;

namespace MageTheorycraft
{
    public class LogEvent
    {
        public enum EventType
        {
            SpellcastStart,
            SpellcastFinish,
            SpellcastEffect,
            TriggerAllBuffs,
            AddBuff,
            RemoveBuff,
            PowerGain,
            Message,
            FightFinished,
            BuffTick,
            Damage
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

        private double _time;
        public double Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public LogEvent(EventType type, object sender, double time, object parameters)
        {
            _type = type;
            _sender = sender;
            _time = time;
            _parameters = parameters;
        }
    }
}
