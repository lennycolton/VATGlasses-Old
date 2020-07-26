namespace VATGlasses
{
    partial class Runways
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Runways));
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.LblSearch = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.LblAirport = new System.Windows.Forms.Label();
            this.LblRunways = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.tlpRunways = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(58, 6);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(100, 20);
            this.TxtSearch.TabIndex = 0;
            // 
            // LblSearch
            // 
            this.LblSearch.AutoSize = true;
            this.LblSearch.Location = new System.Drawing.Point(12, 9);
            this.LblSearch.Name = "LblSearch";
            this.LblSearch.Size = new System.Drawing.Size(40, 13);
            this.LblSearch.TabIndex = 1;
            this.LblSearch.Text = "Airport:";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(164, 4);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 2;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // LblAirport
            // 
            this.LblAirport.Location = new System.Drawing.Point(12, 30);
            this.LblAirport.Name = "LblAirport";
            this.LblAirport.Size = new System.Drawing.Size(227, 40);
            this.LblAirport.TabIndex = 3;
            this.LblAirport.Text = "Enter an ICAO Code to Search for an Airport";
            this.LblAirport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblRunways
            // 
            this.LblRunways.Location = new System.Drawing.Point(12, 57);
            this.LblRunways.Name = "LblRunways";
            this.LblRunways.Size = new System.Drawing.Size(222, 13);
            this.LblRunways.TabIndex = 4;
            this.LblRunways.Text = "Active Runways:";
            this.LblRunways.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(12, 133);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(219, 23);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.Location = new System.Drawing.Point(12, 162);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(219, 23);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // tlpRunways
            // 
            this.tlpRunways.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpRunways.AutoScroll = true;
            this.tlpRunways.AutoSize = true;
            this.tlpRunways.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpRunways.ColumnCount = 2;
            this.tlpRunways.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRunways.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRunways.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRunways.Location = new System.Drawing.Point(12, 73);
            this.tlpRunways.Name = "tlpRunways";
            this.tlpRunways.RowCount = 1;
            this.tlpRunways.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tlpRunways.Size = new System.Drawing.Size(219, 59);
            this.tlpRunways.TabIndex = 10;
            // 
            // Runways
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(246, 197);
            this.Controls.Add(this.tlpRunways);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.LblRunways);
            this.Controls.Add(this.LblAirport);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.LblSearch);
            this.Controls.Add(this.TxtSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Runways";
            this.Text = "Runways";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Label LblSearch;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label LblAirport;
        private System.Windows.Forms.Label LblRunways;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.TableLayoutPanel tlpRunways;
    }
}