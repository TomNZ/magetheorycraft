using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;

namespace MageTheorycraft.Buffs
{
    class QuagmirransEye : Buff
    {
        // Note that the damage bonus for this trinket will
        // be already included in the player's bonus damage
        // so we do not need to compensate for it here - this
        // class is only to give the haste bonus.

        // The following numbers are generally "agreed upon"
        // numbers for this trinket, but may be slightly inaccurate
        protected int _hasteRating = 320;
        protected double _internalCooldown = 18.0;
        protected double _procChance = 0.1;

        protected double _lastProcTime = 0;

        internal QuagmirransEye()
            :
            base("Quagmirrans Eye", 6)
        {
        }

        internal override bool ProcSpellDamage(State state, Damage damage)
        {
            if (state.CurrentTime - _lastProcTime > _internalCooldown || _lastProcTime == 0)
            {
                if (Chance.RandomChance(_procChance))
                {
                    // Procced
                    state.AddLog(LogEvent.EventType.Message, this, "Quagmirrans Eye procced");
                    _lastProcTime = state.CurrentTime;
                    return true;
                }
            }

            return false;
        }

        internal override int ApplyHasteRating(State state, int hasteRating, Spell spell)
        {
            // This code is only reached when the buff is active (procced)
            return base.ApplyHasteRating(state, hasteRating, spell) + _hasteRating;
        }
    }
}
