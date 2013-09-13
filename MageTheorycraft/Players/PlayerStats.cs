using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Players
{
    public class PlayerStats
    {
        public enum PlayerType
        {
            Fire,
            Frost,
            Arcane,
            Hybrid
        }

        private PlayerType _type = PlayerType.Fire;
        public PlayerType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _spellHitRating = 0;
        public int SpellHitRating
        {
            get { return _spellHitRating; }
            set { _spellHitRating = value; }
        }
        public double SpellHitPercent
        {
            get { return (double)_spellHitRating / 1260; }
            set { _spellHitRating = (int)((double)value * 1260); }
        }

        private int _spellHasteRating = 0;
        public int SpellHasteRating
        {
            get { return _spellHasteRating; }
            set { _spellHasteRating = value; }
        }

        private int _spellDamage = 0;
        public int SpellDamage
        {
            get { return _spellDamage; }
            set { _spellDamage = value; }
        }

        private int _spellCritRating = 0;
        public int SpellCritRating
        {
            get { return _spellCritRating; }
            set { _spellCritRating = value; }
        }
        public double SpellCritPercent
        {
            get { return (double)_spellCritRating / 2208; }
            set { _spellCritRating = (int)((double)value * 2208); }
        }

        private int _playerTotalMana = 0;
        public int PlayerTotalMana
        {
            get { return _playerTotalMana; }
            set { _playerTotalMana = value; }
        }

        private int _playerCurrentMana = 0;
        public int PlayerCurrentMana
        {
            get { return _playerCurrentMana; }
            set { _playerCurrentMana = Math.Max(Math.Min(value, _playerTotalMana), 0); }
        }

        private double _reactionTime = 0.02;
        public double ReactionTime
        {
            get { return _reactionTime; }
            set { _reactionTime = value; }
        }

        public double PlayerPercentageMana
        {
            get { return (double)100 * ((double)_playerCurrentMana / (double)_playerTotalMana); }
            set { _playerCurrentMana = (int)(_playerTotalMana * (Math.Max(Math.Min(value, 100), 0) / (double)100)); }
        }

        private int _mp5Casting = 0;
        public int MP5Casting
        {
            get { return _mp5Casting; }
            set { _mp5Casting = value; }
        }

        public int MP2Casting
        {
            get { return (int)((double)_mp5Casting * 2.0 / 5.0); }
        }

        private int _mp5NotCasting = 0;
        public int MP5NotCasting
        {
            get { return _mp5NotCasting; }
            set { _mp5NotCasting = value; }
        }

        public int MP2NotCasting
        {
            get { return (int)((double)_mp5NotCasting * 2.0 / 5.0); }
        }

        // Constructor
        internal PlayerStats()
        {
        }

    }
}
