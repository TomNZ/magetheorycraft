using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MageTalentSelector
{
    public partial class MageTalents : UserControl
    {
        // Arcane
        public int SpecArcFocus
        {
            get { return toInt(txtSpecArcFocus.Text);}
            set { txtSpecArcFocus.Text = value.ToString(); }
        }
        public int SpecWand
        {
            get { return toInt(txtSpecWand.Text); }
            set { txtSpecWand.Text = value.ToString(); }
        }
        public int SpecArcConc
        {
            get { return toInt(txtSpecArcConc.Text); }
            set { txtSpecArcConc.Text = value.ToString(); }
        }
        public int SpecArcImpact
        {
            get { return toInt(txtSpecArcImpact.Text); }
            set { txtSpecArcImpact.Text = value.ToString(); }
        }
        public int SpecArcMeditation
        {
            get { return toInt(txtSpecArcMeditation.Text); }
            set { txtSpecArcMeditation.Text = value.ToString(); }
        }
        public int SpecPoM
        {
            get { return toInt(txtSpecPoM.Text); }
            set { txtSpecPoM.Text = value.ToString(); }
        }
        public int SpecArcInstability
        {
            get { return toInt(txtSpecArcInstability.Text); }
            set { txtSpecArcInstability.Text = value.ToString(); }
        }
        public int SpecArcPotency
        {
            get { return toInt(txtSpecArcPotency.Text); }
            set { txtSpecArcPotency.Text = value.ToString(); }
        }
        public int SpecEmpoweredAM
        {
            get { return toInt(txtSpecEmpoweredAM.Text); }
            set { txtSpecEmpoweredAM.Text = value.ToString(); }
        }
        public int SpecArcPower
        {
            get { return toInt(txtSpecArcPower.Text); }
            set { txtSpecArcPower.Text = value.ToString(); }
        }
        public int SpecSpellPower
        {
            get { return toInt(txtSpecSpellPower.Text); }
            set { txtSpecSpellPower.Text = value.ToString(); }
        }

        // Fire
        public int SpecImpFireball
        {
            get { return toInt(txtSpecImpFireball.Text); }
            set { txtSpecImpFireball.Text = value.ToString(); }
        }
        public int SpecIgnite
        {
            get { return toInt(txtSpecIgnite.Text); }
            set { txtSpecIgnite.Text = value.ToString(); }
        }
        public int SpecIncinerate
        {
            get { return toInt(txtSpecIncinerate.Text); }
            set { txtSpecIncinerate.Text = value.ToString(); }
        }
        public int SpecImpScorch
        {
            get { return toInt(txtSpecImpScorch.Text); }
            set { txtSpecImpScorch.Text = value.ToString(); }
        }
        public int SpecMasterOfElements
        {
            get { return toInt(txtSpecMasterOfElements.Text); }
            set { txtSpecMasterOfElements.Text = value.ToString(); }
        }
        public int SpecPlayingWithFire
        {
            get { return toInt(txtSpecPlayingWithFire.Text); }
            set { txtSpecPlayingWithFire.Text = value.ToString(); }
        }
        public int SpecCriticalMass
        {
            get { return toInt(txtSpecCriticalMass.Text); }
            set { txtSpecCriticalMass.Text = value.ToString(); }
        }
        public int SpecFirePower
        {
            get { return toInt(txtSpecFirePower.Text); }
            set { txtSpecFirePower.Text = value.ToString(); }
        }
        public int SpecPyromaniac
        {
            get { return toInt(txtSpecPyromaniac.Text); }
            set { txtSpecPyromaniac.Text = value.ToString(); }
        }
        public int SpecCombustion
        {
            get { return toInt(txtSpecCombustion.Text); }
            set { txtSpecCombustion.Text = value.ToString(); }
        }
        public int SpecMoltenFury
        {
            get { return toInt(txtSpecMoltenFury.Text); }
            set { txtSpecMoltenFury.Text = value.ToString(); }
        }
        public int SpecEmpoweredFireball
        {
            get { return toInt(txtSpecEmpoweredFireball.Text); }
            set { txtSpecEmpoweredFireball.Text = value.ToString(); }
        }

        // Frost
        public int SpecImpFrostbolt
        {
            get { return toInt(txtSpecImpFrostbolt.Text); }
            set { txtSpecImpFrostbolt.Text = value.ToString(); }
        }
        public int SpecElementalPrecision
        {
            get { return toInt(txtSpecElementalPrecision.Text); }
            set { txtSpecElementalPrecision.Text = value.ToString(); }
        }
        public int SpecIceShards
        {
            get { return toInt(txtSpecIceShards.Text); }
            set { txtSpecIceShards.Text = value.ToString(); }
        }
        public int SpecFrostbite
        {
            get { return toInt(txtSpecFrostbite.Text); }
            set { txtSpecFrostbite.Text = value.ToString(); }
        }
        public int SpecPiercingIce
        {
            get { return toInt(txtSpecPiercingIce.Text); }
            set { txtSpecPiercingIce.Text = value.ToString(); }
        }
        public int SpecIcyVeins
        {
            get { return toInt(txtSpecIcyVeins.Text); }
            set { txtSpecIcyVeins.Text = value.ToString(); }
        }
        public int SpecFrostChanneling
        {
            get { return toInt(txtSpecFrostChanneling.Text); }
            set { txtSpecFrostChanneling.Text = value.ToString(); }
        }
        public int SpecShatter
        {
            get { return toInt(txtSpecShatter.Text); }
            set { txtSpecShatter.Text = value.ToString(); }
        }
        public int SpecColdSnap
        {
            get { return toInt(txtSpecColdSnap.Text); }
            set { txtSpecColdSnap.Text = value.ToString(); }
        }
        public int SpecIceFloes
        {
            get { return toInt(txtSpecIceFloes.Text); }
            set { txtSpecIceFloes.Text = value.ToString(); }
        }
        public int SpecWintersChill
        {
            get { return toInt(txtSpecWintersChill.Text); }
            set { txtSpecWintersChill.Text = value.ToString(); }
        }
        public int SpecArcticWinds
        {
            get { return toInt(txtSpecArcticWinds.Text); }
            set { txtSpecArcticWinds.Text = value.ToString(); }
        }
        public int SpecEmpoweredFrostbolt
        {
            get { return toInt(txtSpecEmpoweredFrostbolt.Text); }
            set { txtSpecEmpoweredFrostbolt.Text = value.ToString(); }
        }
        public int SpecWaterElemental
        {
            get { return toInt(txtSpecWaterElemental.Text); }
            set { txtSpecWaterElemental.Text = value.ToString(); }
        }

        public MageTalents()
        {
            InitializeComponent();
        }

        private int toInt(string input)
        {
            int result;
            if (int.TryParse(input, out result))
                return result;

            return 0;
        }

    }
}