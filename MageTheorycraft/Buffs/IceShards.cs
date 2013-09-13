using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class IceShards : Buff
    {
        double _critMultiplierBoost = 0;

        internal IceShards(int numPoints)
            :
            base("Ice Shards", BuffType.Passive)
        {
            _critMultiplierBoost = 0.2 * Math.Min(numPoints, 5);
        }

        internal override double ApplyCritMultiplier(State state, double critMultiplier, SpellParameter spellParameter)
        {
            return base.ApplyCritMultiplier(state, critMultiplier, spellParameter) + _critMultiplierBoost;
        }
    }
}
