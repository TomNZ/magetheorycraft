namespace BitmapGraph
{
    partial class BitmapGraph
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGenerating = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGenerating
            // 
            this.lblGenerating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGenerating.Location = new System.Drawing.Point(0, 0);
            this.lblGenerating.Name = "lblGenerating";
            this.lblGenerating.Size = new System.Drawing.Size(150, 150);
            this.lblGenerating.TabIndex = 0;
            this.lblGenerating.Text = "Generating graph...";
            this.lblGenerating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGenerating.Visible = false;
            // 
            // BitmapGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblGenerating);
            this.MinimumSize = new System.Drawing.Size(60, 60);
            this.Name = "BitmapGraph";
            this.Resize += new System.EventHandler(this.BitmapGraph_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGenerating;
    }
}
