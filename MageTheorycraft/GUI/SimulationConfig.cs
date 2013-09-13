using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MageTheorycraft.GUI
{
    public partial class SimulationConfig : Form
    {
        public SimulationConfig()
        {
            InitializeComponent();
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

            txtSpecArcFocus.Text = s[0];
            txtSpecWand.Text = s[1];
            txtSpecArcConc.Text = s[2];
            txtSpecArcImpact.Text = s[3];
            txtSpecArcMeditation.Text = s[4];
            txtSpecPoM.Text = s[5];
            txtSpecArcInstability.Text = s[6];
            txtSpecArcPotency.Text = s[7];
            txtSpecEmpoweredAM.Text = s[8];
            txtSpecArcPower.Text = s[9];
            txtSpecSpellPower.Text = s[10];

            txtSpecImpFireball.Text = s[11];
            txtSpecIgnite.Text = s[12];
            txtSpecIncinerate.Text = s[13];
            txtSpecImpScorch.Text = s[14];
            txtSpecMasterOfElements.Text = s[15];
            txtSpecPlayingWithFire.Text = s[16];
            txtSpecCriticalMass.Text = s[17];
            txtSpecFirePower.Text = s[18];
            txtSpecPyromaniac.Text = s[19];
            txtSpecCombustion.Text = s[20];
            txtSpecMoltenFury.Text = s[21];
            txtSpecEmpoweredFireball.Text = s[22];

            txtSpecImpFrostbolt.Text = s[23];
            txtSpecElementalPrecision.Text = s[24];
            txtSpecIceShards.Text = s[25];
            txtSpecFrostbite.Text = s[26];
            txtSpecPiercingIce.Text = s[27];
            txtSpecIcyVeins.Text = s[28];
            txtSpecFrostChanneling.Text = s[29];
            txtSpecShatter.Text = s[30];
            txtSpecColdSnap.Text = s[31];
            txtSpecIceFloes.Text = s[32];
            txtSpecWintersChill.Text = s[33];
            txtSpecArcticWinds.Text = s[34];
            txtSpecEmpoweredFrostbolt.Text = s[35];
            txtSpecWaterElemental.Text = s[36];
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
            CurrentConfig.HitPoints = toInt(txtHitpoints.Text);
            CurrentConfig.Mana = toInt(txtMana.Text);

            CurrentConfig.Caster = (CurrentConfig.CasterType)cmbCasterType.SelectedIndex;
            CurrentConfig.BonusDamage = toInt(txtBonusDamage.Text);
            CurrentConfig.HitRating = toInt(txtHitRating.Text);
            CurrentConfig.CritChance = toDouble(txtCritPercent.Text);
            CurrentConfig.MP5Casting = toInt(txtMP5NotCasting.Text);
            CurrentConfig.MP5NotCasting = toInt(txtMP5Casting.Text);
            CurrentConfig.HasteRating = toInt(txtHasteRating.Text);

            // Trinkets
            CurrentConfig.DarkmoonCrusade = selTrinkets.CheckedIndices.Contains(0);
            CurrentConfig.DarkmoonWrath = selTrinkets.CheckedIndices.Contains(1);
            CurrentConfig.QuagmirransEye = selTrinkets.CheckedIndices.Contains(2);

            // Gear sets
            CurrentConfig.SpellstrikeSet = selSetBonuses.CheckedIndices.Contains(0);
            CurrentConfig.T5Set4 = selSetBonuses.CheckedIndices.Contains(1);

            // Specs

            CurrentConfig.SpecArcFocus = toInt(txtSpecArcFocus.Text);
            CurrentConfig.SpecWand = toInt(txtSpecWand.Text);
            CurrentConfig.SpecArcConc = toInt(txtSpecArcConc.Text);
            CurrentConfig.SpecArcImpact = toInt(txtSpecArcImpact.Text);
            CurrentConfig.SpecArcMeditation = toInt(txtSpecArcMeditation.Text);
            CurrentConfig.SpecPoM = toInt(txtSpecPoM.Text);
            CurrentConfig.SpecArcInstability = toInt(txtSpecArcInstability.Text);
            CurrentConfig.SpecArcPotency = toInt(txtSpecArcPotency.Text);
            CurrentConfig.SpecEmpoweredAM = toInt(txtSpecEmpoweredAM.Text);
            CurrentConfig.SpecArcPower = toInt(txtSpecArcPower.Text);
            CurrentConfig.SpecSpellPower = toInt(txtSpecSpellPower.Text);

            CurrentConfig.SpecImpFireball = toInt(txtSpecImpFireball.Text);
            CurrentConfig.SpecIgnite = toInt(txtSpecIgnite.Text);
            CurrentConfig.SpecIncinerate = toInt(txtSpecIncinerate.Text);
            CurrentConfig.SpecImpScorch = toInt(txtSpecImpScorch.Text);
            CurrentConfig.SpecMasterOfElements = toInt(txtSpecMasterOfElements.Text);
            CurrentConfig.SpecPlayingWithFire = toInt(txtSpecPlayingWithFire.Text);
            CurrentConfig.SpecCriticalMass = toInt(txtSpecCriticalMass.Text);
            CurrentConfig.SpecFirePower = toInt(txtSpecFirePower.Text);
            CurrentConfig.SpecPyromaniac = toInt(txtSpecPyromaniac.Text);
            CurrentConfig.SpecCombustion = toInt(txtSpecCombustion.Text);
            CurrentConfig.SpecMoltenFury = toInt(txtSpecMoltenFury.Text);
            CurrentConfig.SpecEmpoweredFireball = toInt(txtSpecEmpoweredFireball.Text);

            CurrentConfig.SpecImpFrostbolt = toInt(txtSpecImpFrostbolt.Text);
            CurrentConfig.SpecElementalPrecision = toInt(txtSpecElementalPrecision.Text);
            CurrentConfig.SpecIceShards = toInt(txtSpecIceShards.Text);
            CurrentConfig.SpecFrostbite = toInt(txtSpecFrostbite.Text);
            CurrentConfig.SpecPiercingIce = toInt(txtSpecPiercingIce.Text);
            CurrentConfig.SpecIcyVeins = toInt(txtSpecIcyVeins.Text);
            CurrentConfig.SpecFrostChanneling = toInt(txtSpecFrostChanneling.Text);
            CurrentConfig.SpecShatter = toInt(txtSpecShatter.Text);
            CurrentConfig.SpecColdSnap = toInt(txtSpecColdSnap.Text);
            CurrentConfig.SpecIceFloes = toInt(txtSpecIceFloes.Text);
            CurrentConfig.SpecWintersChill = toInt(txtSpecWintersChill.Text);
            CurrentConfig.SpecArcticWinds = toInt(txtSpecArcticWinds.Text);
            CurrentConfig.SpecEmpoweredFrostbolt = toInt(txtSpecEmpoweredFrostbolt.Text);
            CurrentConfig.SpecWaterElemental = toInt(txtSpecWaterElemental.Text);

            // Fight properties
            CurrentConfig.FightLength = toDouble(txtFightLength.Text);
            if (toDouble(txtReactionTime.Text) < 0.01)
                txtReactionTime.Text = "0.01";
            CurrentConfig.ReactionTime = toDouble(txtReactionTime.Text);
            CurrentConfig.ManaRegen = toInt(txtManaRegen.Text);

            // Wand
            CurrentConfig.MinWandDamage = toInt(txtMinWandDamage.Text);
            CurrentConfig.MaxWandDamage = toInt(txtMaxWandDamage.Text);
            CurrentConfig.WandSpeed = toDouble(txtWandSpeed.Text);
        }

        private void LoadSettings()
        {
            txtHitpoints.Text = CurrentConfig.HitPoints.ToString();
            txtMana.Text = CurrentConfig.Mana.ToString();

            cmbCasterType.SelectedIndex = (int)CurrentConfig.Caster;
            txtBonusDamage.Text = CurrentConfig.BonusDamage.ToString();
            txtHitRating.Text = CurrentConfig.HitRating.ToString();
            txtCritPercent.Text = CurrentConfig.CritChance.ToString();
            txtMP5NotCasting.Text = CurrentConfig.MP5Casting.ToString();
            txtMP5Casting.Text = CurrentConfig.MP5NotCasting.ToString();
            txtHasteRating.Text = CurrentConfig.HasteRating.ToString();

            // Trinkets
            selTrinkets.SetItemChecked(0, CurrentConfig.DarkmoonCrusade);
            selTrinkets.SetItemChecked(1, CurrentConfig.DarkmoonWrath);
            selTrinkets.SetItemChecked(2, CurrentConfig.QuagmirransEye);

            // Gear sets
            selSetBonuses.SetItemChecked(0, CurrentConfig.SpellstrikeSet);
            selSetBonuses.SetItemChecked(1, CurrentConfig.T5Set4);

            // Specs
            txtSpecArcFocus.Text = toStringNonZero(CurrentConfig.SpecArcFocus);
            txtSpecWand.Text = toStringNonZero(CurrentConfig.SpecWand);
            txtSpecArcConc.Text = toStringNonZero(CurrentConfig.SpecArcConc);
            txtSpecArcImpact.Text = toStringNonZero(CurrentConfig.SpecArcImpact);
            txtSpecArcMeditation.Text = toStringNonZero(CurrentConfig.SpecArcMeditation);
            txtSpecPoM.Text = toStringNonZero(CurrentConfig.SpecPoM);
            txtSpecArcInstability.Text = toStringNonZero(CurrentConfig.SpecArcInstability);
            txtSpecArcPotency.Text = toStringNonZero(CurrentConfig.SpecArcPotency);
            txtSpecEmpoweredAM.Text = toStringNonZero(CurrentConfig.SpecEmpoweredAM);
            txtSpecArcPower.Text = toStringNonZero(CurrentConfig.SpecArcPower);
            txtSpecSpellPower.Text = toStringNonZero(CurrentConfig.SpecSpellPower);

            txtSpecImpFireball.Text = toStringNonZero(CurrentConfig.SpecImpFireball);
            txtSpecIgnite.Text = toStringNonZero(CurrentConfig.SpecIgnite);
            txtSpecIncinerate.Text = toStringNonZero(CurrentConfig.SpecIncinerate);
            txtSpecImpScorch.Text = toStringNonZero(CurrentConfig.SpecImpScorch);
            txtSpecMasterOfElements.Text = toStringNonZero(CurrentConfig.SpecMasterOfElements);
            txtSpecPlayingWithFire.Text = toStringNonZero(CurrentConfig.SpecPlayingWithFire);
            txtSpecCriticalMass.Text = toStringNonZero(CurrentConfig.SpecCriticalMass);
            txtSpecFirePower.Text = toStringNonZero(CurrentConfig.SpecFirePower);
            txtSpecPyromaniac.Text = toStringNonZero(CurrentConfig.SpecPyromaniac);
            txtSpecCombustion.Text = toStringNonZero(CurrentConfig.SpecCombustion);
            txtSpecMoltenFury.Text = toStringNonZero(CurrentConfig.SpecMoltenFury);
            txtSpecEmpoweredFireball.Text = toStringNonZero(CurrentConfig.SpecEmpoweredFireball);

            txtSpecImpFrostbolt.Text = toStringNonZero(CurrentConfig.SpecImpFrostbolt);
            txtSpecElementalPrecision.Text = toStringNonZero(CurrentConfig.SpecElementalPrecision);
            txtSpecIceShards.Text = toStringNonZero(CurrentConfig.SpecIceShards);
            txtSpecFrostbite.Text = toStringNonZero(CurrentConfig.SpecFrostbite);
            txtSpecPiercingIce.Text = toStringNonZero(CurrentConfig.SpecPiercingIce);
            txtSpecIcyVeins.Text = toStringNonZero(CurrentConfig.SpecIcyVeins);
            txtSpecFrostChanneling.Text = toStringNonZero(CurrentConfig.SpecFrostChanneling);
            txtSpecShatter.Text = toStringNonZero(CurrentConfig.SpecShatter);
            txtSpecColdSnap.Text = toStringNonZero(CurrentConfig.SpecColdSnap);
            txtSpecIceFloes.Text = toStringNonZero(CurrentConfig.SpecIceFloes);
            txtSpecWintersChill.Text = toStringNonZero(CurrentConfig.SpecWintersChill);
            txtSpecArcticWinds.Text = toStringNonZero(CurrentConfig.SpecArcticWinds);
            txtSpecEmpoweredFrostbolt.Text = toStringNonZero(CurrentConfig.SpecEmpoweredFrostbolt);
            txtSpecWaterElemental.Text = toStringNonZero(CurrentConfig.SpecWaterElemental);

            // Fight properties
            txtFightLength.Text = CurrentConfig.FightLength.ToString();
            txtReactionTime.Text = CurrentConfig.ReactionTime.ToString();
            txtManaRegen.Text = CurrentConfig.ManaRegen.ToString();

            // Wand
            txtMinWandDamage.Text = CurrentConfig.MinWandDamage.ToString();
            txtMaxWandDamage.Text = CurrentConfig.MaxWandDamage.ToString();
            txtWandSpeed.Text = CurrentConfig.WandSpeed.ToString();
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