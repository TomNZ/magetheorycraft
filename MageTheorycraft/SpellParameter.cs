using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;
using MageTheorycraft.Buffs;

namespace MageTheorycraft
{
    public class SpellParameter
    {
        private int _manaCost = 0;
        public int ManaCost
        {
            get { return _manaCost; }
            set { _manaCost = value; }
        }

        private double _castTime = 0;
        public double CastTime
        {
            get { return _castTime; }
            set { _castTime = value; }
        }

        private int _bonusDamage = 0;
        public int BonusDamage
        {
            get { return _bonusDamage; }
            set { _bonusDamage = value; }
        }

        private int _hasteRating = 0;
        public int HasteRating
        {
            get { return _hasteRating; }
            set { _hasteRating = value; }
        }

        private Spell _spell;
        public Spell Spell
        {
            get { return _spell; }
            set { _spell = value; }
        }

        internal SpellParameter()
        {
            _spell = new Spell("Unknown");
        }

        internal SpellParameter(string spellName)
        {
            _spell = new Spell(spellName);
        }

        internal SpellParameter(State state, Spell spell)
        {
            _spell = spell;

            _manaCost = spell.ManaCost;
            foreach (Buff b in state.ActiveBuffs)
            {
                _manaCost = b.ApplyManaCost(state, _manaCost, spell);
            }

            _hasteRating = state.PlayerStats.SpellHasteRating;
            foreach(Buff b in state.ActiveBuffs)
            {
                _hasteRating = b.ApplyHasteRating(state, _hasteRating, spell);
            }

            _castTime = spell.CastTime;
            foreach (Buff b in state.ActiveBuffs)
            {
                _castTime = b.ApplyCastTime(state, _castTime, spell);
            }

            // Apply haste to cast time
            _castTime = _castTime / (1.0 + (double)_hasteRating / 1570.0);
        }

        internal void CalculateBonusDamage(State state)
        {
            _bonusDamage = state.PlayerStats.SpellDamage;
            foreach (Buff b in state.ActiveBuffs)
            {
                _bonusDamage = b.ApplyBonusDamage(state, _bonusDamage, this);
            }
        }

        internal void SetDamage(Damage damage)
        {
            _spell.SetDamage(damage, _bonusDamage);
        }
    }
}
