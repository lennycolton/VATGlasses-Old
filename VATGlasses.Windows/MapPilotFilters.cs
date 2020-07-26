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
    public partial class MapPilotFilters : Form
    {
        public MapPilotFilters()
        {
            InitializeComponent();

            nudLower.Minimum = 0;
            nudLower.Maximum = int.MaxValue;

            nudUpper.Minimum = 0;
            nudUpper.Maximum = int.MaxValue;

            nudLower.Value = FilterSettings.intMinPilotAlt;
            nudUpper.Value = FilterSettings.intMaxPilotAlt;

            foreach (Airport apAp in FilterSettings.listDep)
            {
                cbDep.Items.Add(new ComboBoxItem(apAp.strName, apAp));
            }

            foreach (Airport apAp in FilterSettings.listArr)
            {
                cbArr.Items.Add(new ComboBoxItem(apAp.strName, apAp));
            }

            switch (FilterSettings.intPilotFilterMode)
            {
                case 0:
                    rbDep.Checked = true;
                    break;
                case 1:
                    rbArr.Checked = true;
                    break;
                case 2:
                    rbBoth.Checked = true;
                    break;
                case 3:
                    rbNone.Checked = true;
                    break;
                default:
                    rbNone.Checked = true;
                    break;
            }
        }

        private void nudLower_ValueChanged(object sender, EventArgs e)
        {
            if (nudLower.Value > FilterSettings.intMaxPilotAlt)
            {
                nudLower.Value = FilterSettings.intMinPilotAlt;
            }
            else
            {
                FilterSettings.intMinPilotAlt = (int)nudLower.Value;
            }
        }

        private void nudUpper_ValueChanged(object sender, EventArgs e)
        {
            if (nudUpper.Value < FilterSettings.intMinPilotAlt)
            {
                nudUpper.Value = FilterSettings.intMaxPilotAlt;
            }
            else
            {
                FilterSettings.intMaxPilotAlt = (int)nudUpper.Value;
            }
        }

        private void BtnAltReset_Click(object sender, EventArgs e)
        {
            nudLower.Value = 0;
            nudUpper.Value = 66000;
        }

        private void TxtDep_GotFocus(object sender, EventArgs e)
        {
            if (TxtDep.Text == "Enter ICAO Code...")
            {
                TxtDep.Text = "";
            }
        }
        private void TxtDep_LostFocus(object sender, EventArgs e)
        {
            if (TxtDep.Text == null || TxtDep.Text == "" )
            {
                TxtDep.Text = "Enter ICAO Code...";
            }
        }

        private void BtnDepAdd_Click(object sender, EventArgs e)
        {
            string strCallsign = TxtDep.Text;

            Airport apDep = Airport.FindICAO(TxtDep.Text);

            if (apDep != null)
            {
                if (FilterSettings.listDep.Contains(apDep))
                {
                    MessageBox.Show(apDep.strICAO + " is already in the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbDep.SelectedIndex = cbDep.Items.IndexOf(strCallsign);
                }
                else
                {
                    FilterSettings.listDep.Add(apDep);
                    cbDep.Items.Add(new ComboBoxItem(apDep.strName, apDep));
                    cbDep.SelectedIndex = cbDep.Items.Count - 1;
                }
            }
            else
            {
                MessageBox.Show("Airport ICAO code not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDepRemove_Click(object sender, EventArgs e)
        {
            if (cbDep.SelectedIndex != -1)
            {
                FilterSettings.listDep.RemoveAll(item => item == (Airport)((ComboBoxItem)cbDep.SelectedItem).Value);
                cbDep.Items.Remove(cbDep.SelectedItem);
            }
        }

        private void BtnDepClear_Click(object sender, EventArgs e)
        {
            FilterSettings.listDep.Clear();
            cbDep.Items.Clear();
        }

        private void TxtArr_GotFocus(object sender, EventArgs e)
        {
            if (TxtArr.Text == "Enter ICAO Code...")
            {
                TxtArr.Text = "";
            }
        }
        private void TxtArr_LostFocus(object sender, EventArgs e)
        {
            if (TxtArr.Text == null || TxtArr.Text == "")
            {
                TxtArr.Text = "Enter ICAO Code...";
            }
        }

        private void BtnArrAdd_Click(object sender, EventArgs e)
        {
            string strCallsign = TxtArr.Text;

            Airport apArr = Airport.FindICAO(TxtArr.Text);

            if (apArr != null)
            {
                if (FilterSettings.listDep.Contains(apArr))
                {
                    MessageBox.Show(apArr.strICAO + " is already in the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbArr.SelectedIndex = cbArr.Items.IndexOf(strCallsign);
                }
                else
                {
                    FilterSettings.listArr.Add(apArr);
                    cbArr.Items.Add(new ComboBoxItem(apArr.strName, apArr));
                    cbArr.SelectedIndex = cbArr.Items.Count - 1;
                }
            }
            else
            {
                MessageBox.Show("Airport ICAO code not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnArrRemove_Click(object sender, EventArgs e)
        {
            if (cbArr.SelectedIndex != -1)
            {
                FilterSettings.listArr.RemoveAll(item => item == (Airport)((ComboBoxItem)cbArr.SelectedItem).Value);
                cbArr.Items.Remove(cbArr.SelectedItem);
            }
        }

        private void BtnArrClear_Click(object sender, EventArgs e)
        {
            FilterSettings.listArr.Clear();
            cbArr.Items.Clear();
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDep.Checked)
            {
                FilterSettings.intPilotFilterMode = 0;
            }
            else if (rbArr.Checked)
            {
                FilterSettings.intPilotFilterMode = 1;
            }
            else if (rbBoth.Checked)
            {
                FilterSettings.intPilotFilterMode = 2;
            }
            else
            {
                FilterSettings.intPilotFilterMode = 3;
            }
        }
    }
}
