namespace MageTheorycraftGUI
{
    partial class SimulationResults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationResults));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRepetitions = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.prg1 = new System.Windows.Forms.ProgressBar();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteResult = new System.Windows.Forms.Button();
            this.chkResults = new System.Windows.Forms.CheckedListBox();
            this.bitmapGraph1 = new BitmapGraph.BitmapGraph();
            this.dgvStatistics = new System.Windows.Forms.DataGridView();
            this.Stat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCombatLogStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.help = new System.Windows.Forms.ErrorProvider(this.components);
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            this.lblInstructions = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.help)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtRepetitions);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblProgress);
            this.groupBox1.Controls.Add(this.prg1);
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Controls.Add(this.btnConfigure);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulation Control";
            // 
            // txtRepetitions
            // 
            this.help.SetError(this.txtRepetitions, "Number of times to perform simulation - a higher number provides more accuracy at" +
                    " the expense of calculation time.");
            this.txtRepetitions.Location = new System.Drawing.Point(205, 22);
            this.txtRepetitions.Name = "txtRepetitions";
            this.txtRepetitions.Size = new System.Drawing.Size(33, 20);
            this.txtRepetitions.TabIndex = 5;
            this.txtRepetitions.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Repetitions:";
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.Location = new System.Drawing.Point(625, 20);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(79, 23);
            this.lblProgress.TabIndex = 3;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prg1
            // 
            this.prg1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prg1.Location = new System.Drawing.Point(341, 20);
            this.prg1.Name = "prg1";
            this.prg1.Size = new System.Drawing.Size(278, 23);
            this.prg1.TabIndex = 2;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(260, 20);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnConfigure
            // 
            this.btnConfigure.Location = new System.Drawing.Point(6, 20);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(75, 23);
            this.btnConfigure.TabIndex = 0;
            this.btnConfigure.Text = "Configure";
            this.btnConfigure.UseVisualStyleBackColor = true;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblInstructions);
            this.groupBox2.Controls.Add(this.btnDeleteResult);
            this.groupBox2.Controls.Add(this.chkResults);
            this.groupBox2.Controls.Add(this.bitmapGraph1);
            this.groupBox2.Controls.Add(this.dgvStatistics);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(710, 585);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // btnDeleteResult
            // 
            this.btnDeleteResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteResult.Location = new System.Drawing.Point(9, 392);
            this.btnDeleteResult.Name = "btnDeleteResult";
            this.btnDeleteResult.Size = new System.Drawing.Size(60, 22);
            this.btnDeleteResult.TabIndex = 3;
            this.btnDeleteResult.Text = "Delete";
            this.btnDeleteResult.UseVisualStyleBackColor = true;
            this.btnDeleteResult.Click += new System.EventHandler(this.btnDeleteResult_Click);
            // 
            // chkResults
            // 
            this.chkResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.chkResults.FormattingEnabled = true;
            this.chkResults.Location = new System.Drawing.Point(9, 19);
            this.chkResults.Name = "chkResults";
            this.chkResults.Size = new System.Drawing.Size(180, 364);
            this.chkResults.TabIndex = 7;
            this.chkResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkResults_MouseClick);
            this.chkResults.SelectedIndexChanged += new System.EventHandler(this.chkResults_SelectedIndexChanged);
            this.chkResults.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkResults_KeyPress);
            this.chkResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkResults_KeyDown);
            // 
            // bitmapGraph1
            // 
            this.bitmapGraph1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bitmapGraph1.AutoUpdate = false;
            this.bitmapGraph1.BackColor = System.Drawing.Color.White;
            this.bitmapGraph1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bitmapGraph1.BackgroundImage")));
            this.bitmapGraph1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bitmapGraph1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bitmapGraph1.Curved = true;
            this.bitmapGraph1.Lines = ((System.Collections.Generic.List<System.Collections.Generic.List<System.Drawing.Point>>)(resources.GetObject("bitmapGraph1.Lines")));
            this.bitmapGraph1.Location = new System.Drawing.Point(198, 19);
            this.bitmapGraph1.MinimumSize = new System.Drawing.Size(40, 40);
            this.bitmapGraph1.Name = "bitmapGraph1";
            this.bitmapGraph1.Pens = ((System.Collections.Hashtable)(resources.GetObject("bitmapGraph1.Pens")));
            this.bitmapGraph1.Size = new System.Drawing.Size(504, 364);
            this.bitmapGraph1.TabIndex = 6;
            // 
            // dgvStatistics
            // 
            this.dgvStatistics.AllowUserToAddRows = false;
            this.dgvStatistics.AllowUserToDeleteRows = false;
            this.dgvStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stat,
            this.Value});
            this.dgvStatistics.Location = new System.Drawing.Point(198, 407);
            this.dgvStatistics.Name = "dgvStatistics";
            this.dgvStatistics.ReadOnly = true;
            this.dgvStatistics.RowHeadersVisible = false;
            this.dgvStatistics.Size = new System.Drawing.Size(504, 170);
            this.dgvStatistics.TabIndex = 5;
            // 
            // Stat
            // 
            this.Stat.DataPropertyName = "Stat";
            this.Stat.FillWeight = 50F;
            this.Stat.HeaderText = "Stat";
            this.Stat.Name = "Stat";
            this.Stat.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 150;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(195, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Statistics";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFilter);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cmbCombatLogStyle);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(219, 537);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result Filters";
            this.groupBox3.Visible = false;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(138, 135);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.help.SetError(this.textBox1, "Enter the name of a spell to filter the summary statistics.");
            this.textBox1.Location = new System.Drawing.Point(9, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Spell stats filter";
            // 
            // cmbCombatLogStyle
            // 
            this.cmbCombatLogStyle.FormattingEnabled = true;
            this.cmbCombatLogStyle.Items.AddRange(new object[] {
            "Default",
            "Consolidated Casts"});
            this.cmbCombatLogStyle.Location = new System.Drawing.Point(9, 44);
            this.cmbCombatLogStyle.Name = "cmbCombatLogStyle";
            this.cmbCombatLogStyle.Size = new System.Drawing.Size(183, 21);
            this.cmbCombatLogStyle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Combat log style";
            // 
            // help
            // 
            this.help.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.help.ContainerControl = this;
            this.help.Icon = ((System.Drawing.Icon)(resources.GetObject("help.Icon")));
            // 
            // tmr1
            // 
            this.tmr1.Interval = 50;
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // lblInstructions
            // 
            this.lblInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInstructions.Location = new System.Drawing.Point(6, 426);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(183, 151);
            this.lblInstructions.TabIndex = 8;
            this.lblInstructions.Text = resources.GetString("lblInstructions.Text");
            // 
            // SimulationResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(734, 664);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.MinimumSize = new System.Drawing.Size(550, 500);
            this.Name = "SimulationResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MageTheorycraft Simulation";
            this.Load += new System.EventHandler(this.SimulationResults_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimulationResults_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.help)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCombatLogStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ErrorProvider help;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvStatistics;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.ProgressBar prg1;
        private System.Windows.Forms.Timer tmr1;
        private System.Windows.Forms.Label lblProgress;
        private BitmapGraph.BitmapGraph bitmapGraph1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.CheckedListBox chkResults;
        private System.Windows.Forms.Button btnDeleteResult;
        private System.Windows.Forms.TextBox txtRepetitions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblInstructions;
    }
}