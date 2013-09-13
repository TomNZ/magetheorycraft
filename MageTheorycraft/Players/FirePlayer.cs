using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Spells;
using MageTheorycraft.Buffs;

namespace MageTheorycraft.Players
{
    // Defines a virtual "AI" for the spells which the player casts
    class FirePlayer : Player
    {
        private bool _wanding = false;

        // Needs to have an overall view of the system to accurately decide what to do next
        public FirePlayer()
            :
            base("Fire (basic)")
        {
        }

        internal override void NextSpellCast(State state)
        {
            double currentTime = state.CurrentTime;

            Spells.Scorch scorchSpell = (Spells.Scorch)state.GetSpell("Scorch");
            Spells.Fireball fireballSpell = (Spells.Fireball)state.GetSpell("Fireball");
            Combustion combustion = (Combustion)state.GetBuff("Combustion");
            Evocation evocation = (Evocation)state.GetSpell("Evocation");
            ManaPotion manaPotion = (ManaPotion)state.GetSpell("Mana Potion");
            ManaGem manaGem = (ManaGem)state.GetSpell("Mana Gem");
            Buffs.Scorch scorchBuff = (Buffs.Scorch)state.GetBuff("Scorch");
            Wand wand = (Wand)state.GetSpell("Wand");
            IcyVeins icyVeins = (IcyVeins)state.GetBuff("Icy Veins");

            /***************************\
             * Non-cast actions        *
            \***************************/

            // Mana pot
            if (manaPotion.Available(state) && state.PlayerStats.PlayerTotalMana - state.PlayerStats.PlayerCurrentMana > manaPotion.MaxRegen)
            {
                int regenAmount = manaPotion.UseRegen(currentTime);
                state.PlayerStats.PlayerCurrentMana += regenAmount;
                state.AddLog(LogEvent.EventType.PowerGain, manaPotion.Name, regenAmount);
            }
            // Mana gem
            if (manaGem.Available(state) && state.PlayerStats.PlayerTotalMana - state.PlayerStats.PlayerCurrentMana > manaGem.MaxRegen)
            {
                int regenAmount = manaGem.UseRegen(currentTime);
                state.PlayerStats.PlayerCurrentMana += regenAmount;
                state.AddLog(LogEvent.EventType.PowerGain, manaGem.Name, regenAmount);
            }
            // Combustion - only if we don't need to rescorch for a while and if it's available
            if (combustion != null && combustion.Available(currentTime))
            {
                if (scorchBuff == null || (scorchBuff.ExpireTime - currentTime > 22 && scorchBuff.ScorchStackSize == 5))
                {
                    state.AddLog(LogEvent.EventType.Message, this, "Combustion popped");
                    state.AddBuff("Combustion");
                }
            }
            // Icy veins
            if (icyVeins != null && icyVeins.Available(currentTime))
            {
                if (scorchBuff == null || (scorchBuff.ExpireTime - currentTime > 22 && scorchBuff.ScorchStackSize == 5))
                {
                    state.AddLog(LogEvent.EventType.Message, this, "Icy Veins popped");
                    state.AddBuff("Icy Veins");
                }
            }
            // Trinkets

            /***************************\
             * Cast actions            *
            \***************************/

            if (_wanding)
            {
                if (state.PlayerStats.PlayerCurrentMana > 500)
                {
                    _wanding = false;
                }
                else
                {
                    state.CastSpell(wand);
                    return;
                }
            }

            // Evocate when below a certain threshold, if it's available, and we don't have an incoming scorch rebuff
            if (evocation.Available(state) && state.PlayerStats.PlayerPercentageMana <= 20 && (scorchBuff == null || scorchBuff.ExpiryEvent.TriggerTime - currentTime > 12))
            {
                state.CastSpell(evocation);
            }
            // If we have less than 5 scorches stacked or the debuff only has 5 seconds left, cast another
            else if (scorchBuff != null && (scorchBuff.ScorchStackSize < 5 || scorchBuff.ExpiryEvent.TriggerTime - currentTime < 5))
            {
                state.CastSpell(scorchSpell);
            }
            else if (!_wanding && state.PlayerStats.PlayerCurrentMana < fireballSpell.ManaCost)
            {
                _wanding = true;
                state.CastSpell(wand);
            }
            // If nothing else needs attention then cast a fireball
            else
            {
                state.CastSpell(fireballSpell);
            }
        }
    }
}
