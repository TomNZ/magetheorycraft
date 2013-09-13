namespace MageTheorycraftGUI
{
    partial class SimulationConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationConfig));
            this.cmbConfigSelect = new System.Windows.Forms.ComboBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCasterType = new System.Windows.Forms.ComboBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.txtHasteRating = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMP5Casting = new System.Windows.Forms.TextBox();
            this.txtMP5NotCasting = new System.Windows.Forms.TextBox();
            this.txtCritPercent = new System.Windows.Forms.TextBox();
            this.txtHitRating = new System.Windows.Forms.TextBox();
            this.txtBonusDamage = new System.Windows.Forms.TextBox();
            this.txtMana = new System.Windows.Forms.TextBox();
            this.txtHitpoints = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.help = new System.Windows.Forms.ErrorProvider(this.components);
            this.selTrinkets = new System.Windows.Forms.CheckedListBox();
            this.selSetBonuses = new System.Windows.Forms.CheckedListBox();
            this.cmbSpecSelect = new System.Windows.Forms.ComboBox();
            this.txtFightLength = new System.Windows.Forms.TextBox();
            this.txtManaRegen = new System.Windows.Forms.TextBox();
            this.txtMinWandDamage = new System.Windows.Forms.TextBox();
            this.txtMaxWandDamage = new System.Windows.Forms.TextBox();
            this.txtWandSpeed = new System.Windows.Forms.TextBox();
            this.txtReactionTime = new System.Windows.Forms.TextBox();
            this.txtMoltenFuryActiveTime = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label66 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label91 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.talents = new MageTalentSelector.MageTalents();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.help)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbConfigSelect
            // 
            this.cmbConfigSelect.Enabled = false;
            this.cmbConfigSelect.FormattingEnabled = true;
            this.cmbConfigSelect.Location = new System.Drawing.Point(143, 12);
            this.cmbConfigSelect.Name = "cmbConfigSelect";
            this.cmbConfigSelect.Size = new System.Drawing.Size(172, 21);
            this.cmbConfigSelect.TabIndex = 0;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Enabled = false;
            this.help.SetError(this.btnSaveConfig, "SAVING IS NOT YET IMPLEMENTED!!!");
            this.btnSaveConfig.Location = new System.Drawing.Point(375, 12);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(48, 21);
            this.btnSaveConfig.TabIndex = 2;
            this.btnSaveConfig.Text = "Load";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Enabled = false;
            this.btnLoadConfig.Location = new System.Drawing.Point(321, 12);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(48, 21);
            this.btnLoadConfig.TabIndex = 1;
            this.btnLoadConfig.Text = "Save";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Saved configuration:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCasterType);
            this.groupBox1.Controls.Add(this.label67);
            this.groupBox1.Controls.Add(this.label54);
            this.groupBox1.Controls.Add(this.txtHasteRating);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMP5Casting);
            this.groupBox1.Controls.Add(this.txtMP5NotCasting);
            this.groupBox1.Controls.Add(this.txtCritPercent);
            this.groupBox1.Controls.Add(this.txtHitRating);
            this.groupBox1.Controls.Add(this.txtBonusDamage);
            this.groupBox1.Controls.Add(this.txtMana);
            this.groupBox1.Controls.Add(this.txtHitpoints);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 331);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Stats";
            // 
            // cmbCasterType
            // 
            this.help.SetError(this.cmbCasterType, "This setting determines which AI casting rotation is used.");
            this.cmbCasterType.FormattingEnabled = true;
            this.cmbCasterType.Items.AddRange(new object[] {
            "Fire (Basic)",
            "Frost (Basic)",
            "Arcane (AM Spam)"});
            this.cmbCasterType.Location = new System.Drawing.Point(72, 141);
            this.cmbCasterType.Name = "cmbCasterType";
            this.cmbCasterType.Size = new System.Drawing.Size(107, 21);
            this.cmbCasterType.TabIndex = 23;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(6, 144);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(60, 13);
            this.label67.TabIndex = 22;
            this.label67.Text = "Caster type";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(6, 301);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(69, 13);
            this.label54.TabIndex = 20;
            this.label54.Text = "Haste Rating";
            // 
            // txtHasteRating
            // 
            this.help.SetError(this.txtHasteRating, "Base haste rating from gear only. Do not include temporary effects such as Herois" +
                    "m or Icy Veins.");
            this.txtHasteRating.Location = new System.Drawing.Point(108, 298);
            this.txtHasteRating.Name = "txtHasteRating";
            this.txtHasteRating.Size = new System.Drawing.Size(71, 20);
            this.txtHasteRating.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(201, 31);
            this.label11.TabIndex = 18;
            this.label11.Text = "Most stats can be input as they appear on your armory page.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "For all stats, assume full raid buffs";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "MP5 (casting)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Crit chance";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "MP5 (non-casting)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Hit rating";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Bonus damage";
            // 
            // txtMP5Casting
            // 
            this.txtMP5Casting.Location = new System.Drawing.Point(108, 272);
            this.txtMP5Casting.Name = "txtMP5Casting";
            this.txtMP5Casting.Size = new System.Drawing.Size(71, 20);
            this.txtMP5Casting.TabIndex = 9;
            // 
            // txtMP5NotCasting
            // 
            this.help.SetError(this.txtMP5NotCasting, "Do not include effects such as Mana Spring, or Vampiric Touch.");
            this.txtMP5NotCasting.Location = new System.Drawing.Point(108, 246);
            this.txtMP5NotCasting.Name = "txtMP5NotCasting";
            this.txtMP5NotCasting.Size = new System.Drawing.Size(71, 20);
            this.txtMP5NotCasting.TabIndex = 8;
            // 
            // txtCritPercent
            // 
            this.help.SetError(this.txtCritPercent, "Base (non-fire) crit chance (percent). Include Molten Armor but not talents.");
            this.txtCritPercent.Location = new System.Drawing.Point(108, 220);
            this.txtCritPercent.Name = "txtCritPercent";
            this.txtCritPercent.Size = new System.Drawing.Size(71, 20);
            this.txtCritPercent.TabIndex = 7;
            // 
            // txtHitRating
            // 
            this.help.SetError(this.txtHitRating, "Rating from gear, before talents.");
            this.txtHitRating.Location = new System.Drawing.Point(108, 194);
            this.txtHitRating.Name = "txtHitRating";
            this.txtHitRating.Size = new System.Drawing.Size(71, 20);
            this.txtHitRating.TabIndex = 6;
            // 
            // txtBonusDamage
            // 
            this.help.SetError(this.txtBonusDamage, "Fire/frost/arcane damage based on the caster type you have selected above. Assume" +
                    " food/flasks/oils but not shammy buffs etc.");
            this.txtBonusDamage.Location = new System.Drawing.Point(108, 168);
            this.txtBonusDamage.Name = "txtBonusDamage";
            this.txtBonusDamage.Size = new System.Drawing.Size(71, 20);
            this.txtBonusDamage.TabIndex = 5;
            // 
            // txtMana
            // 
            this.txtMana.Location = new System.Drawing.Point(108, 99);
            this.txtMana.Name = "txtMana";
            this.txtMana.Size = new System.Drawing.Size(71, 20);
            this.txtMana.TabIndex = 4;
            // 
            // txtHitpoints
            // 
            this.txtHitpoints.Location = new System.Drawing.Point(108, 73);
            this.txtHitpoints.Name = "txtHitpoints";
            this.txtHitpoints.Size = new System.Drawing.Size(71, 20);
            this.txtHitpoints.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mana";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hitpoints";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(519, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Note: Be sure to read help text when filling in configuration for the first time!" +
                "";
            // 
            // help
            // 
            this.help.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.help.ContainerControl = this;
            this.help.Icon = ((System.Drawing.Icon)(resources.GetObject("help.Icon")));
            // 
            // selTrinkets
            // 
            this.selTrinkets.CheckOnClick = true;
            this.help.SetError(this.selTrinkets, "Select 2 or less for obvious reasons. Note that only trinkets with some non-trivi" +
                    "al effect are included in this list. Trinkets only offering +dmg or similar will" +
                    " be factored into other stats.");
            this.selTrinkets.FormattingEnabled = true;
            this.selTrinkets.Items.AddRange(new object[] {
            "Darkmoon Card: Crusade",
            "Darkmoon Card: Wrath",
            "Quagmirrans Eye"});
            this.selTrinkets.Location = new System.Drawing.Point(6, 65);
            this.selTrinkets.Name = "selTrinkets";
            this.selTrinkets.Size = new System.Drawing.Size(173, 49);
            this.selTrinkets.TabIndex = 10;
            // 
            // selSetBonuses
            // 
            this.selSetBonuses.CheckOnClick = true;
            this.help.SetError(this.selSetBonuses, "Select all that apply.");
            this.selSetBonuses.FormattingEnabled = true;
            this.selSetBonuses.Items.AddRange(new object[] {
            "Spellstrike (2/2)",
            "Tier 5 (4/5)"});
            this.selSetBonuses.Location = new System.Drawing.Point(6, 133);
            this.selSetBonuses.Name = "selSetBonuses";
            this.selSetBonuses.Size = new System.Drawing.Size(173, 49);
            this.selSetBonuses.TabIndex = 11;
            // 
            // cmbSpecSelect
            // 
            this.help.SetError(this.cmbSpecSelect, "Select a standard spec to fill in the talent tree.");
            this.cmbSpecSelect.FormattingEnabled = true;
            this.cmbSpecSelect.Items.AddRange(new object[] {
            "2/48/11",
            "10/48/3"});
            this.cmbSpecSelect.Location = new System.Drawing.Point(95, 62);
            this.cmbSpecSelect.Name = "cmbSpecSelect";
            this.cmbSpecSelect.Size = new System.Drawing.Size(120, 21);
            this.cmbSpecSelect.TabIndex = 12;
            this.cmbSpecSelect.SelectedIndexChanged += new System.EventHandler(this.cmbSpecSelect_SelectedIndexChanged);
            // 
            // txtFightLength
            // 
            this.help.SetError(this.txtFightLength, "Time in seconds that the simulation should run for.");
            this.txtFightLength.Location = new System.Drawing.Point(101, 24);
            this.txtFightLength.Name = "txtFightLength";
            this.txtFightLength.Size = new System.Drawing.Size(71, 20);
            this.txtFightLength.TabIndex = 29;
            // 
            // txtManaRegen
            // 
            this.help.SetError(this.txtManaRegen, "Approximate MP5 from non-player sources such as VT, Mana Spring, etc. Look at a W" +
                    "WS report or similar to see what a typical regen amount is for one of your fight" +
                    "s.");
            this.txtManaRegen.Location = new System.Drawing.Point(101, 76);
            this.txtManaRegen.Name = "txtManaRegen";
            this.txtManaRegen.Size = new System.Drawing.Size(71, 20);
            this.txtManaRegen.TabIndex = 30;
            // 
            // txtMinWandDamage
            // 
            this.help.SetError(this.txtMinWandDamage, "Minimum wand damage as it appears in the wand tooltip.");
            this.txtMinWandDamage.Location = new System.Drawing.Point(101, 42);
            this.txtMinWandDamage.Name = "txtMinWandDamage";
            this.txtMinWandDamage.Size = new System.Drawing.Size(71, 20);
            this.txtMinWandDamage.TabIndex = 32;
            // 
            // txtMaxWandDamage
            // 
            this.help.SetError(this.txtMaxWandDamage, "Maximum wand damage as it appears in the wand tooltip.");
            this.txtMaxWandDamage.Location = new System.Drawing.Point(101, 68);
            this.txtMaxWandDamage.Name = "txtMaxWandDamage";
            this.txtMaxWandDamage.Size = new System.Drawing.Size(71, 20);
            this.txtMaxWandDamage.TabIndex = 33;
            // 
            // txtWandSpeed
            // 
            this.help.SetError(this.txtWandSpeed, "Time in seconds to shoot the wand. Appears in wand tooltip.");
            this.txtWandSpeed.Location = new System.Drawing.Point(101, 94);
            this.txtWandSpeed.Name = "txtWandSpeed";
            this.txtWandSpeed.Size = new System.Drawing.Size(71, 20);
            this.txtWandSpeed.TabIndex = 34;
            // 
            // txtReactionTime
            // 
            this.help.SetError(this.txtReactionTime, "Player reaction time in seconds for new casts. MUST BE NON-ZERO!");
            this.txtReactionTime.Location = new System.Drawing.Point(101, 50);
            this.txtReactionTime.Name = "txtReactionTime";
            this.txtReactionTime.Size = new System.Drawing.Size(71, 20);
            this.txtReactionTime.TabIndex = 32;
            // 
            // txtMoltenFuryActiveTime
            // 
            this.help.SetError(this.txtMoltenFuryActiveTime, "Fraction of fight time that Molten Fury is active for. Note that fire mages and D" +
                    "PS warriors using Execute will make this value lower than 0.2.");
            this.txtMoltenFuryActiveTime.Location = new System.Drawing.Point(101, 102);
            this.txtMoltenFuryActiveTime.Name = "txtMoltenFuryActiveTime";
            this.txtMoltenFuryActiveTime.Size = new System.Drawing.Size(71, 20);
            this.txtMoltenFuryActiveTime.TabIndex = 31;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.talents);
            this.groupBox2.Controls.Add(this.label66);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.cmbSpecSelect);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Location = new System.Drawing.Point(236, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 560);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Talents";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(236, 65);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(104, 13);
            this.label66.TabIndex = 22;
            this.label66.Text = "Defaults to 2/48/11.";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(19, 65);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(70, 13);
            this.label42.TabIndex = 21;
            this.label42.Text = "Cookie cutter";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 39);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(385, 13);
            this.label24.TabIndex = 19;
            this.label24.Text = "Only applicable talents are shown and have boxes for entry. Ignore other talents." +
                "";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(6, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(196, 13);
            this.label23.TabIndex = 18;
            this.label23.Text = "Enter the number of points spent.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.selSetBonuses);
            this.groupBox3.Controls.Add(this.label46);
            this.groupBox3.Controls.Add(this.label45);
            this.groupBox3.Controls.Add(this.selTrinkets);
            this.groupBox3.Controls.Add(this.label44);
            this.groupBox3.Controls.Add(this.label43);
            this.groupBox3.Location = new System.Drawing.Point(15, 407);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(215, 223);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Player Gear";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(6, 117);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(67, 13);
            this.label46.TabIndex = 22;
            this.label46.Text = "Set Bonuses";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(3, 189);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(136, 13);
            this.label45.TabIndex = 21;
            this.label45.Text = "More gear options to come!";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(6, 49);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(45, 13);
            this.label44.TabIndex = 19;
            this.label44.Text = "Trinkets";
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(6, 16);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(186, 33);
            this.label43.TabIndex = 18;
            this.label43.Text = "Select specific gear that you would wear in a typical boss fight.";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(761, 602);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(90, 28);
            this.btnDone.TabIndex = 35;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtMoltenFuryActiveTime);
            this.groupBox4.Controls.Add(this.label91);
            this.groupBox4.Controls.Add(this.txtReactionTime);
            this.groupBox4.Controls.Add(this.label56);
            this.groupBox4.Controls.Add(this.txtManaRegen);
            this.groupBox4.Controls.Add(this.label49);
            this.groupBox4.Controls.Add(this.txtFightLength);
            this.groupBox4.Controls.Add(this.label48);
            this.groupBox4.Controls.Add(this.label47);
            this.groupBox4.Location = new System.Drawing.Point(650, 70);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(201, 162);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fight Properties";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(6, 105);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(81, 13);
            this.label91.TabIndex = 33;
            this.label91.Text = "Molten fury time";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(6, 53);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(72, 13);
            this.label56.TabIndex = 31;
            this.label56.Text = "Reaction time";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(6, 79);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(64, 13);
            this.label49.TabIndex = 22;
            this.label49.Text = "Mana regen";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(6, 27);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(62, 13);
            this.label48.TabIndex = 20;
            this.label48.Text = "Fight length";
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(6, 125);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(189, 31);
            this.label47.TabIndex = 19;
            this.label47.Text = "More options for fight specifics to come!";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtWandSpeed);
            this.groupBox5.Controls.Add(this.label53);
            this.groupBox5.Controls.Add(this.txtMaxWandDamage);
            this.groupBox5.Controls.Add(this.label52);
            this.groupBox5.Controls.Add(this.txtMinWandDamage);
            this.groupBox5.Controls.Add(this.label51);
            this.groupBox5.Controls.Add(this.label50);
            this.groupBox5.Location = new System.Drawing.Point(650, 238);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(201, 124);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Wand Properties";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(6, 97);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(38, 13);
            this.label53.TabIndex = 26;
            this.label53.Text = "Speed";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(6, 71);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(68, 13);
            this.label52.TabIndex = 24;
            this.label52.Text = "Max damage";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(6, 45);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(65, 13);
            this.label51.TabIndex = 22;
            this.label51.Text = "Min damage";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(6, 17);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(129, 13);
            this.label50.TabIndex = 19;
            this.label50.Text = "Enter wand specifics.";
            // 
            // talents
            // 
            this.talents.Location = new System.Drawing.Point(9, 89);
            this.talents.MaximumSize = new System.Drawing.Size(385, 457);
            this.talents.MinimumSize = new System.Drawing.Size(385, 457);
            this.talents.Name = "talents";
            this.talents.Size = new System.Drawing.Size(385, 457);
            this.talents.SpecArcFocus = 0;
            this.talents.SpecWand = 0;
            this.talents.TabIndex = 23;
            // 
            // SimulationConfig
            // 
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 642);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadConfig);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.cmbConfigSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SimulationConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configure MageTheorycraft Simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimulationConfigGUI_FormClosing);
            this.Load += new System.EventHandler(this.SimulationConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.help)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbConfigSelect;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMana;
        private System.Windows.Forms.TextBox txtHitpoints;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider help;
        private System.Windows.Forms.TextBox txtMP5Casting;
        private System.Windows.Forms.TextBox txtMP5NotCasting;
        private System.Windows.Forms.TextBox txtCritPercent;
        private System.Windows.Forms.TextBox txtHitRating;
        private System.Windows.Forms.TextBox txtBonusDamage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ComboBox cmbSpecSelect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.CheckedListBox selSetBonuses;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.CheckedListBox selTrinkets;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtFightLength;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtManaRegen;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtWandSpeed;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox txtMaxWandDamage;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox txtMinWandDamage;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox txtHasteRating;
        private System.Windows.Forms.TextBox txtReactionTime;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.ComboBox cmbCasterType;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox txtMoltenFuryActiveTime;
        private System.Windows.Forms.Label label91;
        private MageTalentSelector.MageTalents talents;
    }
}