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
    public partial class Filter : Form
    {
        Properties.Settings chk;

        public Filter()
        {
            InitializeComponent();

            chk = Properties.Settings.Default;

            cbClients.Checked = chk.FilterClients;
            cbCallsign.Checked = chk.FilterCallsign;
            cbName.Checked = chk.FilterName;
            cbCID.Checked = chk.FilterCID;
            cbPilots.Checked = chk.FilterPilots;
            cbDepICAO.Checked = chk.FilterPilotsDep;
            cbArrICAO.Checked = chk.FilterPilotsArr;
            cbType.Checked = chk.FilterPilotsAC;
            cbATCs.Checked = chk.FilterATCs;
            cbEnd.Checked = chk.FilterATCsEnd;
            cbAirport.Checked = chk.FilterATCsAP;
            cbFreq.Checked = chk.FilterATCsFreq;
            cbATCRating.Checked = chk.FilterATCsRating;
            cbOBS.Checked = chk.FilterOBSs;
            cbOBSRating.Checked = chk.FilterOBSsRating;
            cbAirport.Checked = chk.FilterAirports;
            cbAPICAO.Checked = chk.FilterAirportsICAO;
            cbAPName.Checked = chk.FilterAirportsName;

            cbClients_CheckedChanged(this, null);
            cbAirport_CheckedChanged(this, null);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            chk.FilterClients = cbClients.Checked;
            chk.FilterCallsign = cbCallsign.Checked;
            chk.FilterName = cbName.Checked;
            chk.FilterCID = cbCID.Checked;
            chk.FilterPilots = cbPilots.Checked;
            chk.FilterPilotsDep = cbDepICAO.Checked;
            chk.FilterPilotsArr = cbArrICAO.Checked;
            chk.FilterPilotsAC = cbType.Checked;
            chk.FilterATCs = cbATCs.Checked;
            chk.FilterATCsEnd = cbEnd.Checked;
            chk.FilterATCsAP = cbAirport.Checked;
            chk.FilterATCsFreq = cbFreq.Checked;
            chk.FilterATCsRating = cbATCRating.Checked;
            chk.FilterOBSs = cbOBS.Checked;
            chk.FilterOBSsRating = cbOBSRating.Checked;
            chk.FilterAirports = cbAirport.Checked;
            chk.FilterAirportsICAO = cbAPICAO.Checked;
            chk.FilterAirportsName = cbAPName.Checked;

            Properties.Settings.Default.Save();

            Dispose();
        }

        private void cbClients_CheckedChanged(object sender, EventArgs e)
        {
            if (cbClients.Checked)
            {
                cbCallsign.Enabled = true;
                cbName.Enabled = true;
                cbCID.Enabled = true;
                cbPilots.Enabled = true;
                cbATCs.Enabled = true;
                cbOBS.Enabled = true;

                cbPilots_CheckedChanged(this, null);
                cbATCs_CheckedChanged(this, null);
                cbOBS_CheckedChanged(this, null);
            }
            else
            {
                cbCallsign.Enabled = false;
                cbName.Enabled = false;
                cbCID.Enabled = false;
                cbPilots.Enabled = false;
                cbDepICAO.Enabled = false;
                cbArrICAO.Enabled = false;
                cbType.Enabled = false;
                cbATCs.Enabled = false;
                cbEnd.Enabled = false;
                cbATCICAO.Enabled = false;
                cbFreq.Enabled = false;
                cbATCRating.Enabled = false;
                cbOBS.Enabled = false;
                cbOBSRating.Enabled = false;
            }
        }

        private void cbPilots_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPilots.Checked)
            {
                cbDepICAO.Enabled = true;
                cbArrICAO.Enabled = true;
                cbType.Enabled = true;
            }
            else
            {
                cbDepICAO.Enabled = false;
                cbArrICAO.Enabled = false;
                cbType.Enabled = false;
            }
        }

        private void cbATCs_CheckedChanged(object sender, EventArgs e)
        {
            if (cbATCs.Checked)
            {
                cbEnd.Enabled = true;
                cbATCICAO.Enabled = true;
                cbFreq.Enabled = true;
                cbATCRating.Enabled = true;
            }
            else
            {
                cbEnd.Enabled = false;
                cbATCICAO.Enabled = false;
                cbFreq.Enabled = false;
                cbATCRating.Enabled = false;
            }
        }

        private void cbOBS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOBS.Checked)
            {
                cbOBSRating.Enabled = true;
            }
            else
            {
                cbOBSRating.Enabled = false;
            }
        }

        private void cbAirport_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAirport.Checked)
            {
                cbAPICAO.Enabled = true;
                cbAPName.Enabled = true;
            }
            else
            {
                cbAPICAO.Enabled = false;
                cbAPName.Enabled = false;
            }
        }
    }
}
