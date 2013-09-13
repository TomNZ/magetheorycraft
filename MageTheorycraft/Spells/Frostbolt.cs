using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft;
using MageTheorycraft.Buffs;

namespace MageTheorycraft.Spells
{
    class Frostbolt : Spell
    {
        public Frostbolt(int improvedFrostboltPoints)
            :
            base("Frostbolt", SpellType.Frost, 3.0, 345, 600, 647, 0.814, 0.7)
        {
            if (improvedFrostboltPoints > 0)
            {
                base._castTime -= 0.1 * Math.Min(improvedFrostboltPoints, 5);
            }
        }
    }
}
