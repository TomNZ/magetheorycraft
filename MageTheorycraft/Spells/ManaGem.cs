using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft;
using MageTheorycraft.Buffs;

namespace MageTheorycraft.Spells
{
    class ManaGem : Spell
    {
        private struct Gem
        {
            public int rank;
            public int minRegen;
            public int maxRegen;
            public int charges;

            public Gem(int inRank, int inMinRegen, int inMaxRegen, int inCharges)
            {
                rank = inRank;
                minRegen = inMinRegen;
                maxRegen = inMaxRegen;
                charges = inCharges;
            }
        }

        private Gem[] _gems = 
            {
                new Gem(5, 2340, 2460, 3),
                new Gem(4, 1000, 1200, 1),
                new Gem(3, 775, 925, 1),
                new Gem(2, 550, 650, 1),
                new Gem(1, 375, 425, 1)
            };

        internal int MaxRegen
        {
            get { return HighestAvailableGem().maxRegen; }
        }

        internal ManaGem()
            :
            base("Mana Gem", SpellType.Unknown, 0, 120.0)
        {
        }

        internal int UseRegen(double useTime)
        {
            _cooldownStartedTime = useTime;

            Gem highestGem = HighestAvailableGem();

            UseGemCharge(highestGem);

            return Chance.RandomInt(highestGem.minRegen, highestGem.maxRegen);
        }

        private Gem HighestAvailableGem()
        {
            Gem highestGem = new Gem();

            foreach (Gem gem in _gems)
            {
                if (gem.charges > 0)
                {
                    if (gem.rank > highestGem.rank)
                    {
                        highestGem = gem;
                    }
                }
            }

            return highestGem;
        }

        private void UseGemCharge(Gem gem)
        {
            for (int i = 0; i < _gems.Length; i++)
            {
                if (_gems[i].rank == gem.rank)
                {
                    _gems[i].charges--;
                }
            }
        }

        internal override bool Available(State state)
        {
            if (HighestAvailableGem().charges > 0)
            {
                return base.Available(state);
            }
            else
            {
                return false;
            }
        }
    }
}
