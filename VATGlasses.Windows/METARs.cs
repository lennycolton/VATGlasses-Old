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
    public partial class METARs : Form
    {
        ColorProfile cp;

        public METARs()
        {
            InitializeComponent();
            SetTheme();

            AcceptButton = BtnSearch;
            CancelButton = BtnClose;
        }

        public METARs(string _airport)
        {
            InitializeComponent();
            AcceptButton = BtnSearch;
            CancelButton = BtnClose;

            TxtSearch.Text = _airport;
            BtnSearch_Click(BtnSearch, null);
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
            LblSearch.ForeColor = cp.Text;

            BtnClose.ForeColor = cp.Text;
            BtnSearch.ForeColor = cp.Text;

            BtnClose.BackColor = cp.TransparentControl;
            BtnSearch.BackColor = cp.TransparentControl;

            TxtSearch.BackColor = cp.Window;
            TxtSearch.ForeColor = cp.Text;

            TxtMETAR.BackColor = cp.Window;
            TxtMETAR.ForeColor = cp.Text;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            TxtMETAR.Text = DataLink.Current.GetMETAR(TxtSearch.Text);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
