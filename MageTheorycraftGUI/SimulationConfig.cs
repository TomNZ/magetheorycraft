using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MageTheorycraft;

namespace MageTheorycraftGUI
{
    public partial class SimulationConfig : Form
    {
        private Config _config;
        public Config Config
        {
            get { return _config; }
            set { _config = value; }
        }

        public SimulationConfig()
        {
            InitializeComponent();
            _config = new Config();
        }

        private void cmbSpecSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fill in a cookie cutter spec
            switch (cmbSpecSelect.SelectedIndex)
            {
                case 0:
                    {
                        // 2/48/11
                        FillSpec(";;;;;;;;;;;5;5;2;3;3;3;3;5;3;1;2;5;5;3;;;;1;;;;;;;;");
                    } break;
                case 1:
                    {
                        // 10/48/3
                        FillSpec("2;;5;;;;;;;;;5;5;2;3;3;3;3;5;3;1;2;5;;3;;;;;;;;;;;;");
                    } break;
            }
        }

        private void FillSpec(string spec)
        {
            string[] s = spec.Split(new char[] { ';' }, StringSplitOptions.None);
            if (s.Length != 37)
                return;

            talents.SpecArcFocus = toInt(s[0]);
            talents.SpecWand = toInt(s[1]);
            talents.SpecArcConc = toInt(s[2]);
            talents.SpecArcImpact = toInt(s[3]);
            talents.SpecArcMeditation = toInt(s[4]);
            talents.SpecPoM = toInt(s[5]);
            talents.SpecArcInstability = toInt(s[6]);
            talents.SpecArcPotency = toInt(s[7]);
            talents.SpecEmpoweredAM = toInt(s[8]);
            talents.SpecArcPower = toInt(s[9]);
            talents.SpecSpellPower = toInt(s[10]);

            talents.SpecImpFireball = toInt(s[11]);
            talents.SpecIgnite = toInt(s[12]);
            talents.SpecIncinerate = toInt(s[13]);
            talents.SpecImpScorch = toInt(s[14]);
            talents.SpecMasterOfElements = toInt(s[15]);
            talents.SpecPlayingWithFire = toInt(s[16]);
            talents.SpecCriticalMass = toInt(s[17]);
            talents.SpecFirePower = toInt(s[18]);
            talents.SpecPyromaniac = toInt(s[19]);
            talents.SpecCombustion = toInt(s[20]);
            talents.SpecMoltenFury = toInt(s[21]);
            talents.SpecEmpoweredFireball = toInt(s[22]);

            talents.SpecImpFrostbolt = toInt(s[23]);
            talents.SpecElementalPrecision = toInt(s[24]);
            talents.SpecIceShards = toInt(s[25]);
            talents.SpecFrostbite = toInt(s[26]);
            talents.SpecPiercingIce = toInt(s[27]);
            talents.SpecIcyVeins = toInt(s[28]);
            talents.SpecFrostChanneling = toInt(s[29]);
            talents.SpecShatter = toInt(s[30]);
            talents.SpecColdSnap = toInt(s[31]);
            talents.SpecIceFloes = toInt(s[32]);
            talents.SpecWintersChill = toInt(s[33]);
            talents.SpecArcticWinds = toInt(s[34]);
            talents.SpecEmpoweredFrostbolt = toInt(s[35]);
            talents.SpecWaterElemental = toInt(s[36]);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SimulationConfigGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            _config.HitPoints = toInt(txtHitpoints.Text);
            _config.Mana = toInt(txtMana.Text);

            _config.Caster = (Config.CasterType)cmbCasterType.SelectedIndex;
            _config.BonusDamage = toInt(txtBonusDamage.Text);
            _config.HitRating = toInt(txtHitRating.Text);
            _config.CritChance = toDouble(txtCritPercent.Text);
            _config.MP5Casting = toInt(txtMP5NotCasting.Text);
            _config.MP5NotCasting = toInt(txtMP5Casting.Text);
            _config.HasteRating = toInt(txtHasteRating.Text);

            // Trinkets
            _config.DarkmoonCrusade = selTrinkets.CheckedIndices.Contains(0);
            _config.DarkmoonWrath = selTrinkets.CheckedIndices.Contains(1);
            _config.QuagmirransEye = selTrinkets.CheckedIndices.Contains(2);

            // Gear sets
            _config.SpellstrikeSet = selSetBonuses.CheckedIndices.Contains(0);
            _config.T5Set4 = selSetBonuses.CheckedIndices.Contains(1);

            // Specs

            _config.SpecArcFocus = talents.SpecArcFocus;
            _config.SpecWand = talents.SpecWand;
            _config.SpecArcConc = talents.SpecArcConc;
            _config.SpecArcImpact = talents.SpecArcImpact;
            _config.SpecArcMeditation = talents.SpecArcMeditation;
            _config.SpecPresenceOfMind = talents.SpecPoM;
            _config.SpecArcInstability = talents.SpecArcInstability;
            _config.SpecArcPotency = talents.SpecArcPotency;
            _config.SpecEmpoweredAM = talents.SpecEmpoweredAM;
            _config.SpecArcPower = talents.SpecArcPower;
            _config.SpecSpellPower = talents.SpecSpellPower;

            _config.SpecImpFireball = talents.SpecImpFireball;
            _config.SpecIgnite = talents.SpecIgnite;
            _config.SpecIncinerate = talents.SpecIncinerate;
            _config.SpecImpScorch = talents.SpecImpScorch;
            _config.SpecMasterOfElements = talents.SpecMasterOfElements;
            _config.SpecPlayingWithFire = talents.SpecPlayingWithFire;
            _config.SpecCriticalMass = talents.SpecCriticalMass;
            _config.SpecFirePower = talents.SpecFirePower;
            _config.SpecPyromaniac = talents.SpecPyromaniac;
            _config.SpecCombustion = talents.SpecCombustion;
            _config.SpecMoltenFury = talents.SpecMoltenFury;
            _config.SpecEmpoweredFireball = talents.SpecEmpoweredFireball;

            _config.SpecImpFrostbolt = talents.SpecImpFrostbolt;
            _config.SpecElementalPrecision = talents.SpecElementalPrecision;
            _config.SpecIceShards = talents.SpecIceShards;
            _config.SpecFrostbite = talents.SpecFrostbite;
            _config.SpecPiercingIce = talents.SpecPiercingIce;
            _config.SpecIcyVeins = talents.SpecIcyVeins;
            _config.SpecFrostChanneling = talents.SpecFrostChanneling;
            _config.SpecShatter = talents.SpecShatter;
            _config.SpecColdSnap = talents.SpecColdSnap;
            _config.SpecIceFloes = talents.SpecIceFloes;
            _config.SpecWintersChill = talents.SpecWintersChill;
            _config.SpecArcticWinds = talents.SpecArcticWinds;
            _config.SpecEmpoweredFrostbolt = talents.SpecEmpoweredFrostbolt;
            _config.SpecWaterElemental = talents.SpecWaterElemental;

            // Fight properties
            _config.FightLength = toDouble(txtFightLength.Text);
            if (toDouble(txtReactionTime.Text) < 0.01)
                txtReactionTime.Text = "0.01";
            _config.ReactionTime = toDouble(txtReactionTime.Text);
            _config.ManaRegen = toInt(txtManaRegen.Text);
            _config.MoltenFuryActiveTime = toDouble(txtMoltenFuryActiveTime.Text);

            // Wand
            _config.MinWandDamage = toInt(txtMinWandDamage.Text);
            _config.MaxWandDamage = toInt(txtMaxWandDamage.Text);
            _config.WandSpeed = toDouble(txtWandSpeed.Text);
        }

        private void LoadSettings()
        {
            txtHitpoints.Text = _config.HitPoints.ToString();
            txtMana.Text = _config.Mana.ToString();

            cmbCasterType.SelectedIndex = (int)_config.Caster;
            txtBonusDamage.Text = _config.BonusDamage.ToString();
            txtHitRating.Text = _config.HitRating.ToString();
            txtCritPercent.Text = _config.CritChance.ToString();
            txtMP5NotCasting.Text = _config.MP5Casting.ToString();
            txtMP5Casting.Text = _config.MP5NotCasting.ToString();
            txtHasteRating.Text = _config.HasteRating.ToString();

            // Trinkets
            selTrinkets.SetItemChecked(0, _config.DarkmoonCrusade);
            selTrinkets.SetItemChecked(1, _config.DarkmoonWrath);
            selTrinkets.SetItemChecked(2, _config.QuagmirransEye);

            // Gear sets
            selSetBonuses.SetItemChecked(0, _config.SpellstrikeSet);
            selSetBonuses.SetItemChecked(1, _config.T5Set4);

            // Specs
            talents.SpecArcFocus = _config.SpecArcFocus;
            talents.SpecWand = _config.SpecWand;
            talents.SpecArcConc = _config.SpecArcConc;
            talents.SpecArcImpact = _config.SpecArcImpact;
            talents.SpecArcMeditation = _config.SpecArcMeditation;
            talents.SpecPoM = _config.SpecPresenceOfMind;
            talents.SpecArcInstability = _config.SpecArcInstability;
            talents.SpecArcPotency = _config.SpecArcPotency;
            talents.SpecEmpoweredAM = _config.SpecEmpoweredAM;
            talents.SpecArcPower = _config.SpecArcPower;
            talents.SpecSpellPower = _config.SpecSpellPower;

            talents.SpecImpFireball = _config.SpecImpFireball;
            talents.SpecIgnite = _config.SpecIgnite;
            talents.SpecIncinerate = _config.SpecIncinerate;
            talents.SpecImpScorch = _config.SpecImpScorch;
            talents.SpecMasterOfElements = _config.SpecMasterOfElements;
            talents.SpecPlayingWithFire = _config.SpecPlayingWithFire;
            talents.SpecCriticalMass = _config.SpecCriticalMass;
            talents.SpecFirePower = _config.SpecFirePower;
            talents.SpecPyromaniac = _config.SpecPyromaniac;
            talents.SpecCombustion = _config.SpecCombustion;
            talents.SpecMoltenFury = _config.SpecMoltenFury;
            talents.SpecEmpoweredFireball = _config.SpecEmpoweredFireball;

            talents.SpecImpFrostbolt = _config.SpecImpFrostbolt;
            talents.SpecElementalPrecision = _config.SpecElementalPrecision;
            talents.SpecIceShards = _config.SpecIceShards;
            talents.SpecFrostbite = _config.SpecFrostbite;
            talents.SpecPiercingIce = _config.SpecPiercingIce;
            talents.SpecIcyVeins = _config.SpecIcyVeins;
            talents.SpecFrostChanneling = _config.SpecFrostChanneling;
            talents.SpecShatter = _config.SpecShatter;
            talents.SpecColdSnap = _config.SpecColdSnap;
            talents.SpecIceFloes = _config.SpecIceFloes;
            talents.SpecWintersChill = _config.SpecWintersChill;
            talents.SpecArcticWinds = _config.SpecArcticWinds;
            talents.SpecEmpoweredFrostbolt = _config.SpecEmpoweredFrostbolt;
            talents.SpecWaterElemental = _config.SpecWaterElemental;

            // Fight properties
            txtFightLength.Text = _config.FightLength.ToString();
            txtReactionTime.Text = _config.ReactionTime.ToString();
            txtManaRegen.Text = _config.ManaRegen.ToString();
            txtMoltenFuryActiveTime.Text = _config.MoltenFuryActiveTime.ToString();

            // Wand
            txtMinWandDamage.Text = _config.MinWandDamage.ToString();
            txtMaxWandDamage.Text = _config.MaxWandDamage.ToString();
            txtWandSpeed.Text = _config.WandSpeed.ToString();
        }

        private int toInt(string input)
        {
            int result;
            if (int.TryParse(input, out result))
                return result;

            return 0;
        }

        private double toDouble(string input)
        {
            double result;
            if (double.TryParse(input, out result))
                return result;

            return 0;
        }

        private string toStringNonZero(int input)
        {
            if (input == 0)
                return "";

            return input.ToString();
        }

        private void SimulationConfig_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
    }
}