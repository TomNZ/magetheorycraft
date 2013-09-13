using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class Clearcasting : Buff
    {
        protected bool _nextProc = false;
        protected double _procChance = 0;
        protected Spell _lastSpell = null;
        internal Spell LastSpell
        {
            get { return _lastSpell; }
        }

        internal Clearcasting(int numPoints)
            :
            base("Clearcasting", BuffType.Passive)
        {
            _procChance = 0.02 * Math.Min(numPoints, 3);
        }

        internal override bool ProcSpellCast(State state, SpellParameter spellParameter)
        {
            if (Chance.RandomChance(_procChance))
            {
                _nextProc = true;
            }

            return false;
        }

        internal override int ApplyManaCost(State state, int manaCost, Spell spell)
        {
            if (_nextProc)
            {
                _nextProc = false;
                _lastSpell = spell;
                return 0;
            }

            return base.ApplyManaCost(state, manaCost, spell);
        }
    }
}
