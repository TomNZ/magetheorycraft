using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft;
using MageTheorycraft.Buffs;

namespace MageTheorycraft.Spells
{
    class Scorch : Spell
    {
        public Scorch():
            base("Scorch", SpellType.Fire, 1.5, 180, 305, 361, 0.4286)
        {
        }
    }
}
