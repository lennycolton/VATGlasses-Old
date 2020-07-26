using System;

namespace VATGlasses
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pnlWindow = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.pbSettings = new System.Windows.Forms.PictureBox();
            this.pbMinimise = new System.Windows.Forms.PictureBox();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.pbResize = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.LblVATGlasses = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tcMaster = new System.Windows.Forms.TabControl();
            this.tpMap = new System.Windows.Forms.TabPage();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.flpSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.LblSearchTitle = new System.Windows.Forms.Label();
            this.LblSearchClose = new System.Windows.Forms.Button();
            this.BtnZoomOut = new System.Windows.Forms.Button();
            this.BtnZoomIn = new System.Windows.Forms.Button();
            this.pnlATC = new System.Windows.Forms.Panel();
            this.BtnATCAddCID = new System.Windows.Forms.Button();
            this.BtnATCAddCS = new System.Windows.Forms.Button();
            this.LblNameCID = new System.Windows.Forms.Label();
            this.tlpATC = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSectorInfo = new System.Windows.Forms.Panel();
            this.LblSectorInfo = new System.Windows.Forms.Label();
            this.LblLogon = new System.Windows.Forms.Label();
            this.LblFreq = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblATIS = new System.Windows.Forms.Label();
            this.LblOnline = new System.Windows.Forms.Label();
            this.LblFreqInfo = new System.Windows.Forms.Label();
            this.LblRatingInfo = new System.Windows.Forms.Label();
            this.LblOnlineInfo = new System.Windows.Forms.Label();
            this.LblLogonInfo = new System.Windows.Forms.Label();
            this.LblSectors = new System.Windows.Forms.Label();
            this.LblServer = new System.Windows.Forms.Label();
            this.LblServerInfo = new System.Windows.Forms.Label();
            this.pnlATISInfo = new System.Windows.Forms.Panel();
            this.LblATISInfo = new System.Windows.Forms.Label();
            this.BtnATCClose = new System.Windows.Forms.Button();
            this.LblSpoken = new System.Windows.Forms.Label();
            this.LblCallsign = new System.Windows.Forms.Label();
            this.pnlSectors = new System.Windows.Forms.Panel();
            this.flpSectorData = new System.Windows.Forms.FlowLayoutPanel();
            this.LblATCTitle = new System.Windows.Forms.Label();
            this.BtnSectorsClose = new System.Windows.Forms.Button();
            this.pnlAirport = new System.Windows.Forms.Panel();
            this.LblTopDown = new System.Windows.Forms.Label();
            this.BtnAirportAdd = new System.Windows.Forms.Button();
            this.BtnAirportMETAR = new System.Windows.Forms.Button();
            this.LblAirportName = new System.Windows.Forms.Label();
            this.LblAirportICAO = new System.Windows.Forms.Label();
            this.BtnAirportClose = new System.Windows.Forms.Button();
            this.tlpAirport = new System.Windows.Forms.TableLayoutPanel();
            this.LblControllers = new System.Windows.Forms.Label();
            this.lvAirportControllers = new System.Windows.Forms.ListView();
            this.LblDepartures = new System.Windows.Forms.Label();
            this.LblArrivals = new System.Windows.Forms.Label();
            this.lvAirportArrivals = new System.Windows.Forms.ListView();
            this.lvAirportDepartures = new System.Windows.Forms.ListView();
            this.pnlPilot = new System.Windows.Forms.Panel();
            this.BtnPilotAddCID = new System.Windows.Forms.Button();
            this.BtnPilotAddCS = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbPilotPlan = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.LblPilotArrInfo = new System.Windows.Forms.Label();
            this.LblPilotArr = new System.Windows.Forms.Label();
            this.LblPilotDepInfo = new System.Windows.Forms.Label();
            this.LblPilotDep = new System.Windows.Forms.Label();
            this.LblPilotEnrouteInfo = new System.Windows.Forms.Label();
            this.LblPilotEnroute = new System.Windows.Forms.Label();
            this.LblPilotACInfo = new System.Windows.Forms.Label();
            this.LblPilotAC = new System.Windows.Forms.Label();
            this.pnlPilotRemarks = new System.Windows.Forms.Panel();
            this.gbPilotRemarks = new System.Windows.Forms.GroupBox();
            this.TxtPilotRemarks = new System.Windows.Forms.TextBox();
            this.pnlPilotRoute = new System.Windows.Forms.Panel();
            this.gbPilotRoute = new System.Windows.Forms.GroupBox();
            this.TxtPilotRoute = new System.Windows.Forms.TextBox();
            this.gbPilotStatus = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LblPilotETEInfo = new System.Windows.Forms.Label();
            this.LblPilotETE = new System.Windows.Forms.Label();
            this.LblPilotXPDRInfo = new System.Windows.Forms.Label();
            this.LblPilotRemaining = new System.Windows.Forms.Label();
            this.LblPilotDistanceInfo = new System.Windows.Forms.Label();
            this.LblPilotDistance = new System.Windows.Forms.Label();
            this.LblPilotAltInfo = new System.Windows.Forms.Label();
            this.LblPilotAlt = new System.Windows.Forms.Label();
            this.LblPilotRemainingInfo = new System.Windows.Forms.Label();
            this.LblPilotETA = new System.Windows.Forms.Label();
            this.LblPilotETAInfo = new System.Windows.Forms.Label();
            this.LblPilotXPDR = new System.Windows.Forms.Label();
            this.LblPilotHDG = new System.Windows.Forms.Label();
            this.LblPilotGS = new System.Windows.Forms.Label();
            this.LblPilotGSInfo = new System.Windows.Forms.Label();
            this.LblPilotHDGInfo = new System.Windows.Forms.Label();
            this.gbPilotInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.LblPilotLonInfo = new System.Windows.Forms.Label();
            this.LblPilotLon = new System.Windows.Forms.Label();
            this.LblPilotLatInfo = new System.Windows.Forms.Label();
            this.LblPilotServer = new System.Windows.Forms.Label();
            this.LblPilotServerInfo = new System.Windows.Forms.Label();
            this.LblPilotOnline = new System.Windows.Forms.Label();
            this.LblPilotOnlineInfo = new System.Windows.Forms.Label();
            this.LblPilotSector = new System.Windows.Forms.Label();
            this.LblPilotSectorInfo = new System.Windows.Forms.Label();
            this.LblPilotLat = new System.Windows.Forms.Label();
            this.LblPilotName = new System.Windows.Forms.Label();
            this.LblPilotFlight = new System.Windows.Forms.Label();
            this.LblPilotCallsign = new System.Windows.Forms.Label();
            this.BtnPilotClose = new System.Windows.Forms.Button();
            this.gmcMap = new GMap.NET.WindowsForms.GMapControl();
            this.tpPilots = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.gbPilots = new System.Windows.Forms.GroupBox();
            this.lvPilots = new System.Windows.Forms.ListView();
            this.gbPrefiles = new System.Windows.Forms.GroupBox();
            this.lvPrefiles = new System.Windows.Forms.ListView();
            this.tpControllers = new System.Windows.Forms.TabPage();
            this.tlpControllers = new System.Windows.Forms.TableLayoutPanel();
            this.gbControllers = new System.Windows.Forms.GroupBox();
            this.lvControllers = new System.Windows.Forms.ListView();
            this.gbObservers = new System.Windows.Forms.GroupBox();
            this.lvObservers = new System.Windows.Forms.ListView();
            this.tpServers = new System.Windows.Forms.TabPage();
            this.lvServers = new System.Windows.Forms.ListView();
            this.tpAdded = new System.Windows.Forms.TabPage();
            this.tlpFriends = new System.Windows.Forms.TableLayoutPanel();
            this.gbAddedCIDs = new System.Windows.Forms.GroupBox();
            this.lvAddedCIDs = new System.Windows.Forms.ListView();
            this.gbAddedCallsigns = new System.Windows.Forms.GroupBox();
            this.lvAddedCallsigns = new System.Windows.Forms.ListView();
            this.gbAddedAirports = new System.Windows.Forms.GroupBox();
            this.lvAddedAirports = new System.Windows.Forms.ListView();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tslUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslConnections = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbFilter = new System.Windows.Forms.PictureBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.pnlWindow.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.tcMaster.SuspendLayout();
            this.tpMap.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlATC.SuspendLayout();
            this.tlpATC.SuspendLayout();
            this.pnlSectorInfo.SuspendLayout();
            this.pnlATISInfo.SuspendLayout();
            this.pnlSectors.SuspendLayout();
            this.pnlAirport.SuspendLayout();
            this.tlpAirport.SuspendLayout();
            this.pnlPilot.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbPilotPlan.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.pnlPilotRemarks.SuspendLayout();
            this.gbPilotRemarks.SuspendLayout();
            this.pnlPilotRoute.SuspendLayout();
            this.gbPilotRoute.SuspendLayout();
            this.gbPilotStatus.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbPilotInfo.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tpPilots.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.gbPilots.SuspendLayout();
            this.gbPrefiles.SuspendLayout();
            this.tpControllers.SuspendLayout();
            this.tlpControllers.SuspendLayout();
            this.gbControllers.SuspendLayout();
            this.gbObservers.SuspendLayout();
            this.tpServers.SuspendLayout();
            this.tpAdded.SuspendLayout();
            this.tlpFriends.SuspendLayout();
            this.gbAddedCIDs.SuspendLayout();
            this.gbAddedCallsigns.SuspendLayout();
            this.gbAddedAirports.SuspendLayout();
            this.ssStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWindow
            // 
            this.pnlWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWindow.Controls.Add(this.pnlControls);
            this.pnlWindow.Controls.Add(this.pnlMain);
            this.pnlWindow.Location = new System.Drawing.Point(8, 8);
            this.pnlWindow.Name = "pnlWindow";
            this.pnlWindow.Size = new System.Drawing.Size(800, 481);
            this.pnlWindow.TabIndex = 0;
            // 
            // pnlControls
            // 
            this.pnlControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControls.Controls.Add(this.pbSearch);
            this.pnlControls.Controls.Add(this.pbFilter);
            this.pnlControls.Controls.Add(this.pbRefresh);
            this.pnlControls.Controls.Add(this.pbSettings);
            this.pnlControls.Controls.Add(this.pbMinimise);
            this.pnlControls.Controls.Add(this.TxtSearch);
            this.pnlControls.Controls.Add(this.pbResize);
            this.pnlControls.Controls.Add(this.pbClose);
            this.pnlControls.Controls.Add(this.LblVATGlasses);
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(800, 31);
            this.pnlControls.TabIndex = 2;
            // 
            // pbRefresh
            // 
            this.pbRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbRefresh.InitialImage = null;
            this.pbRefresh.Location = new System.Drawing.Point(648, 0);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(31, 31);
            this.pbRefresh.TabIndex = 30;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.pbRefresh_Click);
            // 
            // pbSettings
            // 
            this.pbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSettings.InitialImage = null;
            this.pbSettings.Location = new System.Drawing.Point(679, 0);
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.Size = new System.Drawing.Size(31, 31);
            this.pbSettings.TabIndex = 29;
            this.pbSettings.TabStop = false;
            // 
            // pbMinimise
            // 
            this.pbMinimise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMinimise.InitialImage = null;
            this.pbMinimise.Location = new System.Drawing.Point(707, 0);
            this.pbMinimise.Name = "pbMinimise";
            this.pbMinimise.Size = new System.Drawing.Size(31, 31);
            this.pbMinimise.TabIndex = 4;
            this.pbMinimise.TabStop = false;
            this.pbMinimise.Click += new System.EventHandler(this.pbMinimise_Click);
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(4, 5);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(165, 20);
            this.TxtSearch.TabIndex = 27;
            this.TxtSearch.Text = "Search clients and airports...";
            // 
            // pbResize
            // 
            this.pbResize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbResize.InitialImage = null;
            this.pbResize.Location = new System.Drawing.Point(738, 0);
            this.pbResize.Name = "pbResize";
            this.pbResize.Size = new System.Drawing.Size(31, 31);
            this.pbResize.TabIndex = 3;
            this.pbResize.TabStop = false;
            this.pbResize.Click += new System.EventHandler(this.pbResize_Click);
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.InitialImage = null;
            this.pbClose.Location = new System.Drawing.Point(769, 0);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(31, 31);
            this.pbClose.TabIndex = 2;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // LblVATGlasses
            // 
            this.LblVATGlasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblVATGlasses.BackColor = System.Drawing.SystemColors.Control;
            this.LblVATGlasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVATGlasses.Location = new System.Drawing.Point(0, 3);
            this.LblVATGlasses.Name = "LblVATGlasses";
            this.LblVATGlasses.Size = new System.Drawing.Size(800, 23);
            this.LblVATGlasses.TabIndex = 8;
            this.LblVATGlasses.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.tcMaster);
            this.pnlMain.Controls.Add(this.ssStatus);
            this.pnlMain.Location = new System.Drawing.Point(0, 31);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 450);
            this.pnlMain.TabIndex = 1;
            // 
            // tcMaster
            // 
            this.tcMaster.Controls.Add(this.tpMap);
            this.tcMaster.Controls.Add(this.tpPilots);
            this.tcMaster.Controls.Add(this.tpControllers);
            this.tcMaster.Controls.Add(this.tpServers);
            this.tcMaster.Controls.Add(this.tpAdded);
            this.tcMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMaster.Location = new System.Drawing.Point(0, 0);
            this.tcMaster.Name = "tcMaster";
            this.tcMaster.SelectedIndex = 0;
            this.tcMaster.Size = new System.Drawing.Size(800, 428);
            this.tcMaster.TabIndex = 22;
            // 
            // tpMap
            // 
            this.tpMap.Controls.Add(this.pnlSearch);
            this.tpMap.Controls.Add(this.BtnZoomOut);
            this.tpMap.Controls.Add(this.BtnZoomIn);
            this.tpMap.Controls.Add(this.pnlATC);
            this.tpMap.Controls.Add(this.pnlSectors);
            this.tpMap.Controls.Add(this.pnlAirport);
            this.tpMap.Controls.Add(this.pnlPilot);
            this.tpMap.Controls.Add(this.gmcMap);
            this.tpMap.Location = new System.Drawing.Point(4, 22);
            this.tpMap.Name = "tpMap";
            this.tpMap.Padding = new System.Windows.Forms.Padding(3);
            this.tpMap.Size = new System.Drawing.Size(792, 402);
            this.tpMap.TabIndex = 0;
            this.tpMap.Text = "Map";
            this.tpMap.UseVisualStyleBackColor = true;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.flpSearch);
            this.pnlSearch.Controls.Add(this.LblSearchTitle);
            this.pnlSearch.Controls.Add(this.LblSearchClose);
            this.pnlSearch.Location = new System.Drawing.Point(492, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(300, 403);
            this.pnlSearch.TabIndex = 8;
            this.pnlSearch.Visible = false;
            // 
            // flpSearch
            // 
            this.flpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpSearch.AutoScroll = true;
            this.flpSearch.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSearch.Location = new System.Drawing.Point(0, 29);
            this.flpSearch.Name = "flpSearch";
            this.flpSearch.Size = new System.Drawing.Size(300, 345);
            this.flpSearch.TabIndex = 7;
            // 
            // LblSearchTitle
            // 
            this.LblSearchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSearchTitle.Location = new System.Drawing.Point(0, 3);
            this.LblSearchTitle.Name = "LblSearchTitle";
            this.LblSearchTitle.Size = new System.Drawing.Size(300, 23);
            this.LblSearchTitle.TabIndex = 5;
            this.LblSearchTitle.Text = "Search Results";
            this.LblSearchTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblSearchClose
            // 
            this.LblSearchClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSearchClose.Location = new System.Drawing.Point(225, 380);
            this.LblSearchClose.Name = "LblSearchClose";
            this.LblSearchClose.Size = new System.Drawing.Size(75, 23);
            this.LblSearchClose.TabIndex = 0;
            this.LblSearchClose.Text = "Close";
            this.LblSearchClose.UseVisualStyleBackColor = true;
            this.LblSearchClose.Click += new System.EventHandler(this.LblSearchClose_Click);
            // 
            // BtnZoomOut
            // 
            this.BtnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnZoomOut.AutoSize = true;
            this.BtnZoomOut.Location = new System.Drawing.Point(763, 377);
            this.BtnZoomOut.Name = "BtnZoomOut";
            this.BtnZoomOut.Size = new System.Drawing.Size(23, 23);
            this.BtnZoomOut.TabIndex = 2;
            this.BtnZoomOut.Text = "-";
            this.BtnZoomOut.UseVisualStyleBackColor = true;
            this.BtnZoomOut.Click += new System.EventHandler(this.BtnZoomOut_Click);
            // 
            // BtnZoomIn
            // 
            this.BtnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnZoomIn.AutoSize = true;
            this.BtnZoomIn.Location = new System.Drawing.Point(763, 348);
            this.BtnZoomIn.Name = "BtnZoomIn";
            this.BtnZoomIn.Size = new System.Drawing.Size(23, 23);
            this.BtnZoomIn.TabIndex = 1;
            this.BtnZoomIn.Text = "+";
            this.BtnZoomIn.UseVisualStyleBackColor = true;
            this.BtnZoomIn.Click += new System.EventHandler(this.BtnZoomIn_Click);
            // 
            // pnlATC
            // 
            this.pnlATC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlATC.Controls.Add(this.BtnATCAddCID);
            this.pnlATC.Controls.Add(this.BtnATCAddCS);
            this.pnlATC.Controls.Add(this.LblNameCID);
            this.pnlATC.Controls.Add(this.tlpATC);
            this.pnlATC.Controls.Add(this.BtnATCClose);
            this.pnlATC.Controls.Add(this.LblSpoken);
            this.pnlATC.Controls.Add(this.LblCallsign);
            this.pnlATC.Location = new System.Drawing.Point(0, 0);
            this.pnlATC.Name = "pnlATC";
            this.pnlATC.Size = new System.Drawing.Size(300, 403);
            this.pnlATC.TabIndex = 7;
            this.pnlATC.Visible = false;
            // 
            // BtnATCAddCID
            // 
            this.BtnATCAddCID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnATCAddCID.Location = new System.Drawing.Point(144, 380);
            this.BtnATCAddCID.Name = "BtnATCAddCID";
            this.BtnATCAddCID.Size = new System.Drawing.Size(75, 23);
            this.BtnATCAddCID.TabIndex = 23;
            this.BtnATCAddCID.Text = "Add User";
            this.BtnATCAddCID.UseVisualStyleBackColor = true;
            this.BtnATCAddCID.Click += new System.EventHandler(this.BtnAddCID_Click);
            // 
            // BtnATCAddCS
            // 
            this.BtnATCAddCS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnATCAddCS.Location = new System.Drawing.Point(63, 380);
            this.BtnATCAddCS.Name = "BtnATCAddCS";
            this.BtnATCAddCS.Size = new System.Drawing.Size(75, 23);
            this.BtnATCAddCS.TabIndex = 22;
            this.BtnATCAddCS.Text = "Add Callsign";
            this.BtnATCAddCS.UseVisualStyleBackColor = true;
            this.BtnATCAddCS.Click += new System.EventHandler(this.BtnAddCS_Click);
            // 
            // LblNameCID
            // 
            this.LblNameCID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNameCID.Location = new System.Drawing.Point(0, 56);
            this.LblNameCID.Name = "LblNameCID";
            this.LblNameCID.Size = new System.Drawing.Size(300, 23);
            this.LblNameCID.TabIndex = 11;
            this.LblNameCID.Text = "Controller Name";
            this.LblNameCID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpATC
            // 
            this.tlpATC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tlpATC.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpATC.ColumnCount = 2;
            this.tlpATC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpATC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpATC.Controls.Add(this.pnlSectorInfo, 1, 6);
            this.tlpATC.Controls.Add(this.LblLogon, 0, 4);
            this.tlpATC.Controls.Add(this.LblFreq, 0, 0);
            this.tlpATC.Controls.Add(this.label2, 0, 1);
            this.tlpATC.Controls.Add(this.LblATIS, 0, 2);
            this.tlpATC.Controls.Add(this.LblOnline, 0, 3);
            this.tlpATC.Controls.Add(this.LblFreqInfo, 1, 0);
            this.tlpATC.Controls.Add(this.LblRatingInfo, 1, 1);
            this.tlpATC.Controls.Add(this.LblOnlineInfo, 1, 3);
            this.tlpATC.Controls.Add(this.LblLogonInfo, 1, 4);
            this.tlpATC.Controls.Add(this.LblSectors, 0, 6);
            this.tlpATC.Controls.Add(this.LblServer, 0, 5);
            this.tlpATC.Controls.Add(this.LblServerInfo, 1, 5);
            this.tlpATC.Controls.Add(this.pnlATISInfo, 1, 2);
            this.tlpATC.Location = new System.Drawing.Point(0, 82);
            this.tlpATC.Name = "tlpATC";
            this.tlpATC.RowCount = 7;
            this.tlpATC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpATC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpATC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpATC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpATC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpATC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpATC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpATC.Size = new System.Drawing.Size(297, 292);
            this.tlpATC.TabIndex = 10;
            // 
            // pnlSectorInfo
            // 
            this.pnlSectorInfo.AutoScroll = true;
            this.pnlSectorInfo.Controls.Add(this.LblSectorInfo);
            this.pnlSectorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSectorInfo.Location = new System.Drawing.Point(119, 240);
            this.pnlSectorInfo.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSectorInfo.Name = "pnlSectorInfo";
            this.pnlSectorInfo.Size = new System.Drawing.Size(177, 51);
            this.pnlSectorInfo.TabIndex = 20;
            // 
            // LblSectorInfo
            // 
            this.LblSectorInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSectorInfo.AutoSize = true;
            this.LblSectorInfo.Location = new System.Drawing.Point(0, 0);
            this.LblSectorInfo.MaximumSize = new System.Drawing.Size(177, 8640);
            this.LblSectorInfo.Name = "LblSectorInfo";
            this.LblSectorInfo.Size = new System.Drawing.Size(0, 13);
            this.LblSectorInfo.TabIndex = 13;
            // 
            // LblLogon
            // 
            this.LblLogon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblLogon.Location = new System.Drawing.Point(4, 192);
            this.LblLogon.Name = "LblLogon";
            this.LblLogon.Size = new System.Drawing.Size(111, 23);
            this.LblLogon.TabIndex = 6;
            this.LblLogon.Text = "Logon Time:";
            this.LblLogon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblFreq
            // 
            this.LblFreq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblFreq.Location = new System.Drawing.Point(4, 1);
            this.LblFreq.Name = "LblFreq";
            this.LblFreq.Size = new System.Drawing.Size(111, 23);
            this.LblFreq.TabIndex = 0;
            this.LblFreq.Text = "Frequency:";
            this.LblFreq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rating:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblATIS
            // 
            this.LblATIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblATIS.Location = new System.Drawing.Point(4, 49);
            this.LblATIS.Name = "LblATIS";
            this.LblATIS.Size = new System.Drawing.Size(111, 118);
            this.LblATIS.TabIndex = 5;
            this.LblATIS.Text = "Controller Info:";
            this.LblATIS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblOnline
            // 
            this.LblOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblOnline.Location = new System.Drawing.Point(4, 168);
            this.LblOnline.Name = "LblOnline";
            this.LblOnline.Size = new System.Drawing.Size(111, 23);
            this.LblOnline.TabIndex = 2;
            this.LblOnline.Text = "Time Online:";
            this.LblOnline.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblFreqInfo
            // 
            this.LblFreqInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblFreqInfo.Location = new System.Drawing.Point(122, 1);
            this.LblFreqInfo.Name = "LblFreqInfo";
            this.LblFreqInfo.Size = new System.Drawing.Size(171, 23);
            this.LblFreqInfo.TabIndex = 7;
            this.LblFreqInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblRatingInfo
            // 
            this.LblRatingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblRatingInfo.Location = new System.Drawing.Point(122, 25);
            this.LblRatingInfo.Name = "LblRatingInfo";
            this.LblRatingInfo.Size = new System.Drawing.Size(171, 23);
            this.LblRatingInfo.TabIndex = 8;
            this.LblRatingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblOnlineInfo
            // 
            this.LblOnlineInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblOnlineInfo.Location = new System.Drawing.Point(122, 168);
            this.LblOnlineInfo.Name = "LblOnlineInfo";
            this.LblOnlineInfo.Size = new System.Drawing.Size(171, 23);
            this.LblOnlineInfo.TabIndex = 10;
            this.LblOnlineInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblLogonInfo
            // 
            this.LblLogonInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblLogonInfo.Location = new System.Drawing.Point(122, 192);
            this.LblLogonInfo.Name = "LblLogonInfo";
            this.LblLogonInfo.Size = new System.Drawing.Size(171, 23);
            this.LblLogonInfo.TabIndex = 11;
            this.LblLogonInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblSectors
            // 
            this.LblSectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblSectors.Location = new System.Drawing.Point(4, 240);
            this.LblSectors.Name = "LblSectors";
            this.LblSectors.Size = new System.Drawing.Size(111, 51);
            this.LblSectors.TabIndex = 12;
            this.LblSectors.Text = "Sectors:";
            this.LblSectors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblServer
            // 
            this.LblServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblServer.Location = new System.Drawing.Point(4, 216);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(111, 23);
            this.LblServer.TabIndex = 14;
            this.LblServer.Text = "Server:";
            this.LblServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblServerInfo
            // 
            this.LblServerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblServerInfo.Location = new System.Drawing.Point(122, 216);
            this.LblServerInfo.Name = "LblServerInfo";
            this.LblServerInfo.Size = new System.Drawing.Size(171, 23);
            this.LblServerInfo.TabIndex = 15;
            this.LblServerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlATISInfo
            // 
            this.pnlATISInfo.AutoScroll = true;
            this.pnlATISInfo.Controls.Add(this.LblATISInfo);
            this.pnlATISInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlATISInfo.Location = new System.Drawing.Point(119, 49);
            this.pnlATISInfo.Margin = new System.Windows.Forms.Padding(0);
            this.pnlATISInfo.Name = "pnlATISInfo";
            this.pnlATISInfo.Size = new System.Drawing.Size(177, 118);
            this.pnlATISInfo.TabIndex = 21;
            // 
            // LblATISInfo
            // 
            this.LblATISInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblATISInfo.AutoSize = true;
            this.LblATISInfo.Location = new System.Drawing.Point(0, 0);
            this.LblATISInfo.MaximumSize = new System.Drawing.Size(177, 8640);
            this.LblATISInfo.Name = "LblATISInfo";
            this.LblATISInfo.Size = new System.Drawing.Size(0, 13);
            this.LblATISInfo.TabIndex = 9;
            // 
            // BtnATCClose
            // 
            this.BtnATCClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnATCClose.Location = new System.Drawing.Point(225, 380);
            this.BtnATCClose.Name = "BtnATCClose";
            this.BtnATCClose.Size = new System.Drawing.Size(75, 23);
            this.BtnATCClose.TabIndex = 8;
            this.BtnATCClose.Text = "Close";
            this.BtnATCClose.UseVisualStyleBackColor = true;
            this.BtnATCClose.Click += new System.EventHandler(this.BtnATCClose_Click);
            // 
            // LblSpoken
            // 
            this.LblSpoken.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSpoken.Location = new System.Drawing.Point(0, 30);
            this.LblSpoken.Name = "LblSpoken";
            this.LblSpoken.Size = new System.Drawing.Size(300, 23);
            this.LblSpoken.TabIndex = 9;
            this.LblSpoken.Text = "Spoken Callsign";
            this.LblSpoken.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblCallsign
            // 
            this.LblCallsign.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCallsign.Location = new System.Drawing.Point(0, 0);
            this.LblCallsign.Name = "LblCallsign";
            this.LblCallsign.Size = new System.Drawing.Size(300, 29);
            this.LblCallsign.TabIndex = 8;
            this.LblCallsign.Text = "Callsign";
            this.LblCallsign.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlSectors
            // 
            this.pnlSectors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSectors.Controls.Add(this.flpSectorData);
            this.pnlSectors.Controls.Add(this.LblATCTitle);
            this.pnlSectors.Controls.Add(this.BtnSectorsClose);
            this.pnlSectors.Location = new System.Drawing.Point(0, 0);
            this.pnlSectors.Name = "pnlSectors";
            this.pnlSectors.Size = new System.Drawing.Size(300, 403);
            this.pnlSectors.TabIndex = 6;
            this.pnlSectors.Visible = false;
            // 
            // flpSectorData
            // 
            this.flpSectorData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpSectorData.AutoScroll = true;
            this.flpSectorData.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSectorData.Location = new System.Drawing.Point(0, 29);
            this.flpSectorData.Name = "flpSectorData";
            this.flpSectorData.Size = new System.Drawing.Size(300, 345);
            this.flpSectorData.TabIndex = 7;
            // 
            // LblATCTitle
            // 
            this.LblATCTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblATCTitle.Location = new System.Drawing.Point(0, 3);
            this.LblATCTitle.Name = "LblATCTitle";
            this.LblATCTitle.Size = new System.Drawing.Size(300, 23);
            this.LblATCTitle.TabIndex = 5;
            this.LblATCTitle.Text = "Active ATC at This Location";
            this.LblATCTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnSectorsClose
            // 
            this.BtnSectorsClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSectorsClose.Location = new System.Drawing.Point(225, 380);
            this.BtnSectorsClose.Name = "BtnSectorsClose";
            this.BtnSectorsClose.Size = new System.Drawing.Size(75, 23);
            this.BtnSectorsClose.TabIndex = 0;
            this.BtnSectorsClose.Text = "Close";
            this.BtnSectorsClose.UseVisualStyleBackColor = true;
            this.BtnSectorsClose.Click += new System.EventHandler(this.BtnSectorsClose_Click);
            // 
            // pnlAirport
            // 
            this.pnlAirport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAirport.Controls.Add(this.LblTopDown);
            this.pnlAirport.Controls.Add(this.BtnAirportAdd);
            this.pnlAirport.Controls.Add(this.BtnAirportMETAR);
            this.pnlAirport.Controls.Add(this.LblAirportName);
            this.pnlAirport.Controls.Add(this.LblAirportICAO);
            this.pnlAirport.Controls.Add(this.BtnAirportClose);
            this.pnlAirport.Controls.Add(this.tlpAirport);
            this.pnlAirport.Location = new System.Drawing.Point(0, 0);
            this.pnlAirport.Name = "pnlAirport";
            this.pnlAirport.Size = new System.Drawing.Size(450, 403);
            this.pnlAirport.TabIndex = 6;
            this.pnlAirport.Visible = false;
            // 
            // LblTopDown
            // 
            this.LblTopDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTopDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTopDown.Location = new System.Drawing.Point(0, 53);
            this.LblTopDown.Name = "LblTopDown";
            this.LblTopDown.Size = new System.Drawing.Size(450, 23);
            this.LblTopDown.TabIndex = 21;
            this.LblTopDown.Text = "First Contact (Departures):";
            this.LblTopDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnAirportAdd
            // 
            this.BtnAirportAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAirportAdd.Location = new System.Drawing.Point(213, 379);
            this.BtnAirportAdd.Name = "BtnAirportAdd";
            this.BtnAirportAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAirportAdd.TabIndex = 19;
            this.BtnAirportAdd.Text = "Add";
            this.BtnAirportAdd.UseVisualStyleBackColor = true;
            this.BtnAirportAdd.Click += new System.EventHandler(this.BtnAirportAdd_Click);
            // 
            // BtnAirportMETAR
            // 
            this.BtnAirportMETAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAirportMETAR.Location = new System.Drawing.Point(294, 379);
            this.BtnAirportMETAR.Name = "BtnAirportMETAR";
            this.BtnAirportMETAR.Size = new System.Drawing.Size(75, 23);
            this.BtnAirportMETAR.TabIndex = 20;
            this.BtnAirportMETAR.Text = "METAR";
            this.BtnAirportMETAR.UseVisualStyleBackColor = true;
            this.BtnAirportMETAR.Click += new System.EventHandler(this.BtnAirportMETAR_Click);
            // 
            // LblAirportName
            // 
            this.LblAirportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAirportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAirportName.Location = new System.Drawing.Point(0, 29);
            this.LblAirportName.Name = "LblAirportName";
            this.LblAirportName.Size = new System.Drawing.Size(450, 23);
            this.LblAirportName.TabIndex = 12;
            this.LblAirportName.Text = "Airport Name";
            this.LblAirportName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblAirportICAO
            // 
            this.LblAirportICAO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAirportICAO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAirportICAO.Location = new System.Drawing.Point(0, 0);
            this.LblAirportICAO.Name = "LblAirportICAO";
            this.LblAirportICAO.Size = new System.Drawing.Size(450, 29);
            this.LblAirportICAO.TabIndex = 12;
            this.LblAirportICAO.Text = "ICAO Code";
            this.LblAirportICAO.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnAirportClose
            // 
            this.BtnAirportClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAirportClose.Location = new System.Drawing.Point(375, 379);
            this.BtnAirportClose.Name = "BtnAirportClose";
            this.BtnAirportClose.Size = new System.Drawing.Size(75, 23);
            this.BtnAirportClose.TabIndex = 12;
            this.BtnAirportClose.Text = "Close";
            this.BtnAirportClose.UseVisualStyleBackColor = true;
            this.BtnAirportClose.Click += new System.EventHandler(this.BtnAirportClose_Click);
            // 
            // tlpAirport
            // 
            this.tlpAirport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpAirport.ColumnCount = 1;
            this.tlpAirport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAirport.Controls.Add(this.LblControllers, 0, 0);
            this.tlpAirport.Controls.Add(this.lvAirportControllers, 0, 1);
            this.tlpAirport.Controls.Add(this.LblDepartures, 0, 2);
            this.tlpAirport.Controls.Add(this.LblArrivals, 0, 4);
            this.tlpAirport.Controls.Add(this.lvAirportArrivals, 0, 5);
            this.tlpAirport.Controls.Add(this.lvAirportDepartures, 0, 3);
            this.tlpAirport.Location = new System.Drawing.Point(0, 79);
            this.tlpAirport.Name = "tlpAirport";
            this.tlpAirport.RowCount = 6;
            this.tlpAirport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpAirport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpAirport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpAirport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpAirport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpAirport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpAirport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAirport.Size = new System.Drawing.Size(450, 292);
            this.tlpAirport.TabIndex = 18;
            // 
            // LblControllers
            // 
            this.LblControllers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblControllers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblControllers.Location = new System.Drawing.Point(3, 0);
            this.LblControllers.Name = "LblControllers";
            this.LblControllers.Size = new System.Drawing.Size(444, 23);
            this.LblControllers.TabIndex = 12;
            this.LblControllers.Text = "Controllers";
            this.LblControllers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvAirportControllers
            // 
            this.lvAirportControllers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAirportControllers.HideSelection = false;
            this.lvAirportControllers.Location = new System.Drawing.Point(3, 26);
            this.lvAirportControllers.Name = "lvAirportControllers";
            this.lvAirportControllers.Size = new System.Drawing.Size(444, 68);
            this.lvAirportControllers.TabIndex = 13;
            this.lvAirportControllers.UseCompatibleStateImageBehavior = false;
            // 
            // LblDepartures
            // 
            this.LblDepartures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDepartures.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDepartures.Location = new System.Drawing.Point(3, 97);
            this.LblDepartures.Name = "LblDepartures";
            this.LblDepartures.Size = new System.Drawing.Size(444, 23);
            this.LblDepartures.TabIndex = 14;
            this.LblDepartures.Text = "Departures";
            this.LblDepartures.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblArrivals
            // 
            this.LblArrivals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblArrivals.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblArrivals.Location = new System.Drawing.Point(3, 194);
            this.LblArrivals.Name = "LblArrivals";
            this.LblArrivals.Size = new System.Drawing.Size(444, 23);
            this.LblArrivals.TabIndex = 16;
            this.LblArrivals.Text = "Arrivals";
            this.LblArrivals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvAirportArrivals
            // 
            this.lvAirportArrivals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAirportArrivals.HideSelection = false;
            this.lvAirportArrivals.Location = new System.Drawing.Point(3, 220);
            this.lvAirportArrivals.Name = "lvAirportArrivals";
            this.lvAirportArrivals.Size = new System.Drawing.Size(444, 69);
            this.lvAirportArrivals.TabIndex = 17;
            this.lvAirportArrivals.UseCompatibleStateImageBehavior = false;
            // 
            // lvAirportDepartures
            // 
            this.lvAirportDepartures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAirportDepartures.HideSelection = false;
            this.lvAirportDepartures.Location = new System.Drawing.Point(3, 123);
            this.lvAirportDepartures.Name = "lvAirportDepartures";
            this.lvAirportDepartures.Size = new System.Drawing.Size(444, 68);
            this.lvAirportDepartures.TabIndex = 15;
            this.lvAirportDepartures.UseCompatibleStateImageBehavior = false;
            // 
            // pnlPilot
            // 
            this.pnlPilot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPilot.Controls.Add(this.BtnPilotAddCID);
            this.pnlPilot.Controls.Add(this.BtnPilotAddCS);
            this.pnlPilot.Controls.Add(this.tableLayoutPanel2);
            this.pnlPilot.Controls.Add(this.LblPilotName);
            this.pnlPilot.Controls.Add(this.LblPilotFlight);
            this.pnlPilot.Controls.Add(this.LblPilotCallsign);
            this.pnlPilot.Controls.Add(this.BtnPilotClose);
            this.pnlPilot.Location = new System.Drawing.Point(0, 0);
            this.pnlPilot.Name = "pnlPilot";
            this.pnlPilot.Size = new System.Drawing.Size(450, 403);
            this.pnlPilot.TabIndex = 19;
            this.pnlPilot.Visible = false;
            // 
            // BtnPilotAddCID
            // 
            this.BtnPilotAddCID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPilotAddCID.Location = new System.Drawing.Point(294, 380);
            this.BtnPilotAddCID.Name = "BtnPilotAddCID";
            this.BtnPilotAddCID.Size = new System.Drawing.Size(75, 23);
            this.BtnPilotAddCID.TabIndex = 21;
            this.BtnPilotAddCID.Text = "Add User";
            this.BtnPilotAddCID.UseVisualStyleBackColor = true;
            this.BtnPilotAddCID.Click += new System.EventHandler(this.BtnAddCID_Click);
            // 
            // BtnPilotAddCS
            // 
            this.BtnPilotAddCS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPilotAddCS.Location = new System.Drawing.Point(213, 380);
            this.BtnPilotAddCS.Name = "BtnPilotAddCS";
            this.BtnPilotAddCS.Size = new System.Drawing.Size(75, 23);
            this.BtnPilotAddCS.TabIndex = 20;
            this.BtnPilotAddCS.Text = "Add Callsign";
            this.BtnPilotAddCS.UseVisualStyleBackColor = true;
            this.BtnPilotAddCS.Click += new System.EventHandler(this.BtnAddCS_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.gbPilotPlan, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.gbPilotStatus, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.gbPilotInfo, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 77);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.15385F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(450, 280);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // gbPilotPlan
            // 
            this.gbPilotPlan.Controls.Add(this.tableLayoutPanel3);
            this.gbPilotPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPilotPlan.Location = new System.Drawing.Point(3, 153);
            this.gbPilotPlan.Name = "gbPilotPlan";
            this.gbPilotPlan.Size = new System.Drawing.Size(444, 124);
            this.gbPilotPlan.TabIndex = 1;
            this.gbPilotPlan.TabStop = false;
            this.gbPilotPlan.Text = "Flight Plan";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.LblPilotArrInfo, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.LblPilotArr, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.LblPilotDepInfo, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.LblPilotDep, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.LblPilotEnrouteInfo, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.LblPilotEnroute, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.LblPilotACInfo, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.LblPilotAC, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.pnlPilotRemarks, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.pnlPilotRoute, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(438, 105);
            this.tableLayoutPanel3.TabIndex = 19;
            // 
            // LblPilotArrInfo
            // 
            this.LblPilotArrInfo.AutoSize = true;
            this.LblPilotArrInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotArrInfo.Location = new System.Drawing.Point(331, 18);
            this.LblPilotArrInfo.Name = "LblPilotArrInfo";
            this.LblPilotArrInfo.Size = new System.Drawing.Size(103, 16);
            this.LblPilotArrInfo.TabIndex = 27;
            this.LblPilotArrInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotArr
            // 
            this.LblPilotArr.AutoSize = true;
            this.LblPilotArr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotArr.Location = new System.Drawing.Point(222, 18);
            this.LblPilotArr.Name = "LblPilotArr";
            this.LblPilotArr.Size = new System.Drawing.Size(102, 16);
            this.LblPilotArr.TabIndex = 26;
            this.LblPilotArr.Text = "Planned Arrival:";
            this.LblPilotArr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotDepInfo
            // 
            this.LblPilotDepInfo.AutoSize = true;
            this.LblPilotDepInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotDepInfo.Location = new System.Drawing.Point(113, 18);
            this.LblPilotDepInfo.Name = "LblPilotDepInfo";
            this.LblPilotDepInfo.Size = new System.Drawing.Size(102, 16);
            this.LblPilotDepInfo.TabIndex = 25;
            this.LblPilotDepInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotDep
            // 
            this.LblPilotDep.AutoSize = true;
            this.LblPilotDep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotDep.Location = new System.Drawing.Point(4, 18);
            this.LblPilotDep.Name = "LblPilotDep";
            this.LblPilotDep.Size = new System.Drawing.Size(102, 16);
            this.LblPilotDep.TabIndex = 24;
            this.LblPilotDep.Text = "Planned Departure:";
            this.LblPilotDep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotEnrouteInfo
            // 
            this.LblPilotEnrouteInfo.AutoSize = true;
            this.LblPilotEnrouteInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotEnrouteInfo.Location = new System.Drawing.Point(331, 1);
            this.LblPilotEnrouteInfo.Name = "LblPilotEnrouteInfo";
            this.LblPilotEnrouteInfo.Size = new System.Drawing.Size(103, 16);
            this.LblPilotEnrouteInfo.TabIndex = 23;
            this.LblPilotEnrouteInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotEnroute
            // 
            this.LblPilotEnroute.AutoSize = true;
            this.LblPilotEnroute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotEnroute.Location = new System.Drawing.Point(222, 1);
            this.LblPilotEnroute.Name = "LblPilotEnroute";
            this.LblPilotEnroute.Size = new System.Drawing.Size(102, 16);
            this.LblPilotEnroute.TabIndex = 22;
            this.LblPilotEnroute.Text = "Enroute Time:";
            this.LblPilotEnroute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotACInfo
            // 
            this.LblPilotACInfo.AutoSize = true;
            this.LblPilotACInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotACInfo.Location = new System.Drawing.Point(113, 1);
            this.LblPilotACInfo.Name = "LblPilotACInfo";
            this.LblPilotACInfo.Size = new System.Drawing.Size(102, 16);
            this.LblPilotACInfo.TabIndex = 21;
            this.LblPilotACInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotAC
            // 
            this.LblPilotAC.AutoSize = true;
            this.LblPilotAC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotAC.Location = new System.Drawing.Point(4, 1);
            this.LblPilotAC.Name = "LblPilotAC";
            this.LblPilotAC.Size = new System.Drawing.Size(102, 16);
            this.LblPilotAC.TabIndex = 20;
            this.LblPilotAC.Text = "Aircraft Type:";
            this.LblPilotAC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlPilotRemarks
            // 
            this.pnlPilotRemarks.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.SetColumnSpan(this.pnlPilotRemarks, 4);
            this.pnlPilotRemarks.Controls.Add(this.gbPilotRemarks);
            this.pnlPilotRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPilotRemarks.Location = new System.Drawing.Point(4, 72);
            this.pnlPilotRemarks.Name = "pnlPilotRemarks";
            this.pnlPilotRemarks.Size = new System.Drawing.Size(430, 29);
            this.pnlPilotRemarks.TabIndex = 0;
            // 
            // gbPilotRemarks
            // 
            this.gbPilotRemarks.BackColor = System.Drawing.Color.White;
            this.gbPilotRemarks.Controls.Add(this.TxtPilotRemarks);
            this.gbPilotRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPilotRemarks.Location = new System.Drawing.Point(0, 0);
            this.gbPilotRemarks.Name = "gbPilotRemarks";
            this.gbPilotRemarks.Size = new System.Drawing.Size(430, 29);
            this.gbPilotRemarks.TabIndex = 1;
            this.gbPilotRemarks.TabStop = false;
            this.gbPilotRemarks.Text = "Remarks";
            // 
            // TxtPilotRemarks
            // 
            this.TxtPilotRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPilotRemarks.Location = new System.Drawing.Point(3, 16);
            this.TxtPilotRemarks.Multiline = true;
            this.TxtPilotRemarks.Name = "TxtPilotRemarks";
            this.TxtPilotRemarks.ReadOnly = true;
            this.TxtPilotRemarks.Size = new System.Drawing.Size(424, 10);
            this.TxtPilotRemarks.TabIndex = 1;
            // 
            // pnlPilotRoute
            // 
            this.pnlPilotRoute.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.SetColumnSpan(this.pnlPilotRoute, 4);
            this.pnlPilotRoute.Controls.Add(this.gbPilotRoute);
            this.pnlPilotRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPilotRoute.Location = new System.Drawing.Point(4, 38);
            this.pnlPilotRoute.Name = "pnlPilotRoute";
            this.pnlPilotRoute.Size = new System.Drawing.Size(430, 27);
            this.pnlPilotRoute.TabIndex = 1;
            // 
            // gbPilotRoute
            // 
            this.gbPilotRoute.BackColor = System.Drawing.Color.Transparent;
            this.gbPilotRoute.Controls.Add(this.TxtPilotRoute);
            this.gbPilotRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPilotRoute.Location = new System.Drawing.Point(0, 0);
            this.gbPilotRoute.Name = "gbPilotRoute";
            this.gbPilotRoute.Size = new System.Drawing.Size(430, 27);
            this.gbPilotRoute.TabIndex = 0;
            this.gbPilotRoute.TabStop = false;
            this.gbPilotRoute.Text = "Route";
            // 
            // TxtPilotRoute
            // 
            this.TxtPilotRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPilotRoute.Location = new System.Drawing.Point(3, 16);
            this.TxtPilotRoute.Multiline = true;
            this.TxtPilotRoute.Name = "TxtPilotRoute";
            this.TxtPilotRoute.ReadOnly = true;
            this.TxtPilotRoute.Size = new System.Drawing.Size(424, 8);
            this.TxtPilotRoute.TabIndex = 0;
            // 
            // gbPilotStatus
            // 
            this.gbPilotStatus.Controls.Add(this.tableLayoutPanel1);
            this.gbPilotStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPilotStatus.Location = new System.Drawing.Point(3, 67);
            this.gbPilotStatus.Name = "gbPilotStatus";
            this.gbPilotStatus.Size = new System.Drawing.Size(444, 80);
            this.gbPilotStatus.TabIndex = 0;
            this.gbPilotStatus.TabStop = false;
            this.gbPilotStatus.Text = "Current Status";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.LblPilotETEInfo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotETE, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotXPDRInfo, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotRemaining, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotDistanceInfo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotDistance, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotAltInfo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotAlt, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotRemainingInfo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotETA, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotETAInfo, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotXPDR, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotHDG, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotGS, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotGSInfo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblPilotHDGInfo, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(438, 61);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // LblPilotETEInfo
            // 
            this.LblPilotETEInfo.AutoSize = true;
            this.LblPilotETEInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotETEInfo.Location = new System.Drawing.Point(113, 46);
            this.LblPilotETEInfo.Name = "LblPilotETEInfo";
            this.LblPilotETEInfo.Size = new System.Drawing.Size(102, 14);
            this.LblPilotETEInfo.TabIndex = 23;
            this.LblPilotETEInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotETE
            // 
            this.LblPilotETE.AutoSize = true;
            this.LblPilotETE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotETE.Location = new System.Drawing.Point(4, 46);
            this.LblPilotETE.Name = "LblPilotETE";
            this.LblPilotETE.Size = new System.Drawing.Size(102, 14);
            this.LblPilotETE.TabIndex = 22;
            this.LblPilotETE.Text = "ETE:";
            this.LblPilotETE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotXPDRInfo
            // 
            this.LblPilotXPDRInfo.AutoSize = true;
            this.LblPilotXPDRInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotXPDRInfo.Location = new System.Drawing.Point(331, 31);
            this.LblPilotXPDRInfo.Name = "LblPilotXPDRInfo";
            this.LblPilotXPDRInfo.Size = new System.Drawing.Size(103, 14);
            this.LblPilotXPDRInfo.TabIndex = 21;
            this.LblPilotXPDRInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotRemaining
            // 
            this.LblPilotRemaining.AutoSize = true;
            this.LblPilotRemaining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotRemaining.Location = new System.Drawing.Point(222, 1);
            this.LblPilotRemaining.Name = "LblPilotRemaining";
            this.LblPilotRemaining.Size = new System.Drawing.Size(102, 14);
            this.LblPilotRemaining.TabIndex = 19;
            this.LblPilotRemaining.Text = "Remaining:";
            this.LblPilotRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotDistanceInfo
            // 
            this.LblPilotDistanceInfo.AutoSize = true;
            this.LblPilotDistanceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotDistanceInfo.Location = new System.Drawing.Point(113, 1);
            this.LblPilotDistanceInfo.Name = "LblPilotDistanceInfo";
            this.LblPilotDistanceInfo.Size = new System.Drawing.Size(102, 14);
            this.LblPilotDistanceInfo.TabIndex = 18;
            this.LblPilotDistanceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotDistance
            // 
            this.LblPilotDistance.AutoSize = true;
            this.LblPilotDistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotDistance.Location = new System.Drawing.Point(4, 1);
            this.LblPilotDistance.Name = "LblPilotDistance";
            this.LblPilotDistance.Size = new System.Drawing.Size(102, 14);
            this.LblPilotDistance.TabIndex = 17;
            this.LblPilotDistance.Text = "Distance Covered:";
            this.LblPilotDistance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotAltInfo
            // 
            this.LblPilotAltInfo.AutoSize = true;
            this.LblPilotAltInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotAltInfo.Location = new System.Drawing.Point(113, 16);
            this.LblPilotAltInfo.Name = "LblPilotAltInfo";
            this.LblPilotAltInfo.Size = new System.Drawing.Size(102, 14);
            this.LblPilotAltInfo.TabIndex = 5;
            this.LblPilotAltInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotAlt
            // 
            this.LblPilotAlt.AutoSize = true;
            this.LblPilotAlt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotAlt.Location = new System.Drawing.Point(4, 16);
            this.LblPilotAlt.Name = "LblPilotAlt";
            this.LblPilotAlt.Size = new System.Drawing.Size(102, 14);
            this.LblPilotAlt.TabIndex = 4;
            this.LblPilotAlt.Text = "Altitude:";
            this.LblPilotAlt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotRemainingInfo
            // 
            this.LblPilotRemainingInfo.AutoSize = true;
            this.LblPilotRemainingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotRemainingInfo.Location = new System.Drawing.Point(331, 1);
            this.LblPilotRemainingInfo.Name = "LblPilotRemainingInfo";
            this.LblPilotRemainingInfo.Size = new System.Drawing.Size(103, 14);
            this.LblPilotRemainingInfo.TabIndex = 16;
            this.LblPilotRemainingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotETA
            // 
            this.LblPilotETA.AutoSize = true;
            this.LblPilotETA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotETA.Location = new System.Drawing.Point(222, 46);
            this.LblPilotETA.Name = "LblPilotETA";
            this.LblPilotETA.Size = new System.Drawing.Size(102, 14);
            this.LblPilotETA.TabIndex = 10;
            this.LblPilotETA.Text = "ETA:";
            this.LblPilotETA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotETAInfo
            // 
            this.LblPilotETAInfo.AutoSize = true;
            this.LblPilotETAInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotETAInfo.Location = new System.Drawing.Point(331, 46);
            this.LblPilotETAInfo.Name = "LblPilotETAInfo";
            this.LblPilotETAInfo.Size = new System.Drawing.Size(103, 14);
            this.LblPilotETAInfo.TabIndex = 11;
            this.LblPilotETAInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotXPDR
            // 
            this.LblPilotXPDR.AutoSize = true;
            this.LblPilotXPDR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotXPDR.Location = new System.Drawing.Point(222, 31);
            this.LblPilotXPDR.Name = "LblPilotXPDR";
            this.LblPilotXPDR.Size = new System.Drawing.Size(102, 14);
            this.LblPilotXPDR.TabIndex = 20;
            this.LblPilotXPDR.Text = "Transponder:";
            this.LblPilotXPDR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotHDG
            // 
            this.LblPilotHDG.AutoSize = true;
            this.LblPilotHDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotHDG.Location = new System.Drawing.Point(222, 16);
            this.LblPilotHDG.Name = "LblPilotHDG";
            this.LblPilotHDG.Size = new System.Drawing.Size(102, 14);
            this.LblPilotHDG.TabIndex = 8;
            this.LblPilotHDG.Text = "Heading:";
            this.LblPilotHDG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotGS
            // 
            this.LblPilotGS.AutoSize = true;
            this.LblPilotGS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotGS.Location = new System.Drawing.Point(4, 31);
            this.LblPilotGS.Name = "LblPilotGS";
            this.LblPilotGS.Size = new System.Drawing.Size(102, 14);
            this.LblPilotGS.TabIndex = 6;
            this.LblPilotGS.Text = "Ground Speed:";
            this.LblPilotGS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotGSInfo
            // 
            this.LblPilotGSInfo.AutoSize = true;
            this.LblPilotGSInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotGSInfo.Location = new System.Drawing.Point(113, 31);
            this.LblPilotGSInfo.Name = "LblPilotGSInfo";
            this.LblPilotGSInfo.Size = new System.Drawing.Size(102, 14);
            this.LblPilotGSInfo.TabIndex = 7;
            this.LblPilotGSInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotHDGInfo
            // 
            this.LblPilotHDGInfo.AutoSize = true;
            this.LblPilotHDGInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotHDGInfo.Location = new System.Drawing.Point(331, 16);
            this.LblPilotHDGInfo.Name = "LblPilotHDGInfo";
            this.LblPilotHDGInfo.Size = new System.Drawing.Size(103, 14);
            this.LblPilotHDGInfo.TabIndex = 9;
            this.LblPilotHDGInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbPilotInfo
            // 
            this.gbPilotInfo.Controls.Add(this.tableLayoutPanel4);
            this.gbPilotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPilotInfo.Location = new System.Drawing.Point(3, 3);
            this.gbPilotInfo.Name = "gbPilotInfo";
            this.gbPilotInfo.Size = new System.Drawing.Size(444, 58);
            this.gbPilotInfo.TabIndex = 2;
            this.gbPilotInfo.TabStop = false;
            this.gbPilotInfo.Text = "Pilot Information";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.LblPilotLonInfo, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.LblPilotLon, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.LblPilotLatInfo, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.LblPilotServer, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.LblPilotServerInfo, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.LblPilotOnline, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.LblPilotOnlineInfo, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.LblPilotSector, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.LblPilotSectorInfo, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.LblPilotLat, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(438, 39);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // LblPilotLonInfo
            // 
            this.LblPilotLonInfo.AutoSize = true;
            this.LblPilotLonInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotLonInfo.Location = new System.Drawing.Point(331, 13);
            this.LblPilotLonInfo.Name = "LblPilotLonInfo";
            this.LblPilotLonInfo.Size = new System.Drawing.Size(103, 11);
            this.LblPilotLonInfo.TabIndex = 19;
            this.LblPilotLonInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotLon
            // 
            this.LblPilotLon.AutoSize = true;
            this.LblPilotLon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotLon.Location = new System.Drawing.Point(222, 13);
            this.LblPilotLon.Name = "LblPilotLon";
            this.LblPilotLon.Size = new System.Drawing.Size(102, 11);
            this.LblPilotLon.TabIndex = 18;
            this.LblPilotLon.Text = "Longitude:";
            this.LblPilotLon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotLatInfo
            // 
            this.LblPilotLatInfo.AutoSize = true;
            this.LblPilotLatInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotLatInfo.Location = new System.Drawing.Point(113, 13);
            this.LblPilotLatInfo.Name = "LblPilotLatInfo";
            this.LblPilotLatInfo.Size = new System.Drawing.Size(102, 11);
            this.LblPilotLatInfo.TabIndex = 17;
            this.LblPilotLatInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotServer
            // 
            this.LblPilotServer.AutoSize = true;
            this.LblPilotServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotServer.Location = new System.Drawing.Point(4, 25);
            this.LblPilotServer.Name = "LblPilotServer";
            this.LblPilotServer.Size = new System.Drawing.Size(102, 13);
            this.LblPilotServer.TabIndex = 12;
            this.LblPilotServer.Text = "Server:";
            this.LblPilotServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotServerInfo
            // 
            this.LblPilotServerInfo.AutoSize = true;
            this.LblPilotServerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotServerInfo.Location = new System.Drawing.Point(113, 25);
            this.LblPilotServerInfo.Name = "LblPilotServerInfo";
            this.LblPilotServerInfo.Size = new System.Drawing.Size(102, 13);
            this.LblPilotServerInfo.TabIndex = 13;
            this.LblPilotServerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotOnline
            // 
            this.LblPilotOnline.AutoSize = true;
            this.LblPilotOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotOnline.Location = new System.Drawing.Point(222, 25);
            this.LblPilotOnline.Name = "LblPilotOnline";
            this.LblPilotOnline.Size = new System.Drawing.Size(102, 13);
            this.LblPilotOnline.TabIndex = 14;
            this.LblPilotOnline.Text = "Time Online:";
            this.LblPilotOnline.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotOnlineInfo
            // 
            this.LblPilotOnlineInfo.AutoSize = true;
            this.LblPilotOnlineInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotOnlineInfo.Location = new System.Drawing.Point(331, 25);
            this.LblPilotOnlineInfo.Name = "LblPilotOnlineInfo";
            this.LblPilotOnlineInfo.Size = new System.Drawing.Size(103, 13);
            this.LblPilotOnlineInfo.TabIndex = 15;
            this.LblPilotOnlineInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotSector
            // 
            this.LblPilotSector.AutoSize = true;
            this.LblPilotSector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotSector.Location = new System.Drawing.Point(4, 1);
            this.LblPilotSector.Name = "LblPilotSector";
            this.LblPilotSector.Size = new System.Drawing.Size(102, 11);
            this.LblPilotSector.TabIndex = 2;
            this.LblPilotSector.Text = "Current Sector:";
            this.LblPilotSector.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotSectorInfo
            // 
            this.LblPilotSectorInfo.AutoSize = true;
            this.LblPilotSectorInfo.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel4.SetColumnSpan(this.LblPilotSectorInfo, 3);
            this.LblPilotSectorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotSectorInfo.Location = new System.Drawing.Point(110, 1);
            this.LblPilotSectorInfo.Margin = new System.Windows.Forms.Padding(0);
            this.LblPilotSectorInfo.Name = "LblPilotSectorInfo";
            this.LblPilotSectorInfo.Size = new System.Drawing.Size(327, 11);
            this.LblPilotSectorInfo.TabIndex = 3;
            this.LblPilotSectorInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilotLat
            // 
            this.LblPilotLat.AutoSize = true;
            this.LblPilotLat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilotLat.Location = new System.Drawing.Point(4, 13);
            this.LblPilotLat.Name = "LblPilotLat";
            this.LblPilotLat.Size = new System.Drawing.Size(102, 11);
            this.LblPilotLat.TabIndex = 16;
            this.LblPilotLat.Text = "Latitude:";
            this.LblPilotLat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPilotName
            // 
            this.LblPilotName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPilotName.Location = new System.Drawing.Point(0, 52);
            this.LblPilotName.Name = "LblPilotName";
            this.LblPilotName.Size = new System.Drawing.Size(443, 23);
            this.LblPilotName.TabIndex = 12;
            this.LblPilotName.Text = "Pilot Name";
            this.LblPilotName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPilotFlight
            // 
            this.LblPilotFlight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPilotFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPilotFlight.Location = new System.Drawing.Point(0, 32);
            this.LblPilotFlight.Name = "LblPilotFlight";
            this.LblPilotFlight.Size = new System.Drawing.Size(450, 23);
            this.LblPilotFlight.TabIndex = 12;
            this.LblPilotFlight.Text = "Flight";
            this.LblPilotFlight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblPilotCallsign
            // 
            this.LblPilotCallsign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPilotCallsign.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPilotCallsign.Location = new System.Drawing.Point(0, 3);
            this.LblPilotCallsign.Name = "LblPilotCallsign";
            this.LblPilotCallsign.Size = new System.Drawing.Size(450, 29);
            this.LblPilotCallsign.TabIndex = 12;
            this.LblPilotCallsign.Text = "Callsign";
            this.LblPilotCallsign.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnPilotClose
            // 
            this.BtnPilotClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPilotClose.Location = new System.Drawing.Point(375, 380);
            this.BtnPilotClose.Name = "BtnPilotClose";
            this.BtnPilotClose.Size = new System.Drawing.Size(75, 23);
            this.BtnPilotClose.TabIndex = 12;
            this.BtnPilotClose.Text = "Close";
            this.BtnPilotClose.UseVisualStyleBackColor = true;
            this.BtnPilotClose.Click += new System.EventHandler(this.BtnPilotClose_Click);
            // 
            // gmcMap
            // 
            this.gmcMap.Bearing = 0F;
            this.gmcMap.CanDragMap = true;
            this.gmcMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmcMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmcMap.GrayScaleMode = false;
            this.gmcMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmcMap.LevelsKeepInMemmory = 5;
            this.gmcMap.Location = new System.Drawing.Point(3, 3);
            this.gmcMap.MarkersEnabled = true;
            this.gmcMap.MaxZoom = 2;
            this.gmcMap.MinZoom = 2;
            this.gmcMap.MouseWheelZoomEnabled = true;
            this.gmcMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmcMap.Name = "gmcMap";
            this.gmcMap.NegativeMode = false;
            this.gmcMap.PolygonsEnabled = true;
            this.gmcMap.RetryLoadTile = 0;
            this.gmcMap.RoutesEnabled = true;
            this.gmcMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmcMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmcMap.ShowTileGridLines = false;
            this.gmcMap.Size = new System.Drawing.Size(786, 396);
            this.gmcMap.TabIndex = 5;
            this.gmcMap.Zoom = 0D;
            // 
            // tpPilots
            // 
            this.tpPilots.Controls.Add(this.tableLayoutPanel5);
            this.tpPilots.Location = new System.Drawing.Point(4, 22);
            this.tpPilots.Name = "tpPilots";
            this.tpPilots.Padding = new System.Windows.Forms.Padding(3);
            this.tpPilots.Size = new System.Drawing.Size(792, 402);
            this.tpPilots.TabIndex = 1;
            this.tpPilots.Text = "Pilots";
            this.tpPilots.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.gbPilots, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.gbPrefiles, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(786, 396);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // gbPilots
            // 
            this.gbPilots.Controls.Add(this.lvPilots);
            this.gbPilots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPilots.Location = new System.Drawing.Point(3, 3);
            this.gbPilots.Name = "gbPilots";
            this.gbPilots.Size = new System.Drawing.Size(780, 231);
            this.gbPilots.TabIndex = 1;
            this.gbPilots.TabStop = false;
            this.gbPilots.Text = "Current Flights";
            // 
            // lvPilots
            // 
            this.lvPilots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPilots.FullRowSelect = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.lvPilots.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lvPilots.HideSelection = false;
            this.lvPilots.Location = new System.Drawing.Point(3, 16);
            this.lvPilots.MultiSelect = false;
            this.lvPilots.Name = "lvPilots";
            this.lvPilots.Size = new System.Drawing.Size(774, 212);
            this.lvPilots.TabIndex = 0;
            this.lvPilots.UseCompatibleStateImageBehavior = false;
            // 
            // gbPrefiles
            // 
            this.gbPrefiles.Controls.Add(this.lvPrefiles);
            this.gbPrefiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPrefiles.Location = new System.Drawing.Point(3, 240);
            this.gbPrefiles.Name = "gbPrefiles";
            this.gbPrefiles.Size = new System.Drawing.Size(780, 153);
            this.gbPrefiles.TabIndex = 2;
            this.gbPrefiles.TabStop = false;
            this.gbPrefiles.Text = "Prefiled Flight Plans";
            // 
            // lvPrefiles
            // 
            this.lvPrefiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPrefiles.FullRowSelect = true;
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup1";
            this.lvPrefiles.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
            this.lvPrefiles.HideSelection = false;
            this.lvPrefiles.Location = new System.Drawing.Point(3, 16);
            this.lvPrefiles.MultiSelect = false;
            this.lvPrefiles.Name = "lvPrefiles";
            this.lvPrefiles.Size = new System.Drawing.Size(774, 134);
            this.lvPrefiles.TabIndex = 1;
            this.lvPrefiles.UseCompatibleStateImageBehavior = false;
            // 
            // tpControllers
            // 
            this.tpControllers.Controls.Add(this.tlpControllers);
            this.tpControllers.Location = new System.Drawing.Point(4, 22);
            this.tpControllers.Name = "tpControllers";
            this.tpControllers.Padding = new System.Windows.Forms.Padding(3);
            this.tpControllers.Size = new System.Drawing.Size(792, 402);
            this.tpControllers.TabIndex = 2;
            this.tpControllers.Text = "Controllers";
            this.tpControllers.UseVisualStyleBackColor = true;
            // 
            // tlpControllers
            // 
            this.tlpControllers.ColumnCount = 1;
            this.tlpControllers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpControllers.Controls.Add(this.gbControllers, 0, 0);
            this.tlpControllers.Controls.Add(this.gbObservers, 0, 1);
            this.tlpControllers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControllers.Location = new System.Drawing.Point(3, 3);
            this.tlpControllers.Name = "tlpControllers";
            this.tlpControllers.RowCount = 2;
            this.tlpControllers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpControllers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpControllers.Size = new System.Drawing.Size(786, 396);
            this.tlpControllers.TabIndex = 3;
            // 
            // gbControllers
            // 
            this.gbControllers.Controls.Add(this.lvControllers);
            this.gbControllers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbControllers.Location = new System.Drawing.Point(3, 3);
            this.gbControllers.Name = "gbControllers";
            this.gbControllers.Size = new System.Drawing.Size(780, 231);
            this.gbControllers.TabIndex = 4;
            this.gbControllers.TabStop = false;
            this.gbControllers.Text = "Controllers";
            // 
            // lvControllers
            // 
            this.lvControllers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvControllers.FullRowSelect = true;
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup1";
            this.lvControllers.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
            this.lvControllers.HideSelection = false;
            this.lvControllers.Location = new System.Drawing.Point(3, 16);
            this.lvControllers.Name = "lvControllers";
            this.lvControllers.Size = new System.Drawing.Size(774, 212);
            this.lvControllers.TabIndex = 2;
            this.lvControllers.UseCompatibleStateImageBehavior = false;
            // 
            // gbObservers
            // 
            this.gbObservers.Controls.Add(this.lvObservers);
            this.gbObservers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbObservers.Location = new System.Drawing.Point(3, 240);
            this.gbObservers.Name = "gbObservers";
            this.gbObservers.Size = new System.Drawing.Size(780, 153);
            this.gbObservers.TabIndex = 5;
            this.gbObservers.TabStop = false;
            this.gbObservers.Text = "Observers";
            // 
            // lvObservers
            // 
            this.lvObservers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvObservers.FullRowSelect = true;
            listViewGroup4.Header = "ListViewGroup";
            listViewGroup4.Name = "listViewGroup1";
            this.lvObservers.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup4});
            this.lvObservers.HideSelection = false;
            this.lvObservers.Location = new System.Drawing.Point(3, 16);
            this.lvObservers.Name = "lvObservers";
            this.lvObservers.Size = new System.Drawing.Size(774, 134);
            this.lvObservers.TabIndex = 3;
            this.lvObservers.UseCompatibleStateImageBehavior = false;
            // 
            // tpServers
            // 
            this.tpServers.Controls.Add(this.lvServers);
            this.tpServers.Location = new System.Drawing.Point(4, 22);
            this.tpServers.Name = "tpServers";
            this.tpServers.Size = new System.Drawing.Size(792, 402);
            this.tpServers.TabIndex = 3;
            this.tpServers.Text = "Servers";
            this.tpServers.UseVisualStyleBackColor = true;
            // 
            // lvServers
            // 
            this.lvServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvServers.FullRowSelect = true;
            listViewGroup5.Header = "ListViewGroup";
            listViewGroup5.Name = "listViewGroup1";
            this.lvServers.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5});
            this.lvServers.HideSelection = false;
            this.lvServers.Location = new System.Drawing.Point(0, 0);
            this.lvServers.Name = "lvServers";
            this.lvServers.Size = new System.Drawing.Size(792, 402);
            this.lvServers.TabIndex = 3;
            this.lvServers.UseCompatibleStateImageBehavior = false;
            // 
            // tpAdded
            // 
            this.tpAdded.Controls.Add(this.tlpFriends);
            this.tpAdded.Location = new System.Drawing.Point(4, 22);
            this.tpAdded.Name = "tpAdded";
            this.tpAdded.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdded.Size = new System.Drawing.Size(792, 402);
            this.tpAdded.TabIndex = 4;
            this.tpAdded.Text = "Added";
            this.tpAdded.UseVisualStyleBackColor = true;
            // 
            // tlpFriends
            // 
            this.tlpFriends.ColumnCount = 3;
            this.tlpFriends.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFriends.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFriends.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFriends.Controls.Add(this.gbAddedCIDs, 2, 0);
            this.tlpFriends.Controls.Add(this.gbAddedCallsigns, 1, 0);
            this.tlpFriends.Controls.Add(this.gbAddedAirports, 0, 0);
            this.tlpFriends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFriends.Location = new System.Drawing.Point(3, 3);
            this.tlpFriends.Name = "tlpFriends";
            this.tlpFriends.RowCount = 1;
            this.tlpFriends.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFriends.Size = new System.Drawing.Size(786, 396);
            this.tlpFriends.TabIndex = 0;
            // 
            // gbAddedCIDs
            // 
            this.gbAddedCIDs.Controls.Add(this.lvAddedCIDs);
            this.gbAddedCIDs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAddedCIDs.Location = new System.Drawing.Point(527, 3);
            this.gbAddedCIDs.Name = "gbAddedCIDs";
            this.gbAddedCIDs.Size = new System.Drawing.Size(256, 390);
            this.gbAddedCIDs.TabIndex = 1;
            this.gbAddedCIDs.TabStop = false;
            this.gbAddedCIDs.Text = "Users - By CID";
            // 
            // lvAddedCIDs
            // 
            this.lvAddedCIDs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAddedCIDs.FullRowSelect = true;
            this.lvAddedCIDs.HideSelection = false;
            this.lvAddedCIDs.Location = new System.Drawing.Point(3, 16);
            this.lvAddedCIDs.Name = "lvAddedCIDs";
            this.lvAddedCIDs.Size = new System.Drawing.Size(250, 371);
            this.lvAddedCIDs.TabIndex = 2;
            this.lvAddedCIDs.UseCompatibleStateImageBehavior = false;
            // 
            // gbAddedCallsigns
            // 
            this.gbAddedCallsigns.Controls.Add(this.lvAddedCallsigns);
            this.gbAddedCallsigns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAddedCallsigns.Location = new System.Drawing.Point(265, 3);
            this.gbAddedCallsigns.Name = "gbAddedCallsigns";
            this.gbAddedCallsigns.Size = new System.Drawing.Size(256, 390);
            this.gbAddedCallsigns.TabIndex = 1;
            this.gbAddedCallsigns.TabStop = false;
            this.gbAddedCallsigns.Text = "Users - By Callsign";
            // 
            // lvAddedCallsigns
            // 
            this.lvAddedCallsigns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAddedCallsigns.FullRowSelect = true;
            this.lvAddedCallsigns.HideSelection = false;
            this.lvAddedCallsigns.Location = new System.Drawing.Point(3, 16);
            this.lvAddedCallsigns.Name = "lvAddedCallsigns";
            this.lvAddedCallsigns.Size = new System.Drawing.Size(250, 371);
            this.lvAddedCallsigns.TabIndex = 1;
            this.lvAddedCallsigns.UseCompatibleStateImageBehavior = false;
            // 
            // gbAddedAirports
            // 
            this.gbAddedAirports.Controls.Add(this.lvAddedAirports);
            this.gbAddedAirports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAddedAirports.Location = new System.Drawing.Point(3, 3);
            this.gbAddedAirports.Name = "gbAddedAirports";
            this.gbAddedAirports.Size = new System.Drawing.Size(256, 390);
            this.gbAddedAirports.TabIndex = 0;
            this.gbAddedAirports.TabStop = false;
            this.gbAddedAirports.Text = "Airports";
            // 
            // lvAddedAirports
            // 
            this.lvAddedAirports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAddedAirports.FullRowSelect = true;
            this.lvAddedAirports.HideSelection = false;
            this.lvAddedAirports.Location = new System.Drawing.Point(3, 16);
            this.lvAddedAirports.Name = "lvAddedAirports";
            this.lvAddedAirports.Size = new System.Drawing.Size(250, 371);
            this.lvAddedAirports.TabIndex = 0;
            this.lvAddedAirports.UseCompatibleStateImageBehavior = false;
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslUpdate,
            this.tslSpring,
            this.tslConnections});
            this.ssStatus.Location = new System.Drawing.Point(0, 428);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(800, 22);
            this.ssStatus.SizingGrip = false;
            this.ssStatus.TabIndex = 24;
            // 
            // tslUpdate
            // 
            this.tslUpdate.Name = "tslUpdate";
            this.tslUpdate.Size = new System.Drawing.Size(52, 17);
            this.tslUpdate.Text = "Updated";
            // 
            // tslSpring
            // 
            this.tslSpring.Name = "tslSpring";
            this.tslSpring.Size = new System.Drawing.Size(631, 17);
            this.tslSpring.Spring = true;
            // 
            // tslConnections
            // 
            this.tslConnections.Name = "tslConnections";
            this.tslConnections.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tslConnections.Size = new System.Drawing.Size(102, 17);
            this.tslConnections.Text = "Total Connections";
            // 
            // pbFilter
            // 
            this.pbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbFilter.InitialImage = null;
            this.pbFilter.Location = new System.Drawing.Point(206, 0);
            this.pbFilter.Name = "pbFilter";
            this.pbFilter.Size = new System.Drawing.Size(31, 31);
            this.pbFilter.TabIndex = 32;
            this.pbFilter.TabStop = false;
            this.pbFilter.Click += new System.EventHandler(this.pbFilter_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbSearch.InitialImage = null;
            this.pbSearch.Location = new System.Drawing.Point(175, 0);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(31, 31);
            this.pbSearch.TabIndex = 33;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 497);
            this.Controls.Add(this.pnlWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "VATGlasses";
            this.pnlWindow.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.tcMaster.ResumeLayout(false);
            this.tpMap.ResumeLayout(false);
            this.tpMap.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlATC.ResumeLayout(false);
            this.tlpATC.ResumeLayout(false);
            this.pnlSectorInfo.ResumeLayout(false);
            this.pnlSectorInfo.PerformLayout();
            this.pnlATISInfo.ResumeLayout(false);
            this.pnlATISInfo.PerformLayout();
            this.pnlSectors.ResumeLayout(false);
            this.pnlAirport.ResumeLayout(false);
            this.tlpAirport.ResumeLayout(false);
            this.pnlPilot.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbPilotPlan.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.pnlPilotRemarks.ResumeLayout(false);
            this.gbPilotRemarks.ResumeLayout(false);
            this.gbPilotRemarks.PerformLayout();
            this.pnlPilotRoute.ResumeLayout(false);
            this.gbPilotRoute.ResumeLayout(false);
            this.gbPilotRoute.PerformLayout();
            this.gbPilotStatus.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbPilotInfo.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tpPilots.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.gbPilots.ResumeLayout(false);
            this.gbPrefiles.ResumeLayout(false);
            this.tpControllers.ResumeLayout(false);
            this.tlpControllers.ResumeLayout(false);
            this.gbControllers.ResumeLayout(false);
            this.gbObservers.ResumeLayout(false);
            this.tpServers.ResumeLayout(false);
            this.tpAdded.ResumeLayout(false);
            this.tlpFriends.ResumeLayout(false);
            this.gbAddedCIDs.ResumeLayout(false);
            this.gbAddedCallsigns.ResumeLayout(false);
            this.gbAddedAirports.ResumeLayout(false);
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWindow;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TabControl tcMaster;
        private System.Windows.Forms.TabPage tpMap;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.FlowLayoutPanel flpSearch;
        private System.Windows.Forms.Label LblSearchTitle;
        private System.Windows.Forms.Button LblSearchClose;
        private System.Windows.Forms.Button BtnZoomOut;
        private System.Windows.Forms.Button BtnZoomIn;
        private System.Windows.Forms.Panel pnlAirport;
        private System.Windows.Forms.Button BtnAirportAdd;
        private System.Windows.Forms.Button BtnAirportMETAR;
        private System.Windows.Forms.Label LblAirportName;
        private System.Windows.Forms.Label LblAirportICAO;
        private System.Windows.Forms.Button BtnAirportClose;
        private System.Windows.Forms.TableLayoutPanel tlpAirport;
        private System.Windows.Forms.Label LblControllers;
        private System.Windows.Forms.ListView lvAirportControllers;
        private System.Windows.Forms.Label LblDepartures;
        private System.Windows.Forms.Label LblArrivals;
        private System.Windows.Forms.ListView lvAirportArrivals;
        private System.Windows.Forms.ListView lvAirportDepartures;
        private System.Windows.Forms.Panel pnlPilot;
        private System.Windows.Forms.Button BtnPilotAddCID;
        private System.Windows.Forms.Button BtnPilotAddCS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gbPilotPlan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label LblPilotArrInfo;
        private System.Windows.Forms.Label LblPilotArr;
        private System.Windows.Forms.Label LblPilotDepInfo;
        private System.Windows.Forms.Label LblPilotDep;
        private System.Windows.Forms.Label LblPilotEnrouteInfo;
        private System.Windows.Forms.Label LblPilotEnroute;
        private System.Windows.Forms.Label LblPilotACInfo;
        private System.Windows.Forms.Label LblPilotAC;
        private System.Windows.Forms.Panel pnlPilotRemarks;
        private System.Windows.Forms.GroupBox gbPilotRemarks;
        private System.Windows.Forms.TextBox TxtPilotRemarks;
        private System.Windows.Forms.Panel pnlPilotRoute;
        private System.Windows.Forms.GroupBox gbPilotRoute;
        private System.Windows.Forms.TextBox TxtPilotRoute;
        private System.Windows.Forms.GroupBox gbPilotStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LblPilotETEInfo;
        private System.Windows.Forms.Label LblPilotETE;
        private System.Windows.Forms.Label LblPilotXPDRInfo;
        private System.Windows.Forms.Label LblPilotRemaining;
        private System.Windows.Forms.Label LblPilotDistanceInfo;
        private System.Windows.Forms.Label LblPilotDistance;
        private System.Windows.Forms.Label LblPilotAltInfo;
        private System.Windows.Forms.Label LblPilotAlt;
        private System.Windows.Forms.Label LblPilotRemainingInfo;
        private System.Windows.Forms.Label LblPilotETA;
        private System.Windows.Forms.Label LblPilotETAInfo;
        private System.Windows.Forms.Label LblPilotXPDR;
        private System.Windows.Forms.Label LblPilotHDG;
        private System.Windows.Forms.Label LblPilotGS;
        private System.Windows.Forms.Label LblPilotGSInfo;
        private System.Windows.Forms.Label LblPilotHDGInfo;
        private System.Windows.Forms.GroupBox gbPilotInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label LblPilotLonInfo;
        private System.Windows.Forms.Label LblPilotLon;
        private System.Windows.Forms.Label LblPilotLatInfo;
        private System.Windows.Forms.Label LblPilotServer;
        private System.Windows.Forms.Label LblPilotServerInfo;
        private System.Windows.Forms.Label LblPilotOnline;
        private System.Windows.Forms.Label LblPilotOnlineInfo;
        private System.Windows.Forms.Label LblPilotSector;
        private System.Windows.Forms.Label LblPilotSectorInfo;
        private System.Windows.Forms.Label LblPilotLat;
        private System.Windows.Forms.Label LblPilotName;
        private System.Windows.Forms.Label LblPilotFlight;
        private System.Windows.Forms.Label LblPilotCallsign;
        private System.Windows.Forms.Button BtnPilotClose;
        private System.Windows.Forms.Panel pnlATC;
        private System.Windows.Forms.Button BtnATCAddCID;
        private System.Windows.Forms.Button BtnATCAddCS;
        private System.Windows.Forms.Label LblNameCID;
        private System.Windows.Forms.TableLayoutPanel tlpATC;
        private System.Windows.Forms.Panel pnlSectorInfo;
        private System.Windows.Forms.Label LblSectorInfo;
        private System.Windows.Forms.Label LblLogon;
        private System.Windows.Forms.Label LblFreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblATIS;
        private System.Windows.Forms.Label LblOnline;
        private System.Windows.Forms.Label LblFreqInfo;
        private System.Windows.Forms.Label LblRatingInfo;
        private System.Windows.Forms.Label LblATISInfo;
        private System.Windows.Forms.Label LblOnlineInfo;
        private System.Windows.Forms.Label LblLogonInfo;
        private System.Windows.Forms.Label LblSectors;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.Label LblServerInfo;
        private System.Windows.Forms.Button BtnATCClose;
        private System.Windows.Forms.Label LblSpoken;
        private System.Windows.Forms.Label LblCallsign;
        private System.Windows.Forms.Panel pnlSectors;
        private System.Windows.Forms.FlowLayoutPanel flpSectorData;
        private System.Windows.Forms.Label LblATCTitle;
        private System.Windows.Forms.Button BtnSectorsClose;
        private GMap.NET.WindowsForms.GMapControl gmcMap;
        private System.Windows.Forms.TabPage tpPilots;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox gbPilots;
        private System.Windows.Forms.ListView lvPilots;
        private System.Windows.Forms.GroupBox gbPrefiles;
        private System.Windows.Forms.ListView lvPrefiles;
        private System.Windows.Forms.TabPage tpControllers;
        private System.Windows.Forms.TableLayoutPanel tlpControllers;
        private System.Windows.Forms.GroupBox gbControllers;
        private System.Windows.Forms.ListView lvControllers;
        private System.Windows.Forms.GroupBox gbObservers;
        private System.Windows.Forms.ListView lvObservers;
        private System.Windows.Forms.TabPage tpServers;
        private System.Windows.Forms.ListView lvServers;
        private System.Windows.Forms.TabPage tpAdded;
        private System.Windows.Forms.TableLayoutPanel tlpFriends;
        private System.Windows.Forms.GroupBox gbAddedCIDs;
        private System.Windows.Forms.ListView lvAddedCIDs;
        private System.Windows.Forms.GroupBox gbAddedCallsigns;
        private System.Windows.Forms.ListView lvAddedCallsigns;
        private System.Windows.Forms.GroupBox gbAddedAirports;
        private System.Windows.Forms.ListView lvAddedAirports;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslUpdate;
        private System.Windows.Forms.ToolStripStatusLabel tslSpring;
        private System.Windows.Forms.ToolStripStatusLabel tslConnections;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.PictureBox pbMinimise;
        private System.Windows.Forms.PictureBox pbResize;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.PictureBox pbSettings;
        private System.Windows.Forms.Label LblVATGlasses;
        private System.Windows.Forms.PictureBox pbRefresh;
        private System.Windows.Forms.Panel pnlATISInfo;
        private System.Windows.Forms.Label LblTopDown;
        private System.Windows.Forms.PictureBox pbFilter;
        private System.Windows.Forms.PictureBox pbSearch;
    }
}

