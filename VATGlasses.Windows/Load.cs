using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VATGlasses
{
    public partial class Load : Form
    {
        Bitmap bmpLogo = new Bitmap(Image.FromFile(@"images\light\plane.png"), 176, 176);
        BackgroundWorker bgwLoad;

        public Load()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = CultureInfo.InstalledUICulture;

            pbLogo.Image = bmpLogo;

            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            bgwLoad = new BackgroundWorker();
            bgwLoad.WorkerReportsProgress = true;
            bgwLoad.DoWork += BgwLoad_DoWork;
            bgwLoad.RunWorkerCompleted += BgwLoad_RunWorkerCompleted;
            bgwLoad.ProgressChanged += BgwLoad_ProgressChanged;
            bgwLoad.RunWorkerAsync();
        }

        private void BgwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwLoad.ReportProgress(0);
            Thread.Sleep(1000);

            DataLink.Current = new DataLink();
            //DataLink.Current.CheckVersion();

            //bgwLoad.ReportProgress(10);
            //Thread.Sleep(1000);

            try
            {
                DataLink.LoadFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error whilst loading data files. VATGlasses will now close.\n\nFull error log:\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }

            bgwLoad.ReportProgress(33);
            Thread.Sleep(1000);

            try
            {
                DataLink.Current.PullStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error whilst accessing the VATSIM Status API (URL Page). VATGlasses will now close.\n\nFull error log:\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }

            try
            {
                DataLink.Current.Pull();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error whilst loading from the VATSIM Status API (Data Page). VATGlasses will now close.\n\nFull error log:\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }

            bgwLoad.ReportProgress(67);
            Thread.Sleep(1000);

            try
            {
                ThreadStart ts = new ThreadStart(OpenForm);
                Thread t = new Thread(ts);
                t.IsBackground = false;

                try
                {
                    t.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error whilst loading the main UI. VATGlasses will now close.\n\nFull error log:\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error whilst creating the main UI. VATGlasses will now close.\n\nFull error log:\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }
        }

        private void OpenForm()
        {
            Main mainForm = new Main();
            mainForm.Show();
            mainForm.BringToFront();
            Application.Run();
        }

        private void BgwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Value = 100;
            LblProgress.Text = "Loading complete!";
            Thread.Sleep(1000);

            Dispose();
        }

        private void BgwLoad_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                //case 0:
                //    LblProgress.Text = "Checking for updates...";
                //    break;
                case 0:
                    LblProgress.Text = "Loading data files...";
                    break;
                case 33:
                    LblProgress.Text = "Talking to VATSIM...";
                    break;
                case 67:
                    LblProgress.Text = "Loading UI...";
                    break;
            }

            pbProgress.Value = e.ProgressPercentage;
        }
    }
}
