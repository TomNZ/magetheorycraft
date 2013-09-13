using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MageTheorycraft.GUI
{
    public partial class SimulationResults : Form
    {
        private Timeline _lastTimeline;
        private Log _lastLog;

        public SimulationResults()
        {
            InitializeComponent();
        }

        static void Main(string[] args)
        {
            SimulationResults gui = new SimulationResults();
            Application.EnableVisualStyles();
            Application.Run(gui);
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            SimulationConfig configForm = new SimulationConfig();
            configForm.ShowDialog();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            RunSimulation();
            OutputResults();
        }

        private void RunSimulation()
        {
            State state = new State(new Players.FirePlayer());

            // Set up the initial player stats
            // Include all appropriate raid buffs that you would have for the fight
            // in question
            state.PlayerStats.PlayerTotalMana = CurrentConfig.Mana;
            state.PlayerStats.PlayerCurrentMana = CurrentConfig.Mana;
            state.PlayerStats.SpellDamage = CurrentConfig.BonusDamage; // Fire
            state.PlayerStats.SpellHitRating = CurrentConfig.HitRating; // Before talents
            state.PlayerStats.SpellCritPercent = CurrentConfig.CritChance / 100; // Base (non-fire)
            state.PlayerStats.SpellHasteRating = CurrentConfig.HasteRating; // Passive haste from gear
            state.PlayerStats.ReactionTime = CurrentConfig.ReactionTime; // Time in seconds (should be >0)
            state.PlayerStats.MP5Casting = CurrentConfig.MP5Casting + CurrentConfig.ManaRegen;
            state.PlayerStats.MP5NotCasting = CurrentConfig.MP5NotCasting + CurrentConfig.ManaRegen;

            // Set up the initial spells
            state.AvailableSpells.Add(new Spells.Scorch());
            state.AvailableSpells.Add(new Spells.Fireball(CurrentConfig.SpecImpFireball)); // Improved Fireball points
            state.AvailableSpells.Add(new Spells.Evocation());
            state.AvailableSpells.Add(new Spells.ManaPotion());
            state.AvailableSpells.Add(new Spells.ManaGem());
            state.AvailableSpells.Add(new Spells.Wand(CurrentConfig.MinWandDamage, CurrentConfig.MaxWandDamage, CurrentConfig.WandSpeed));

            // Spec/buffs
            if (CurrentConfig.SpecMasterOfElements > 0)
                state.AvailableBuffs.Add(new Buffs.MasterOfElements(CurrentConfig.SpecMasterOfElements));
            if (CurrentConfig.SpecImpScorch > 0)
                state.AvailableBuffs.Add(new Buffs.Scorch(CurrentConfig.SpecImpScorch)); // Improved Scorch points
            if (CurrentConfig.SpecIgnite > 0)
                state.AvailableBuffs.Add(new Buffs.Ignite(CurrentConfig.SpecIgnite));
            if (CurrentConfig.SpecElementalPrecision > 0)
                state.AvailableBuffs.Add(new Buffs.ElementalPrecision(CurrentConfig.SpecElementalPrecision));
            if (CurrentConfig.SpecEmpoweredFireball > 0)
            state.AvailableBuffs.Add(new Buffs.EmpoweredFireball(CurrentConfig.SpecEmpoweredFireball));
            if (CurrentConfig.SpecArcConc > 0)
                state.AvailableBuffs.Add(new Buffs.Clearcasting(CurrentConfig.SpecArcConc));
            if (CurrentConfig.SpecCriticalMass > 0)
                state.AvailableBuffs.Add(new Buffs.CriticalMass(CurrentConfig.SpecCriticalMass));
            if (CurrentConfig.SpecFirePower > 0)
                state.AvailableBuffs.Add(new Buffs.FirePower(CurrentConfig.SpecFirePower));
            if (CurrentConfig.SpecPlayingWithFire > 0)
                state.AvailableBuffs.Add(new Buffs.PlayingWithFire(CurrentConfig.SpecPlayingWithFire));
            if (CurrentConfig.SpecPyromaniac > 0)
            state.AvailableBuffs.Add(new Buffs.Pyromaniac(CurrentConfig.SpecPyromaniac));
            if (CurrentConfig.SpecIncinerate > 0)
                state.AvailableBuffs.Add(new Buffs.Incineration(CurrentConfig.SpecIncinerate));
            if (CurrentConfig.SpecCombustion == 1)
                state.AvailableBuffs.Add(new Buffs.Combustion());

            // Other
            state.AvailableBuffs.Add(new Buffs.Fireball()); // Fireball tick

            // Trinkets
            if (CurrentConfig.QuagmirransEye)
                state.AvailableBuffs.Add(new Buffs.QuagmirransEye()); // QE
            if (CurrentConfig.DarkmoonWrath)
                state.AvailableBuffs.Add(new Buffs.DarkmoonWrath());
            if (CurrentConfig.DarkmoonCrusade)
                state.AvailableBuffs.Add(new Buffs.DarkmoonCrusade());

            // Gear sets
            if (CurrentConfig.SpellstrikeSet)
                state.AvailableBuffs.Add(new Buffs.SpellstrikeSet()); // Spellstrike
            if (CurrentConfig.T5Set4)
                state.AvailableBuffs.Add(new Buffs.T5Set4());

            // Initialise
            state.Initialise(CurrentConfig.FightLength);

            while (state.PerformNextEvent())
            {
            }

            _lastLog = state.Log;
            _lastTimeline = state.Timeline;
        }

        private void OutputResults()
        {
            // Combat log
            DataTable dt = new DataTable();
            dt.Columns.Add("Time");
            dt.Columns.Add("Event");

            double totalDamage = 0;
            int totalHit = 0;
            int totalCrit = 0;

            switch (cmbCombatLogStyle.SelectedIndex)
            {
                case 1:
                    {
                        // Consolidated casts
                    } break;
                default:
                    {
                        foreach (LogEvent log in _lastLog.Events)
                        {
                            switch (log.Type)
                            {
                                case LogEvent.EventType.PowerGain:
                                    {
                                        dt.Rows.Add(new string[] { log.Time.ToString("0.00") ,  "You gain " + (int)log.Parameters + " from " + (string)log.Sender });
                                    } break;
                                case LogEvent.EventType.Message:
                                    {
                                        dt.Rows.Add(new string[] { log.Time.ToString("0.00"), (string)log.Parameters });
                                    } break;
                                case LogEvent.EventType.Damage:
                                    {
                                        Damage damage = (Damage)log.Parameters;

                                        // Don't output ticks - fireball tick is very spammy
                                        if (damage.Type != Damage.DamageType.Tick)
                                        {
                                            string message = "Your " + damage.SpellParameter.Spell.Name + " ";

                                            switch (damage.Type)
                                            {
                                                case Damage.DamageType.Crit:
                                                    {
                                                        message += "crits for " + (int)damage.Value;

                                                        if (damage.SpellParameter.Spell.Type == MageTheorycraft.Spells.Spell.SpellType.Fire)
                                                            totalCrit++;
                                                    } break;
                                                case Damage.DamageType.Hit:
                                                    {
                                                        message += "hits for " + (int)damage.Value;

                                                        if (damage.SpellParameter.Spell.Type == MageTheorycraft.Spells.Spell.SpellType.Fire)
                                                            totalHit++;
                                                    } break;
                                                case Damage.DamageType.Resist:
                                                    {
                                                        message += "was resisted";
                                                    } break;
                                            }
                                            dt.Rows.Add(new string[] { damage.Time.ToString("0.00"), message });;
                                        }

                                        totalDamage += damage.Value;
                                    } break;
                            }
                        }
                    } break;
            }

            dgvCombatLog.DataSource = dt;

            dt = new DataTable();
            dt.Columns.Add("Stat");
            dt.Columns.Add("Value");

            dt.Rows.Add(new string[] { "Total dmg", ((int)totalDamage).ToString() });

            double dps = totalDamage / CurrentConfig.FightLength;
            dt.Rows.Add(new string[] { "DPS", dps.ToString("0.0") });

            double critPercent = 100.0 * (double)totalCrit / (double)(totalCrit + totalHit);
            dt.Rows.Add(new string[] { "Crit %", critPercent.ToString("0.00") });

            dgvStatistics.DataSource = dt;
        }
    }
}