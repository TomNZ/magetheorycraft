// Deprecated for GUI

using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft
{
    class Program
    {
        public void Run()
        {
            Console.WriteLine("Deprecated");

            /*
            
            double fightLength = 360;  // Length of fight, in seconds
            State state = new State(new Players.FirePlayer());

            // Set up the initial player stats
            // Include all appropriate raid buffs that you would have for the fight
            // in question
            state.PlayerStats.PlayerTotalMana = 8500;
            state.PlayerStats.PlayerCurrentMana = 8500;
            state.PlayerStats.SpellDamage = 1100; // Fire
            state.PlayerStats.SpellHitRating = 164; // Before talents
            state.PlayerStats.SpellCritPercent = 0.22; // Base (non-fire)
            state.PlayerStats.SpellHasteRating = 40; // Passive haste from gear
            state.PlayerStats.ReactionTime = 0.02; // Time in seconds (should be >0)
            state.PlayerStats.MP5Casting = 8;
            state.PlayerStats.MP5NotCasting = 192;

            // Set up the initial spells
            state.AvailableSpells.Add(new Spells.Scorch());
            state.AvailableSpells.Add(new Spells.Fireball(5)); // Improved Fireball points
            state.AvailableSpells.Add(new Spells.Evocation());
            state.AvailableSpells.Add(new Spells.ManaPotion());
            state.AvailableSpells.Add(new Spells.ManaGem());
            state.AvailableSpells.Add(new Spells.Wand(165, 307, 1.5));

            // Set up the initial buffs available for this fight (typical 10/48/3 setup)
            // TODO: Create Icy Veins buff and 2/48/11 spec
            state.AvailableBuffs.Add(new Buffs.MasterOfElements(3));
            state.AvailableBuffs.Add(new Buffs.Scorch(3)); // Improved Scorch points
            state.AvailableBuffs.Add(new Buffs.Ignite(5));
            state.AvailableBuffs.Add(new Buffs.ElementalPrecision(3));
            state.AvailableBuffs.Add(new Buffs.EmpoweredFireball(5));
            state.AvailableBuffs.Add(new Buffs.Clearcasting(5));
            state.AvailableBuffs.Add(new Buffs.CriticalMass(3));
            state.AvailableBuffs.Add(new Buffs.FirePower(5));
            state.AvailableBuffs.Add(new Buffs.PlayingWithFire(3));
            state.AvailableBuffs.Add(new Buffs.Pyromaniac(3));
            state.AvailableBuffs.Add(new Buffs.Incineration(2));

            state.AvailableBuffs.Add(new Buffs.Combustion());
            state.AvailableBuffs.Add(new Buffs.Fireball()); // Fireball tick
            state.AvailableBuffs.Add(new Buffs.QuagmirransEye()); // Trinket 1

            // Initialise
            state.Initialise(fightLength);

            Console.WriteLine("Processing Events:");
            while (state.PerformNextEvent())
            {
                Console.Write(".");
            }

            Console.WriteLine();
            Console.WriteLine();

            // Show some output
            double totalDamage = 0;
            int totalHit = 0;
            int totalCrit = 0;

            foreach (LogEvent log in state.Log.Events)
            {
                switch(log.Type)
                {
                    case LogEvent.EventType.PowerGain:
                        {
                            Console.WriteLine(log.Time.ToString("0.00") + ": You gain " + (int)log.Parameters + " from " + (string)log.Sender);
                        } break;
                    case LogEvent.EventType.Message:
                        {
                            Console.WriteLine(log.Time.ToString("0.00") + ": " + (string)log.Parameters);
                        } break;
                    case LogEvent.EventType.Damage:
                        {
                            Damage damage = (Damage)log.Parameters;

                            // Don't output ticks - fireball tick is very spammy
                            if (damage.Type != Damage.DamageType.Tick)
                            {
                                Console.Write(damage.Time.ToString("0.00") + ": " + "Your " + damage.SpellParameter.Spell.Name + " ");
                                switch (damage.Type)
                                {
                                    case Damage.DamageType.Crit:
                                        {
                                            Console.Write("crits for " + (int)damage.Value);

                                            if (damage.SpellParameter.Spell.Type == MageTheorycraft.Spells.Spell.SpellType.Fire)
                                                totalCrit++;
                                        } break;
                                    case Damage.DamageType.Hit:
                                        {
                                            Console.Write("hits for " + (int)damage.Value);

                                            if (damage.SpellParameter.Spell.Type == MageTheorycraft.Spells.Spell.SpellType.Fire)
                                                totalHit++;
                                        } break;
                                    case Damage.DamageType.Resist:
                                        {
                                            Console.Write("was resisted");
                                        } break;
                                }
                                Console.WriteLine();
                            }

                            totalDamage += damage.Value;
                        } break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Total damage: " + (int)totalDamage);

            double dps = totalDamage / fightLength;
            Console.WriteLine("Overall DPS: " + dps.ToString("0.0"));

            double critPercent = 100.0 * (double)totalCrit / (double)(totalCrit + totalHit);
            Console.WriteLine("Crit %: " + critPercent.ToString("0.00"));

            Console.WriteLine("Remaining mana: " + state.PlayerStats.PlayerCurrentMana);

            Console.WriteLine();
            Console.Write("Press ENTER to exit ");
            Console.ReadLine();
             
             */
        }
    }
}
