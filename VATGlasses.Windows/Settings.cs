using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VATGlasses
{
    public partial class Settings : Form
    {
        ColorProfile cp;

        public Settings()
        {
            InitializeComponent();
            SetTheme();

            switch (Properties.Settings.Default.ZoomMode)
            {
                case 0:
                    radCentre.Checked = true;
                    break;
                case 1:
                    radMouseCentre.Checked = true;
                    break;
                case 2:
                    radMouseNoCentre.Checked = true;
                    break;
                default:
                    radCentre.Checked = true;
                    break;
            }

            switch (Properties.Settings.Default.ColorProfile)
            {
                case 0:
                    radLight.Checked = true;
                    break;
                case 1:
                    radDark.Checked = true;
                    break;
                default:
                    radLight.Checked = true;
                    break;
            }

            switch (Properties.Settings.Default.MinimiseMode)
            {
                case 0:
                    radTaskbar.Checked = true;
                    break;
                case 1:
                    radTray.Checked = true;
                    break;
                default:
                    radTaskbar.Checked = true;
                    break;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (radCentre.Checked)
            {
                Properties.Settings.Default.ZoomMode = 0;
            }
            else if (radMouseCentre.Checked)
            {
                Properties.Settings.Default.ZoomMode = 1;
            }
            else if (radMouseNoCentre.Checked)
            {
                Properties.Settings.Default.ZoomMode = 2;
            }

            if (radLight.Checked)
            {
                Properties.Settings.Default.ColorProfile = 0;
            }
            else if (radDark.Checked)
            {
                Properties.Settings.Default.ColorProfile = 1;
            }

            if (radTaskbar.Checked)
            {
                Properties.Settings.Default.MinimiseMode = 0;
            }
            else if (radTray.Checked)
            {
                Properties.Settings.Default.MinimiseMode = 1;
            }

            Properties.Settings.Default.Save();

            Dispose();
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

            gbZoom.ForeColor = cp.Text;
            gbColour.ForeColor = cp.Text;
            gbMinimise.ForeColor = cp.Text;

            radCentre.ForeColor = cp.Text;
            radMouseCentre.ForeColor = cp.Text;
            radMouseNoCentre.ForeColor = cp.Text;
            radLight.ForeColor = cp.Text;
            radDark.ForeColor = cp.Text;
            radTaskbar.ForeColor = cp.Text;
            radTray.ForeColor = cp.Text;

            BtnSave.BackColor = cp.TransparentControl;
            BtnSave.ForeColor = cp.Text;

            BtnClose.BackColor = cp.TransparentControl;
            BtnClose.ForeColor = cp.Text;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
