using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft;
using MageTheorycraft.Buffs;

namespace MageTheorycraft.Spells
{
    class Fireball : Spell
    {
        public Fireball(int improvedFireballPoints)
            :
            base("Fireball", SpellType.Fire, 3.5, 425, 717, 913, 1.0, 0.7)
        {
            if (improvedFireballPoints > 0)
            {
                base._castTime -= 0.1 * Math.Min(improvedFireballPoints, 5);
            }
        }
    }
}
