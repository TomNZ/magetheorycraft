using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft;
using MageTheorycraft.Buffs;

namespace MageTheorycraft.Spells
{
    class ManaPotion : Spell
    {
        private int _minRegen = 1800;
        private int _maxRegen = 3000;

        public int MaxRegen
        {
            get { return _maxRegen; }
        }

        public ManaPotion()
            :
            base("Mana Potion", SpellType.Unknown, 0, 120.0)
        {
        }

        public int UseRegen(double useTime)
        {
            _cooldownStartedTime = useTime;

            // TODO: Needs some sort of crit chance??
            return Chance.RandomInt(_minRegen, _maxRegen);
        }
    }
}
