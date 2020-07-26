namespace VATGlasses
{
    partial class Filter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filter));
            this.LblFilter = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LblClients = new System.Windows.Forms.Label();
            this.LblPilots = new System.Windows.Forms.Label();
            this.LblDepICAO = new System.Windows.Forms.Label();
            this.LblArrICAO = new System.Windows.Forms.Label();
            this.LblType = new System.Windows.Forms.Label();
            this.LblEnd = new System.Windows.Forms.Label();
            this.LblATCICAO = new System.Windows.Forms.Label();
            this.LblFreq = new System.Windows.Forms.Label();
            this.LblApName = new System.Windows.Forms.Label();
            this.LblApICAO = new System.Windows.Forms.Label();
            this.LblOBS = new System.Windows.Forms.Label();
            this.LblOBSRating = new System.Windows.Forms.Label();
            this.LblATCRating = new System.Windows.Forms.Label();
            this.LblAirport = new System.Windows.Forms.Label();
            this.cbClients = new System.Windows.Forms.CheckBox();
            this.cbCallsign = new System.Windows.Forms.CheckBox();
            this.cbName = new System.Windows.Forms.CheckBox();
            this.cbPilots = new System.Windows.Forms.CheckBox();
            this.cbDepICAO = new System.Windows.Forms.CheckBox();
            this.cbArrICAO = new System.Windows.Forms.CheckBox();
            this.cbType = new System.Windows.Forms.CheckBox();
            this.cbEnd = new System.Windows.Forms.CheckBox();
            this.cbATCICAO = new System.Windows.Forms.CheckBox();
            this.cbFreq = new System.Windows.Forms.CheckBox();
            this.cbATCRating = new System.Windows.Forms.CheckBox();
            this.cbOBS = new System.Windows.Forms.CheckBox();
            this.cbOBSRating = new System.Windows.Forms.CheckBox();
            this.cbAirport = new System.Windows.Forms.CheckBox();
            this.cbAPICAO = new System.Windows.Forms.CheckBox();
            this.cbAPName = new System.Windows.Forms.CheckBox();
            this.LblCallsign = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.cbATCs = new System.Windows.Forms.CheckBox();
            this.LblATCs = new System.Windows.Forms.Label();
            this.cbCID = new System.Windows.Forms.CheckBox();
            this.LblCID = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblFilter
            // 
            this.LblFilter.AutoSize = true;
            this.LblFilter.Location = new System.Drawing.Point(12, 9);
            this.LblFilter.Name = "LblFilter";
            this.LblFilter.Size = new System.Drawing.Size(70, 13);
            this.LblFilter.TabIndex = 1;
            this.LblFilter.Text = "Select Filters:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.Controls.Add(this.LblClients, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblPilots, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.LblDepICAO, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.LblArrICAO, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.LblType, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.LblATCs, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.LblEnd, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.LblATCICAO, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.LblFreq, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.LblApName, 2, 17);
            this.tableLayoutPanel1.Controls.Add(this.LblApICAO, 2, 16);
            this.tableLayoutPanel1.Controls.Add(this.LblOBS, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.LblOBSRating, 2, 14);
            this.tableLayoutPanel1.Controls.Add(this.LblATCRating, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.LblAirport, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.cbClients, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbCallsign, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbName, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbPilots, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbDepICAO, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbArrICAO, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbType, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.cbATCs, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.cbEnd, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbATCICAO, 3, 10);
            this.tableLayoutPanel1.Controls.Add(this.cbFreq, 3, 11);
            this.tableLayoutPanel1.Controls.Add(this.cbATCRating, 3, 12);
            this.tableLayoutPanel1.Controls.Add(this.cbOBS, 3, 13);
            this.tableLayoutPanel1.Controls.Add(this.cbOBSRating, 3, 14);
            this.tableLayoutPanel1.Controls.Add(this.cbAirport, 3, 15);
            this.tableLayoutPanel1.Controls.Add(this.cbAPICAO, 3, 16);
            this.tableLayoutPanel1.Controls.Add(this.cbAPName, 3, 17);
            this.tableLayoutPanel1.Controls.Add(this.LblCallsign, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.LblName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbCID, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.LblCID, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 18;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(324, 498);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // LblClients
            // 
            this.LblClients.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.LblClients, 3);
            this.LblClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblClients.Location = new System.Drawing.Point(4, 1);
            this.LblClients.Name = "LblClients";
            this.LblClients.Size = new System.Drawing.Size(296, 26);
            this.LblClients.TabIndex = 0;
            this.LblClients.Text = "View Clients";
            this.LblClients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPilots
            // 
            this.LblPilots.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.LblPilots, 2);
            this.LblPilots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPilots.Location = new System.Drawing.Point(105, 109);
            this.LblPilots.Name = "LblPilots";
            this.LblPilots.Size = new System.Drawing.Size(195, 26);
            this.LblPilots.TabIndex = 3;
            this.LblPilots.Text = "View Pilots";
            this.LblPilots.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblDepICAO
            // 
            this.LblDepICAO.AutoSize = true;
            this.LblDepICAO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDepICAO.Location = new System.Drawing.Point(206, 136);
            this.LblDepICAO.Name = "LblDepICAO";
            this.LblDepICAO.Size = new System.Drawing.Size(94, 26);
            this.LblDepICAO.TabIndex = 4;
            this.LblDepICAO.Text = "By Departure ICAO";
            this.LblDepICAO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblArrICAO
            // 
            this.LblArrICAO.AutoSize = true;
            this.LblArrICAO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblArrICAO.Location = new System.Drawing.Point(206, 163);
            this.LblArrICAO.Name = "LblArrICAO";
            this.LblArrICAO.Size = new System.Drawing.Size(94, 26);
            this.LblArrICAO.TabIndex = 5;
            this.LblArrICAO.Text = "By Arrival ICAO";
            this.LblArrICAO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblType.Location = new System.Drawing.Point(206, 190);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(94, 26);
            this.LblType.TabIndex = 6;
            this.LblType.Text = "By Aircraft Type";
            this.LblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblEnd
            // 
            this.LblEnd.AutoSize = true;
            this.LblEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblEnd.Location = new System.Drawing.Point(206, 244);
            this.LblEnd.Name = "LblEnd";
            this.LblEnd.Size = new System.Drawing.Size(94, 26);
            this.LblEnd.TabIndex = 9;
            this.LblEnd.Text = "By End Segment";
            this.LblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblATCICAO
            // 
            this.LblATCICAO.AutoSize = true;
            this.LblATCICAO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblATCICAO.Location = new System.Drawing.Point(206, 271);
            this.LblATCICAO.Name = "LblATCICAO";
            this.LblATCICAO.Size = new System.Drawing.Size(94, 26);
            this.LblATCICAO.TabIndex = 10;
            this.LblATCICAO.Text = "By Airport ICAO";
            this.LblATCICAO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblFreq
            // 
            this.LblFreq.AutoSize = true;
            this.LblFreq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblFreq.Location = new System.Drawing.Point(206, 298);
            this.LblFreq.Name = "LblFreq";
            this.LblFreq.Size = new System.Drawing.Size(94, 26);
            this.LblFreq.TabIndex = 11;
            this.LblFreq.Text = "By Frequency";
            this.LblFreq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblApName
            // 
            this.LblApName.AutoSize = true;
            this.LblApName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblApName.Location = new System.Drawing.Point(206, 460);
            this.LblApName.Name = "LblApName";
            this.LblApName.Size = new System.Drawing.Size(94, 37);
            this.LblApName.TabIndex = 15;
            this.LblApName.Text = "By Name";
            this.LblApName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblApICAO
            // 
            this.LblApICAO.AutoSize = true;
            this.LblApICAO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblApICAO.Location = new System.Drawing.Point(206, 433);
            this.LblApICAO.Name = "LblApICAO";
            this.LblApICAO.Size = new System.Drawing.Size(94, 26);
            this.LblApICAO.TabIndex = 14;
            this.LblApICAO.Text = "By ICAO";
            this.LblApICAO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblOBS
            // 
            this.LblOBS.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.LblOBS, 2);
            this.LblOBS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblOBS.Location = new System.Drawing.Point(105, 352);
            this.LblOBS.Name = "LblOBS";
            this.LblOBS.Size = new System.Drawing.Size(195, 26);
            this.LblOBS.TabIndex = 12;
            this.LblOBS.Text = "View Observers";
            this.LblOBS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblOBSRating
            // 
            this.LblOBSRating.AutoSize = true;
            this.LblOBSRating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblOBSRating.Location = new System.Drawing.Point(206, 379);
            this.LblOBSRating.Name = "LblOBSRating";
            this.LblOBSRating.Size = new System.Drawing.Size(94, 26);
            this.LblOBSRating.TabIndex = 16;
            this.LblOBSRating.Text = "By Rating";
            this.LblOBSRating.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblATCRating
            // 
            this.LblATCRating.AutoSize = true;
            this.LblATCRating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblATCRating.Location = new System.Drawing.Point(206, 325);
            this.LblATCRating.Name = "LblATCRating";
            this.LblATCRating.Size = new System.Drawing.Size(94, 26);
            this.LblATCRating.TabIndex = 17;
            this.LblATCRating.Text = "By Rating";
            this.LblATCRating.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAirport
            // 
            this.LblAirport.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.LblAirport, 3);
            this.LblAirport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblAirport.Location = new System.Drawing.Point(4, 406);
            this.LblAirport.Name = "LblAirport";
            this.LblAirport.Size = new System.Drawing.Size(296, 26);
            this.LblAirport.TabIndex = 13;
            this.LblAirport.Text = "View Airports";
            this.LblAirport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbClients
            // 
            this.cbClients.AutoSize = true;
            this.cbClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbClients.Location = new System.Drawing.Point(304, 1);
            this.cbClients.Margin = new System.Windows.Forms.Padding(0);
            this.cbClients.Name = "cbClients";
            this.cbClients.Size = new System.Drawing.Size(19, 26);
            this.cbClients.TabIndex = 19;
            this.cbClients.UseVisualStyleBackColor = true;
            this.cbClients.CheckedChanged += new System.EventHandler(this.cbClients_CheckedChanged);
            // 
            // cbCallsign
            // 
            this.cbCallsign.AutoSize = true;
            this.cbCallsign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCallsign.Location = new System.Drawing.Point(304, 28);
            this.cbCallsign.Margin = new System.Windows.Forms.Padding(0);
            this.cbCallsign.Name = "cbCallsign";
            this.cbCallsign.Size = new System.Drawing.Size(19, 26);
            this.cbCallsign.TabIndex = 18;
            this.cbCallsign.UseVisualStyleBackColor = true;
            // 
            // cbName
            // 
            this.cbName.AutoSize = true;
            this.cbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbName.Location = new System.Drawing.Point(304, 55);
            this.cbName.Margin = new System.Windows.Forms.Padding(0);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(19, 26);
            this.cbName.TabIndex = 20;
            this.cbName.UseVisualStyleBackColor = true;
            // 
            // cbPilots
            // 
            this.cbPilots.AutoSize = true;
            this.cbPilots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPilots.Location = new System.Drawing.Point(304, 109);
            this.cbPilots.Margin = new System.Windows.Forms.Padding(0);
            this.cbPilots.Name = "cbPilots";
            this.cbPilots.Size = new System.Drawing.Size(19, 26);
            this.cbPilots.TabIndex = 21;
            this.cbPilots.UseVisualStyleBackColor = true;
            this.cbPilots.CheckedChanged += new System.EventHandler(this.cbPilots_CheckedChanged);
            // 
            // cbDepICAO
            // 
            this.cbDepICAO.AutoSize = true;
            this.cbDepICAO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDepICAO.Location = new System.Drawing.Point(304, 136);
            this.cbDepICAO.Margin = new System.Windows.Forms.Padding(0);
            this.cbDepICAO.Name = "cbDepICAO";
            this.cbDepICAO.Size = new System.Drawing.Size(19, 26);
            this.cbDepICAO.TabIndex = 22;
            this.cbDepICAO.UseVisualStyleBackColor = true;
            // 
            // cbArrICAO
            // 
            this.cbArrICAO.AutoSize = true;
            this.cbArrICAO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbArrICAO.Location = new System.Drawing.Point(304, 163);
            this.cbArrICAO.Margin = new System.Windows.Forms.Padding(0);
            this.cbArrICAO.Name = "cbArrICAO";
            this.cbArrICAO.Size = new System.Drawing.Size(19, 26);
            this.cbArrICAO.TabIndex = 23;
            this.cbArrICAO.UseVisualStyleBackColor = true;
            // 
            // cbType
            // 
            this.cbType.AutoSize = true;
            this.cbType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbType.Location = new System.Drawing.Point(304, 190);
            this.cbType.Margin = new System.Windows.Forms.Padding(0);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(19, 26);
            this.cbType.TabIndex = 24;
            this.cbType.UseVisualStyleBackColor = true;
            // 
            // cbEnd
            // 
            this.cbEnd.AutoSize = true;
            this.cbEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEnd.Location = new System.Drawing.Point(304, 244);
            this.cbEnd.Margin = new System.Windows.Forms.Padding(0);
            this.cbEnd.Name = "cbEnd";
            this.cbEnd.Size = new System.Drawing.Size(19, 26);
            this.cbEnd.TabIndex = 27;
            this.cbEnd.UseVisualStyleBackColor = true;
            // 
            // cbATCICAO
            // 
            this.cbATCICAO.AutoSize = true;
            this.cbATCICAO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbATCICAO.Location = new System.Drawing.Point(304, 271);
            this.cbATCICAO.Margin = new System.Windows.Forms.Padding(0);
            this.cbATCICAO.Name = "cbATCICAO";
            this.cbATCICAO.Size = new System.Drawing.Size(19, 26);
            this.cbATCICAO.TabIndex = 28;
            this.cbATCICAO.UseVisualStyleBackColor = true;
            // 
            // cbFreq
            // 
            this.cbFreq.AutoSize = true;
            this.cbFreq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFreq.Location = new System.Drawing.Point(304, 298);
            this.cbFreq.Margin = new System.Windows.Forms.Padding(0);
            this.cbFreq.Name = "cbFreq";
            this.cbFreq.Size = new System.Drawing.Size(19, 26);
            this.cbFreq.TabIndex = 29;
            this.cbFreq.UseVisualStyleBackColor = true;
            // 
            // cbATCRating
            // 
            this.cbATCRating.AutoSize = true;
            this.cbATCRating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbATCRating.Location = new System.Drawing.Point(304, 325);
            this.cbATCRating.Margin = new System.Windows.Forms.Padding(0);
            this.cbATCRating.Name = "cbATCRating";
            this.cbATCRating.Size = new System.Drawing.Size(19, 26);
            this.cbATCRating.TabIndex = 30;
            this.cbATCRating.UseVisualStyleBackColor = true;
            // 
            // cbOBS
            // 
            this.cbOBS.AutoSize = true;
            this.cbOBS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbOBS.Location = new System.Drawing.Point(304, 352);
            this.cbOBS.Margin = new System.Windows.Forms.Padding(0);
            this.cbOBS.Name = "cbOBS";
            this.cbOBS.Size = new System.Drawing.Size(19, 26);
            this.cbOBS.TabIndex = 31;
            this.cbOBS.UseVisualStyleBackColor = true;
            this.cbOBS.CheckedChanged += new System.EventHandler(this.cbOBS_CheckedChanged);
            // 
            // cbOBSRating
            // 
            this.cbOBSRating.AutoSize = true;
            this.cbOBSRating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbOBSRating.Location = new System.Drawing.Point(304, 379);
            this.cbOBSRating.Margin = new System.Windows.Forms.Padding(0);
            this.cbOBSRating.Name = "cbOBSRating";
            this.cbOBSRating.Size = new System.Drawing.Size(19, 26);
            this.cbOBSRating.TabIndex = 32;
            this.cbOBSRating.UseVisualStyleBackColor = true;
            // 
            // cbAirport
            // 
            this.cbAirport.AutoSize = true;
            this.cbAirport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAirport.Location = new System.Drawing.Point(304, 406);
            this.cbAirport.Margin = new System.Windows.Forms.Padding(0);
            this.cbAirport.Name = "cbAirport";
            this.cbAirport.Size = new System.Drawing.Size(19, 26);
            this.cbAirport.TabIndex = 33;
            this.cbAirport.UseVisualStyleBackColor = true;
            this.cbAirport.CheckedChanged += new System.EventHandler(this.cbAirport_CheckedChanged);
            // 
            // cbAPICAO
            // 
            this.cbAPICAO.AutoSize = true;
            this.cbAPICAO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAPICAO.Location = new System.Drawing.Point(304, 433);
            this.cbAPICAO.Margin = new System.Windows.Forms.Padding(0);
            this.cbAPICAO.Name = "cbAPICAO";
            this.cbAPICAO.Size = new System.Drawing.Size(19, 26);
            this.cbAPICAO.TabIndex = 34;
            this.cbAPICAO.UseVisualStyleBackColor = true;
            // 
            // cbAPName
            // 
            this.cbAPName.AutoSize = true;
            this.cbAPName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAPName.Location = new System.Drawing.Point(304, 460);
            this.cbAPName.Margin = new System.Windows.Forms.Padding(0);
            this.cbAPName.Name = "cbAPName";
            this.cbAPName.Size = new System.Drawing.Size(19, 37);
            this.cbAPName.TabIndex = 35;
            this.cbAPName.UseVisualStyleBackColor = true;
            // 
            // LblCallsign
            // 
            this.LblCallsign.AutoSize = true;
            this.LblCallsign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCallsign.Location = new System.Drawing.Point(206, 28);
            this.LblCallsign.Name = "LblCallsign";
            this.LblCallsign.Size = new System.Drawing.Size(94, 26);
            this.LblCallsign.TabIndex = 1;
            this.LblCallsign.Text = "By Callsign";
            this.LblCallsign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblName.Location = new System.Drawing.Point(206, 55);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(94, 26);
            this.LblName.TabIndex = 2;
            this.LblName.Text = "By Name";
            this.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(180, 529);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(261, 529);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 4;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // cbATCs
            // 
            this.cbATCs.AutoSize = true;
            this.cbATCs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbATCs.Location = new System.Drawing.Point(304, 217);
            this.cbATCs.Margin = new System.Windows.Forms.Padding(0);
            this.cbATCs.Name = "cbATCs";
            this.cbATCs.Size = new System.Drawing.Size(19, 26);
            this.cbATCs.TabIndex = 25;
            this.cbATCs.UseVisualStyleBackColor = true;
            this.cbATCs.CheckedChanged += new System.EventHandler(this.cbATCs_CheckedChanged);
            // 
            // LblATCs
            // 
            this.LblATCs.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.LblATCs, 2);
            this.LblATCs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblATCs.Location = new System.Drawing.Point(105, 217);
            this.LblATCs.Name = "LblATCs";
            this.LblATCs.Size = new System.Drawing.Size(195, 26);
            this.LblATCs.TabIndex = 7;
            this.LblATCs.Text = "View ATCs";
            this.LblATCs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbCID
            // 
            this.cbCID.AutoSize = true;
            this.cbCID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCID.Location = new System.Drawing.Point(304, 82);
            this.cbCID.Margin = new System.Windows.Forms.Padding(0);
            this.cbCID.Name = "cbCID";
            this.cbCID.Size = new System.Drawing.Size(19, 26);
            this.cbCID.TabIndex = 36;
            this.cbCID.UseVisualStyleBackColor = true;
            // 
            // LblCID
            // 
            this.LblCID.AutoSize = true;
            this.LblCID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCID.Location = new System.Drawing.Point(206, 82);
            this.LblCID.Name = "LblCID";
            this.LblCID.Size = new System.Drawing.Size(94, 26);
            this.LblCID.TabIndex = 37;
            this.LblCID.Text = "By CID";
            this.LblCID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 561);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.LblFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Filter";
            this.Text = "Filter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LblClients;
        private System.Windows.Forms.Label LblCallsign;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblPilots;
        private System.Windows.Forms.Label LblDepICAO;
        private System.Windows.Forms.Label LblArrICAO;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Label LblEnd;
        private System.Windows.Forms.Label LblATCICAO;
        private System.Windows.Forms.Label LblFreq;
        private System.Windows.Forms.Label LblApName;
        private System.Windows.Forms.Label LblApICAO;
        private System.Windows.Forms.Label LblOBS;
        private System.Windows.Forms.Label LblOBSRating;
        private System.Windows.Forms.Label LblATCRating;
        private System.Windows.Forms.Label LblAirport;
        private System.Windows.Forms.CheckBox cbClients;
        private System.Windows.Forms.CheckBox cbCallsign;
        private System.Windows.Forms.CheckBox cbName;
        private System.Windows.Forms.CheckBox cbPilots;
        private System.Windows.Forms.CheckBox cbDepICAO;
        private System.Windows.Forms.CheckBox cbArrICAO;
        private System.Windows.Forms.CheckBox cbType;
        private System.Windows.Forms.CheckBox cbEnd;
        private System.Windows.Forms.CheckBox cbATCICAO;
        private System.Windows.Forms.CheckBox cbFreq;
        private System.Windows.Forms.CheckBox cbATCRating;
        private System.Windows.Forms.CheckBox cbOBS;
        private System.Windows.Forms.CheckBox cbOBSRating;
        private System.Windows.Forms.CheckBox cbAirport;
        private System.Windows.Forms.CheckBox cbAPICAO;
        private System.Windows.Forms.CheckBox cbAPName;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label LblATCs;
        private System.Windows.Forms.CheckBox cbATCs;
        private System.Windows.Forms.CheckBox cbCID;
        private System.Windows.Forms.Label LblCID;
    }
}