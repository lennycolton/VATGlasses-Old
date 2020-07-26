﻿using System;
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
    public partial class MapATCFiltersWithFIR : Form
    {
        public MapATCFiltersWithFIR()
        {
            InitializeComponent();

            nudLower.Minimum = 0;
            nudLower.Maximum = int.MaxValue;

            nudUpper.Minimum = 0;
            nudUpper.Maximum = int.MaxValue;

            nudLower.Value = FilterSettings.intMinATCAlt;
            nudUpper.Value = FilterSettings.intMaxATCAlt;

            foreach (FIRDisplay frdFrd in FIRDisplay.list)
            {
                string strName = frdFrd.listFIRs[0].strIdent;

                if (frdFrd.listFIRs[0].isOceanic)
                {
                    strName += " Oceanic";
                }

                cbFIRs.Items.Add(new ComboBoxItem(strName, frdFrd));
            }

            foreach (string strStr in FilterSettings.listATCCallsigns)
            {
                cbOwners.Items.Add(strStr);
            }
        }

        private void nudLower_ValueChanged(object sender, EventArgs e)
        {
            if (nudLower.Value > FilterSettings.intMaxATCAlt)
            {
                nudLower.Value = FilterSettings.intMinATCAlt;
            }
            else
            {
                FilterSettings.intMinATCAlt = (int)nudLower.Value;
            }
        }

        private void nudUpper_ValueChanged(object sender, EventArgs e)
        {
            if (nudUpper.Value < FilterSettings.intMinATCAlt)
            {
                nudUpper.Value = FilterSettings.intMaxATCAlt;
            }
            else
            {
                FilterSettings.intMaxATCAlt = (int)nudUpper.Value;
            }
        }

        private void cbFIRs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((FIRDisplay)((ComboBoxItem)cbFIRs.SelectedItem).Value).isShown)
            {
                rbShow.Checked = true;
            }
            else
            {
                rbHide.Checked = true;
            }
        }

        private void rbOwned_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFIRs.SelectedIndex != -1)
            {
                if (rbShow.Checked)
                {
                    ((FIRDisplay)((ComboBoxItem)cbFIRs.SelectedItem).Value).isShown = true;
                }
                else
                {
                    ((FIRDisplay)((ComboBoxItem)cbFIRs.SelectedItem).Value).isShown = false;
                }
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            foreach (FIRDisplay frdFrd in FIRDisplay.list)
            {
                frdFrd.isShown = true;
            }

            if (cbFIRs.SelectedIndex != -1)
            {
                rbShow.Checked = true;
            }
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            foreach (FIRDisplay frdFrd in FIRDisplay.list)
            {
                frdFrd.isShown = false;
            }

            if (cbFIRs.SelectedIndex != -1)
            {
                rbHide.Checked = true;
            }
        }

        private void BtnAltReset_Click(object sender, EventArgs e)
        {
            nudLower.Value = 0;
            nudUpper.Value = 1000000;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string strCallsign = TxtAdd.Text;

            if (FilterSettings.listATCCallsigns.Contains(strCallsign))
            {
                MessageBox.Show("The callsign entered is already in the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbOwners.SelectedIndex = cbOwners.Items.IndexOf(strCallsign);
            }
            else
            {
                FilterSettings.listATCCallsigns.Add(strCallsign);
                cbOwners.Items.Add(strCallsign);
                cbOwners.SelectedIndex = cbOwners.Items.Count - 1;
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (cbOwners.SelectedIndex != -1)
            {
                string strCallsign = (string)cbOwners.SelectedItem;

                if (FilterSettings.listATCCallsigns.Contains(strCallsign))
                {
                    FilterSettings.listATCCallsigns.RemoveAll(item => item == strCallsign);

                    while (cbOwners.Items.Contains(strCallsign))
                    {
                        cbOwners.Items.Remove(strCallsign);
                    }
                }
            }
        }
            

        private void BtnClear_Click(object sender, EventArgs e)
        {
            FilterSettings.listATCCallsigns.Clear();
            cbOwners.Items.Clear();
        }
    }
}
