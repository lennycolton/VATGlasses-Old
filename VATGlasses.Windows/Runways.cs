using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VATGlasses
{
    public partial class Runways : Form
    {
        List<Runway> listActive;
        Airport apCurrent;

        ColorProfile cp;

        public Runways()
        {
            InitializeComponent();

            AcceptButton = BtnSearch;
            CancelButton = BtnClose;

            SetTheme();
        }

        private void SetTheme()
        {
            switch (Properties.Settings.Default.ColorProfile)
            {
                case 0:
                    cp = ColorProfile.Light;
                    break;
                case 1:
                    cp = ColorProfile.Dark;
                    break;
            }

            BackColor = cp.Control;

            LblAirport.ForeColor = cp.Text;
            LblRunways.ForeColor = cp.Text;
            LblSearch.ForeColor = cp.Text;

            BtnClose.ForeColor = cp.Text;
            BtnSave.ForeColor = cp.Text;
            BtnSearch.ForeColor = cp.Text;

            BtnClose.BackColor = cp.TransparentControl;
            BtnSave.BackColor = cp.TransparentControl;
            BtnSearch.BackColor = cp.TransparentControl;

            TxtSearch.BackColor = cp.Window;
            TxtSearch.ForeColor = cp.Text;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            tlpRunways.Controls.Clear();
            tlpRunways.RowCount = 0;

            if (TxtSearch.Text != "")
            {
                apCurrent = Airport.FindICAO(TxtSearch.Text);
                if (apCurrent == null)
                {
                    MessageBox.Show("Airport not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int intSize = tlpRunways.Height;
                    listActive = new List<Runway>(apCurrent.listRunways);

                    foreach (Runway rwyRwy in apCurrent.listRunways)
                    {
                        if (rwyRwy != null)
                        {
                            tlpRunways.RowStyles.Add(new RowStyle(SizeType.Absolute, 23));

                            // 
                            // LblRunway
                            // 
                            Label LblRunway = new Label();
                            LblRunway.ForeColor = cp.Text;
                            tlpRunways.Controls.Add(LblRunway, 0, tlpRunways.RowCount - 1);
                            LblRunway.AutoSize = true;
                            LblRunway.Dock = DockStyle.Fill;
                            LblRunway.Location = new Point(3, 0);
                            LblRunway.Name = "LblRunway";
                            LblRunway.Size = new Size(35, 23);
                            LblRunway.Text = rwyRwy.strRunway;
                            LblRunway.TextAlign = ContentAlignment.MiddleRight;

                            // 
                            // chkActive
                            // 
                            CheckBox chkActive = new CheckBox();
                            chkActive.BackColor = cp.Window;
                            chkActive.ForeColor = cp.Text;
                            tlpRunways.Controls.Add(chkActive, 1, tlpRunways.RowCount - 1);
                            chkActive.AutoSize = true;
                            chkActive.Dock = DockStyle.Fill;
                            chkActive.Location = new Point(201, 3);
                            chkActive.Name = "chkActive";
                            chkActive.Size = new Size(15, 13);
                            chkActive.UseVisualStyleBackColor = true;
                            chkActive.Tag = rwyRwy;

                            if (apCurrent.listActive.Contains(rwyRwy))
                            {
                                chkActive.Checked = true;
                            }

                            tlpRunways.RowCount++;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter an ICAO airport code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            apCurrent.ClearActives();
            
            for (int i = 0; i < tlpRunways.RowCount; i++)
            {
                CheckBox chkActive = (CheckBox)tlpRunways.GetControlFromPosition(1, i);
                if (chkActive.Checked)
                {
                    apCurrent.AddActive((Runway)chkActive.Tag);
                }
            }

            Runway.SaveCurrent(Runway.strCurrentFile, apCurrent);

            MessageBox.Show("Active Runways Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
