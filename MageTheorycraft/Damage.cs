using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;

namespace MageTheorycraft
{
    public class Damage
    {
        public enum DamageType
        {
            Hit,
            Crit,
            Resist,
            Tick
        }

        private DamageType _type = DamageType.Hit;
        public DamageType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private double _value = 0;
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private double _time = 0;
        public double Time
        {
            get { return _time; }
            set { _time = value; }
        }

        private SpellParameter _spellParameter = null;
        public SpellParameter SpellParameter
        {
            get {
                if (_spellParameter != null)
                    return _spellParameter;
                else
                    return new SpellParameter();
            }
            set { _spellParameter = value; }
        }

        internal Damage(double value, double time, string source)
        {
            _time = time;
            _value = value;
            _spellParameter = new SpellParameter(source);
        }

        internal Damage(double value, double time, string source, DamageType type)
            :
            this(value, time, source)
        {
            _type = type;
        }

        internal Damage(double time, SpellParameter spellParameter)
        {
            _time = time;
            _spellParameter = spellParameter;
        }

        internal Damage(double value, DamageType type, double time, SpellParameter spellParameter)
        {
            _value = value;
            _type = type;
            _time = time;
            _spellParameter = spellParameter;
        }
    }
}
