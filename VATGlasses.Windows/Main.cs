using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Globalization;

namespace VATGlasses
{
    public partial class Main : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        Runways rwsWindow = null;
        MapPilotFilters mpfWindow = null;
        MapATCFilters mafWindow = null;
        METARs metWindow = null;
        AirspaceAlert asaWindow = null;
        Settings setWindow = null;
        About abtWindow = null;
        Filter fltWindow = null;

        bool isRunwaysOpen = false;
        bool isMapPilotFiltersOpen = false;
        bool isMapATCFiltersOpen = false;
        bool isMETARsOpen = false;
        bool isAlertsOpen = false;
        bool isSettingsOpen = false;
        bool isAboutOpen = false;
        bool isFiltersOpen = false;

        BackgroundWorker bgwAPI;
        BackgroundWorker bgwPing;

        bool isFIRCheckChanged = false;
        bool isCheckChanged = false;
        bool isPingBusy = false;
        int intSpeedThreshold = 40;
        int intDistanceThreshold = 5;
        bool isMaximised = true;

        Icon icoPlane = new Icon(@"images\plane.ico");
        Bitmap bmpPlane = new Bitmap(Image.FromFile(@"images\plane2.png"), 16, 16);
        //Bitmap bmpBlank =  new Bitmap(Image.FromFile(@"images\Blank.bmp"), 1, 1);
        Bitmap bmpGrey = new Bitmap(Image.FromFile(@"images\Grey.bmp"), 6, 6);
        Bitmap bmpA = new Bitmap(Image.FromFile(@"images\A.bmp"), 12, 12);
        Bitmap bmpD = new Bitmap(Image.FromFile(@"images\D.bmp"), 12, 12);
        Bitmap bmpDA = new Bitmap(Image.FromFile(@"images\DA.bmp"), 12, 24);
        Bitmap bmpG = new Bitmap(Image.FromFile(@"images\G.bmp"), 12, 12);
        Bitmap bmpGA = new Bitmap(Image.FromFile(@"images\GA.bmp"), 12, 24);
        Bitmap bmpGD = new Bitmap(Image.FromFile(@"images\GD.bmp"), 12, 24);
        Bitmap bmpGDA = new Bitmap(Image.FromFile(@"images\GDA.bmp"), 12, 36);
        Bitmap bmpT = new Bitmap(Image.FromFile(@"images\T.bmp"), 12, 12);
        Bitmap bmpTA = new Bitmap(Image.FromFile(@"images\TA.bmp"), 12, 24);
        Bitmap bmpTD = new Bitmap(Image.FromFile(@"images\TD.bmp"), 12, 24);
        Bitmap bmpTDA = new Bitmap(Image.FromFile(@"images\TDA.bmp"), 12, 36);
        Bitmap bmpTG = new Bitmap(Image.FromFile(@"images\TG.bmp"), 12, 24);
        Bitmap bmpTGA = new Bitmap(Image.FromFile(@"images\TGA.bmp"), 12, 36);
        Bitmap bmpTGD = new Bitmap(Image.FromFile(@"images\TGD.bmp"), 12, 36);
        Bitmap bmpTGDA = new Bitmap(Image.FromFile(@"images\TGDA.bmp"), 12, 48);

        NotifyIcon ntfTray;
        ContextMenu cmSettings;
        ColorProfile cp;

        MenuItem runwaysMenuItem = new MenuItem();
        MenuItem displayMenuItem = new MenuItem();
        MenuItem flightsMenuItem = new MenuItem();
        MenuItem iconsMenuItem = new MenuItem();
        MenuItem callsignsMenuItem = new MenuItem();
        MenuItem mapPilotFiltersMenuItem = new MenuItem();
        MenuItem airportsMenuItem = new MenuItem();
        MenuItem iconsMenuItem1 = new MenuItem();
        MenuItem activeMenuItem = new MenuItem();
        MenuItem inactiveWithTrafficMenuItem = new MenuItem();
        MenuItem inactiveNoTrafficMenuItem = new MenuItem();
        MenuItem aTCMenuItem = new MenuItem();
        MenuItem fIRsMenuItem = new MenuItem();
        MenuItem boundariesMenuItem = new MenuItem();
        MenuItem labelsMenuItem = new MenuItem();
        MenuItem aTCSectorsMenuItem = new MenuItem();
        MenuItem approachMenuItem = new MenuItem();
        MenuItem enRouteMenuItem = new MenuItem();
        MenuItem mapATCFiltersMenuItem = new MenuItem();
        MenuItem mETARMenuItem = new MenuItem();
        MenuItem alertsMenuItem = new MenuItem();
        MenuItem hijackMenuItem = new MenuItem();
        MenuItem commsFailureMenuItem = new MenuItem();
        MenuItem emergencyMenuItem = new MenuItem();
        MenuItem approachingAirspaceMenuItem = new MenuItem();
        MenuItem reportBugMenuItem = new MenuItem();
        MenuItem contributeMenuItem = new MenuItem();
        MenuItem settingsMenuItem = new MenuItem();
        MenuItem aboutMenuItem = new MenuItem();

        List<Tuple<GMapPolygon, SolidBrush>> listHighlighted = new List<Tuple<GMapPolygon, SolidBrush>>();

        public Main()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = CultureInfo.InstalledUICulture;

            SetTheme();

            TxtSearch.GotFocus += TxtSearch_RemoveText;
            TxtSearch.LostFocus += TxtSearch_AddText;

            gmcMap.MouseWheel += GmcMap_MouseWheel;

            ntfTray = new NotifyIcon();
            ntfTray.Icon = icoPlane;
            ntfTray.Text = "VATGlasses";
            ntfTray.DoubleClick += NtfTray_DoubleClick;

            pnlControls.MouseMove += pnlControls_MouseMove;
            LblVATGlasses.MouseMove += pnlControls_MouseMove;
            pbSettings.MouseClick += pbSettings_MouseClick;

            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);

            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
            WindowState = FormWindowState.Maximized;
            FormClosing += Main_FormClosing;

            Resize += Main_Resize;

            BtnAirportAdd.Tag = pnlAirport;
            BtnATCAddCID.Tag = BtnATCAddCS.Tag = pnlATC;
            BtnPilotAddCID.Tag = BtnPilotAddCS.Tag = pnlPilot;

            InitializeBackgroundPing();

            SettingsContextMenuSetup();
            ListViewSetup();

            MapInit();
            UpdateAll();
            BackgroundAPI();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (Properties.Settings.Default.MinimiseMode == 1)
                {
                    Hide();
                    ntfTray.Visible = true;
                }
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                isMaximised = true;
            }
            else
            {
                isMaximised = false;
            }
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
            pnlWindow.BackColor = cp.Control;
            pnlMain.BackColor = cp.Control;
            pnlAirport.BackColor = cp.Control;
            pnlATC.BackColor = cp.Control;
            pnlPilot.BackColor = cp.Control;
            pnlSearch.BackColor = cp.Control;
            pnlSectors.BackColor = cp.Control;

            LblVATGlasses.BackColor = cp.Control;
            LblVATGlasses.Image = cp.Logo;

            BtnAirportAdd.BackColor = cp.TransparentControl;
            BtnAirportAdd.ForeColor = cp.Text;
            BtnAirportClose.BackColor = cp.TransparentControl;
            BtnAirportClose.ForeColor = cp.Text;
            BtnAirportMETAR.BackColor = cp.TransparentControl;
            BtnAirportMETAR.ForeColor = cp.Text;
            BtnATCAddCID.BackColor = cp.TransparentControl;
            BtnATCAddCID.ForeColor = cp.Text;
            BtnATCAddCS.BackColor = cp.TransparentControl;
            BtnATCAddCS.ForeColor = cp.Text;
            BtnATCClose.BackColor = cp.TransparentControl;
            BtnATCClose.ForeColor = cp.Text;
            BtnPilotAddCID.BackColor = cp.TransparentControl;
            BtnPilotAddCID.ForeColor = cp.Text;
            BtnPilotAddCS.BackColor = cp.TransparentControl;
            BtnPilotAddCS.ForeColor = cp.Text;
            BtnPilotClose.BackColor = cp.TransparentControl;
            BtnPilotClose.ForeColor = cp.Text;
            BtnSectorsClose.BackColor = cp.TransparentControl;
            BtnSectorsClose.ForeColor = cp.Text;
            BtnZoomIn.BackColor = cp.TransparentControl;
            BtnZoomIn.ForeColor = cp.Text;
            BtnZoomOut.BackColor = cp.TransparentControl;
            BtnZoomOut.ForeColor = cp.Text;

            ssStatus.BackColor = cp.Control;
            tslUpdate.ForeColor = cp.Text;
            tslSpring.ForeColor = cp.Text;
            tslConnections.ForeColor = cp.Text;

            tcMaster.BackColor = cp.Control;
            tpMap.BackColor = cp.Control;
            tpPilots.BackColor = cp.Control;
            tpControllers.BackColor = cp.Control;
            tpServers.BackColor = cp.Control;
            tpAdded.BackColor = cp.Control;

            lvAddedAirports.BackColor = cp.Window;
            lvAddedAirports.ForeColor = cp.Text;
            lvAddedCallsigns.BackColor = cp.Window;
            lvAddedCallsigns.ForeColor = cp.Text;
            lvAddedCIDs.BackColor = cp.Window;
            lvAddedCIDs.ForeColor = cp.Text;
            lvAirportArrivals.BackColor = cp.Window;
            lvAirportArrivals.ForeColor = cp.Text;
            lvAirportControllers.BackColor = cp.Window;
            lvAirportControllers.ForeColor = cp.Text;
            lvAirportDepartures.BackColor = cp.Window;
            lvAirportDepartures.ForeColor = cp.Text;
            lvControllers.BackColor = cp.Window;
            lvControllers.ForeColor = cp.Text;
            lvObservers.BackColor = cp.Window;
            lvObservers.ForeColor = cp.Text;
            lvPilots.BackColor = cp.Window;
            lvPilots.ForeColor = cp.Text;
            lvPrefiles.BackColor = cp.Window;
            lvPrefiles.ForeColor = cp.Text;
            lvServers.BackColor = cp.Window;
            lvServers.ForeColor = cp.Text;

            pbClose.Image = cp.Close;
            pbResize.Image = cp.Maximise;
            pbMinimise.Image = cp.Minimise;
            pbRefresh.Image = cp.Refresh;
            pbSettings.Image = cp.Settings;
            pbSearch.Image = cp.Search;
            pbFilter.Image = cp.Filter;

            LblAirportICAO.ForeColor = cp.Text;
            LblAirportName.ForeColor = cp.Text;
            LblArrivals.ForeColor = cp.Text;
            LblATCTitle.ForeColor = cp.Text;
            LblATIS.ForeColor = cp.Text;
            LblATISInfo.ForeColor = cp.Text;
            LblCallsign.ForeColor = cp.Text;
            LblControllers.ForeColor = cp.Text;
            LblDepartures.ForeColor = cp.Text;
            LblFreq.ForeColor = cp.Text;
            LblFreqInfo.ForeColor = cp.Text;
            LblLogon.ForeColor = cp.Text;
            LblLogonInfo.ForeColor = cp.Text;
            LblNameCID.ForeColor = cp.Text;
            LblOnline.ForeColor = cp.Text;
            LblOnlineInfo.ForeColor = cp.Text;
            LblPilotAC.ForeColor = cp.Text;
            LblPilotACInfo.ForeColor = cp.Text;
            LblPilotAlt.ForeColor = cp.Text;
            LblPilotAltInfo.ForeColor = cp.Text;
            LblPilotArr.ForeColor = cp.Text;
            LblPilotArrInfo.ForeColor = cp.Text;
            LblPilotCallsign.ForeColor = cp.Text;
            LblPilotDep.ForeColor = cp.Text;
            LblPilotDepInfo.ForeColor = cp.Text;
            LblPilotDistance.ForeColor = cp.Text;
            LblPilotDistanceInfo.ForeColor = cp.Text;
            LblPilotEnroute.ForeColor = cp.Text;
            LblPilotEnrouteInfo.ForeColor = cp.Text;
            LblPilotETA.ForeColor = cp.Text;
            LblPilotETAInfo.ForeColor = cp.Text;
            LblPilotETE.ForeColor = cp.Text;
            LblPilotETEInfo.ForeColor = cp.Text;
            LblPilotFlight.ForeColor = cp.Text;
            LblPilotGS.ForeColor = cp.Text;
            LblPilotGSInfo.ForeColor = cp.Text;
            LblPilotHDG.ForeColor = cp.Text;
            LblPilotHDGInfo.ForeColor = cp.Text;
            LblPilotLat.ForeColor = cp.Text;
            LblPilotLatInfo.ForeColor = cp.Text;
            LblPilotLon.ForeColor = cp.Text;
            LblPilotLonInfo.ForeColor = cp.Text;
            LblPilotName.ForeColor = cp.Text;
            LblPilotOnline.ForeColor = cp.Text;
            LblPilotOnlineInfo.ForeColor = cp.Text;
            LblPilotRemaining.ForeColor = cp.Text;
            LblPilotRemainingInfo.ForeColor = cp.Text;
            LblPilotSector.ForeColor = cp.Text;
            LblPilotSectorInfo.ForeColor = cp.Text;
            LblPilotServer.ForeColor = cp.Text;
            LblPilotServerInfo.ForeColor = cp.Text;
            LblPilotXPDR.ForeColor = cp.Text;
            LblPilotXPDRInfo.ForeColor = cp.Text;
            LblRatingInfo.ForeColor = cp.Text;
            LblSearchClose.ForeColor = cp.Text;
            LblSearchTitle.ForeColor = cp.Text;
            LblSectorInfo.ForeColor = cp.Text;
            LblSectors.ForeColor = cp.Text;
            LblServer.ForeColor = cp.Text;
            LblServerInfo.ForeColor = cp.Text;
            LblSpoken.ForeColor = cp.Text;
            LblTopDown.ForeColor = cp.Text;
            LblVATGlasses.ForeColor = cp.Text;

            TxtPilotRoute.BackColor = cp.Control;
            TxtPilotRoute.ForeColor = cp.Text;

            TxtPilotRemarks.BackColor = cp.Control;
            TxtPilotRemarks.ForeColor = cp.Text;

            LblPilotSectorInfo.BackColor = cp.Control;

            TxtSearch.BackColor = cp.Window;
            TxtSearch.ForeColor = cp.Text;

            gbAddedAirports.ForeColor = cp.Text;
            gbAddedCallsigns.ForeColor = cp.Text;
            gbAddedCIDs.ForeColor = cp.Text;
            gbControllers.ForeColor = cp.Text;
            gbObservers.ForeColor = cp.Text;
            gbPilotInfo.ForeColor = cp.Text;
            gbPilotPlan.ForeColor = cp.Text;
            gbPilotRoute.BackColor = cp.Control;
            gbPilotRoute.ForeColor = cp.Text;
            gbPilotRemarks.BackColor = cp.Control;
            gbPilotRemarks.ForeColor = cp.Text;
            gbPilots.ForeColor = cp.Text;
            gbPilotStatus.ForeColor = cp.Text;
            gbPrefiles.ForeColor = cp.Text;
        }

        private void SettingsContextMenuSetup()
        {
            // 
            // runwaysMenuItem
            // 
            this.runwaysMenuItem.Name = "runwaysMenuItem";
            this.runwaysMenuItem.Text = "Runways";
            this.runwaysMenuItem.Click += new System.EventHandler(this.runwaysMenuItem_Click);
            // 
            // displayMenuItem
            // 
            this.displayMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.flightsMenuItem,
            this.airportsMenuItem,
            this.fIRsMenuItem,
            this.aTCSectorsMenuItem});
            this.displayMenuItem.Name = "displayMenuItem";
            this.displayMenuItem.Text = "Display";
            // 
            // flightsMenuItem
            // 
            this.flightsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.iconsMenuItem,
            this.callsignsMenuItem,
            this.mapPilotFiltersMenuItem});
            this.flightsMenuItem.Name = "flightsMenuItem";
            this.flightsMenuItem.Text = "Flights";
            // 
            // iconsMenuItem
            // 
            this.iconsMenuItem.Name = "iconsMenuItem";
            this.iconsMenuItem.Text = "Icons";
            // 
            // callsignsMenuItem
            // 
            this.callsignsMenuItem.Name = "callsignsMenuItem";
            this.callsignsMenuItem.Text = "Callsigns";
            // 
            // mapPilotFiltersMenuItem
            // 
            this.mapPilotFiltersMenuItem.Name = "mapPilotFiltersMenuItem";
            this.mapPilotFiltersMenuItem.Text = "Advanced Filters";
            this.mapPilotFiltersMenuItem.Click += new System.EventHandler(this.mapPilotFiltersMenuItem_Click);
            // 
            // airportsMenuItem
            // 
            this.airportsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.iconsMenuItem1,
            this.aTCMenuItem});
            this.airportsMenuItem.Name = "airportsMenuItem";
            this.airportsMenuItem.Text = "Airports";
            // 
            // iconsMenuItem1
            // 
            this.iconsMenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.activeMenuItem,
            this.inactiveWithTrafficMenuItem,
            this.inactiveNoTrafficMenuItem});
            this.iconsMenuItem1.Name = "iconsMenuItem1";
            this.iconsMenuItem1.Text = "Icons";
            // 
            // activeMenuItem
            // 
            this.activeMenuItem.Name = "activeMenuItem";
            this.activeMenuItem.Text = "Active";
            // 
            // inactiveWithTrafficMenuItem
            // 
            this.inactiveWithTrafficMenuItem.Name = "inactiveWithTrafficMenuItem";
            this.inactiveWithTrafficMenuItem.Text = "Inactive (With Traffic)";
            // 
            // inactiveNoTrafficMenuItem
            this.inactiveNoTrafficMenuItem.Name = "inactiveNoTrafficMenuItem";
            this.inactiveNoTrafficMenuItem.Text = "Inactive (No Traffic)";
            // 
            // aTCMenuItem
            // 
            this.aTCMenuItem.Name = "aTCMenuItem";
            this.aTCMenuItem.Text = "ATC";
            // 
            // fIRsMenuItem
            // 
            this.fIRsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.boundariesMenuItem,
            this.labelsMenuItem});
            this.fIRsMenuItem.Name = "fIRsMenuItem";
            this.fIRsMenuItem.Text = "FIRs";
            // 
            // boundariesMenuItem
            // 
            this.boundariesMenuItem.Name = "boundariesMenuItem";
            this.boundariesMenuItem.Text = "Boundaries";
            // 
            // labelsMenuItem
            // 
            this.labelsMenuItem.Name = "labelsMenuItem";
            this.labelsMenuItem.Text = "Labels";
            // 
            // aTCSectorsMenuItem
            // 
            this.aTCSectorsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.approachMenuItem,
            this.enRouteMenuItem,
            this.mapATCFiltersMenuItem});
            this.aTCSectorsMenuItem.Name = "aTCSectorsMenuItem";
            this.aTCSectorsMenuItem.Text = "ATC Sectors";
            // 
            // approachMenuItem
            // 
            this.approachMenuItem.Name = "approachMenuItem";
            this.approachMenuItem.Text = "Approach";
            // 
            // enRouteMenuItem
            // 
            this.enRouteMenuItem.Name = "enRouteMenuItem";
            this.enRouteMenuItem.Text = "En-Route";
            // 
            // mapATCFiltersMenuItem
            // 
            this.mapATCFiltersMenuItem.Name = "mapATCFiltersMenuItem";
            this.mapATCFiltersMenuItem.Text = "Advanced Filters";
            this.mapATCFiltersMenuItem.Click += new System.EventHandler(this.mapATCFiltersMenuItem_Click);
            // 
            // mETARMenuItem
            // 
            this.mETARMenuItem.Name = "mETARMenuItem";
            this.mETARMenuItem.Text = "METAR";
            this.mETARMenuItem.Click += new System.EventHandler(this.mETARMenuItem_Click);
            // 
            // alertsMenuItem
            // 
            this.alertsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.hijackMenuItem,
            this.commsFailureMenuItem,
            this.emergencyMenuItem,
            this.approachingAirspaceMenuItem});
            this.alertsMenuItem.Name = "alertsMenuItem";
            this.alertsMenuItem.Text = "Alerts";
            // 
            // hijackMenuItem
            // 
            this.hijackMenuItem.Name = "hijackMenuItem";
            this.hijackMenuItem.Text = "Hijack";
            // 
            // commsFailureMenuItem
            // 
            this.commsFailureMenuItem.Name = "commsFailureMenuItem";
            this.commsFailureMenuItem.Text = "Comms Failure";
            // 
            // emergencyMenuItem
            // 
            this.emergencyMenuItem.Name = "emergencyMenuItem";
            this.emergencyMenuItem.Text = "Emergency";
            // 
            // approachingAirspaceMenuItem
            // 
            this.approachingAirspaceMenuItem.Name = "approachingAirspaceMenuItem";
            this.approachingAirspaceMenuItem.Text = "Approaching Airspace";
            this.approachingAirspaceMenuItem.Click += new System.EventHandler(this.approachingAirspaceMenuItem_Click);
            // 
            // reportBugMenuItem
            // 
            this.reportBugMenuItem.Name = "reportBugMenuItem";
            this.reportBugMenuItem.Text = "Report Bug";
            this.reportBugMenuItem.Click += new System.EventHandler(this.reportBugMenuItem_Click);
            // 
            // contributeMenuItem
            // 
            this.contributeMenuItem.Name = "contributeMenuItem";
            this.contributeMenuItem.Text = "Contribute";
            this.contributeMenuItem.Click += new System.EventHandler(this.contributeMenuItem_Click);
            //
            // settingsMenuItem
            //
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Text = "Settings";
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);

            iconsMenuItem.Click += DropDown_Click;
            iconsMenuItem.Checked = Properties.Settings.Default.MapFlightIcon;

            callsignsMenuItem.Click += DropDown_Click;
            callsignsMenuItem.Checked = Properties.Settings.Default.MapFlightCallsign;

            activeMenuItem.Click += DropDown_Click;
            activeMenuItem.Checked = Properties.Settings.Default.MapAirportActive;

            inactiveWithTrafficMenuItem.Click += DropDown_Click;
            inactiveWithTrafficMenuItem.Checked = Properties.Settings.Default.MapAirportInWith;

            inactiveNoTrafficMenuItem.Click += DropDown_Click;
            inactiveNoTrafficMenuItem.Checked = Properties.Settings.Default.MapAirportInNo;

            aTCMenuItem.Click += DropDown_Click;
            aTCMenuItem.Checked = Properties.Settings.Default.MapAirportATC;

            boundariesMenuItem.Click += FIRDropDown_Click;
            boundariesMenuItem.Checked = Properties.Settings.Default.MapFIRBound;

            labelsMenuItem.Click += FIRDropDown_Click;
            labelsMenuItem.Checked = Properties.Settings.Default.MapFIRLabel;

            approachMenuItem.Click += DropDown_Click;
            approachMenuItem.Checked = Properties.Settings.Default.MapATCApp;

            enRouteMenuItem.Click += DropDown_Click;
            enRouteMenuItem.Checked = Properties.Settings.Default.MapATCEnr;

            hijackMenuItem.Click += NotificationSetting_Click;
            hijackMenuItem.Checked = Properties.Settings.Default.AlertHijack;

            commsFailureMenuItem.Click += NotificationSetting_Click;
            commsFailureMenuItem.Checked = Properties.Settings.Default.AlertComms;

            emergencyMenuItem.Click += NotificationSetting_Click;
            emergencyMenuItem.Checked = Properties.Settings.Default.AlertEmergency;

            cmSettings = new ContextMenu();
            cmSettings.MenuItems.Add(runwaysMenuItem);
            cmSettings.MenuItems.Add(displayMenuItem);
            cmSettings.MenuItems.Add(mETARMenuItem);
            cmSettings.MenuItems.Add(alertsMenuItem);
            cmSettings.MenuItems.Add(reportBugMenuItem);
            cmSettings.MenuItems.Add(contributeMenuItem);
            cmSettings.MenuItems.Add(settingsMenuItem);
            cmSettings.MenuItems.Add(aboutMenuItem);
            pbSettings.ContextMenu = cmSettings;
        }

        private void pbSettings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pbSettings.ContextMenu.Show(pbSettings, new Point(e.X, e.Y), LeftRightAlignment.Right);
            }
        }

        protected override void OnPaint(PaintEventArgs e) // you can safely omit this method if you want
        {
            e.Graphics.FillRectangle(new SolidBrush(cp.Control), rctTop);
            e.Graphics.FillRectangle(new SolidBrush(cp.Control), rctLeft);
            e.Graphics.FillRectangle(new SolidBrush(cp.Control), rctRight);
            e.Graphics.FillRectangle(new SolidBrush(cp.Control), rctBottom);
        }

        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        const int _ = 10; // you can rename this variable if you like

        Rectangle rctTop { get { return new Rectangle(0, 0, ClientSize.Width, _); } }
        Rectangle rctLeft { get { return new Rectangle(0, 0, _, ClientSize.Height); } }
        Rectangle rctBottom { get { return new Rectangle(0, ClientSize.Height - _, ClientSize.Width, _); } }
        Rectangle rctRight { get { return new Rectangle(ClientSize.Width - _, 0, _, ClientSize.Height); } }

        Rectangle rctTopLeft { get { return new Rectangle(0, 0, _, _); } }
        Rectangle rctTopRight { get { return new Rectangle(ClientSize.Width - _, 0, _, _); } }
        Rectangle rctBottomLeft { get { return new Rectangle(0, ClientSize.Height - _, _, _); } }
        Rectangle rctBottomRight { get { return new Rectangle(ClientSize.Width - _, ClientSize.Height - _, _, _); } }


        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (WindowState != FormWindowState.Maximized && message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = PointToClient(Cursor.Position);

                if (rctTopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (rctTopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (rctBottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (rctBottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (rctTop.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (rctLeft.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (rctRight.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (rctBottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }

        private void pnlControls_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void NtfTray_DoubleClick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MinimiseMode == 1 || WindowState == FormWindowState.Minimized)
            {
                Show();

                if (isMaximised)
                {
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                }
            }

            Focus();
        }

        private void InitializeBackgroundPing()
        {
            bgwPing = new BackgroundWorker();
            bgwPing.DoWork += BgwPing_DoWork;
            bgwPing.RunWorkerCompleted += BgwPing_RunWorkerCompleted;
        }

        private void BgwPing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Tuple<Server, ListViewColumnMouseEventArgs> tupData = (Tuple<Server, ListViewColumnMouseEventArgs>)e.Result;

            for (int i = 0; i < 5; i++)
            {
                if (tupData.Item1.longarrPing[i] == -1)
                {
                    tupData.Item2.Item.SubItems[i + 6].Text = "Fail";
                }
                else
                {
                    tupData.Item2.Item.SubItems[i + 6].Text = tupData.Item1.longarrPing[i].ToString("####");
                }
            }

            isPingBusy = false;
        }

        private void BgwPing_DoWork(object sender, DoWorkEventArgs e)
        {
            Tuple<Server, ListViewColumnMouseEventArgs> tupData = (Tuple<Server, ListViewColumnMouseEventArgs>)e.Argument;

            tupData.Item1.isPinging = true;
            tupData.Item1.longarrPing = new long[5];

            for (int i = 0; i < 5; i++)
            {
                Ping ping = new Ping();

                PingReply result = ping.Send(tupData.Item1.ipAddress);

                if (result.Status == IPStatus.Success)
                {
                    tupData.Item1.longarrPing[i] = result.RoundtripTime;
                }
                else
                {
                    tupData.Item1.longarrPing[i] = -1;
                }
            }

            e.Result = tupData;
            tupData.Item1.isPinging = false;
        }

        private void NotificationSetting_Click(object sender, EventArgs e)
        {
            CheckMenuItem((MenuItem)sender);
        }

        private void CheckMenuItem(MenuItem _sender)
        {
            if (_sender.Checked)
            {
                _sender.Checked = false;
            }
            else
            {
                _sender.Checked = true;
            }
        }

        private void AlertsDropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
            else
            {
                Properties.Settings.Default.AlertHijack = hijackMenuItem.Checked;
                Properties.Settings.Default.AlertComms = commsFailureMenuItem.Checked;
                Properties.Settings.Default.AlertEmergency = emergencyMenuItem.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void BackgroundAPI()
        {
            bgwAPI = new BackgroundWorker();
            bgwAPI.DoWork += BgwAPI_DoWork;
            bgwAPI.RunWorkerCompleted += BgwAPI_RunWorkerCompleted;
            bgwAPI.WorkerSupportsCancellation = true;
            bgwAPI.RunWorkerAsync();
        }

        private void BgwAPI_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateAll();
            bgwAPI.RunWorkerAsync();
        }

        private void BgwAPI_DoWork(object sender, DoWorkEventArgs e)
        {
            int intSleepSeconds = (int)Math.Round(DataLink.Current.decReload * 60);
            int i = 0;

            while (!e.Cancel && i < 1000 * intSleepSeconds)
            {
                System.Threading.Thread.Sleep(1);

                if (bgwAPI.CancellationPending)
                {
                    e.Cancel = true;
                }
            }

            DataLink.Current.Pull();
        }

        private void ListViewSetup()
        {
            //Pilots Tab - Pilots
            lvPilots.View = View.Details;
            lvPilots.ShowGroups = false;
            lvPilots.GridLines = true;
            lvPilots.ColumnClick += Lv_ColumnClick;

            lvPilots.Columns.Clear();
            lvPilots.Columns.Add("Callsign", -2, HorizontalAlignment.Center);
            lvPilots.Columns.Add("CID", -2, HorizontalAlignment.Center);
            lvPilots.Columns.Add("Name", -2, HorizontalAlignment.Center);
            lvPilots.Columns.Add("Departure Airport", -2, HorizontalAlignment.Center);
            lvPilots.Columns.Add("Arrival Airport", -2, HorizontalAlignment.Center);
            lvPilots.Columns.Add("Time Online", -2, HorizontalAlignment.Center);
            lvPilots.Columns.Add("", -2, HorizontalAlignment.Center);

            //Pilots Tab - Prefiles
            lvPrefiles.View = View.Details;
            lvPrefiles.ShowGroups = false;
            lvPrefiles.GridLines = true;
            lvPrefiles.ColumnClick += Lv_ColumnClick;

            lvPrefiles.Columns.Clear();
            lvPrefiles.Columns.Add("Callsign", -2, HorizontalAlignment.Center);
            lvPrefiles.Columns.Add("CID", -2, HorizontalAlignment.Center);
            lvPrefiles.Columns.Add("Departure Airport", -2, HorizontalAlignment.Center);
            lvPrefiles.Columns.Add("Arrival Airport", -2, HorizontalAlignment.Center);
            lvPrefiles.Columns.Add("", -2, HorizontalAlignment.Center);

            //Controllers Tab - Controllers
            lvControllers.View = View.Details;
            lvControllers.ShowGroups = false;
            lvControllers.GridLines = true;
            lvControllers.ColumnClick += Lv_ColumnClick;

            lvControllers.Columns.Clear();
            lvControllers.Columns.Add("Callsign", -2, HorizontalAlignment.Center);
            lvControllers.Columns.Add("Frequency", -2, HorizontalAlignment.Center);
            lvControllers.Columns.Add("CID", -2, HorizontalAlignment.Center);
            lvControllers.Columns.Add("Name", -2, HorizontalAlignment.Center);
            lvControllers.Columns.Add("Rating", -2, HorizontalAlignment.Center);
            lvControllers.Columns.Add("Facility", -2, HorizontalAlignment.Center);
            lvControllers.Columns.Add("Position", -2, HorizontalAlignment.Center);
            lvControllers.Columns.Add("Time Online", -2, HorizontalAlignment.Center);
            lvControllers.Columns.Add("", -2, HorizontalAlignment.Center);

            //Observers Tab - Observers
            lvObservers.View = View.Details;
            lvObservers.ShowGroups = false;
            lvObservers.GridLines = true;
            lvObservers.ColumnClick += Lv_ColumnClick;

            lvObservers.Columns.Clear();
            lvObservers.Columns.Add("Callsign", -2, HorizontalAlignment.Center);
            lvObservers.Columns.Add("CID", -2, HorizontalAlignment.Center);
            lvObservers.Columns.Add("Name", -2, HorizontalAlignment.Center);
            lvObservers.Columns.Add("Rating", -2, HorizontalAlignment.Center);
            lvObservers.Columns.Add("Time Online", -2, HorizontalAlignment.Center);
            lvObservers.Columns.Add("", -2, HorizontalAlignment.Center);

            //Servers Tab
            lvServers.View = View.Details;
            lvServers.ShowGroups = false;
            lvServers.GridLines = true;
            lvServers.ColumnClick += Lv_ColumnClick;

            lvServers.Columns.Clear();
            lvServers.Columns.Add("Identifier", -2, HorizontalAlignment.Center);
            lvServers.Columns.Add("Name", -2, HorizontalAlignment.Center);
            lvServers.Columns.Add("Location", -2, HorizontalAlignment.Center);
            lvServers.Columns.Add("IP Address", -2, HorizontalAlignment.Center);
            lvServers.Columns.Add("Online?", -2, HorizontalAlignment.Center);
            lvServers.Columns.Add("Ping", -2, HorizontalAlignment.Center);
            lvServers.Columns.Add("", 30, HorizontalAlignment.Center);
            lvServers.Columns.Add("", 30, HorizontalAlignment.Center);
            lvServers.Columns.Add("", 30, HorizontalAlignment.Center);
            lvServers.Columns.Add("", 30, HorizontalAlignment.Center);
            lvServers.Columns.Add("", 30, HorizontalAlignment.Center);
            lvServers.Columns.Add("", -2, HorizontalAlignment.Center);

            ListViewExtender lvePing = new ListViewExtender(lvServers);
            ListViewButtonColumn buttonPingServer = new ListViewButtonColumn(5);
            buttonPingServer.Click += PingServer;
            buttonPingServer.FixedWidth = true;
            lvePing.AddColumn(buttonPingServer);

            //Airport Panel - Controllers
            lvAirportControllers.View = View.Details;
            lvAirportControllers.ShowGroups = false;
            lvAirportControllers.GridLines = true;
            lvAirportControllers.ColumnClick += Lv_ColumnClick;

            lvAirportControllers.Columns.Clear();
            lvAirportControllers.Columns.Add("Callsign", -2, HorizontalAlignment.Center);
            lvAirportControllers.Columns.Add("Frequency", -2, HorizontalAlignment.Center);
            lvAirportControllers.Columns.Add("Position", -2, HorizontalAlignment.Center);
            lvAirportControllers.Columns.Add("Details", -2, HorizontalAlignment.Center);
            lvAirportControllers.DoubleClick += lvAirportControllers_DoubleClick;

            //Airport Panel - Departures
            lvAirportDepartures.View = View.Details;
            lvAirportDepartures.ShowGroups = false;
            lvAirportDepartures.GridLines = true;
            lvAirportDepartures.ColumnClick += Lv_ColumnClick;

            lvAirportDepartures.Columns.Clear();
            lvAirportDepartures.Columns.Add("Callsign", -2, HorizontalAlignment.Center);
            lvAirportDepartures.Columns.Add("CID", -2, HorizontalAlignment.Center);
            lvAirportDepartures.Columns.Add("Name", -2, HorizontalAlignment.Center);
            lvAirportDepartures.Columns.Add("Destination", -2, HorizontalAlignment.Center);
            lvAirportDepartures.DoubleClick += lvAirportDepartures_DoubleClick;

            //Airport Panel - Arrivals
            lvAirportArrivals.View = View.Details;
            lvAirportArrivals.ShowGroups = false;
            lvAirportArrivals.GridLines = true;
            lvAirportArrivals.ColumnClick += Lv_ColumnClick;

            lvAirportArrivals.Columns.Clear();
            lvAirportArrivals.Columns.Add("Callsign", -2, HorizontalAlignment.Center);
            lvAirportArrivals.Columns.Add("CID", -2, HorizontalAlignment.Center);
            lvAirportArrivals.Columns.Add("Name", -2, HorizontalAlignment.Center);
            lvAirportArrivals.Columns.Add("Departure", -2, HorizontalAlignment.Center);
            lvAirportArrivals.DoubleClick += lvAirportArrivals_DoubleClick;

            //Added Panel - Airports
            lvAddedAirports.View = View.Details;
            lvAddedAirports.ShowGroups = false;
            lvAddedAirports.GridLines = true;
            lvAddedAirports.ColumnClick += Lv_ColumnClick;

            lvAddedAirports.Columns.Clear();
            lvAddedAirports.Columns.Add("ICAO", -2, HorizontalAlignment.Center);
            lvAddedAirports.Columns.Add("Name", -2, HorizontalAlignment.Center);
            lvAddedAirports.Columns.Add("Latitude", -2, HorizontalAlignment.Center);
            lvAddedAirports.Columns.Add("Longitude", -2, HorizontalAlignment.Center);
            lvAddedAirports.Columns.Add("Remove", 75, HorizontalAlignment.Center);
            lvAddedAirports.Columns.Add("Details", -2, HorizontalAlignment.Center);

            ListViewExtender lveAirports = new ListViewExtender(lvAddedAirports);
            ListViewButtonColumn buttonRemoveAirport = new ListViewButtonColumn(4);
            buttonRemoveAirport.Click += RemoveFavAirport;
            buttonRemoveAirport.FixedWidth = true;
            lveAirports.AddColumn(buttonRemoveAirport);

            //Added Panel - Callsigns
            lvAddedCallsigns.View = View.Details;
            lvAddedCallsigns.ShowGroups = false;
            lvAddedCallsigns.GridLines = true;
            lvAddedCallsigns.ColumnClick += Lv_ColumnClick;

            lvAddedCallsigns.Columns.Clear();
            lvAddedCallsigns.Columns.Add("Callsign", -2, HorizontalAlignment.Center);
            lvAddedCallsigns.Columns.Add("CID", -2, HorizontalAlignment.Center);
            lvAddedCallsigns.Columns.Add("Name", -2, HorizontalAlignment.Center);
            lvAddedCallsigns.Columns.Add("Remove", 75, HorizontalAlignment.Center);
            lvAddedCallsigns.Columns.Add("Details", -2, HorizontalAlignment.Center);

            ListViewExtender lveCallsigns = new ListViewExtender(lvAddedCallsigns);
            ListViewButtonColumn buttonRemoveCallsign = new ListViewButtonColumn(3);
            buttonRemoveCallsign.Click += RemoveFavCallsign;
            buttonRemoveCallsign.FixedWidth = true;
            lveCallsigns.AddColumn(buttonRemoveCallsign);

            //Added Panel - CIDs
            lvAddedCIDs.View = View.Details;
            lvAddedCIDs.ShowGroups = false;
            lvAddedCIDs.GridLines = true;
            lvAddedCIDs.ColumnClick += Lv_ColumnClick;

            lvAddedCIDs.Columns.Clear();
            lvAddedCIDs.Columns.Add("Callsign", -2, HorizontalAlignment.Center);
            lvAddedCIDs.Columns.Add("CID", -2, HorizontalAlignment.Center);
            lvAddedCIDs.Columns.Add("Name", -2, HorizontalAlignment.Center);
            lvAddedCIDs.Columns.Add("Remove", 75, HorizontalAlignment.Center);
            lvAddedCIDs.Columns.Add("Details", -2, HorizontalAlignment.Center);

            ListViewExtender lveCIDs = new ListViewExtender(lvAddedCIDs);
            ListViewButtonColumn buttonRemoveCID = new ListViewButtonColumn(3);
            buttonRemoveCID.Click += RemoveFavCID;
            buttonRemoveCID.FixedWidth = true;
            lveCIDs.AddColumn(buttonRemoveCID);
        }

        private void PingServer(object sender, ListViewColumnMouseEventArgs e)
        {
            if (isPingBusy)
            {
                MessageBox.Show("Please wait for the current ping operation to complete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Tuple<Server, ListViewColumnMouseEventArgs> tupData = new Tuple<Server, ListViewColumnMouseEventArgs>((Server)e.Item.Tag, e);
                if (!tupData.Item1.isPinging)
                {
                    isPingBusy = true;
                    bgwPing.RunWorkerAsync(tupData);
                }
            }
        }

        private void ViewControllerDetails(object sender, ListViewColumnMouseEventArgs e)
        {
            ListView lvTemp = e.Item.ListView;
            ListViewItem lviTemp = e.Item;

            if (lviTemp.Tag != null)
            {
                OpenATCPanel((Controller)lviTemp.Tag);
            }
        }

        private void RemoveFavAirport(object sender, ListViewColumnMouseEventArgs e)
        {
            ListView lvTemp = e.Item.ListView;
            ListViewItem lviTemp = e.Item;
            Airport apFav = (Airport)lviTemp.Tag;

            apFav.RemoveFav();
            lvTemp.Items.Remove(lviTemp);
        }

        private void RemoveFavCallsign(object sender, ListViewColumnMouseEventArgs e)
        {
            ListView lvTemp = e.Item.ListView;
            ListViewItem lviTemp = e.Item;
            FavClient fvcClient = (FavClient)lviTemp.Tag;

            fvcClient.RemoveCallsign();
            LoadPilots();
            LoadATC();
            lvTemp.Items.Remove(lviTemp);
        }

        private void RemoveFavCID(object sender, ListViewColumnMouseEventArgs e)
        {
            ListView lvTemp = e.Item.ListView;
            ListViewItem lviTemp = e.Item;
            FavClient fvcClient = (FavClient)lviTemp.Tag;

            fvcClient.RemoveCID();
            LoadPilots();
            LoadATC();
            lvTemp.Items.Remove(lviTemp);
        }

        private void Lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lvSender = (ListView)sender;
            lvSender.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        private void UpdateAll()
        {
            LoadPilots();
            LoadPrefiles();
            LoadATC();
            LoadObs();
            LoadServers();
            LoadAdded();
            MapUpdate();

            if (hijackMenuItem.Checked)
            {
                for (int i = 0; i < Pilot.list7500.Count; i++)
                {
                    if (Pilot.list7500[i].Item2 == true)
                    {
                        ntfTray.ShowBalloonTip(15000, "Hijack", Pilot.list7500[i].Item1 + " is squawking 7500.", ToolTipIcon.Info);
                        Pilot.list7500[i] = (Pilot.list7500[i].Item1, false);
                    }
                }
            }

            if (commsFailureMenuItem.Checked)
            {
                for (int i = 0; i < Pilot.list7600.Count; i++)
                {
                    if (Pilot.list7600[i].Item2 == true)
                    {
                        ntfTray.ShowBalloonTip(15000, "Comms Failure", Pilot.list7600[i].Item1 + " is squawking 7600.", ToolTipIcon.Info);
                        Pilot.list7600[i] = (Pilot.list7600[i].Item1, false);
                    }
                }
            }

            if (emergencyMenuItem.Checked)
            {
                for (int i = 0; i < Pilot.list7700.Count; i++)
                {
                    if (Pilot.list7700[i].Item2 == true)
                    {
                        ntfTray.ShowBalloonTip(15000, "Emergency", Pilot.list7700[i].Item1 + " is squawking 7700.", ToolTipIcon.Info);
                        Pilot.list7700[i] = (Pilot.list7700[i].Item1, false);
                    }
                }
            }
        }

        private void MapInit()
        {
            GMapProvider.UserAgent = "VATGlasses Maps for VATSIM " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            gmcMap.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gmcMap.OnMapZoomChanged += GmcMap_OnMapZoomChanged;
            gmcMap.DragButton = MouseButtons.Left;

            if (Properties.Settings.Default.ZoomMode == 0)
            {
                gmcMap.MouseWheelZoomEnabled = false;
            }
            else if (Properties.Settings.Default.ZoomMode == 1)
            {
                gmcMap.MouseWheelZoomEnabled = true;
                gmcMap.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            }
            else if (Properties.Settings.Default.ZoomMode == 2)
            {
                gmcMap.MouseWheelZoomEnabled = true;
                gmcMap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            }

            gmcMap.IgnoreMarkerOnMouseWheel = true;
            gmcMap.MouseClick += GmcMap_MouseClick;
            gmcMap.DisableFocusOnMouseEnter = true;
            gmcMap.ShowCenter = false;
            gmcMap.MaxZoom = 18;
            gmcMap.MinZoom = 2;
            gmcMap.OnMapClick += GmcMap_OnMapClick;
            gmcMap.OnMarkerClick += GmcMap_OnMarkerClick;
            gmcMap.Zoom = 3;
            gmcMap.Overlays.Clear();

            gmcMap.Overlays.Add(new GMapOverlay("firs"));
            List<GMapPolygon> listPolygons = new List<GMapPolygon>();

            if (boundariesMenuItem.Checked || labelsMenuItem.Checked)
            {
                foreach (FIR firFir in FIR.list)
                {
                    if (boundariesMenuItem.Checked)
                    {
                        List<PointLatLng> listPoints = new List<PointLatLng>();

                        foreach (double[] dblDbl in firFir.listVertices)
                        {
                            listPoints.Add(new PointLatLng(dblDbl[0], dblDbl[1]));
                        }

                        GMapPolygon plyTemp = new GMapPolygon(listPoints, firFir.strIdent);
                        plyTemp.Fill = new SolidBrush(Color.Transparent);
                        plyTemp.Stroke = new Pen(new SolidBrush(Color.Gray), (float)0.01);
                        plyTemp.Tag = firFir;

                        listPolygons.Add(plyTemp);
                        gmcMap.Overlays[0].Polygons.Add(plyTemp);
                    }

                    if (labelsMenuItem.Checked && !firFir.isExtension)
                    {
                        string strOceanic = "";

                        if (firFir.isOceanic)
                        {
                            strOceanic += " Oceanic";
                        }

                        Point offset = new Point(0, 0); // the offset of the marker
                        GMarkerCross crtMarker = new GMarkerCross(new PointLatLng(firFir.dblCentreLat, firFir.dblCentreLon)); // position of the marker
                        crtMarker.Pen = new Pen(Color.Transparent); // marker has lines, draw them with transparent color (i.e., not show them)
                        crtMarker.ToolTipText = firFir.strIdent + strOceanic; // marker's text is the property
                        crtMarker.IsVisible = true; // marker visible
                        crtMarker.ToolTipMode = MarkerTooltipMode.Always; // marker always show its tooltip
                        crtMarker.ToolTip.Offset = offset; // move the tooltip to the appro. center of the cell
                        crtMarker.ToolTip.Fill = new SolidBrush(Color.Transparent); // the marker's text is in a box, make the box transparent
                        crtMarker.ToolTip.Stroke.Color = Color.Transparent; // no border for the marker's box
                        crtMarker.ToolTip.Foreground = new SolidBrush(Color.Gray); // marker's text colour
                        crtMarker.ToolTip.Font = new Font(crtMarker.ToolTip.Font, FontStyle.Bold); // make marker font bold

                        gmcMap.Overlays[0].Markers.Add(crtMarker); // add this marker to the overlay
                    }
                }
            }

            for (int i = 1; i < 6; i++)
            {
                gmcMap.Overlays.Add(new GMapOverlay());
            }
        }

        private void GmcMap_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.ZoomMode == 0)
            {
                gmcMap.Zoom += e.Delta / 120;
            }
        }

        private void GmcMap_OnMapZoomChanged()
        {
            if (gmcMap.Zoom >= 3)
            {
                gmcMap.DragButton = MouseButtons.Left;
            }
            else
            {
                gmcMap.DragButton = MouseButtons.None;
            }
        }

        private void GmcMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            ResetHighlight();
            gmcMap.Overlays[4].Routes.Clear();

            if (item.Tag is Airport)
            {
                OpenAirportPanel((Airport)item.Tag);
            }
            else if (item.Tag is Pilot)
            {
                Pilot pltCurrent = (Pilot)item.Tag;

                OpenPilotPanel(pltCurrent);

                List<PointLatLng> listRoutePoints = new List<PointLatLng>();

                if (pltCurrent.apDep != null)
                {
                    listRoutePoints.Add(new PointLatLng(pltCurrent.apDep.dblLat, pltCurrent.apDep.dblLon));
                }

                listRoutePoints.Add(new PointLatLng(pltCurrent.dblLat, pltCurrent.dblLon));

                if (pltCurrent.apArr != null)
                {
                    listRoutePoints.Add(new PointLatLng(pltCurrent.apArr.dblLat, pltCurrent.apArr.dblLon));
                }

                if (listRoutePoints.Count > 1)
                {
                    GMapRoute gmrDep = new GMapRoute(listRoutePoints, pltCurrent.strCallsign);
                    gmcMap.Overlays[4].Routes.Add(gmrDep);
                }
            }
        }

        private void OpenPilotPanel(Pilot _pilot)
        {
            LblPilotCallsign.Text = _pilot.strCallsign;
            pnlPilot.Tag = _pilot;

            string strDep;
            if (_pilot.apDep == null)
            {
                strDep = "????";
            }
            else
            {
                strDep = _pilot.apDep.strICAO;
            }

            string strArr;
            if (_pilot.apArr == null)
            {
                strArr = "????";
            }
            else
            {
                strArr = _pilot.apArr.strICAO;
            }

            string strAlt;
            if (_pilot.apAlt == null)
            {
                strAlt = "????";
            }
            else
            {
                strAlt = _pilot.apAlt.strICAO;
            }

            LblPilotFlight.Text = strDep + " - " + strArr + " (" + strAlt + ")";

            if (_pilot.strName == _pilot.intCID.ToString())
            {
                LblPilotName.Text = _pilot.intCID.ToString();
            }
            else
            {
                LblPilotName.Text = _pilot.strName + " (" + _pilot.intCID.ToString() + ")";
            }

            List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> listSectors = FindClickedSectors(new PointLatLng(_pilot.dblLat, _pilot.dblLon));
            Tuple<Controller, Airspace, Sector, GMapPolygon, bool> tupSector = null;

            foreach (Tuple<Controller, Airspace, Sector, GMapPolygon, bool> tupTup in listSectors)
            {
                if ((tupTup.Item3.intMinAlt < _pilot.intAlt || tupTup.Item3.intMinAlt == null) && (tupTup.Item3.intMaxAlt > _pilot.intAlt || tupTup.Item3.intMaxAlt == null))
                {
                    tupSector = tupTup;
                }
            }

            if (_pilot.decGS < intSpeedThreshold)
            {
                LblPilotSectorInfo.Text = "Slow Moving - Most Likely on the Ground";
            }
            else if (tupSector == null)
            {
                LblPilotSectorInfo.Text = "None: Monitoring UNICOM on 122.800";
            }
            else
            {
                LblPilotSectorInfo.Text = tupSector.Item2.strName + " (" + tupSector.Item1.atcClient.strCallsign + ")";
            }

            if (_pilot.dblLat > 0)
            {
                LblPilotLatInfo.Text = _pilot.dblLat.ToString("00.0000") + " N";
            }
            else if (_pilot.dblLat < 0)
            {
                LblPilotLatInfo.Text = Math.Abs(_pilot.dblLat).ToString("00.0000") + " S";
            }
            else
            {
                LblPilotLatInfo.Text = "00.00000";
            }

            if (_pilot.dblLon > 0)
            {
                LblPilotLonInfo.Text = _pilot.dblLon.ToString("00.0000") + " E";
            }
            else if (_pilot.dblLon < 0)
            {
                LblPilotLonInfo.Text = Math.Abs(_pilot.dblLon).ToString("00.0000") + " W";
            }
            else
            {
                LblPilotLonInfo.Text = "00.00000";
            }

            LblPilotServerInfo.Text = _pilot.strServer;
            TimeSpan tspOnline = DateTime.UtcNow - _pilot.dtLogon;
            LblPilotOnlineInfo.Text = Math.Truncate(tspOnline.TotalHours).ToString() + ":" + tspOnline.Minutes.ToString("00");

            GeoCoordinate geoPilot = new GeoCoordinate(_pilot.dblLat, _pilot.dblLon);

            double? dblCovered;
            try
            {
                dblCovered = new GeoCoordinate(_pilot.apDep.dblLat, _pilot.apDep.dblLon).GetDistanceTo(geoPilot) / 1852;
            }
            catch
            {
                dblCovered = null;
            }

            double? dblRemaining;
            try
            {
                dblRemaining = geoPilot.GetDistanceTo(new GeoCoordinate(_pilot.apArr.dblLat, _pilot.apArr.dblLon)) / 1852;
            }
            catch
            {
                dblRemaining = null;
            }

            if (dblCovered == null)
            {
                LblPilotDistanceInfo.Text = "";
            }
            else
            {
                LblPilotDistanceInfo.Text = ((double)dblCovered).ToString("F0") + " NMi";
            }

            if (dblRemaining == null)
            {
                LblPilotRemainingInfo.Text = "";
            }
            else
            {
                LblPilotRemainingInfo.Text = ((double)dblRemaining).ToString("F0") + " NMi";
            }

            LblPilotAltInfo.Text = _pilot.intAlt + " ft";
            LblPilotHDGInfo.Text = _pilot.intHeading + "°";
            LblPilotGSInfo.Text = _pilot.decGS.ToString("F0") + " Knots";
            LblPilotXPDRInfo.Text = _pilot.intXPDR.ToString();

            if (dblRemaining == null || _pilot.decGS == 0)
            {
                LblPilotETEInfo.Text = "";
                LblPilotETAInfo.Text = "";
            }
            else
            {
                double dblHours = (double)dblRemaining / (double)_pilot.decGS;
                TimeSpan tspETE = new TimeSpan((int)Math.Truncate(dblHours), (int)Math.Truncate(dblHours % 1 * 60), 0);
                LblPilotETEInfo.Text = Math.Truncate(tspETE.TotalHours).ToString() + ":" + tspETE.Minutes.ToString("00");
                DateTime dtETA = DateTime.UtcNow.Add(tspETE);
                LblPilotETAInfo.Text = dtETA.ToString("HH:mm") + "z";
            }

            LblPilotACInfo.Text = _pilot.strAircraft;

            if (_pilot.dtDep == default(DateTime))
            {
                LblPilotDepInfo.Text = "";
                LblPilotEnrouteInfo.Text = "";
                LblPilotArrInfo.Text = "";
            }
            else
            {
                LblPilotDepInfo.Text = _pilot.dtDep.ToString("HH:mm") + "z";

                if (_pilot.tspEnroute == default(TimeSpan))
                {
                    LblPilotArrInfo.Text = "";
                }
                else
                {
                    DateTime dtArr = _pilot.dtDep.Add(_pilot.tspEnroute);
                    LblPilotArrInfo.Text = dtArr.ToString("HH:mm") + "z";
                }
            }

            if (_pilot.tspEnroute == default(TimeSpan))
            {
                LblPilotEnrouteInfo.Text = "";
            }
            else
            {
                LblPilotEnrouteInfo.Text = Math.Truncate(_pilot.tspEnroute.TotalHours).ToString() + ":" + _pilot.tspEnroute.Minutes.ToString("00");
            }

            TxtPilotRoute.Text = _pilot.strRoute;
            TxtPilotRemarks.Text = _pilot.strRemarks;

            pnlAirport.Hide();
            pnlATC.Hide();
            pnlSectors.Hide();
            pnlPilot.Show();
        }

        private void OpenAirportPanel(Airport _airport)
        {
            pnlAirport.Tag = _airport;
            LblAirportICAO.Text = _airport.strICAO;
            LblAirportName.Text = _airport.strName;

            AirportPanelDataLoad(_airport);

            switch (_airport.intTopDown)
            {
                case 0:

                    if (_airport.listTopDown.Count == 0)
                    {
                        LblTopDown.Text = "No Top-Down Controller Data Available";
                    }
                    else
                    {
                        LblTopDown.Text = "No ATC Services: Monitor UNICOM (122.800)";
                    }

                    break;
                case 1:
                    LblTopDown.Text = "First Contact (Departures): Clearance Delivery";
                    break;
                case 2:
                    LblTopDown.Text = "First Contact (Departures): Ground Control";
                    break;
                case 3:
                    LblTopDown.Text = "First Contact (Departures): Local Control";
                    break;
                case 4:
                    LblTopDown.Text = "First Contact (Departures): " + _airport.ctlTopDown.atcClient.strCallsign + " (" + ((decimal)_airport.ctlTopDown.decFreq).ToString("#.000") + ")";
                    break;
            }

            int intDeps = lvAirportDepartures.Items.Count;

            if (intDeps == 0)
            {
                LblDepartures.Text = "No Departures";
            }
            else if (intDeps == 1)
            {
                LblDepartures.Text = "1 Departure";
            }
            else
            {
                LblDepartures.Text = intDeps + " Departures";
            }

            int intArrs = lvAirportArrivals.Items.Count;

            if (intArrs == 0)
            {
                LblArrivals.Text = "No Arrivals";
            }
            else if (intArrs == 1)
            {
                LblArrivals.Text = "1 Arrival";
            }
            else
            {
                LblArrivals.Text = intArrs + " Arrivals";
            }

            lvAirportControllers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvAirportDepartures.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvAirportArrivals.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            pnlATC.Hide();
            pnlPilot.Hide();
            pnlSectors.Hide();
            pnlAirport.Show();
        }

        private int AirportPanelDataLoad(Airport _airport)
        {
            try
            {
                ListViewItem lviTemp;

                lvAirportControllers.Items.Clear();
                lvAirportDepartures.Items.Clear();
                lvAirportArrivals.Items.Clear();

                foreach (ATC atcAtc in _airport.listDelivery)
                {
                    lviTemp = new ListViewItem(new string[] { atcAtc.strCallsign, atcAtc.decFreq.ToString("#.000"), _airport.strName + " Delivery", "Clearance Delivery" });
                    lviTemp.Tag = atcAtc;

                    if (_airport.intTopDown == 1)
                    {
                        lviTemp.ForeColor = cp.Accent;
                    }

                    lvAirportControllers.Items.Add(lviTemp);
                }
                foreach (ATC atcAtc in _airport.listGround)
                {
                    lviTemp = new ListViewItem(new string[] { atcAtc.strCallsign, atcAtc.decFreq.ToString("#.000"), _airport.strName + " Ground", "Ground Control" });
                    lviTemp.Tag = atcAtc;

                    if (_airport.intTopDown == 2)
                    {
                        lviTemp.ForeColor = cp.Accent;
                    }

                    lvAirportControllers.Items.Add(lviTemp);
                }
                foreach (ATC atcAtc in _airport.listTower)
                {
                    lviTemp = null;

                    if (_airport.isInfo && atcAtc.strCallsign.Substring(atcAtc.strCallsign.Length - 6) == "_I_TWR")
                    {
                        lviTemp = new ListViewItem(new string[] { atcAtc.strCallsign, atcAtc.decFreq.ToString("#.000"), _airport.strName + " Information", "AFIS Station" });
                    }
                    else if (_airport.isRadio && atcAtc.strCallsign.Substring(atcAtc.strCallsign.Length - 6) == "_R_TWR")
                    {
                        lviTemp = new ListViewItem(new string[] { atcAtc.strCallsign, atcAtc.decFreq.ToString("#.000"), _airport.strName + " Radio", "A/G Station" });
                    }
                    else
                    {
                        lviTemp = new ListViewItem(new string[] { atcAtc.strCallsign, atcAtc.decFreq.ToString("#.000"), _airport.strName + " Tower", "Local Control" });
                    }

                    lviTemp.Tag = atcAtc;

                    if (_airport.intTopDown == 3)
                    {
                        lviTemp.ForeColor = cp.Accent;
                    }

                    lvAirportControllers.Items.Add(lviTemp);
                }
                foreach (ATC atcAtc in _airport.listATIS)
                {
                    lviTemp = new ListViewItem(new string[] { atcAtc.strCallsign, atcAtc.decFreq.ToString("#.000"), _airport.strName + " Information", "Voice ATIS" });
                    lviTemp.Tag = atcAtc;
                    lvAirportControllers.Items.Add(lviTemp);
                }

                List<ATC> listATCAdded = new List<ATC>();

                foreach (Tuple<Controller, Airspace, Sector, GMapPolygon, bool> tupTup in FindClickedSectors(new PointLatLng(_airport.dblLat, _airport.dblLon)))
                {
                    if (!listATCAdded.Contains(tupTup.Item1.atcClient))
                    {
                        lviTemp = new ListViewItem(new string[] { tupTup.Item1.atcClient.strCallsign, tupTup.Item1.atcClient.decFreq.ToString("#.000"), tupTup.Item1.strCallsign, "Overlying Controller" });
                        lviTemp.Tag = tupTup.Item1;

                        if (_airport.ctlTopDown != null && tupTup.Item1.atcClient.strCallsign == _airport.ctlTopDown.atcClient.strCallsign)
                        {
                            lviTemp.ForeColor = cp.Accent;
                        }

                        lvAirportControllers.Items.Add(lviTemp);
                        listATCAdded.Add(tupTup.Item1.atcClient);
                    }
                }

                List<Pilot>[] listarrDepArrs = Pilot.Find(_airport);

                foreach (Pilot pltPlt in Pilot.list)
                {
                    if (pltPlt.apDep == null && pltPlt.decGS < intSpeedThreshold && pltPlt.GetDistanceTo(_airport) < intDistanceThreshold)
                    {
                        lviTemp = new ListViewItem(new string[] { pltPlt.strCallsign, pltPlt.intCID.ToString(), pltPlt.strName, "" });
                        lviTemp.Tag = pltPlt;
                        lvAirportDepartures.Items.Add(lviTemp);
                    }
                }

                foreach (Pilot pltPlt in listarrDepArrs[0])
                {
                    if (pltPlt.decGS < intSpeedThreshold && pltPlt.GetDistanceTo(_airport) < intDistanceThreshold)
                    {
                        string strArr;

                        if (pltPlt.apArr != null)
                        {
                            strArr = pltPlt.apArr.strICAO + " - " + pltPlt.apArr.strName;
                        }
                        else
                        {
                            strArr = "";
                        }

                        lviTemp = new ListViewItem(new string[] { pltPlt.strCallsign, pltPlt.intCID.ToString(), pltPlt.strName, strArr });
                        lviTemp.Tag = pltPlt;
                        lvAirportDepartures.Items.Add(lviTemp);
                    }
                }

                foreach (Pilot pltPlt in listarrDepArrs[1])
                {
                    if (pltPlt.decGS < intSpeedThreshold && pltPlt.GetDistanceTo(_airport) < intDistanceThreshold)
                    {
                        string strDep;

                        if (pltPlt.apDep != null)
                        {
                            strDep = pltPlt.apDep.strICAO + " - " + pltPlt.apDep.strName;
                        }
                        else
                        {
                            strDep = "";
                        }

                        lviTemp = new ListViewItem(new string[] { pltPlt.strCallsign, pltPlt.intCID.ToString(), pltPlt.strName, strDep });
                        lviTemp.Tag = pltPlt;
                        lvAirportArrivals.Items.Add(lviTemp);
                    }
                }

                return _airport.intTopDown;
            }
            catch
            {
                return AirportPanelDataLoad(_airport);
            }
        }

        private void GmcMap_OnMapClick(PointLatLng PointClick, MouseEventArgs e)
        {
            if (!gmcMap.IsMouseOverMarker)
            {
                ResetHighlight();
                gmcMap.Overlays[4].Routes.Clear();
                List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> listClicked = FindClickedSectors(new PointLatLng(PointClick.Lng, PointClick.Lat));
                OpenSectorsPanel(listClicked);
            }
        }

        private List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> FindClickedSectors(PointLatLng _point)
        {
            List<GMapPolygon> listPolygons = new List<GMapPolygon>();

            foreach (GMapPolygon plySector in gmcMap.Overlays[1].Polygons)
            {
                if (plySector.IsInside(_point))
                {
                    listPolygons.Add(plySector);
                }
            }

            foreach (GMapPolygon plySector in gmcMap.Overlays[2].Polygons)
            {
                if (plySector.IsInside(_point))
                {
                    listPolygons.Add(plySector);
                }
            }

            List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> listSectors = new List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>>();

            foreach (GMapPolygon plySector in listPolygons)
            {
                string[] strarrLocation = plySector.Name.Split('|');

                Tuple<Airspace,Sector> tupFind = Controller.FindSector(strarrLocation[0], strarrLocation[1], strarrLocation[2]);
                if (tupFind != null)
                {
                    bool isTransparent = false;

                    if (((SolidBrush)plySector.Fill).Color == Color.Transparent)
                    {
                        isTransparent = true;
                    }

                    listSectors.Add(new Tuple<Controller, Airspace, Sector, GMapPolygon, bool>(Controller.Find(strarrLocation[0]), tupFind.Item1, tupFind.Item2, plySector, isTransparent));
                }
            }

            return listSectors;
        }

        private void OpenSectorsPanel(List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> _sectors)
        {
            ResetHighlight();

            if (_sectors.Count > 0)
            {
                bool isSectorVisible = false;

                foreach (Tuple<Controller, Airspace, Sector, GMapPolygon, bool> tupTup in _sectors)
                {
                    if (!tupTup.Item5)
                    {
                        isSectorVisible = true;
                    }
                }

                if (isSectorVisible)
                {
                    foreach (Tuple<Controller, Airspace, Sector, GMapPolygon, bool> tupTup in _sectors)
                    {
                        listHighlighted.Add(new Tuple<GMapPolygon, SolidBrush>(tupTup.Item4, (SolidBrush)tupTup.Item4.Fill));
                        tupTup.Item4.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    }

                    foreach (Tuple<Controller, Airspace, Sector, GMapPolygon, bool> tup2 in _sectors)
                    {
                        if (tup2.Item3.intMinAlt == null)
                        {
                            tup2.Item3.intMinAlt = 0;
                        }

                        if (tup2.Item3.intMaxAlt == null)
                        {
                            tup2.Item3.intMaxAlt = 66000;
                        }
                    }

                    foreach (Tuple<Controller, Airspace, Sector, GMapPolygon, bool> tupTup in _sectors)
                    {
                        int intMinTemp = (int)tupTup.Item3.intMinAlt;
                        int intMaxTemp = (int)tupTup.Item3.intMaxAlt;

                        foreach (Tuple<Controller, Airspace, Sector, GMapPolygon, bool> tup2 in _sectors)
                        {
                            if (tup2.Item3.intMaxAlt > tupTup.Item3.intMaxAlt && tup2.Item3.intMinAlt <= tupTup.Item3.intMinAlt)
                            {
                                tup2.Item3.intMinAlt = tupTup.Item3.intMaxAlt;
                            }
                            else if (tup2.Item3.intMinAlt < tupTup.Item3.intMinAlt && tup2.Item3.intMaxAlt >= tupTup.Item3.intMaxAlt)
                            {
                                tup2.Item3.intMaxAlt = tupTup.Item3.intMinAlt;
                            }
                        }

                        tupTup.Item3.intMinAlt = intMinTemp;
                        tupTup.Item3.intMaxAlt = intMaxTemp;
                    }

                    for (int i = 0; i < _sectors.Count - 1; i++)
                    {
                        bool isFakeTransparent = false;

                        if (FilterSettings.intMinATCAlt >= _sectors[i].Item3.intMaxAlt)
                        {
                            isFakeTransparent = true;
                        }
                        else if (FilterSettings.intMaxATCAlt <= _sectors[i].Item3.intMinAlt)
                        {
                            isFakeTransparent = true;
                        }

                        if (isFakeTransparent)
                        {
                            _sectors[i] = new Tuple<Controller, Airspace, Sector, GMapPolygon, bool>(_sectors[i].Item1, _sectors[i].Item2, _sectors[i].Item3, _sectors[i].Item4, true);
                        }
                    }

                    _sectors = Sector.SortDisplay(_sectors);

                    foreach (Tuple<Controller, Airspace, Sector, GMapPolygon, bool> tup2 in _sectors)
                    {
                        if (tup2.Item3.intMinAlt == 0)
                        {
                            tup2.Item3.intMinAlt = null;
                        }

                        if (tup2.Item3.intMaxAlt == 66000)
                        {
                            tup2.Item3.intMaxAlt = null;
                        }
                    }

                    flpSectorData.Controls.Clear();
                    foreach (Tuple<Controller, Airspace, Sector, GMapPolygon, bool> tupTup in _sectors)
                    {
                        if (!tupTup.Item5)
                        {
                            // 
                            // TxtData
                            // 
                            TextBox TxtData = new TextBox();
                            TxtData.BackColor = cp.Window;
                            TxtData.ForeColor = cp.Text;
                            flpSectorData.Controls.Add(TxtData);
                            TxtData.Multiline = true;
                            TxtData.ReadOnly = true;
                            TxtData.Font = new Font(TxtData.Font.FontFamily, (float)9.25);
                            TxtData.Size = new Size(294, 84);
                            TxtData.TextAlign = HorizontalAlignment.Center;
                            TxtData.Text = tupTup.Item1.atcClient.strCallsign + " (" + tupTup.Item1.atcClient.decFreq.ToString("#.000") + ")\r\n" + tupTup.Item2.strName + "\r\n";
                            if (tupTup.Item3.intMinAlt == null & tupTup.Item3.intMaxAlt == null)
                            {
                                TxtData.Text += "At All Altitudes\r\n";
                            }
                            else if (tupTup.Item3.intMinAlt == null)
                            {
                                TxtData.Text += "Below " + tupTup.Item3.intMaxAlt + " ft\r\n";
                            }
                            else if (tupTup.Item3.intMaxAlt == null)
                            {
                                TxtData.Text += "Above " + tupTup.Item3.intMinAlt + " ft\r\n";
                            }
                            else
                            {
                                TxtData.Text += "From " + tupTup.Item3.intMinAlt + " ft to " + tupTup.Item3.intMaxAlt + " ft\r\n";
                            }
                            TxtData.Text += "(" + tupTup.Item2.strDescription + ")";

                            // 
                            // BtnControllerDetails
                            // 
                            Button BtnControllerDetails = new Button();
                            BtnControllerDetails.BackColor = cp.Control;
                            BtnControllerDetails.ForeColor = cp.Text;
                            flpSectorData.Controls.Add(BtnControllerDetails);
                            BtnControllerDetails.Name = "BtnControllerDetails";
                            BtnControllerDetails.Anchor = AnchorStyles.Right;
                            BtnControllerDetails.Size = new Size(75, 23);
                            BtnControllerDetails.Text = "Details";
                            BtnControllerDetails.UseVisualStyleBackColor = true;
                            BtnControllerDetails.Tag = tupTup;
                            BtnControllerDetails.Click += BtnControllerDetails_Click;
                        }
                    }

                    flpSectorData.Refresh();
                    gmcMap.Refresh();

                    pnlAirport.Hide();
                    pnlATC.Hide();
                    pnlPilot.Hide();
                    pnlSectors.Show();
                }
                else
                {
                    pnlAirport.Hide();
                    pnlATC.Hide();
                    pnlPilot.Hide();
                    pnlSectors.Hide();
                }
            }
            else
            {
                pnlAirport.Hide();
                pnlATC.Hide();
                pnlPilot.Hide();
                pnlSectors.Hide();
            }
        }

        private void OpenATCPanel(Controller _controller)
        {
            pnlATC.Tag = _controller.atcClient;

            LblCallsign.Text = _controller.atcClient.strCallsign;
            LblSpoken.Text = _controller.strCallsign;

            if (_controller.atcClient.strName == _controller.atcClient.intCID.ToString())
            {
                LblNameCID.Text = _controller.atcClient.intCID.ToString();
            }
            else
            {
                LblNameCID.Text = _controller.atcClient.strName + " (" + _controller.atcClient.intCID + ")";
            }

            LblFreqInfo.Text = _controller.atcClient.decFreq.ToString("#.000");
            LblRatingInfo.Text = ATC.strarrRatings[_controller.atcClient.intRating - 1];
            LblATISInfo.Text = _controller.atcClient.strATIS;
            TimeSpan tspTemp = DateTime.UtcNow - _controller.atcClient.dtLogon;
            LblOnlineInfo.Text = Math.Truncate(tspTemp.TotalHours).ToString() + ":" + tspTemp.Minutes.ToString("00");
            LblLogonInfo.Text = _controller.atcClient.dtLogon.ToString("dd/MM/yyyy HH:mm") + "z";
            LblServerInfo.Text = _controller.atcClient.strServer;
            LblSectorInfo.Text = "";

            foreach (OwnedAirspace owaOwa in _controller.listOwned)
            {
                LblSectorInfo.Text += owaOwa.aspAirspace.strName + "\r\n";
            }

            LblSectorInfo.Text = LblSectorInfo.Text.Substring(0, LblSectorInfo.Text.Length - 2);

            HighlightOwned(_controller);

            pnlAirport.Hide();
            pnlSectors.Hide();
            pnlPilot.Hide();
            pnlATC.Show();
        }

        private void HighlightOwned(Controller _controller)
        {
            ResetHighlight();

            List<Sector> listSectors = new List<Sector>();

            foreach (OwnedAirspace owaOwa in _controller.listOwned)
            {
                foreach (Sector sctSct in owaOwa.aspAirspace.listSectors)
                {
                    listSectors.Add(sctSct);
                }
            }

            foreach (GMapPolygon plyPly in gmcMap.Overlays[2].Polygons)
            {
                if (listSectors.Contains((Sector)plyPly.Tag))
                {
                    listHighlighted.Add(new Tuple<GMapPolygon, SolidBrush>(plyPly, (SolidBrush)plyPly.Fill));
                    plyPly.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                }
            }

            foreach (GMapPolygon plyPly in gmcMap.Overlays[1].Polygons)
            {
                if (listSectors.Contains((Sector)plyPly.Tag))
                {
                    listHighlighted.Add(new Tuple<GMapPolygon, SolidBrush>(plyPly, (SolidBrush)plyPly.Fill));
                    plyPly.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                }
            }

            gmcMap.Refresh();
        }

        private void ResetHighlight()
        {
            //if (pnlATC.Visible == false)
            //{
                foreach (Tuple<GMapPolygon, SolidBrush> tupTup in listHighlighted)
                {
                    tupTup.Item1.Fill = tupTup.Item2;
                }
            //}

            gmcMap.Refresh();
        }

        private void OpenATCPanel(ATC _atc, Airport _airport)
        {
            pnlATC.Tag = _atc;

            string strName = "";
            if (_atc.intFacility == 2)
            {
                strName = _airport.strName + " Delivery";
            }
            else if (_atc.intFacility == 3)
            {
                strName = _airport.strName + " Ground";
            }
            else if (_atc.intFacility == 4)
            {
                if (_airport.isInfo && _atc.strCallsign.Substring(_atc.strCallsign.Length - 6) == "_I_TWR")
                {
                    strName = _airport.strName + " Information";
                }
                else if (_airport.isRadio && _atc.strCallsign.Substring(_atc.strCallsign.Length - 6) == "_R_TWR")
                {
                    strName = _airport.strName + " Radio";
                }
                else
                {
                    strName = _airport.strName + " Tower";
                }
            }
            else if (_atc.intFacility == 7)
            {
                strName = _airport.strName + " Information";
            }

            LblCallsign.Text = _atc.strCallsign;
            LblSpoken.Text = strName;
            LblNameCID.Text = _atc.strName + " (" + _atc.intCID + ")";
            LblFreqInfo.Text = _atc.decFreq.ToString("#.000");
            LblRatingInfo.Text = ATC.strarrRatings[_atc.intRating - 1];
            LblATISInfo.Text = _atc.strATIS;
            TimeSpan tspTemp = DateTime.UtcNow - _atc.dtLogon;
            LblOnlineInfo.Text = Math.Truncate(tspTemp.TotalHours).ToString() + ":" + tspTemp.Minutes.ToString("00");
            LblLogonInfo.Text = _atc.dtLogon.ToString("dd/MM/yyyy HH:mm") + "z";
            LblServerInfo.Text = _atc.strServer;
            LblSectorInfo.Text = strName;

            pnlAirport.Hide();
            pnlSectors.Hide();
            pnlPilot.Hide();
            pnlATC.Show();
        }

        private void BtnControllerDetails_Click(object sender, EventArgs e)
        {
            Tuple<Controller, Airspace, Sector, GMapPolygon, bool> tupSector = (Tuple<Controller, Airspace, Sector, GMapPolygon, bool>)((Button)sender).Tag;
            OpenATCPanel(tupSector.Item1);
        }

        private void lbATC_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (e.Index > -1)
            {
                object item = list.Items[e.Index];
                e.DrawBackground();
                e.DrawFocusRectangle();
                Brush brush = new SolidBrush(e.ForeColor);
                SizeF size = e.Graphics.MeasureString(item.ToString(), e.Font);
                e.Graphics.DrawString(item.ToString(), e.Font, brush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2), e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));
            }
        }

        private void MapUpdate()
        {
            AllMarkers();
            AllPolygons();
            tslUpdate.Text = "Last Update: " + DataLink.Current.dtUpdate.ToShortDateString() + " " + DataLink.Current.dtUpdate.ToString("HHmm") + "z";

            int intTotal = Pilot.list.Count + ATC.list.Count + ATC.observers.Count;
            int[] intarrATCStat = ATC.GetConnectionStat();
            tslConnections.Text = intTotal + " Connections (" + Pilot.list.Count + " Pilots, " + intarrATCStat[0] + " Controllers, " + intarrATCStat[1] + " ATIS Reports, " + ATC.observers.Count + " Observers)";

            if (Properties.Settings.Default.AlertAirspace && Properties.Settings.Default.AlertCID != -1)
            {
                int intEntry = -1;
                bool isNearby = false;
                bool isInside = false;
                Client cltAlert = Client.Find(Properties.Settings.Default.AlertCID);

                if (cltAlert != null && cltAlert is Pilot)
                {
                    Pilot pltTemp = (Pilot)cltAlert;
                    PointLatLng pntPilot = new PointLatLng(pltTemp.dblLat, pltTemp.dblLon);

                    List<PointLatLng> listMovement = new List<PointLatLng>();
                    listMovement.Add(pntPilot);

                    for (int i = 1; i <= 12; i++)
                    {
                        double[] dblarrMovement = Destination((pltTemp.dblLat, pltTemp.dblLon), (double)pltTemp.decGS * i / 120, pltTemp.intHeading);
                        listMovement.Add(new PointLatLng(dblarrMovement[0], dblarrMovement[1]));
                    }

                    foreach (GMapPolygon plyPly in gmcMap.Overlays[2].Polygons)
                    {
                        if (plyPly.IsInside(pntPilot))
                        {
                            isInside = true;
                        }

                        string[] strarrLocation = plyPly.Name.Split('|');

                        Tuple<Airspace, Sector> tupFind = Controller.FindSector(strarrLocation[0], strarrLocation[1], strarrLocation[2]);
                        if (tupFind != null)
                        {
                            for (int i = 0; i < listMovement.Count; i++)
                            {
                                PointLatLng pntPnt = listMovement[i];

                                if (plyPly.IsInside(pntPnt) && pltTemp.intAlt > tupFind.Item2.intMinAlt && pltTemp.intAlt < tupFind.Item2.intMaxAlt && intEntry == -1)
                                {
                                    isNearby = true;
                                    intEntry = i;
                                }
                            }
                        }
                    }

                    foreach (GMapPolygon plyPly in gmcMap.Overlays[1].Polygons)
                    {
                        if (plyPly.IsInside(pntPilot))
                        {
                            isInside = true;
                        }

                        string[] strarrLocation = plyPly.Name.Split('|');

                        Tuple<Airspace, Sector> tupFind = Controller.FindSector(strarrLocation[0], strarrLocation[1], strarrLocation[2]);
                        if (tupFind != null)
                        {
                            foreach (PointLatLng pntPnt in listMovement)
                            {
                                if (plyPly.IsInside(pntPnt) && pltTemp.intAlt > tupFind.Item2.intMinAlt && pltTemp.intAlt < tupFind.Item2.intMaxAlt)
                                {
                                    isNearby = true;
                                }
                            }
                        }
                    }

                    if (!isInside && isNearby)
                    {
                        ntfTray.ShowBalloonTip(15000, "Near Airspace", "Less than " + intEntry * 12 + " minutes from active airspace.", ToolTipIcon.Info);
                    }
                }
            }
        }

        public static double[] Destination((double Lat, double Lon) startPoint, double distance, double bearing)
        {
            double radius = 6371010;
            double lat1 = startPoint.Lat * (Math.PI / 180);
            double lon1 = startPoint.Lon * (Math.PI / 180);
            double brng = bearing * (Math.PI / 180);
            double lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(distance / radius) + Math.Cos(lat1) * Math.Sin(distance / radius) * Math.Cos(brng));
            double lon2 = lon1 + Math.Atan2(Math.Sin(brng) * Math.Sin(distance / radius) * Math.Cos(lat1), Math.Cos(distance / radius) - Math.Sin(lat1) * Math.Sin(lat2));
            return new double[] { lat2 * (180 / Math.PI), lon2 * (180 / Math.PI) };
        }

        private void AllPolygons()
        {
            gmcMap.Overlays[1] = new GMapOverlay("enroute");
            gmcMap.Overlays[2] = new GMapOverlay("approach");

            if (approachMenuItem.Checked || enRouteMenuItem.Checked)
            {
                foreach (Controller ctlCtl in Controller.listActive)
                {
                    foreach (OwnedAirspace owaOwa in ctlCtl.listOwned)
                    {
                        foreach (Sector sctSct in owaOwa.aspAirspace.listSectors)
                        {
                            bool isRunwayActive = false;
                            bool isSectorActive = true;
                            bool isFiltered = false;

                            if (sctSct.listRunways.Count == 0)
                            {
                                isRunwayActive = true;
                            }
                            else
                            {
                                foreach (Runway rwyRwy in sctSct.listRunways)
                                {
                                    if (rwyRwy.apOwner.listActive.Contains(rwyRwy))
                                    {
                                        isRunwayActive = true;
                                    }
                                }
                            }

                            if (owaOwa.intMinAlt >= sctSct.intMaxAlt)
                            {
                                isSectorActive = false;
                            }
                            else if (owaOwa.intMaxAlt <= sctSct.intMinAlt)
                            {
                                isSectorActive = false;
                            }

                            foreach (GMapPolygon plyPly in gmcMap.Overlays[0].Polygons)
                            {
                                FIR firTemp = (FIR)plyPly.Tag;

                                if (firTemp.frdDisplay.isShown)
                                {
                                    if (sctSct is PolySector)
                                    {
                                        PolySector sctTemp = (PolySector)sctSct;

                                        foreach (double[] dblDbl in sctTemp.Points)
                                        {
                                            if (plyPly.IsInside(new PointLatLng(dblDbl[0], dblDbl[1])))
                                            {
                                                isFiltered = true;
                                            }
                                        }
                                    }
                                    else if (sctSct is CircleSector)
                                    {
                                        CircleSector sctTemp = (CircleSector)sctSct;

                                        if (plyPly.IsInside(new PointLatLng(sctTemp.Point[0], sctTemp.Point[1])))
                                        {
                                            isFiltered = true;
                                        }
                                    }
                                }
                            }

                            if (FilterSettings.intMinATCAlt >= sctSct.intMaxAlt)
                            {
                                isFiltered = false;
                            }
                            else if (FilterSettings.intMaxATCAlt <= sctSct.intMinAlt)
                            {
                                isFiltered = false;
                            }

                            if (FilterSettings.listATCCallsigns.Count != 0 && !FilterSettings.listATCCallsigns.Contains(ctlCtl.atcClient.strCallsign))
                            {
                                isFiltered = false;
                            }

                            if (isSectorActive && isRunwayActive)
                            {
                                GMapPolygon plyPly = null;

                                if (sctSct is PolySector)
                                {
                                    List<PointLatLng> listPoints = new List<PointLatLng>();

                                    foreach (double[] dblDbl in ((PolySector)sctSct).Points)
                                    {
                                        listPoints.Add(new PointLatLng(dblDbl[0], dblDbl[1]));
                                    }

                                    plyPly = new GMapPolygon(listPoints, ctlCtl.strID.ToString() + "|" + owaOwa.aspAirspace.strID.ToString() + "|" + sctSct.strID.ToString());
                                }
                                else if (sctSct is CircleSector)
                                {
                                    plyPly = CreateCircle((CircleSector)sctSct);
                                    plyPly.Name = ctlCtl.strID.ToString() + "|" + owaOwa.aspAirspace.strID.ToString() + "|" + sctSct.strID.ToString();
                                }

                                if (isFiltered)
                                {
                                    plyPly.Stroke = new Pen(new SolidBrush(Color.Black), (float)0.5);
                                }
                                else
                                {
                                    plyPly.Stroke = new Pen(new SolidBrush(Color.Transparent), (float)0);
                                }

                                plyPly.Tag = sctSct;

                                if (approachMenuItem.Checked && owaOwa.isApproach)
                                {
                                    if (isFiltered)
                                    {
                                        plyPly.Fill = new SolidBrush(Color.FromArgb(50, Color.DeepPink));
                                    }
                                    else
                                    {
                                        plyPly.Fill = new SolidBrush(Color.Transparent);
                                    }

                                    gmcMap.Overlays[2].Polygons.Add(plyPly);
                                }
                                else if (enRouteMenuItem.Checked && !owaOwa.isApproach)
                                {
                                    if (isFiltered)
                                    {
                                        if (owaOwa.intMinAlt != null && owaOwa.intMinAlt != 0)
                                        {
                                            plyPly.Fill = new SolidBrush(Color.FromArgb(50, Color.GreenYellow));
                                        }
                                        else
                                        {
                                            plyPly.Fill = new SolidBrush(Color.FromArgb(50, Color.Teal));
                                        }
                                    }
                                    else
                                    {
                                        plyPly.Fill = new SolidBrush(Color.Transparent);
                                    }

                                    gmcMap.Overlays[1].Polygons.Add(plyPly);
                                }
                            }
                        }
                    }
                }
            }
        }

        private GMapPolygon CreateCircle(CircleSector _sector)
        {
            int intNauticalMilesToMetres = 1852;
            double radius = _sector.Radius * intNauticalMilesToMetres;

            PointLatLng point = new PointLatLng(_sector.Point[0], _sector.Point[1]);
            int segments = 1080;

            List<PointLatLng> listPoints = new List<PointLatLng>();

            for (int i = 0; i < segments; i++)
            {
                listPoints.Add(FindPointAtDistanceFrom(point, i * (Math.PI / 180), radius / 1000));
            }

            GMapPolygon polygon = new GMapPolygon(listPoints, "Circle");
            return polygon;
        }

        public static GMap.NET.PointLatLng FindPointAtDistanceFrom(GMap.NET.PointLatLng startPoint, double initialBearingRadians, double distanceKilometres)
        {
            const double radiusEarthKilometres = 6371.01;
            var distRatio = distanceKilometres / radiusEarthKilometres;
            var distRatioSine = Math.Sin(distRatio);
            var distRatioCosine = Math.Cos(distRatio);

            var startLatRad = DegreesToRadians(startPoint.Lat);
            var startLonRad = DegreesToRadians(startPoint.Lng);

            var startLatCos = Math.Cos(startLatRad);
            var startLatSin = Math.Sin(startLatRad);

            var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));
            var endLonRads = startLonRad + Math.Atan2(Math.Sin(initialBearingRadians) * distRatioSine * startLatCos, distRatioCosine - startLatSin * Math.Sin(endLatRads));

            return new GMap.NET.PointLatLng(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads));
        }

        public static double DegreesToRadians(double degrees)
        {
            const double degToRadFactor = Math.PI / 180;
            return degrees * degToRadFactor;
        }

        public static double RadiansToDegrees(double radians)
        {
            const double radToDegFactor = 180 / Math.PI;
            return radians * radToDegFactor;
        }

        public static double DistanceTwoPoint(double startLat, double startLong, double endLat, double endLong)
        {

            var startPoint = new GeoCoordinate(startLat, startLong);
            var endPoint = new GeoCoordinate(endLat, endLong);

            return startPoint.GetDistanceTo(endPoint);
        }

        private void AllMarkers()
        {
            gmcMap.Overlays[3] = new GMapOverlay("airports");
            gmcMap.Overlays[5] = new GMapOverlay("aerodrome-atc-logo");

            if (activeMenuItem.Checked || inactiveWithTrafficMenuItem.Checked || inactiveNoTrafficMenuItem.Checked || aTCMenuItem.Checked)
            {
                foreach (Airport apAp in Airport.listSorted)
                {
                    PointLatLng pntTemp = new PointLatLng(apAp.dblLat, apAp.dblLon);

                    if ((apAp.AerodromeCount() > 0 && activeMenuItem.Checked) || (apAp.AerodromeCount() == 0 && ((apAp.intFrom != 0 || apAp.intTo != 0) && inactiveWithTrafficMenuItem.Checked) || (apAp.intFrom == 0 && apAp.intTo == 0 && inactiveNoTrafficMenuItem.Checked)))
                    {
                        GMarkerGoogle mkAp = new GMarkerGoogle(pntTemp, bmpGrey);
                        mkAp.ToolTip = new GMapToolTip(mkAp);
                        mkAp.ToolTip.Fill = new SolidBrush(Color.Transparent);
                        mkAp.ToolTip.Foreground = new SolidBrush(Color.FromArgb(10, 40, 100));
                        mkAp.ToolTip.Stroke.Color = Color.Transparent;
                        mkAp.ToolTip.Offset = new Point(0, 0);
                        mkAp.ToolTipMode = MarkerTooltipMode.Always;
                        mkAp.ToolTipText = apAp.strICAO;
                        mkAp.Tag = apAp;

                        gmcMap.Overlays[3].Markers.Add(mkAp);

                        if (apAp.AerodromeCount() > 0)
                        {
                            GMarkerGoogle mkLg = new GMarkerGoogle(pntTemp, bmpGrey);

                            if (aTCMenuItem.Checked)
                            {
                                mkLg = new GMarkerGoogle(pntTemp, GetATCLogo(apAp));
                            }

                            mkLg.ToolTip = new GMapToolTip(mkLg);
                            mkLg.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            mkLg.ToolTipText = "";
                            mkLg.Tag = apAp;

                            mkLg.ToolTipText = CreateToolTipText(apAp);

                            if (mkLg.ToolTipText.Length > 0)
                            {
                                mkLg.ToolTipText = mkLg.ToolTipText.Substring(0, mkLg.ToolTipText.Length - 1);
                            }

                            gmcMap.Overlays[5].Markers.Add(mkLg);
                        }
                    }
                    else if (aTCMenuItem.Checked && apAp.AerodromeCount() > 0)
                    {
                        GMarkerGoogle mkLg = new GMarkerGoogle(pntTemp, GetATCLogo(apAp));

                        mkLg.ToolTip = new GMapToolTip(mkLg);
                        mkLg.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        mkLg.ToolTipText = "";
                        mkLg.Tag = apAp;

                        mkLg.ToolTipText = CreateToolTipText(apAp);

                        if (mkLg.ToolTipText.Length > 0)
                        {
                            mkLg.ToolTipText = mkLg.ToolTipText.Substring(0, mkLg.ToolTipText.Length - 1);
                        }

                        gmcMap.Overlays[5].Markers.Add(mkLg);
                    }
                }
            }

            PilotMarkersDataLoad();
        }

        private string CreateToolTipText(Airport _ap)
        {
            try
            {
                string strReturn = "";

                foreach (ATC atcAtc in _ap.listDelivery)
                {
                    strReturn += atcAtc.strCallsign + "\t|\t" + atcAtc.decFreq.ToString("F3") + "\n";
                }
                foreach (ATC atcAtc in _ap.listGround)
                {
                    strReturn += atcAtc.strCallsign + "\t|\t" + atcAtc.decFreq.ToString("F3") + "\n";
                }
                foreach (ATC atcAtc in _ap.listTower)
                {
                    strReturn += atcAtc.strCallsign + "\t|\t" + atcAtc.decFreq.ToString("F3") + "\n";
                }
                foreach (ATC atcAtc in _ap.listATIS)
                {
                    strReturn += atcAtc.strCallsign + "\t|\t" + atcAtc.decFreq.ToString("F3") + "\n";
                }

                return strReturn;
            }
            catch
            {
                return CreateToolTipText(_ap);
            }
        }

        private void PilotMarkersDataLoad()
        {
            try
            {
                gmcMap.Overlays[4] = new GMapOverlay("aircraft");

                if (iconsMenuItem.Checked || callsignsMenuItem.Checked)
                {
                    foreach (Pilot pltPlt in Pilot.list)
                    {
                        if (pltPlt.decGS > 40 && pltPlt.intAlt > FilterSettings.intMinPilotAlt && pltPlt.intAlt < FilterSettings.intMaxPilotAlt)
                        {
                            switch (FilterSettings.intPilotFilterMode)
                            {
                                case 0:
                                    if (FilterSettings.listDep.Contains(pltPlt.apDep))
                                    {
                                        AddPilotMarker(pltPlt);
                                    }
                                    break;
                                case 1:
                                    if (FilterSettings.listArr.Contains(pltPlt.apArr))
                                    {
                                        AddPilotMarker(pltPlt);
                                    }
                                    break;
                                case 2:
                                    if (FilterSettings.listDep.Contains(pltPlt.apDep) && FilterSettings.listArr.Contains(pltPlt.apArr))
                                    {
                                        AddPilotMarker(pltPlt);
                                    }
                                    break;
                                case 3:
                                    AddPilotMarker(pltPlt);
                                    break;
                            }
                        }
                    }
                }
            }
            catch
            {
                PilotMarkersDataLoad();
            }
        }

        private void AddPilotMarker(Pilot _pilot)
        {
            if (iconsMenuItem.Checked)
            {
                GMarkerGoogle mkTemp = new GMarkerGoogle(new PointLatLng(_pilot.dblLat, _pilot.dblLon), (Bitmap)RotateImage(bmpPlane, _pilot.intHeading));
                mkTemp.Tag = _pilot;

                if (callsignsMenuItem.Checked)
                {
                    mkTemp.ToolTip = new GMapToolTip(mkTemp);
                    mkTemp.ToolTip.Fill = new SolidBrush(Color.Transparent);
                    mkTemp.ToolTip.Stroke.Color = Color.Transparent;
                    mkTemp.ToolTip.Offset = new Point(0, 0);
                    mkTemp.ToolTipMode = MarkerTooltipMode.Always;
                    mkTemp.ToolTipText = _pilot.strCallsign;

                    if (_pilot.intXPDR == 7500 || _pilot.intXPDR == 7600 || _pilot.intXPDR == 7700)
                    {
                        mkTemp.ToolTip.Foreground = new SolidBrush(Color.Red);
                    }
                    else if (_pilot.isFav)
                    {
                        mkTemp.ToolTip.Foreground = new SolidBrush(Color.DarkOrange);
                    }
                    else
                    {
                        mkTemp.ToolTip.Foreground = new SolidBrush(Color.Black);
                    }
                }

                gmcMap.Overlays[4].Markers.Add(mkTemp);
            }
            else
            {
                GMarkerCross crtTemp = new GMarkerCross(new PointLatLng(_pilot.dblLat, _pilot.dblLon));
                crtTemp.Pen = new Pen(Color.Transparent);
                crtTemp.Tag = _pilot;

                if (callsignsMenuItem.Checked)
                {
                    crtTemp.ToolTip = new GMapToolTip(crtTemp);
                    crtTemp.ToolTip.Fill = new SolidBrush(Color.Transparent);
                    crtTemp.ToolTip.Stroke.Color = Color.Transparent;
                    crtTemp.ToolTip.Offset = new Point(0, 0);
                    crtTemp.ToolTipMode = MarkerTooltipMode.Always;
                    crtTemp.ToolTipText = _pilot.strCallsign;

                    if (_pilot.isFav)
                    {
                        crtTemp.ToolTip.Foreground = new SolidBrush(Color.Orange);
                    }
                    else
                    {
                        crtTemp.ToolTip.Foreground = new SolidBrush(Color.Black);
                    }
                }

                gmcMap.Overlays[4].Markers.Add(crtTemp);
            }
        }

        private Bitmap GetATCLogo(Airport _ap)
        {
            switch (_ap.intAerodrome)
            {
                case 0:
                    return bmpGrey;
                case 1:
                    return bmpA;
                case 2:
                    return bmpD;
                case 3:
                    return bmpDA;
                case 4:
                    return bmpG;
                case 5:
                    return bmpGA;
                case 6:
                    return bmpGD;
                case 7:
                    return bmpGDA;
                case 8:
                    return bmpT;
                case 9:
                    return bmpTA;
                case 10:
                    return bmpTD;
                case 11:
                    return bmpTDA;
                case 12:
                    return bmpTG;
                case 13:
                    return bmpTGA;
                case 14:
                    return bmpTGD;
                case 15:
                    return bmpTGDA;
                default:
                    return bmpGrey;
            }
        }

        private PointLatLng PolygonCentre(GMapPolygon _polygon)
        {
            List<PointLatLng> listPoints = _polygon.Points;
            PointLatLng pntCentre = new PointLatLng();

            int intSum = 0;
            double dblLat = 0;
            double dblLon = 0;

            foreach (PointLatLng pntPnt in listPoints)
            {
                intSum += 1;
                dblLat += pntPnt.Lat;
                dblLon += pntPnt.Lng;
            }

            dblLat = dblLat / intSum;
            dblLon = dblLon / intSum;

            pntCentre.Lat = dblLat;
            pntCentre.Lng = dblLon;

            return pntCentre;
        }

        private void GmcMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gmcMap.Position = gmcMap.FromLocalToLatLng(e.X, e.Y);
            }
        }

        private void LoadPilots()
        {
            try
            {
                lvPilots.Items.Clear();

                foreach (Pilot pltPlt in Pilot.list)
                {
                    string strDep;
                    string strArr;

                    TimeSpan tspTemp = new TimeSpan(DateTime.UtcNow.Subtract(pltPlt.dtLogon).Ticks);
                    tspTemp = new TimeSpan(tspTemp.Days, tspTemp.Hours, tspTemp.Minutes, tspTemp.Seconds);

                    if (pltPlt.apDep != null)
                    {
                        strDep = pltPlt.apDep.strICAO + " - " + pltPlt.apDep.strName;
                    }
                    else
                    {
                        strDep = "";
                    }

                    if (pltPlt.apArr != null)
                    {
                        strArr = pltPlt.apArr.strICAO + " - " + pltPlt.apArr.strName;
                    }
                    else
                    {
                        strArr = "";
                    }

                    ListViewItem lviTemp = new ListViewItem(new string[] { pltPlt.strCallsign, pltPlt.intCID.ToString(), pltPlt.strName, strDep, strArr, Math.Truncate(tspTemp.TotalHours).ToString() + ":" + tspTemp.Minutes.ToString("00") });

                    if (pltPlt.intXPDR == 7500 || pltPlt.intXPDR == 7600 || pltPlt.intXPDR == 7700)
                    {
                        lviTemp.ForeColor = Color.Red;
                    }
                    else if (pltPlt.isFav)
                    {
                        lviTemp.ForeColor = Color.DarkOrange;
                    }

                    lviTemp.Tag = pltPlt;
                    lvPilots.Items.Add(lviTemp);
                }
            }
            catch
            {
                LoadPilots();
            }
        }

        private void LoadPrefiles()
        {
            lvPrefiles.Items.Clear();

            foreach (FPlan fplFpl in FPlan.prefiles)
            {
                string strDep;
                string strArr;

                if (fplFpl.apDep != null)
                {
                    strDep = fplFpl.apDep.strICAO + " - " + fplFpl.apDep.strName;
                }
                else
                {
                    strDep = "";
                }

                if (fplFpl.apArr != null)
                {
                    strArr = fplFpl.apArr.strICAO + " - " + fplFpl.apArr.strName;
                }
                else
                {
                    strArr = "";
                }

                ListViewItem lviTemp = new ListViewItem(new string[] { fplFpl.strCallsign, fplFpl.intCID.ToString(), strDep, strArr});
                lviTemp.Tag = fplFpl;
                lvPrefiles.Items.Add(lviTemp);
            }
        }

        private void LoadATC()
        {
            try
            {
                lvControllers.Items.Clear();

                foreach (ATC atcAtc in ATC.list)
                {
                    string strPosition = "";
                    string strAPName;

                    if (atcAtc.intFacility == 2 || atcAtc.intFacility == 3 || atcAtc.intFacility == 4 || atcAtc.intFacility == 7)
                    {
                        Airport apTemp = Airport.FindWithAlias(atcAtc.strCallsign.Split('_')[0]);

                        if (apTemp == null)
                        {
                            strAPName = "Unknown";
                        }
                        else
                        {
                            strAPName = apTemp.strName;
                        }

                        if (atcAtc.intFacility == 2)
                        {
                            strPosition = strAPName + " Delivery";
                        }
                        else if (atcAtc.intFacility == 3)
                        {
                            strPosition = strAPName + " Ground";
                        }
                        else if (atcAtc.intFacility == 4)
                        {
                            if (apTemp == null || (apTemp.isInfo == false && apTemp.isRadio == false))
                            {
                                strPosition = strAPName + " Tower   ";
                            }
                            else if (apTemp.isInfo && atcAtc.strCallsign.Substring(atcAtc.strCallsign.Length - 6) == "_I_TWR")
                            {
                                strPosition = strAPName + " Information";
                            }
                            else if (apTemp.isRadio && atcAtc.strCallsign.Substring(atcAtc.strCallsign.Length - 6) == "_R_TWR")
                            {
                                strPosition = strAPName + " Radio";
                            }
                        }
                        else if (atcAtc.intFacility == 7)
                        {
                            strPosition = strAPName + " Information";
                        }
                    }
                    else if (atcAtc.ctlController == null)
                    {
                        strPosition = "Unknown";
                    }
                    else
                    {
                        strPosition = atcAtc.ctlController.strCallsign;
                    }

                    TimeSpan tspTemp = new TimeSpan(DateTime.UtcNow.Subtract(atcAtc.dtLogon).Ticks);
                    tspTemp = new TimeSpan(tspTemp.Days, tspTemp.Hours, tspTemp.Minutes, tspTemp.Seconds);

                    ListViewItem lviTemp = new ListViewItem(new string[] { atcAtc.strCallsign, atcAtc.decFreq.ToString("#.000"), atcAtc.intCID.ToString(), atcAtc.strName, ATC.strarrRatings[atcAtc.intRating - 1], ATC.strarrFacilities[atcAtc.intFacility - 1], strPosition, Math.Truncate(tspTemp.TotalHours).ToString() + ":" + tspTemp.Minutes.ToString("00") });

                    if (atcAtc.isFav)
                    {
                        lviTemp.ForeColor = Color.DarkOrange;
                    }

                    lviTemp.Tag = atcAtc;
                    lvControllers.Items.Add(lviTemp);
                }
            }
            catch
            {
                LoadATC();
            }   
        }

        private void LoadObs()
        {
            try
            {
                lvObservers.Items.Clear();

                foreach (ATC obsObs in ATC.observers)
                {
                    TimeSpan tspTemp = new TimeSpan(DateTime.UtcNow.Subtract(obsObs.dtLogon).Ticks);
                    tspTemp = new TimeSpan(tspTemp.Days, tspTemp.Hours, tspTemp.Minutes, tspTemp.Seconds);

                    ListViewItem lviTemp = new ListViewItem(new string[] { obsObs.strCallsign, obsObs.intCID.ToString(), obsObs.strName, ATC.strarrRatings[obsObs.intRating - 1], Math.Truncate(tspTemp.TotalHours).ToString() + ":" + tspTemp.Minutes.ToString("00") });
                    lviTemp.Tag = obsObs;
                    lvObservers.Items.Add(lviTemp);
                }
            }
            catch
            {
                LoadObs();
            }
        }

        private void LoadServers()
        {
            try
            {
                lvServers.Items.Clear();

                foreach (Server srvSrv in Server.list)
                {
                    ListViewItem lviTemp = new ListViewItem(new string[] { srvSrv.strIdent, srvSrv.strName, srvSrv.strLocation, srvSrv.ipAddress.ToString(), srvSrv.isConnectable.ToString(), "Ping", "    ", "    ", "    ", "    ", "    " });
                    lviTemp.Tag = srvSrv;
                    lvServers.Items.Add(lviTemp);
                }
            }
            catch
            {
                LoadServers();
            }
        }

        private void LoadAdded()
        {
            LoadAddedAirports();
            LoadAddedUsers();
        }

        private void LoadAddedAirports()
        {
            lvAddedAirports.Items.Clear();

            foreach (Airport apAp in Airport.listFavs)
            {
                string strLat;
                string strLon;

                if (apAp.dblLat > 0)
                {
                    strLat = apAp.dblLat.ToString("00.0000") + " N";
                }
                else if (apAp.dblLat < 0)
                {
                    strLat = Math.Abs(apAp.dblLat).ToString("00.0000") + " S";
                }
                else
                {
                    strLat = "00.00000";
                }

                if (apAp.dblLon > 0)
                {
                    strLon = apAp.dblLon.ToString("00.0000") + " E";
                }

                else if (apAp.dblLon < 0)
                {
                    strLon = Math.Abs(apAp.dblLon).ToString("00.0000") + " W";
                }
                else
                {
                    strLon = "00.00000";
                }

                ListViewItem lviTemp = new ListViewItem(new string[] { apAp.strICAO, apAp.strName, strLat, strLon, "Remove", ""});

                lviTemp.Tag = apAp;

                lvAddedAirports.Items.Add(lviTemp);
            }
        }

        private void LoadAddedUsers()
        {
            try
            {
                lvAddedCallsigns.Items.Clear();
                lvAddedCIDs.Items.Clear();

                foreach (FavClient fvcFvc in Client.listFavs)
                {
                    if (fvcFvc.cltClient != null)
                    {
                        if (fvcFvc.strCallsign != null)
                        {
                            ListViewItem lviTemp = new ListViewItem(new string[] { fvcFvc.cltClient.strCallsign, fvcFvc.cltClient.intCID.ToString(), fvcFvc.cltClient.strName, "Remove", "" });
                            lviTemp.Tag = fvcFvc;
                            lvAddedCallsigns.Items.Add(lviTemp);
                        }

                        if (fvcFvc.intCID != null)
                        {
                            ListViewItem lviTemp = new ListViewItem(new string[] { fvcFvc.cltClient.strCallsign, fvcFvc.cltClient.intCID.ToString(), fvcFvc.cltClient.strName, "Remove", "" });
                            lviTemp.Tag = fvcFvc;
                            lvAddedCIDs.Items.Add(lviTemp);
                        }
                    }
                    else
                    {
                        if (fvcFvc.strCallsign != null)
                        {
                            ListViewItem lviTemp = new ListViewItem(new string[] { fvcFvc.strCallsign, "", "", "Remove", "" });
                            lviTemp.Tag = fvcFvc;
                            lvAddedCallsigns.Items.Add(lviTemp);
                        }

                        if (fvcFvc.intCID != null)
                        {
                            ListViewItem lviTemp = new ListViewItem(new string[] { "", fvcFvc.intCID.ToString(), "", "Remove", "" });
                            lviTemp.Tag = fvcFvc;
                            lvAddedCIDs.Items.Add(lviTemp);
                        }
                    }
                }
            }
            catch
            {
                LoadAddedUsers();
            }
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            gmcMap.Zoom += 1;
        }
        
        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            gmcMap.Zoom -= 1;
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void lvPilots_DoubleClick(object sender, EventArgs e)
        {
            if (lvPilots.SelectedItems.Count != 0)
            {
                Pilot pltTemp = (Pilot)lvPilots.SelectedItems[0].Tag;
                gmcMap.Position = new PointLatLng(pltTemp.dblLat, pltTemp.dblLon);
                OpenPilotPanel(pltTemp);
                tcMaster.SelectedIndex = 0;
            }
        }

        private void BtnSectorsClose_Click(object sender, EventArgs e)
        {
            pnlSectors.Hide();
        }

        private void BtnATCClose_Click(object sender, System.EventArgs e)
        {
            pnlATC.Hide();
            ResetHighlight();
        }

        private void lvControllers_DoubleClick(object sender, EventArgs e)
        {
            pnlSectors.Hide();
            pnlAirport.Hide();

            if (lvControllers.SelectedItems.Count != 0)
            {
                ATC atcTemp = (ATC)lvControllers.SelectedItems[0].Tag;

                if (atcTemp.intFacility == 2 || atcTemp.intFacility == 3 || atcTemp.intFacility == 4 || atcTemp.intFacility == 7)
                {
                    Airport apFind = Airport.FindICAO(atcTemp.strCallsign.Split('_')[0]);
                    OpenATCPanel(atcTemp, apFind);
                }
                else
                {
                    gmcMap.Position = new PointLatLng(atcTemp.dblLat, atcTemp.dblLon);
                    pnlATC.Hide();

                    if (atcTemp.ctlController != null)
                    {
                        OpenATCPanel(atcTemp.ctlController);
                    }
                }

                gmcMap.Position = new PointLatLng(atcTemp.dblLat, atcTemp.dblLon);
                tcMaster.SelectedIndex = 0;
            }
        }

        private void lvAirportControllers_DoubleClick(object sender, EventArgs e)
        {
            if (lvAirportControllers.SelectedItems.Count != 0)
            {
                if (lvAirportControllers.SelectedItems[0].Tag is ATC)
                {
                    OpenATCPanel((ATC)lvAirportControllers.SelectedItems[0].Tag, (Airport)pnlAirport.Tag);
                }
                else if (lvAirportControllers.SelectedItems[0].Tag is Controller)
                {
                    OpenATCPanel((Controller)lvAirportControllers.SelectedItems[0].Tag);
                }
            }
        }

        private void lvAirportDepartures_DoubleClick(object sender, EventArgs e)
        {
            if (lvAirportDepartures.SelectedItems.Count != 0)
            {
                OpenPilotPanel((Pilot)((ListView)sender).SelectedItems[0].Tag);
            }
        }

        private void lvAirportArrivals_DoubleClick(object sender, EventArgs e)
        {
            if (lvAirportArrivals.SelectedItems.Count != 0)
            {
                OpenPilotPanel((Pilot)((ListView)sender).SelectedItems[0].Tag);
            }
        }

        private void runwaysMenuItem_Click(object sender, EventArgs e)
        {
            if (isRunwaysOpen)
            {
                rwsWindow.BringToFront();
                rwsWindow.Focus();
            }
            else
            {
                isRunwaysOpen = true;
                rwsWindow = new Runways();
                rwsWindow.Show();
                rwsWindow.Disposed += runwaysUpdatedWrapper;
            }
        }

        private void runwaysUpdatedWrapper(object sender, EventArgs e)
        {
            isRunwaysOpen = false;
            MapUpdate();
        }

        private void BtnAirportClose_Click(object sender, EventArgs e)
        {
            pnlAirport.Hide();
        }

        private void BtnPilotClose_Click(object sender, EventArgs e)
        {
            pnlPilot.Hide();
        }

        private void DropDown_Closing()
        {
            if (isFIRCheckChanged)
            {
                isFIRCheckChanged = false;
                isCheckChanged = false;
                MapInit();
                MapUpdate();

                Properties.Settings.Default.MapFIRBound = boundariesMenuItem.Checked;
                Properties.Settings.Default.MapFIRLabel = labelsMenuItem.Checked;
                Properties.Settings.Default.Save();
            }
            else if (isCheckChanged)
            {
                isCheckChanged = false;
                MapUpdate();

                Properties.Settings.Default.MapFlightIcon = iconsMenuItem.Checked;
                Properties.Settings.Default.MapFlightCallsign = callsignsMenuItem.Checked;

                Properties.Settings.Default.MapAirportActive = activeMenuItem.Checked;
                Properties.Settings.Default.MapAirportInWith = inactiveWithTrafficMenuItem.Checked;
                Properties.Settings.Default.MapAirportInNo = inactiveNoTrafficMenuItem.Checked;
                Properties.Settings.Default.MapAirportATC = aTCMenuItem.Checked;

                Properties.Settings.Default.MapATCApp = approachMenuItem.Checked;
                Properties.Settings.Default.MapATCEnr = enRouteMenuItem.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void FIRDropDown_Click(object sender, EventArgs e)
        {
            isFIRCheckChanged = true;
            CheckMenuItem((MenuItem)sender);
            DropDown_Closing();
        }

        private void DropDown_Click(object sender, EventArgs e)
        {
            isCheckChanged = true;
            CheckMenuItem((MenuItem)sender);
            DropDown_Closing();
        }

        private void TxtSearch_RemoveText(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "Search clients and airports...")
            {
                ((TextBox)sender).Text = "";
            }
        }

        private void TxtSearch_AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = "Search clients and airports...";
            }
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            if (TxtSearch.Text != null && TxtSearch.Text != "" && TxtSearch.Text != "Search clients and airports...")
            {
                flpSearch.Controls.Clear();
                Properties.Settings chk = Properties.Settings.Default;

                List<Pilot> listPS = new List<Pilot>();
                List<ATC> listAS = new List<ATC>();
                List<ATC> listOS = new List<ATC>();
                List<Airport> listApS = new List<Airport>();

                if (chk.FilterClients)
                {
                    if (chk.FilterCallsign)
                    {
                        if (chk.FilterPilots)
                        {
                            listPS.AddRange(Pilot.FindStartCS(TxtSearch.Text));
                        }

                        if (chk.FilterATCs)
                        {
                            listAS.AddRange(ATC.FindStartCS(TxtSearch.Text));
                        }

                        if (chk.FilterOBSs)
                        {
                            listOS.AddRange(ATC.FindOBSStartCS(TxtSearch.Text));
                        }
                    }

                    if (chk.FilterName)
                    {
                        if (chk.FilterPilots)
                        {
                            listPS.AddRange(Pilot.FindStartName(TxtSearch.Text));
                        }

                        if (chk.FilterATCs)
                        {
                            listAS.AddRange(ATC.FindStartName(TxtSearch.Text));
                        }

                        if (chk.FilterOBSs)
                        {
                            listOS.AddRange(ATC.FindOBSStartName(TxtSearch.Text));
                        }
                    }

                    if (chk.FilterCID)
                    {
                        if (chk.FilterPilots)
                        {
                            listPS.AddRange(Pilot.FindStartCID(TxtSearch.Text));
                        }

                        if (chk.FilterATCs)
                        {
                            listAS.AddRange(ATC.FindStartCID(TxtSearch.Text));
                        }

                        if (chk.FilterOBSs)
                        {
                            listOS.AddRange(ATC.FindOBSStartCID(TxtSearch.Text));
                        }
                    }

                    if (chk.FilterPilots)
                    {
                        if (chk.FilterPilotsDep)
                        {
                            listPS.AddRange(Pilot.FindStartDepICAO(TxtSearch.Text));
                        }

                        if (chk.FilterPilotsArr)
                        {
                            listPS.AddRange(Pilot.FindStartArrICAO(TxtSearch.Text));
                        }

                        if (chk.FilterPilotsAC)
                        {
                            listPS.AddRange(Pilot.FindStartAircraft(TxtSearch.Text));
                        }
                    }

                    if (chk.FilterATCs)
                    {
                        if (chk.FilterATCsEnd)
                        {
                            listAS.AddRange(ATC.FindStartEnd(TxtSearch.Text));
                        }

                        if (chk.FilterATCsAP)
                        {
                            listAS.AddRange(ATC.FindStartStart(TxtSearch.Text));
                        }

                        if (chk.FilterATCsFreq)
                        {
                            listAS.AddRange(ATC.FindStartFreq(TxtSearch.Text));
                        }

                        if (chk.FilterATCsRating)
                        {
                            listAS.AddRange(ATC.FindStartRating(TxtSearch.Text));
                        }
                    }

                    if (chk.FilterOBSs)
                    {
                        if (chk.FilterOBSsRating)
                        {
                            listOS.AddRange(ATC.FindOBSStartRating(TxtSearch.Text));
                        }
                    }
                }

                if (chk.FilterAirports)
                {
                    if (chk.FilterAirportsICAO)
                    {
                        listApS.AddRange(Airport.FindStartICAO(TxtSearch.Text));
                    }

                    if (chk.FilterAirportsName)
                    {
                        listApS.AddRange(Airport.FindStartName(TxtSearch.Text));
                    }
                }

                foreach (Pilot pltPlt in listPS)
                {
                    // 
                    // TxtData
                    // 
                    TextBox TxtData = new TextBox();
                    TxtData.BackColor = cp.Window;
                    TxtData.ForeColor = cp.Text;
                    flpSectorData.Controls.Add(TxtData);
                    TxtData.Multiline = true;
                    TxtData.ReadOnly = true;
                    TxtData.Font = new Font(TxtData.Font.FontFamily, (float)9.25);
                    TxtData.Size = new Size(294, 23);
                    TxtData.TextAlign = HorizontalAlignment.Center;

                    string strDep = "????";
                    string strArr = "????";

                    if (pltPlt.apDep != null)
                    {
                        strDep = pltPlt.apDep.strICAO;
                    }

                    if (pltPlt.apArr != null)
                    {
                        strArr = pltPlt.apArr.strICAO;
                    }

                    TxtData.Text = pltPlt.strCallsign + " (" + strDep + " - " + strArr + ") - " + pltPlt.intCID;

                    // 
                    // BtnView
                    // 
                    Button BtnView = new Button();
                    BtnView.BackColor = cp.TransparentControl;
                    BtnView.ForeColor = cp.Text;
                    flpSectorData.Controls.Add(BtnView);
                    BtnView.Name = "BtnView";
                    BtnView.Anchor = AnchorStyles.Right;
                    BtnView.Size = new Size(75, 23);
                    BtnView.Text = "View";
                    BtnView.UseVisualStyleBackColor = true;
                    BtnView.Tag = pltPlt;
                    BtnView.Click += BtnView_Click;

                    flpSearch.Controls.Add(TxtData);
                    flpSearch.Controls.Add(BtnView);
                }

                foreach (ATC atcAtc in listAS)
                {
                    // 
                    // TxtData
                    // 
                    TextBox TxtData = new TextBox();
                    TxtData.BackColor = cp.Window;
                    TxtData.ForeColor = cp.Text;
                    flpSectorData.Controls.Add(TxtData);
                    TxtData.Multiline = true;
                    TxtData.ReadOnly = true;
                    TxtData.Font = new Font(TxtData.Font.FontFamily, (float)9.25);
                    TxtData.Size = new Size(294, 23);
                    TxtData.TextAlign = HorizontalAlignment.Center;
                    TxtData.Text = atcAtc.strCallsign + " (" + atcAtc.decFreq.ToString("000.000") + ") - " + atcAtc.intCID;

                    // 
                    // BtnView
                    // 
                    Button BtnView = new Button();
                    BtnView.BackColor = cp.TransparentControl;
                    BtnView.ForeColor = cp.Text;
                    flpSectorData.Controls.Add(BtnView);
                    BtnView.Name = "BtnView";
                    BtnView.Anchor = AnchorStyles.Right;
                    BtnView.Size = new Size(75, 23);
                    BtnView.Text = "View";
                    BtnView.UseVisualStyleBackColor = true;
                    BtnView.Tag = atcAtc;
                    BtnView.Click += BtnView_Click;

                    flpSearch.Controls.Add(TxtData);
                    flpSearch.Controls.Add(BtnView);
                }

                foreach (ATC obsObs in listOS)
                {
                    // 
                    // TxtData
                    // 
                    TextBox TxtData = new TextBox();
                    TxtData.BackColor = cp.Window;
                    TxtData.ForeColor = cp.Text;
                    flpSectorData.Controls.Add(TxtData);
                    TxtData.Multiline = true;
                    TxtData.ReadOnly = true;
                    TxtData.Font = new Font(TxtData.Font.FontFamily, (float)9.25);
                    TxtData.Size = new Size(294, 23);
                    TxtData.TextAlign = HorizontalAlignment.Center;
                    TxtData.Text = obsObs.strCallsign + " (Observer) - " + obsObs.intCID;

                    // 
                    // BtnView
                    // 
                    Button BtnView = new Button();
                    BtnView.BackColor = cp.TransparentControl;
                    BtnView.ForeColor = cp.Text;
                    flpSectorData.Controls.Add(BtnView);
                    BtnView.Name = "BtnView";
                    BtnView.Anchor = AnchorStyles.Right;
                    BtnView.Size = new Size(75, 23);
                    BtnView.Text = "View";
                    BtnView.UseVisualStyleBackColor = true;
                    BtnView.Enabled = false;

                    flpSearch.Controls.Add(TxtData);
                    flpSearch.Controls.Add(BtnView);
                }
                
                foreach (Airport apAp in listApS)
                {
                    // 
                    // TxtData
                    // 
                    TextBox TxtData = new TextBox();
                    TxtData.BackColor = cp.Window;
                    TxtData.ForeColor = cp.Text;
                    flpSectorData.Controls.Add(TxtData);
                    TxtData.Multiline = true;
                    TxtData.ReadOnly = true;
                    TxtData.Font = new Font(TxtData.Font.FontFamily, (float)9.25);
                    TxtData.Size = new Size(294, 23);
                    TxtData.TextAlign = HorizontalAlignment.Center;

                    TxtData.Text = apAp.strICAO + " (" + apAp.strName + ")";

                    // 
                    // BtnView
                    // 
                    Button BtnView = new Button();
                    BtnView.BackColor = cp.TransparentControl;
                    BtnView.ForeColor = cp.Text;
                    flpSectorData.Controls.Add(BtnView);
                    BtnView.Name = "BtnView";
                    BtnView.Anchor = AnchorStyles.Right;
                    BtnView.Size = new Size(75, 23);
                    BtnView.Text = "View";
                    BtnView.UseVisualStyleBackColor = true;
                    BtnView.Tag = apAp;
                    BtnView.Click += BtnView_Click;

                    flpSearch.Controls.Add(TxtData);
                    flpSearch.Controls.Add(BtnView);
                }

                pnlSearch.Show();
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            object objResult = ((Button)sender).Tag;

            if (objResult is Pilot)
            {
                OpenPilotPanel((Pilot)objResult);
            }
            else if (objResult is ATC)
            {
                int intFacility = ((ATC)objResult).intFacility;

                if (intFacility == 2 || intFacility == 3 || intFacility == 4 || intFacility == 7)
                {
                    Airport apTemp = Airport.FindWithAlias(((ATC)objResult).strCallsign.Split('_')[0]);

                    if (apTemp != null)
                    {
                        OpenATCPanel((ATC)objResult, apTemp);
                    }
                    else
                    {
                        MessageBox.Show("Airport not found for aerodrome control position.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    OpenATCPanel(((ATC)objResult).ctlController);
                }
            }
            else if (objResult is Airport)
            {
                OpenAirportPanel((Airport)objResult);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Threading.Thread.Sleep(5);
            Environment.Exit(0);
        }

        private void BtnAirportAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ((Airport)((Panel)((Button)sender).Tag).Tag).AddFav();
                LoadAdded();
                MessageBox.Show("Added to Favourites", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Already in Favourites", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAddCID_Click(object sender, EventArgs e)
        {
            try
            {
                ((Client)((Panel)((Button)sender).Tag).Tag).AddFavCID();
                LoadPilots();
                LoadATC();
                LoadAdded();
                MessageBox.Show("Added to Favourites", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Already in Favourites", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
}

        private void BtnAddCS_Click(object sender, EventArgs e)
        {
            try
            {
                ((Client)((Panel)((Button)sender).Tag).Tag).AddFavCS();
                LoadPilots();
                LoadATC();
                LoadAdded();
                MessageBox.Show("Added to Favourites", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Already in Favourites", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            if (isAboutOpen)
            {
                abtWindow.BringToFront();
                abtWindow.Focus();
            }
            else
            {
                isAboutOpen = true;
                abtWindow = new About();
                abtWindow.Show();
                abtWindow.Disposed += AboutDisposedWrapper;
            }
        }

        private void AboutDisposedWrapper(object sender, EventArgs e)
        {
            isAboutOpen = false;
        }

        private void LblSearchClose_Click(object sender, EventArgs e)
        {
            pnlSearch.Hide();
        }

        private void mETARMenuItem_Click(object sender, EventArgs e)
        {
            if (isMETARsOpen)
            {
                metWindow.BringToFront();
                metWindow.Focus();
            }
            else
            {
                isMETARsOpen = true;
                metWindow = new METARs();
                metWindow.Show();
                metWindow.Disposed += METARsDisposedWrapper;
            }
        }

        private void METARsDisposedWrapper(object sender, EventArgs e)
        {
            isMETARsOpen = false;
        }

        private void BtnAirportMETAR_Click(object sender, EventArgs e)
        {
            METARs metMet = null;

            if (isMETARsOpen)
            {
                metMet.BringToFront();
                metMet.Focus();
            }
            else
            {
                isMETARsOpen = true;
                metMet = new METARs(((Airport)pnlAirport.Tag).strICAO);
                metMet.Show();
                metMet.Disposed += METARsDisposedWrapper;
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            bgwAPI.CancelAsync();
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            if (isSettingsOpen)
            {
                setWindow.BringToFront();
                setWindow.Focus();
            }
            else
            {
                isSettingsOpen = true;
                setWindow = new Settings();
                setWindow.Show();
                setWindow.Disposed += SettingsDisposedWrapper;
            }
        }

        private void SettingsDisposedWrapper(object sender, EventArgs e)
        {
            isSettingsOpen = false;
            SetTheme();
            pnlAirport.Hide();
            pnlATC.Hide();
            pnlPilot.Hide();
            pnlSearch.Hide();
            pnlSectors.Hide();
            MapInit();
            MapUpdate();
        }

        private void pbFilter_Click(object sender, EventArgs e)
        {
            if (isFiltersOpen)
            {
                fltWindow.BringToFront();
                fltWindow.Focus();
            }
            else
            {
                isFiltersOpen = true;
                fltWindow = new Filter();
                fltWindow.Show();
                fltWindow.Disposed += FilterDisposedWrapper;
            }
        }

        private void FilterDisposedWrapper(object sender, EventArgs e)
        {
            isFiltersOpen = false;

            if (pnlSearch.Visible)
            {
                pbSearch_Click(this, null);
            }
        }

        private void contributeMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/lennycolton/VATGlasses-Data");
        }

        private void reportBugMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://vatglasses.ga/report-issue");
        }

        private void approachingAirspaceMenuItem_Click(object sender, EventArgs e)
        {
            if (isAlertsOpen)
            {
                asaWindow.BringToFront();
                asaWindow.Focus();
            }
            else
            {
                isAlertsOpen = true;
                asaWindow = new AirspaceAlert();
                asaWindow.Show();
                asaWindow.Disposed += AirspaceAlertDisposedWrapper;
            }
        }

        private void AirspaceAlertDisposedWrapper(object sender, EventArgs e)
        {
            isAlertsOpen = false;
        }


        private void mapPilotFiltersMenuItem_Click(object sender, EventArgs e)
        {
            if (isMapPilotFiltersOpen)
            {
                mpfWindow.BringToFront();
                mpfWindow.Focus();
            }
            else
            {
                isMapPilotFiltersOpen = true;
                mpfWindow = new MapPilotFilters();
                mpfWindow.Show();
                mpfWindow.Disposed += MapPilotFiltersDisposedWrapper;
            }
        }

        private void MapPilotFiltersDisposedWrapper(object sender, EventArgs e)
        {
            isMapPilotFiltersOpen = false;
            MapUpdate();
        }

        private void mapATCFiltersMenuItem_Click(object sender, EventArgs e)
        {
            if (isMapATCFiltersOpen)
            {
                mafWindow.BringToFront();
                mafWindow.Focus();
            }
            else
            {
                isMapATCFiltersOpen = true;
                mafWindow = new MapATCFilters();
                mafWindow.Show();
                mafWindow.Disposed += MapATCFiltersDisposedWrapper;
            }
        }

        private void MapATCFiltersDisposedWrapper(object sender, EventArgs e)
        {
            isMapATCFiltersOpen = false;
            MapUpdate();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5);
            Environment.Exit(0);
        }

        private void pbResize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void pbMinimise_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}