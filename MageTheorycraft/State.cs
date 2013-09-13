using System;
using System.Collections.Generic;
using System.Text;
using MageTheorycraft.Buffs;
using MageTheorycraft.Players;
using MageTheorycraft.Spells;
using System.Net.Sockets;

namespace MageTheorycraft
{
    public class State
    {
        private IList<Buff> _activeBuffs;
        public IList<Buff> ActiveBuffs
        {
            get { return _activeBuffs; }
        }

        private IList<Buff> _availableBuffs;
        public IList<Buff> AvailableBuffs
        {
            get { return _availableBuffs; }
        }
        
        private IList<Spell> _availableSpells;
        public IList<Spell> AvailableSpells
        {
            get { return _availableSpells; }
        }

        private Timeline _timeline;
        public Timeline Timeline
        {
            get { return _timeline; }
            set { _timeline = value; }
        }

        private Log _log;
        public Log Log
        {
            get { return _log; }
            set { _log = value; }
        }

        private double _currentTime = 0;
        internal double CurrentTime
        {
            get { return _currentTime; }
            set { _currentTime = value; }
        }

        private PlayerStats _playerStats;
        public PlayerStats PlayerStats
        {
            get { return _playerStats; }
            internal set { _playerStats = value; }
        }

        private Player _player;
        public Player Player
        {
            get { return _player; }
            internal set { _player = value; }
        }

        private IList<Damage> _damages;
        public IList<Damage> Damages
        {
            get { return _damages; }
        }

        private Config _config;
        public Config Config
        {
            get { return _config; }
            internal set { Initialise(value); }
        }

        private double _lastCastTime = -1;
        private double _lastCastFinishTime = -5;
        private double _lastEventTime = 0;
        private double _lastRegenTime = 0;

        private double _globalCooldown = 1.5;
        internal double GlobalCooldown
        {
            get { return _globalCooldown; }
            set { _globalCooldown = value; }
        }

        private double _finishTime;
        public double FinishTime
        {
            get { return _finishTime; }
        }

        public State(Config config)
        {
            Initialise(config);
        }

        internal void Initialise(Config config)
        {
            // Initialise the state from the configuration
            // Most of this is hard coded stuff - not ideal but does the job

            _config = config;

            _activeBuffs = new List<Buff>();
            _availableBuffs = new List<Buff>();
            _availableSpells = new List<Spell>();
            _timeline = new Timeline();
            _log = new Log();
            _playerStats = new PlayerStats();
            _damages = new List<Damage>();

            // Just fire for now
            _player = new FirePlayer();

            if (config == null) return;

            // Set up the initial player stats
            PlayerStats.PlayerTotalMana = config.Mana;
            PlayerStats.PlayerCurrentMana = config.Mana;
            PlayerStats.SpellDamage = config.BonusDamage; // Fire
            PlayerStats.SpellHitRating = config.HitRating; // Before talents
            PlayerStats.SpellCritPercent = config.CritChance / 100; // Base (non-fire)
            PlayerStats.SpellHasteRating = config.HasteRating; // Passive haste from gear
            PlayerStats.ReactionTime = config.ReactionTime; // Time in seconds (should be >0)
            PlayerStats.MP5Casting = config.MP5Casting + config.ManaRegen;
            PlayerStats.MP5NotCasting = config.MP5NotCasting + config.ManaRegen;

            // Set up the initial spells
            AvailableSpells.Add(new Spells.Scorch());
            AvailableSpells.Add(new Spells.Fireball(config.SpecImpFireball)); // Improved Fireball points
            AvailableSpells.Add(new Spells.Evocation());
            AvailableSpells.Add(new Spells.ManaPotion());
            AvailableSpells.Add(new Spells.ManaGem());
            AvailableSpells.Add(new Spells.Wand(config.MinWandDamage, config.MaxWandDamage, config.WandSpeed));

            // Spec/buffs

            // Passive talents
            if (config.SpecMasterOfElements > 0)
                AvailableBuffs.Add(new Buffs.MasterOfElements(config.SpecMasterOfElements));
            if (config.SpecIgnite > 0)
                AvailableBuffs.Add(new Buffs.Ignite(config.SpecIgnite));
            if (config.SpecElementalPrecision > 0)
                AvailableBuffs.Add(new Buffs.ElementalPrecision(config.SpecElementalPrecision));
            if (config.SpecEmpoweredFireball > 0)
                AvailableBuffs.Add(new Buffs.EmpoweredFireball(config.SpecEmpoweredFireball));
            if (config.SpecCriticalMass > 0)
                AvailableBuffs.Add(new Buffs.CriticalMass(config.SpecCriticalMass));
            if (config.SpecFirePower > 0)
                AvailableBuffs.Add(new Buffs.FirePower(config.SpecFirePower));
            if (config.SpecPlayingWithFire > 0)
                AvailableBuffs.Add(new Buffs.PlayingWithFire(config.SpecPlayingWithFire));
            if (config.SpecPyromaniac > 0)
                AvailableBuffs.Add(new Buffs.Pyromaniac(config.SpecPyromaniac));
            if (config.SpecIncinerate > 0)
                AvailableBuffs.Add(new Buffs.Incineration(config.SpecIncinerate));
            if (config.SpecMoltenFury > 0)
                AvailableBuffs.Add(new Buffs.MoltenFury(config.SpecMoltenFury, config.MoltenFuryActiveTime));

            // Active talents
            if (config.SpecImpScorch > 0)
                AvailableBuffs.Add(new Buffs.Scorch(config.SpecImpScorch)); // Improved Scorch points
            if (config.SpecArcConc > 0)
                AvailableBuffs.Add(new Buffs.Clearcasting(config.SpecArcConc));

            // Player activated talents
            if (config.SpecCombustion == 1)
                AvailableBuffs.Add(new Buffs.Combustion());
            if (config.SpecIcyVeins == 1)
                AvailableBuffs.Add(new Buffs.IcyVeins());
            if (config.SpecArcPower == 1)
                AvailableBuffs.Add(new Buffs.ArcanePower());
            if (config.SpecPresenceOfMind == 1)
                AvailableBuffs.Add(new Buffs.PresenceOfMind());

            // Other
            AvailableBuffs.Add(new Buffs.Fireball()); // Fireball tick

            // Trinkets
            if (config.QuagmirransEye)
                AvailableBuffs.Add(new Buffs.QuagmirransEye()); // QE
            if (config.DarkmoonWrath)
                AvailableBuffs.Add(new Buffs.DarkmoonWrath());
            if (config.DarkmoonCrusade)
                AvailableBuffs.Add(new Buffs.DarkmoonCrusade());

            // Gear sets
            if (config.SpellstrikeSet)
                AvailableBuffs.Add(new Buffs.SpellstrikeSet()); // Spellstrike
            if (config.T5Set4)
                AvailableBuffs.Add(new Buffs.T5Set4());

            // Place passive available buffs in the active stack
            foreach (Buff b in _availableBuffs)
            {
                if (b.Type == Buff.BuffType.Passive)
                {
                    _activeBuffs.Add(b);
                    b.Gain(this);
                }
            }

            // Add first events
            AddEvent(TimelineEvent.EventType.FightFinished, this, config.FightLength, null);
            _finishTime = config.FightLength;
            Player.NextSpellCast(this);
        }

        public void Run()
        {
            while (PerformNextEvent())
            {
            }
        }

        internal void CastSpell(Spell spell)
        {
            SpellParameter spellParameter = new SpellParameter(this, spell);

            if (spellParameter.ManaCost < _playerStats.PlayerCurrentMana)
            {
                AddEvent(TimelineEvent.EventType.SpellcastStart, this, 0, spellParameter);
            }
            else
            {
                CastSpell(GetSpell("Wand"));
            }
        }

        internal void AddDamage(SpellParameter spellParameter)
        {
            Damage damage = new Damage(CurrentTime, spellParameter);

            double spellHit = _playerStats.SpellHitPercent + 0.83;
            foreach (Buff b in _activeBuffs)
            {
                spellHit = b.ApplySpellHit(this, spellHit, spellParameter.Spell);
            }

            if (!Chance.RandomChance(spellHit))
            {
                damage.Type = Damage.DamageType.Resist;
            }
            else
            {
                double spellCrit = _playerStats.SpellCritPercent;
                foreach (Buff b in _activeBuffs)
                {
                    spellCrit = b.ApplySpellCrit(this, spellCrit, spellParameter);
                }

                if (Chance.RandomChance(spellCrit))
                {
                    damage.Type = Damage.DamageType.Crit;
                }
                else
                {
                    damage.Type = Damage.DamageType.Hit;
                }

                spellParameter.SetDamage(damage);

                // Crit
                if (damage.Type == Damage.DamageType.Crit)
                {
                    double critMultiplier = 0.5;
                    foreach (Buff b in _activeBuffs)
                    {
                        critMultiplier = b.ApplyCritMultiplier(this, critMultiplier, spellParameter);
                    }

                    damage.Value += damage.Value * critMultiplier;
                }

                foreach (Buff b in _activeBuffs)
                {
                    damage = b.ApplyDamage(this, damage);
                }
            }

            _damages.Add(damage);
            _log.AddEvent(new LogEvent(LogEvent.EventType.Damage, this, _currentTime, damage));

            foreach (Buff b in _availableBuffs)
            {
                if (b.ProcSpellDamage(this, damage) && b.Type == Buff.BuffType.Active)
                {
                    if (!_activeBuffs.Contains(b))
                    {
                        _activeBuffs.Add(b);
                    }

                    b.Gain(this);
                }
            }
        }

        internal void AddEvent(TimelineEvent.EventType type, object sender, double deltaTime, object parameters)
        {
            TimelineEvent e = new TimelineEvent(type, sender, _currentTime + deltaTime, parameters);
            _timeline.Events.Add(e);
        }

        internal void AddLog(LogEvent.EventType type, object sender, object parameters)
        {
            LogEvent e = new LogEvent(type, sender, _currentTime, parameters);
            _log.Events.Add(e);
        }

        internal void AddBuff(string buff)
        {
            foreach (Buff b in _activeBuffs)
            {
                if (b.Name == buff)
                {
                    b.Gain(this);
                    return;
                }
            }

            foreach (Buff b in _availableBuffs)
            {
                if (b.Name == buff && (b.Type == Buff.BuffType.Active || b.Type == Buff.BuffType.ActiveAura))
                {
                    _activeBuffs.Add(b);
                    b.Gain(this);
                    return;
                }
            }
        }

        // Returns true if there are still more events
        public bool PerformNextEvent()
        {
            TimelineEvent e = _timeline.NextEvent(_currentTime);

            _currentTime = e.TriggerTime;

            // MP5 regen
            if (_currentTime - _lastRegenTime > 2)
            {
                int mp5Casting = PlayerStats.MP5Casting;
                foreach (Buff b in _activeBuffs)
                {
                    mp5Casting = b.ApplyMP5Casting(this, mp5Casting);
                }
                int mp2Casting = (int)((double)mp5Casting * 2.0 / 5.0);

                int mp5NotCasting = PlayerStats.MP5NotCasting;
                foreach (Buff b in _activeBuffs)
                {
                    mp5NotCasting = b.ApplyMP5NotCasting(this, mp5NotCasting);
                }
                int mp2NotCasting = (int)((double)mp5NotCasting * 2.0 / 5.0);

                // 5 Second Rule
                if (_currentTime - _lastCastFinishTime > 5)
                {
                    // Casting part
                    if (_lastCastFinishTime + 5 - _lastRegenTime > 2)
                    {
                        _playerStats.PlayerCurrentMana += mp2Casting * ((int)(_lastCastFinishTime + 5 - _lastRegenTime) / 2);
                        _lastRegenTime += 2 * ((int)(_lastCastFinishTime + 5 - _lastRegenTime) / 2);
                    }

                    // Non casting part
                    _playerStats.PlayerCurrentMana += mp2NotCasting * ((int)(_currentTime - _lastRegenTime) / 2);
                    _lastRegenTime += 2 * ((int)(_currentTime - _lastRegenTime) / 2);
                }
                else
                {
                    // Normal casting regen
                    _playerStats.PlayerCurrentMana += mp2Casting * ((int)(_currentTime - _lastRegenTime) / 2);
                    _lastRegenTime += 2 * ((int)(_currentTime - _lastRegenTime) / 2);
                }
            }

            if (e.Type == TimelineEvent.EventType.FightFinished)
                return false;

            if (e.Type == TimelineEvent.EventType.SpellcastFinish)
            {
                // Queue up next cast (respecting GCD)
                double nextCastStart = Math.Max(_lastCastTime + _globalCooldown + _playerStats.ReactionTime, _currentTime + _playerStats.ReactionTime);
                _timeline.Events.Add(new TimelineEvent(TimelineEvent.EventType.TriggerPlayerCast, this, nextCastStart, _player));

                if (((SpellParameter)e.Parameters).Spell.Type != Spell.SpellType.Physical)
                    _lastCastFinishTime = _currentTime;
            }

            if (e.Type == TimelineEvent.EventType.SpellcastStart && ((SpellParameter)e.Parameters).Spell.Type != Spell.SpellType.Physical)
                _lastCastTime = _currentTime;

            e.Trigger(this);

            _lastEventTime = _currentTime;

            return true;
        }

        public Spell GetSpell(string spellName)
        {
            foreach (Spell spell in _availableSpells)
            {
                if (spell.Name == spellName)
                    return spell;
            }

            return null;
        }

        public Buff GetBuff(string buffName)
        {
            foreach (Buff buff in _availableBuffs)
            {
                if (buff.Name == buffName)
                    return buff;
            }

            return null;
        }

        internal void SuccessfulCast(SpellParameter spellParameter)
        {
            foreach (Buff b in _availableBuffs)
            {
                if (b.ProcSpellCast(this, spellParameter) && b.Type == Buff.BuffType.Active)
                {
                    if (!_activeBuffs.Contains(b))
                    {
                        _activeBuffs.Add(b);
                    }

                    b.Gain(this);
                }
            }
        }
    }
}
