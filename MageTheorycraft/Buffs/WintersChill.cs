using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class WintersChill : Buff
    {
        protected int _stackSize = 0;
        public int StackSize
        {
            get { return _stackSize; }
        }

        protected double _procChance = 0;

        protected const double _critBoostPerStack = 0.02;

        internal WintersChill(int numPoints)
            :
            base("Winter's Chill", 15)
        {
            _procChance = 0.2 * Math.Min(numPoints, 5);
        }

        internal override bool ProcSpellDamage(State state, Damage damage)
        {
            if (damage.SpellParameter.Spell.Type == Spell.SpellType.Frost && damage.Type != Damage.DamageType.Resist)
            {
                if (Chance.RandomChance(_procChance))
                    return true;
            }

            return false;
        }

        internal override void Gain(State state)
        {
            base.Gain(state);

            if (_stackSize < 5)
                _stackSize += 1;
        }

        internal override void Fade(State state)
        {
            _stackSize = 0;
        }

        internal override double ApplySpellCrit(State state, double spellCrit, SpellParameter spellParameter)
        {
            if (spellParameter.Spell.Type == Spell.SpellType.Frost)
                return base.ApplySpellCrit(state, spellCrit, spellParameter) + _stackSize * _critBoostPerStack;

            return base.ApplySpellCrit(state, spellCrit, spellParameter);
        }
    }
}
