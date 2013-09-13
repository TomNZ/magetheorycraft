using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Buffs
{
    class MoltenFury : Buff
    {
        protected double _damageMultiplier = 1;

        protected double _activeTime = 0.18;
        internal double ActiveTime
        {
            get { return _activeTime; }
            set { _activeTime = value; }
        }

        internal MoltenFury(int numPoints)
            :
            base("Molten Fury", BuffType.Passive)
        {
            _damageMultiplier = 1 + (0.1 * numPoints);
        }

        internal MoltenFury(int numPoints, double activeTime)
            :
            this(numPoints)
        {
            _activeTime = activeTime;
        }

        internal override Damage ApplyDamage(State state, Damage damage)
        {
            if ((state.CurrentTime / state.FinishTime) > (1 - _activeTime))
                damage.Value *= _damageMultiplier;

            return base.ApplyDamage(state, damage);
        }
    }
}
