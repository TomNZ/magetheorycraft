using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MageTheorycraft;
using MageTheorycraft.Players;

namespace MageTheorycraftGUI
{
    public partial class SimulationResults : Form
    {
        private Config _config = new Config();
        private Simulation _sim;
        private List<List<Point>> _lines = new List<List<Point>>();
        private List<Statistics> _stats = new List<Statistics>();

        private System.Windows.Forms.TextBox editBox;

        public SimulationResults()
        {
            InitializeComponent();

            editBox = new System.Windows.Forms.TextBox();
			editBox.Location = new System.Drawing.Point(0,0);
			editBox.Size = new System.Drawing.Size(0,0);
			editBox.Hide();
			chkResults.Controls.AddRange(new System.Windows.Forms.Control[] {this.editBox});			
			editBox.Text = "";
			editBox.BorderStyle = BorderStyle.FixedSingle;

            editBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditOver);
            editBox.LostFocus += new System.EventHandler(this.FocusOver);
        }

        static void Main(string[] args)
        {
            SimulationResults gui = new SimulationResults();
            Application.EnableVisualStyles();
            Application.Run(gui);
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            SimulationConfig configForm = new SimulationConfig();
            configForm.Config = _config;
            configForm.ShowDialog();
            _config = configForm.Config;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            RunSimulation();
        }

        private void RunSimulation()
        {
            int numReps = 0;

            if (!int.TryParse(txtRepetitions.Text, out numReps))
                return;

            // Initialise
            if (_sim != null)
                _sim.Dispose();

            _sim = null;
            _sim = new Simulation(_config);

            _sim.Repetitions = numReps;

            _sim.AsyncRun();

            prg1.Maximum = _sim.Repetitions;
            tmr1.Start();
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            prg1.Value = _sim.AsyncThreadsRun;
            lblProgress.Text = _sim.AsyncThreadsRun + " / " + _sim.Repetitions;

            if (!_sim.AsyncRunning)
            {
                prg1.Value = _sim.Repetitions;
                tmr1.Stop();
                FinishedSimulation();
            }
        }

        private void FinishedSimulation()
        {
            _lines.Add(_sim.Statistics.AverageDPSProfile);
            _stats.Add(_sim.Statistics);

            chkResults.Items.Add("Result", true);

            chkResults.SelectedIndex = chkResults.Items.Count - 1;
        }

        private void OutputResults(int index)
        {
            if (index < 0 || index >= _stats.Count)
                return;

            DataTable dt = new DataTable();
            dt.Columns.Add("Stat");
            dt.Columns.Add("Value");

            dt.Rows.Add(new string[] { "Total Damage", _stats[index].AverageTotalDamage.ToString() });
            dt.Rows.Add(new string[] { "Average DPS", _stats[index].AverageTotalDPS.ToString("0.0") });
            dt.Rows.Add(new string[] { "Caster Type", _stats[index].Config.Caster.ToString()} );

            dgvStatistics.DataSource = dt;
        }

        private void SimulationResults_Load(object sender, EventArgs e)
        {
            bitmapGraph1.Font = new Font("Tahoma", 7);
        }

        private void chkResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            OutputResults(chkResults.SelectedIndex);

            BuildActiveLines();
            BuildColors();
            bitmapGraph1.Redraw();
        }

        private void BuildColors()
        {
            int numLines = chkResults.CheckedIndices.Count;

            Hashtable pensHT = new Hashtable();

            if (chkResults.SelectedIndex != -1 && chkResults.CheckedIndices.Contains(chkResults.SelectedIndex))
                pensHT[numLines - 1] = new Pen(Color.Red, 2);

            bitmapGraph1.Pens = pensHT;
        }

        private void BuildActiveLines()
        {
            _lines.Clear();

            for (int i = 0; i < chkResults.Items.Count; i++)
            {
                if (i != chkResults.SelectedIndex)
                {
                    if (chkResults.CheckedIndices.Contains(i))
                        _lines.Add(_stats[i].AverageDPSProfile);
                }
            }

            if (chkResults.SelectedIndex != -1 && chkResults.CheckedIndices.Contains(chkResults.SelectedIndex))
            {
                _lines.Add(_stats[chkResults.SelectedIndex].AverageDPSProfile);
            }

            bitmapGraph1.Lines = _lines;
        }

        private void chkResults_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                CreateEditBox(sender);
        }

        private void chkResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
                CreateEditBox(sender);
            if (e.KeyData == Keys.Delete)
                DeleteSelectedResult();
        }

        private int itemSelected;

        private void CreateEditBox(object sender)
        {
            chkResults = (CheckedListBox)sender;
            itemSelected = chkResults.SelectedIndex;
            Rectangle r = chkResults.GetItemRectangle(itemSelected);
            string itemText = (string)chkResults.Items[itemSelected];

            int delta = 0;
            editBox.Location = new System.Drawing.Point(r.X + delta, r.Y + delta);
            editBox.Size = new System.Drawing.Size(r.Width - 10, r.Height - delta);
            editBox.Show();
            editBox.Text = itemText;
            editBox.Focus();
            editBox.SelectAll();
        }

        private void FocusOver(object sender, System.EventArgs e)
        {
            chkResults.Items[itemSelected] = editBox.Text;
            editBox.Hide();
        }

        private void EditOver(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkResults.Items[itemSelected] = editBox.Text;
                editBox.Hide();
            }
        }

        private void DeleteResult(int deleteIndex)
        {
            chkResults.Items.RemoveAt(deleteIndex);
            _stats.RemoveAt(deleteIndex);

            BuildActiveLines();
            BuildColors();

            bitmapGraph1.Redraw();
        }

        private void DeleteSelectedResult()
        {
            if (chkResults.SelectedIndex == -1)
                return;

            int deleteIndex = chkResults.SelectedIndex;

            DeleteResult(deleteIndex);
        }

        private void btnDeleteResult_Click(object sender, EventArgs e)
        {
            DeleteSelectedResult();
        }

        private void SimulationResults_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_sim != null)
                _sim.Dispose();

            _sim = null;
        }

        private void chkResults_MouseClick(object sender, MouseEventArgs e)
        {
            BuildActiveLines();
            BuildColors();
            bitmapGraph1.Redraw();
        }
    }
}