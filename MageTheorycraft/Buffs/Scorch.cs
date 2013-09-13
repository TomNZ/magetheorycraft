using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class Scorch : Buff
    {
        protected int _scorchStackSize = 0;
        internal int ScorchStackSize
        {
            get { return _scorchStackSize; }
        }

        protected double _procChance = 0;

        internal Scorch(int improvedScorchPoints)
            :
            base("Scorch", 30)
        {
            if (improvedScorchPoints == 3)
            {
                _procChance = 1;
            }
            else
            {
                _procChance = 0.33 * Math.Min(improvedScorchPoints, 2);
            }
        }

        internal override bool ProcSpellDamage(State state, Damage damage)
        {
            if (damage.SpellParameter.Spell.Name == "Scorch" && damage.Type != Damage.DamageType.Resist)
            {
                if (Chance.RandomChance(_procChance))
                    return true;
            }

            return false;
        }

        internal override void Gain(State state)
        {
            base.Gain(state);

            if (_scorchStackSize < 5)
                _scorchStackSize += 1;
        }

        internal override void Fade(State state)
        {
            _scorchStackSize = 0;
        }

        internal override Damage ApplyDamage(State state, Damage damage)
        {
            if (damage.SpellParameter.Spell.Type == Spell.SpellType.Fire)
                damage.Value += damage.Value * (0.03 * _scorchStackSize);

            return damage;
        }
    }
}
