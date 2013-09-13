using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft;
using MageTheorycraft.Buffs;

namespace MageTheorycraft.Spells
{
    class Wand : Spell
    {
        // This is a small "hack" - we make the wand do physical
        // damage so that it doesn't reset the 5SR.

        // Ideally in future we need to introduce a special mechanic
        // for attacks like the wand and an equipped weapon - currently
        // the wand triggers effects like quagmirrans eye.
        public Wand(int minDamage, int maxDamage, double speed)
            :
            base("Wand", SpellType.Physical)
        {
            _castTime = speed;
            _minDamage = minDamage;
            _maxDamage = maxDamage;
            _manaCost = 0;
            _bonusDamageCoefficient = 0;
        }
    }
}
