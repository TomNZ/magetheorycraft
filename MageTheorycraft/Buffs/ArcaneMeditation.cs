using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class ArcaneMeditation : Buff
    {
        private double _regenPercent = 0;

        internal ArcaneMeditation(int numPoints)
            :
            base("Arcane Meditation", BuffType.Passive)
        {
            _regenPercent = 0.1 * Math.Min(numPoints, 3);
        }

        internal override int ApplyMP5Casting(State state, int mp5Casting)
        {
            return base.ApplyMP5Casting(state, mp5Casting) + (int)((double)state.PlayerStats.MP5Casting * _regenPercent);
        }
    }
}
