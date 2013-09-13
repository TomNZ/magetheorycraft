using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft
{
    public class Config
    {
        public enum CasterType
        {
            FireBasic,
            FrostBasic,
            ArcaneAMSpam
        }

        // Stats
        public int HitPoints = 8000;
        public int Mana = 8000;

        public int BonusDamage = 1100;
        public int HitRating = 164;
        public double CritChance = 22;
        public int MP5Casting = 150;
        public int MP5NotCasting = 0;
        public int HasteRating = 50;
        public CasterType Caster = CasterType.FireBasic;

        // Trinkets
        public bool QuagmirransEye = false;
        public bool DarkmoonWrath = false;
        public bool DarkmoonCrusade = false;

        // Gear sets
        public bool SpellstrikeSet = false;
        public bool T5Set4 = false;

        // Specs
        public int SpecArcFocus = 0;
        public int SpecWand = 0;
        public int SpecArcConc = 0;
        public int SpecArcImpact = 0;
        public int SpecArcMeditation = 0;
        public int SpecPresenceOfMind = 0;
        public int SpecArcInstability = 0;
        public int SpecArcPotency = 0;
        public int SpecEmpoweredAM = 0;
        public int SpecArcPower = 0;
        public int SpecSpellPower = 0;

        public int SpecImpFireball = 5;
        public int SpecIgnite = 5;
        public int SpecIncinerate = 2;
        public int SpecImpScorch = 3;
        public int SpecMasterOfElements = 3;
        public int SpecPlayingWithFire = 3;
        public int SpecCriticalMass = 3;
        public int SpecFirePower = 5;
        public int SpecPyromaniac = 3;
        public int SpecCombustion = 1;
        public int SpecMoltenFury = 2;
        public int SpecEmpoweredFireball = 5;

        public int SpecImpFrostbolt = 5;
        public int SpecElementalPrecision = 3;
        public int SpecIceShards = 0;
        public int SpecFrostbite = 0;
        public int SpecImpFrostNova = 2;
        public int SpecPiercingIce = 0;
        public int SpecIcyVeins = 1;
        public int SpecFrostChanneling = 0;
        public int SpecShatter = 0;
        public int SpecColdSnap = 0;
        public int SpecIceFloes = 0;
        public int SpecWintersChill = 0;
        public int SpecArcticWinds = 0;
        public int SpecEmpoweredFrostbolt = 0;
        public int SpecWaterElemental = 0;

        // Fight properties
        public double FightLength = 300;
        public double ReactionTime = 0.02;
        public int ManaRegen = 150;
        public double MoltenFuryActiveTime = 0.16;

        // Wand
        public int MinWandDamage = 165;
        public int MaxWandDamage = 300;
        public double WandSpeed = 1.5;
    }
}
