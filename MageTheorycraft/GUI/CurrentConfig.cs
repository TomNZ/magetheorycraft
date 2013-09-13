using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.GUI
{
    class CurrentConfig
    {
        private CurrentConfig()
        {
            // Prevent instantiation
        }

        public enum CasterType
        {
            FireBasic,
            FrostBasic,
            ArcaneAMSpam
        }

        // Stats
        public static int HitPoints = 8000;
        public static int Mana = 8000;

        public static int BonusDamage = 1100;
        public static int HitRating = 164;
        public static double CritChance = 22;
        public static int MP5Casting = 150;
        public static int MP5NotCasting = 0;
        public static int HasteRating = 50;
        public static CasterType Caster = CasterType.FireBasic;

        // Trinkets
        public static bool QuagmirransEye = false;
        public static bool DarkmoonWrath = false;
        public static bool DarkmoonCrusade = false;

        // Gear sets
        public static bool SpellstrikeSet = false;
        public static bool T5Set4 = false;

        // Specs
        public static int SpecArcFocus = 0;
        public static int SpecWand = 0;
        public static int SpecArcConc = 0;
        public static int SpecArcImpact = 0;
        public static int SpecArcMeditation = 0;
        public static int SpecPoM = 0;
        public static int SpecArcInstability = 0;
        public static int SpecArcPotency = 0;
        public static int SpecEmpoweredAM = 0;
        public static int SpecArcPower = 0;
        public static int SpecSpellPower = 0;

        public static int SpecImpFireball = 5;
        public static int SpecIgnite = 5;
        public static int SpecIncinerate = 2;
        public static int SpecImpScorch = 3;
        public static int SpecMasterOfElements = 3;
        public static int SpecPlayingWithFire = 3;
        public static int SpecCriticalMass = 3;
        public static int SpecFirePower = 5;
        public static int SpecPyromaniac = 3;
        public static int SpecCombustion = 1;
        public static int SpecMoltenFury = 2;
        public static int SpecEmpoweredFireball = 5;

        public static int SpecImpFrostbolt = 5;
        public static int SpecElementalPrecision = 3;
        public static int SpecIceShards = 0;
        public static int SpecFrostbite = 0;
        public static int SpecImpFrostNova = 2;
        public static int SpecPiercingIce = 0;
        public static int SpecIcyVeins = 1;
        public static int SpecFrostChanneling = 0;
        public static int SpecShatter = 0;
        public static int SpecColdSnap = 0;
        public static int SpecIceFloes = 0;
        public static int SpecWintersChill = 0;
        public static int SpecArcticWinds = 0;
        public static int SpecEmpoweredFrostbolt = 0;
        public static int SpecWaterElemental = 0;

        // Fight properties
        public static double FightLength = 300;
        public static double ReactionTime = 0.02;
        public static int ManaRegen = 100;

        // Wand
        public static int MinWandDamage = 165;
        public static int MaxWandDamage = 300;
        public static double WandSpeed = 1.5;
    }
}
