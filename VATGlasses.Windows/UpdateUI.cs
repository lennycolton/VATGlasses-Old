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
using System.Reflection;

namespace VATGlasses
{
    public partial class UpdateUI : Form
    {
        BackgroundWorker bgwMove;
        BackgroundWorker bgwUpdate;

        GitUpdater gupUpdate;

        bool[] isarrLegacyPrefs;
        Tuple<bool[], Version[]> tupUpdate = null;

        public UpdateUI()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = CultureInfo.InstalledUICulture;

            InitializeBackgroundMove();
            InitializeBackgroundUpdate();

            FormClosing += UpdateUI_FormClosing;

            gupUpdate = new GitUpdater();

            isarrLegacyPrefs = gupUpdate.CheckPrefs();

            try
            {
                tupUpdate = gupUpdate.CheckUpdate();
            }
            catch
            {
                MessageBox.Show("Error whilst checking for data file updates.", "VATGlasses", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }

            if (isarrLegacyPrefs.Contains(true))
            {
                DialogResult result = MessageBox.Show("The preference (Current Runways and Added Items) files have been moved to a new location (the \"prefs\" folder) as of VATGlasses 1.1.1.0.\n\nThis allows preferences to be retained across data releases.\n\nVersions of these files have been found in the \"data\" folder (The location used by previous versions of VATGlasses).\n\nWould you like to migrate these to the \"prefs\" folder?\n\nIf preference files are already present in the \"prefs\" folder, they will be overwritten.\n\n(If you have just updated from a version of VATGlasses before 1.1.1.0, you should run this process to keep your preference files.)", "VATGlasses", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    BusyStart();
                    bgwMove.RunWorkerAsync();
                }
                else if (tupUpdate != null)
                {
                    UpdateInterface();
                }
            }
            else if (tupUpdate != null)
            {
                UpdateInterface();
            }
        }

        private void UpdateInterface()
        {
            if (!tupUpdate.Item1[0])
            {
                if (tupUpdate.Item1[2])
                {
                    MessageBox.Show("No installed data release found.\r\n\r\nVATGlasses will not run without a valid data release\r\n\r\nLatest Data Release: " + gupUpdate.apiData.strName + "\r\n\r\nThis data release requires VATGlasses " + tupUpdate.Item2[0].ToString() + " or higher.\r\n\r\nVersion " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " is currently installed." + "\r\n\r\nPlease update to a newer version of VATGlasses before installing this data release.", "VATGlasses", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Dispose();
                }
                else if (tupUpdate.Item1[3])
                {
                    MessageBox.Show("No installed data release found.\r\n\r\nVATGlasses will not run without a valid data release\r\n\r\nLatest Data Release: " + gupUpdate.apiData.strName + "\r\n\r\nThis data release requires VATGlasses " + tupUpdate.Item2[1].ToString() + " or lower.\r\n\r\nVersion " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " is currently installed." + "\r\n\r\nPlease let the development team know so that they can make a compatible data release.", "VATGlasses", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Dispose();
                }
                else
                {
                    DialogResult result = MessageBox.Show("No installed data release found.\r\n\r\nLatest Data Release: " + gupUpdate.apiData.strTag + "\r\n\r\nThis release will now be installed.", "VATGlasses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BusyStart();
                    bgwUpdate.RunWorkerAsync();
                }
            }
            else if (tupUpdate.Item1[1])
            {
                if (tupUpdate.Item1[2])
                {
                    MessageBox.Show("Latest Data Release: " + gupUpdate.apiData.strName + "\r\n\r\nThis data release requires VATGlasses " + tupUpdate.Item2[0].ToString() + " or higher.\r\n\r\nVersion " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " is currently installed." + "\r\n\r\nPlease update to a newer version of VATGlasses before installing this data release.", "VATGlasses", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Dispose();
                }
                else if (tupUpdate.Item1[3])
                {
                    MessageBox.Show("Latest Data Release: " + gupUpdate.apiData.strName + "\r\n\r\nThis data release requires VATGlasses " + tupUpdate.Item2[1].ToString() + " or lower.\r\n\r\nVersion " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " is currently installed." + "\r\n\r\nPlease let the development team know so that they can make a compatible data release.", "VATGlasses", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Dispose();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Latest Data Release: " + gupUpdate.apiData.strTag + "\r\n\r\nWould you like to update to this release?", "VATGlasses", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        BusyStart();
                        bgwUpdate.RunWorkerAsync();
                    }
                    else
                    {
                        Dispose();
                    }
                }
            }
            else
            {
                Dispose();
            }
        }

        private void UpdateUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("The program is busy. Closing now may cause data corruption. Are you sure that you want to close?", "VATGlasses", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void InitializeBackgroundMove()
        {
            bgwMove = new BackgroundWorker();
            bgwMove.DoWork += BgwMove_DoWork;
            bgwMove.RunWorkerCompleted += BgwMove_RunWorkerCompleted;
        }

        private void BgwMove_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                gupUpdate.MovePrefs(isarrLegacyPrefs);
                e.Result = true;
            }
            catch
            {
                e.Result = false;
            }
        }

        private void BgwMove_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BusyFinish();

            bool isSuccess = (bool)e.Result;

            if (isSuccess)
            {
                MessageBox.Show("Preference files moved to new location.", "VATGlasses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("An error occurred.", "VATGlasses", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateInterface();
        }

        private void InitializeBackgroundUpdate()
        {
            bgwUpdate = new BackgroundWorker();
            bgwUpdate.DoWork += BgwUpdate_DoWork;
            bgwUpdate.RunWorkerCompleted += BgwUpdate_RunWorkerCompleted;
        }

        private void BgwUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                gupUpdate.Update();
                e.Result = true;
            }
            catch
            {
                e.Result = false;
            }
        }

        private void BgwUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BusyFinish();

            bool isSuccess = (bool)e.Result;

            if (isSuccess)
            {
                MessageBox.Show("Update complete.", "VATGlasses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("An error occurred.", "VATGlasses", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Dispose();
        }

        private void BusyStart()
        {
            pbUpdate.Style = ProgressBarStyle.Marquee;
            pbUpdate.MarqueeAnimationSpeed = 30;
            Show();
        }

        private void BusyFinish()
        {
            Hide();
            pbUpdate.Style = ProgressBarStyle.Continuous;
            pbUpdate.Value = 0;
        }
    }
}
