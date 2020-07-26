using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VATGlasses
{
    public partial class AirspaceAlert : Form
    {
        ColorProfile cp;

        public AirspaceAlert()
        {
            InitializeComponent();
            SetTheme();

            TxtCID.Text = Properties.Settings.Default.AlertCID.ToString();
            chkActive.Checked = Properties.Settings.Default.AlertAirspace;
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

            LblCID.ForeColor = cp.Text;

            BtnClose.ForeColor = cp.Text;
            BtnSave.ForeColor = cp.Text;

            BtnClose.BackColor = cp.TransparentControl;
            BtnSave.BackColor = cp.TransparentControl;

            TxtCID.BackColor = cp.Window;
            TxtCID.ForeColor = cp.Text;

            chkActive.BackColor = cp.Window;
            chkActive.ForeColor = cp.Text;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtCID.Text, NumberStyles.None, CultureInfo.CurrentCulture, out int intCID) && intCID >= 800000)
            {
                Properties.Settings.Default.AlertCID = intCID;
                Properties.Settings.Default.AlertAirspace = chkActive.Checked;

                MessageBox.Show("Alert Settings Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid CID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
